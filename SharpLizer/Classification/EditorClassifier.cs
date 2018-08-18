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

            var classificationType = GetClassificationType(currentSpan, documentRoot, semanticModel);
            if (classificationType == null) return null;

            return new ClassificationSpan(new SnapshotSpan(snapshot, currentSpan.TextSpan.Start, currentSpan.TextSpan.Length), classificationType);
        }

        private IClassificationType GetClassificationType(ClassifiedSpan currentSpan, CompilationUnitSyntax documentRoot, SemanticModel semanticModel)
        {
            IClassificationType classificationType = null;

            // Get the innermost span, which corresponds to the span being proccessed
            var spanType = currentSpan.ClassificationType;
            var node = documentRoot.FindNode(currentSpan.TextSpan, true, true);
            var nodeKind = node.Kind();

            var token = node.FindToken(currentSpan.TextSpan.Start);

            if (spanType.Contains("name")) classificationType = GetIdentifierClassification(token, semanticModel);
            else
            {
                switch (spanType)
                {
                    case "keyword":
                        classificationType = GetKeywordClassification(token);
                        break;

                    case "identifier":
                        {
                            classificationType = GetIdentifierClassification(token);
                            if (classificationType != null) break;
                            if (IsChildOfKind(token, SyntaxKind.NamespaceDeclaration))
                                classificationType = _classifications[ClassificationTypes.Identifiers.NamespaceIdentifier];
                            break;
                        }

                    case "operator":
                        {
                            if (token.Kind() == SyntaxKind.DotToken)
                            {
                                if (IsChildOfKind(token, SyntaxKind.NamespaceDeclaration)) classificationType = _classifications[ClassificationTypes.Identifiers.NamespaceIdentifier];
                            }
                            break;
                        }
                }
            }

            return classificationType;
        }

        private IClassificationType GetVariableClassification(SyntaxNode node, SemanticModel semanticModel)
        {
            var declarationNode = node.Parent.Parent;
            switch (declarationNode.Kind())
            {
                case SyntaxKind.FieldDeclaration:
                    {
                        var symbol = GetSymbol(node, semanticModel);
                        if (symbol == null) return null;
                        return GetFieldClassification(symbol);
                    }
                default:
                    return null;
            }
        }
        private IClassificationType GetFieldClassification(ISymbol symbol)
        {
            var typeInfo = (symbol as IFieldSymbol)?.Type;
            switch (typeInfo.SpecialType)
            {
                case SpecialType.System_Boolean:
                    return _classifications[ClassificationTypes.Fields.BooleanField];

                case SpecialType.System_Byte:
                case SpecialType.System_SByte:
                    return _classifications[ClassificationTypes.Fields.ByteField];

                case SpecialType.System_Char:
                    return _classifications[ClassificationTypes.Fields.CharField];

                case SpecialType.System_DateTime:
                    return _classifications[ClassificationTypes.Fields.DateTimeField];

                case SpecialType.System_Int16:
                case SpecialType.System_Int32:
                case SpecialType.System_Int64:
                case SpecialType.System_UInt16:
                case SpecialType.System_UInt32:
                case SpecialType.System_UInt64:
                case SpecialType.System_Decimal:
                case SpecialType.System_Double:
                case SpecialType.System_Single:
                    return _classifications[ClassificationTypes.Fields.NumericField];

                case SpecialType.System_String:
                    return _classifications[ClassificationTypes.Fields.StringField];

                default:
                    return _classifications[ClassificationTypes.Fields.Field];
            }

        }
        private IClassificationType GetPropertyClassification(ISymbol symbol)
        {
            var typeInfo = (symbol as IPropertySymbol)?.Type;
            switch (typeInfo.SpecialType)
            {
                case SpecialType.System_Boolean:
                    return _classifications[ClassificationTypes.Properties.BooleanProperty];

                case SpecialType.System_SByte:
                case SpecialType.System_Byte:
                    return _classifications[ClassificationTypes.Properties.ByteProperty];

                case SpecialType.System_Char:
                    return _classifications[ClassificationTypes.Properties.CharProperty];

                case SpecialType.System_DateTime:
                    return _classifications[ClassificationTypes.Properties.DateTimeProperty];

                case SpecialType.System_Int16:
                case SpecialType.System_UInt16:
                case SpecialType.System_Int32:
                case SpecialType.System_UInt32:
                case SpecialType.System_Int64:
                case SpecialType.System_UInt64:
                case SpecialType.System_Decimal:
                case SpecialType.System_Single:
                case SpecialType.System_Double:
                    return _classifications[ClassificationTypes.Properties.NumericProperty];

                case SpecialType.System_String:
                    return _classifications[ClassificationTypes.Properties.StringProperty];

                default:
                    return _classifications[ClassificationTypes.Properties.Property];
            }
        }
        private IClassificationType GetKeywordClassification(SyntaxToken token)
        {
            switch (token.Kind())
            {
                #region Abstraction Keywords
                case SyntaxKind.AbstractKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.AbstractKeyword];

                case SyntaxKind.AsyncKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.AsyncKeyword];

                case SyntaxKind.NewKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.NewKeyword];

                case SyntaxKind.OverrideKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.OverrideKeyword];

                case SyntaxKind.SealedKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.SealedKeyword];

                case SyntaxKind.VirtualKeyword:
                    return _classifications[ClassificationTypes.AbstractionTypes.VirtualKeyword];

                #endregion

                #region Declaration Keywords
                case SyntaxKind.ClassKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.ClassKeyword];

                case SyntaxKind.DelegateKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.DelegateKeyword];

                case SyntaxKind.EnumKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.ClassKeyword];

                case SyntaxKind.InterfaceKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.InterfaceKeyword];

                case SyntaxKind.NamespaceKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.NamespaceKeyword];

                case SyntaxKind.StructKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.StructKeyword];

                #endregion

                #region Encapsulation Keywords
                case SyntaxKind.PublicKeyword:
                case SyntaxKind.PrivateKeyword:
                case SyntaxKind.InternalKeyword:
                case SyntaxKind.ProtectedKeyword:
                    return _classifications[ClassificationTypes.DeclarationTypes.EncapsulationKeywords];

                #endregion

                default:
                    return null;
            }
        }
        private IClassificationType GetIdentifierClassification(SyntaxToken token, SemanticModel semanticModel = null)
        {
            switch (token.Parent.Kind())
            {
                #region Identifiers
                case SyntaxKind.ClassDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.ClassIdentifier];

                case SyntaxKind.ConstructorDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.ConstructorIdentifier];

                case SyntaxKind.DelegateDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.DelegateIdentifier];

                case SyntaxKind.EnumDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.EnumIdentifier];

                case SyntaxKind.InterfaceDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.InterfaceIdentifier];

                case SyntaxKind.MethodDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.MethodIdentifier];

                case SyntaxKind.NamespaceDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.NamespaceIdentifier];
                case SyntaxKind.PropertyDeclaration:
                    {
                        var symbol = GetSymbol(token.Parent, semanticModel);
                        if (symbol == null) return null;
                        return GetPropertyClassification(symbol);
                    }

                case SyntaxKind.StructDeclaration:
                    return _classifications[ClassificationTypes.Identifiers.StructIdentifier];
                case SyntaxKind.VariableDeclarator:
                    return GetVariableClassification(token.Parent, semanticModel);
                default:
                    return null;
                    #endregion
            }
        }

        #region Helpers
        private bool IsChildOfKind(SyntaxToken token,SyntaxKind kind)
        {
            var declarationNode = GetDeclarationNode(token);
            if (declarationNode == null) return false;
            return declarationNode.IsKind(kind);
        }

        SyntaxNode GetDeclarationNode(SyntaxToken token)
        {
            if (token.Parent != null && token.Parent.Kind().ToString().Contains("Declaration")) return token.Parent;
            return GetParentNode(token.Parent);
        }

        SyntaxNode GetParentNode(SyntaxNode node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Kind().ToString().Contains("Declaration")) return node.Parent;
            return GetParentNode(node.Parent);

        }

        private ISymbol GetSymbol(SyntaxNode node, SemanticModel semanticModel)
        {
            var symbol = semanticModel.GetDeclaredSymbol(node);
            if (symbol == null) symbol = semanticModel.GetSymbolInfo(node).Symbol;
            return symbol;
        }
        #endregion

    }
}
