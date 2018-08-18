using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;

namespace SharpLizer.Classification
{
    /// <summary>
    /// Classifier that classifies all text as an instance of the "EditorClassifier" classification type.
    /// </summary>
    internal class EditorClassifier : IClassifier
    {
        /// <summary>
        /// Classification type.
        /// </summary>
        private readonly IDictionary<string, IClassificationType> _classifications;
        private readonly IClassificationTypeRegistryService _registryService;
        private ITextBuffer _textBuffer;


        /// <summary>
        /// Initializes a new instance of the <see cref="EditorClassifier"/> class.
        /// </summary>
        /// <param name="registry">Classification registry.</param>
        internal EditorClassifier(IClassificationTypeRegistryService registry, ITextBuffer buffer, IDictionary<string, IClassificationType> classifications)
        {
            _registryService = registry;
            _classifications = classifications;
            _textBuffer = buffer;
            _textBuffer.Changed += TextBufferChanged;
        }


        #region IClassifier

#pragma warning disable 67

        /// <summary>
        /// An event that occurs when the classification of a span of text has changed.
        /// </summary>
        /// <remarks>
        /// This event gets raised if a non-text change would affect the classification in some way,
        /// for example typing /* would cause the classification to change in C# without directly
        /// affecting the span.
        /// </remarks>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        private void TextBufferChanged(object sender, TextContentChangedEventArgs e)
        {
            if (e.Changes.Count == 0) return;

            var classificationChangedHandler = this.ClassificationChanged;
            if (classificationChangedHandler == null) return;

            var newSnapshot = e.After;
            foreach (var change in e.Changes)
            {
                var snapshopSpan = new SnapshotSpan(newSnapshot, change.NewSpan);
                classificationChangedHandler(this, new ClassificationChangedEventArgs(snapshopSpan));

            }

            //classificationChangedHandler(this,new ClassificationChangedEventArgs(snapshop))

        }

#pragma warning restore 67

        /// <summary>
        /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
        /// </summary>
        /// <remarks>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// </remarks>
        /// <param name="span">The span currently being classified.</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            // Get a snaphot of the current document
            var snapshot = span.Snapshot;

            // Get the Workspace belonging to the document
            var workspace = snapshot.TextBuffer.GetWorkspace();
            if (workspace == null) return new List<ClassificationSpan>();

            // Get the current document and its model
            var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
            var semanticModel = document.GetSemanticModelAsync().Result;
            var documentRoot = semanticModel.SyntaxTree.GetCompilationUnitRoot();

            var currentDocumentSpan = new TextSpan(span.Start.Position, span.Length);
            var classifiedSpans = Classifier.GetClassifiedSpans(semanticModel, currentDocumentSpan, workspace);

            var result = new List<ClassificationSpan>();
            foreach (var classifiedSpan in classifiedSpans)
            {
                var classificationSpan = GetClassificationSpan(snapshot, classifiedSpan, documentRoot, semanticModel);
                if (classificationSpan == null) continue;

                result.Add(classificationSpan);

            }
            return result;
        }

        #endregion

        private ClassificationSpan GetClassificationSpan(ITextSnapshot snapshot, ClassifiedSpan currentSpan, CompilationUnitSyntax documentRoot, SemanticModel semanticModel)
        {

            var classificationType = GetClassificationType(currentSpan, snapshot, documentRoot, semanticModel);
            if (classificationType == null) return null;

            return new ClassificationSpan(new SnapshotSpan(snapshot, currentSpan.TextSpan.Start, currentSpan.TextSpan.Length), classificationType);
        }

        private IClassificationType GetClassificationType(ClassifiedSpan currentSpan, ITextSnapshot snapshot, CompilationUnitSyntax documentRoot, SemanticModel semanticModel)
        {
            IClassificationType classificationType = null;
            // Get the innermost span, which corresponds to the span being proccessed
            var node = documentRoot.FindNode(currentSpan.TextSpan, true, true);

            var type = currentSpan.ClassificationType;
            var nodeKind = node.Kind();

            if (nodeKind.ToString().EndsWith("Declaration", StringComparison.InvariantCultureIgnoreCase))
            {
                var token = node.FindToken(currentSpan.TextSpan.Start);
                switch (token.Kind())
                {
                    #region Abstraction Keywords
                    case SyntaxKind.AbstractKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.AbstractKeyword];
                        break;
                    case SyntaxKind.AsyncKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.AsyncKeyword];
                        break;
                    case SyntaxKind.NewKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.NewKeyword];
                        break;
                    case SyntaxKind.OverrideKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.OverrideKeyword];
                        break;
                    case SyntaxKind.SealedKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.SealedKeyword];
                        break;
                    case SyntaxKind.VirtualKeyword:
                        classificationType = _classifications[ClassificationTypes.AbstractionTypes.VirtualKeyword];
                        break;
                    #endregion

                    #region Declaration Keywords
                    case SyntaxKind.ClassKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.ClassKeyword];
                        break;
                    case SyntaxKind.DelegateKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.DelegateKeyword];
                        break;
                    case SyntaxKind.EnumKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.ClassKeyword];
                        break;
                    case SyntaxKind.InterfaceKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.InterfaceKeyword];
                        break;
                    case SyntaxKind.NamespaceKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.NamespaceKeyword];
                        break;
                    case SyntaxKind.StructKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.StructKeyword];
                        break;
                    #endregion

                    #region Encapsulation Keywords
                    case SyntaxKind.PublicKeyword:
                    case SyntaxKind.PrivateKeyword:
                    case SyntaxKind.InternalKeyword:
                    case SyntaxKind.ProtectedKeyword:
                        classificationType = _classifications[ClassificationTypes.DeclarationTypes.EncapsulationKeywords];
                        break;
                        #endregion

                }

                if (classificationType == null && token.Kind() == SyntaxKind.IdentifierToken)
                {
                    switch (token.Parent.Kind())
                    {
                        #region Identifiers
                        case SyntaxKind.ClassDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.ClassIdentifier];
                            break;
                        case SyntaxKind.ConstructorDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.ConstructorIdentifier];
                            break;
                        case SyntaxKind.DelegateDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.DelegateIdentifier];
                            break;
                        case SyntaxKind.EnumDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.EnumIdentifier];
                            break;
                        case SyntaxKind.InterfaceDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.InterfaceIdentifier];
                            break;
                        case SyntaxKind.MethodDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.MethodIdentifier];
                            break;
                        case SyntaxKind.StructDeclaration:
                            classificationType = _classifications[ClassificationTypes.Identifiers.StructIdentifier];
                            break;
                            #endregion
                    }
                }
            }

            // Namespace declarations start with an IdentifierName node. There are two cases we need to handle:
            // 1) If the namespace is topmost (e.g: SharpLizer), the parent will have the NamespaceDeclaration as SyntaxKind
            // 2) If the namespace is nested (e.g: SharpLizer.Classification), the grandparent will have the NamespaceDeclaration as SyntaxKind
            else if (node.Kind() == SyntaxKind.QualifiedName || node.Parent?.Kind() == SyntaxKind.QualifiedName || node.Parent?.Kind() == SyntaxKind.NamespaceDeclaration)
            {
                if (node.Parent?.Kind() == SyntaxKind.NamespaceDeclaration || node.Parent?.Parent?.Kind() == SyntaxKind.NamespaceDeclaration)
                {
                    classificationType = _classifications[ClassificationTypes.Identifiers.NamespaceIdentifier];
                }

            }

            // Attributes also start with an IdentifierName node but 
            // in this case we need to look only for the grandparent  to know if it's part of an attribute
            else if (node.Parent?.Parent?.Kind() == SyntaxKind.AttributeList
                    || node.Parent?.Parent?.Kind() == SyntaxKind.AttributeArgumentList
                    || node.Parent?.Parent?.Kind() == SyntaxKind.AttributeArgument)
            {
                var token = node.FindToken(currentSpan.TextSpan.Start);
                switch (node.Parent?.Kind())
                {
                    case SyntaxKind.NameEquals:
                        {
                            if (token.Kind() == SyntaxKind.IdentifierToken) classificationType = _classifications[ClassificationTypes.Identifiers.AttributePropertyIdentifier];
                            break;
                        }
                    case SyntaxKind.Attribute:
                        classificationType = _classifications[ClassificationTypes.Identifiers.AttributeIdentifier];
                        break;
                }
            }

            else if (type.Contains("name") && nodeKind == SyntaxKind.VariableDeclarator)
            {
                var token = node.FindToken(currentSpan.TextSpan.Start);

                var symbol = semanticModel.GetDeclaredSymbol(node);
                if (symbol == null) symbol = semanticModel.GetSymbolInfo(node).Symbol;
                if (symbol == null) return classificationType;

                switch (symbol.Kind)
                {
                    case SymbolKind.Field:
                        {
                            var typeInformation = (symbol as IFieldSymbol)?.Type;
                            switch (typeInformation.SpecialType)
                            {
                                case SpecialType.System_Boolean:
                                    classificationType = _classifications[ClassificationTypes.Fields.BooleanField];
                                    break;

                                case SpecialType.System_Byte:
                                case SpecialType.System_SByte:
                                    classificationType = _classifications[ClassificationTypes.Fields.ByteField];
                                    break;

                                case SpecialType.System_Char:
                                    classificationType = _classifications[ClassificationTypes.Fields.CharField];
                                    break;

                                case SpecialType.System_DateTime:
                                    classificationType = _classifications[ClassificationTypes.Fields.DateTimeField];
                                    break;

                                case SpecialType.System_Int16:
                                case SpecialType.System_Int32:
                                case SpecialType.System_Int64:
                                case SpecialType.System_UInt16:
                                case SpecialType.System_UInt32:
                                case SpecialType.System_UInt64:
                                case SpecialType.System_Decimal:
                                case SpecialType.System_Double:
                                case SpecialType.System_Single:
                                    classificationType = _classifications[ClassificationTypes.Fields.NumericField];
                                    break;

                                case SpecialType.System_String:
                                    classificationType = _classifications[ClassificationTypes.Fields.StringField];
                                    break;

                                default:
                                    classificationType = _classifications[ClassificationTypes.Fields.Field];
                                    break;
                            }

                        }
                        break;
                    case SymbolKind.Property:
                        {
                            var typeInformation = (symbol as IPropertySymbol)?.Type;
                            switch (typeInformation.SpecialType)
                            {
                                case SpecialType.System_Boolean:
                                    classificationType = _classifications[ClassificationTypes.Properties.BooleanProperty];
                                    break;

                                case SpecialType.System_SByte:
                                case SpecialType.System_Byte:
                                    classificationType = _classifications[ClassificationTypes.Properties.ByteProperty];
                                    break;

                                case SpecialType.System_Char:
                                    classificationType = _classifications[ClassificationTypes.Properties.CharProperty];
                                    break;

                                case SpecialType.System_DateTime:
                                    classificationType = _classifications[ClassificationTypes.Properties.DateTimeProperty];
                                    break;

                                case SpecialType.System_Int16:
                                case SpecialType.System_UInt16:
                                case SpecialType.System_Int32:
                                case SpecialType.System_UInt32:
                                case SpecialType.System_Int64:
                                case SpecialType.System_UInt64:
                                case SpecialType.System_Decimal:
                                case SpecialType.System_Single:
                                case SpecialType.System_Double:
                                    classificationType = _classifications[ClassificationTypes.Properties.NumericProperty];
                                    break;

                                case SpecialType.System_String:
                                    classificationType = _classifications[ClassificationTypes.Properties.StringProperty];
                                    break;

                                default:
                                    classificationType = _classifications[ClassificationTypes.Properties.Property];
                                    break;
                            }
                            break;
                        }
                }

            }

            return classificationType;
        }

    }
}
