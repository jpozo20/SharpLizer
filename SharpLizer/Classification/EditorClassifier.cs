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
        internal EditorClassifier(IClassificationTypeRegistryService registry, ITextBuffer buffer, IDictionary<string,IClassificationType> classifications)
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
        public  IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
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
            var classifiedSpans = Classifier.GetClassifiedSpans(semanticModel, currentDocumentSpan,workspace);

            var result = new List<ClassificationSpan>();
            foreach (var classifiedSpan in classifiedSpans)
            {
                var classificationSpan = GetClassificationSpan(snapshot, classifiedSpan, documentRoot, semanticModel);
                if (classificationSpan == null) continue;

                result.Add(classificationSpan);

            }
            return result;
        }

        private ClassificationSpan GetClassificationSpan(ITextSnapshot snapshot, ClassifiedSpan currentSpan, CompilationUnitSyntax documentRoot, SemanticModel semanticModel) {

            var classificationType = GetClassificationType(currentSpan, snapshot, documentRoot, semanticModel);
            if (classificationType == null) return null;

            return new ClassificationSpan(new SnapshotSpan(snapshot, currentSpan.TextSpan.Start, currentSpan.TextSpan.Length), classificationType);
        }

        private IClassificationType GetClassificationType(ClassifiedSpan currentSpan, ITextSnapshot snapshot, CompilationUnitSyntax documentRoot, SemanticModel semanticModel)
        {
            // Get the innermost span, which corresponds to the span being proccessed
            var node = documentRoot.FindNode(currentSpan.TextSpan, true, true);

            var type = currentSpan.ClassificationType;
            var nodeKind = node.Kind();

            if (nodeKind.ToString().EndsWith("Declaration",StringComparison.InvariantCultureIgnoreCase))
            {
                var token = node.FindToken(currentSpan.TextSpan.Start);
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


                    default:
                        return null;
                }
            }
            else
            {
                switch (nodeKind)
                {
                    case SyntaxKind.MethodDeclaration:
                        return _classifications[ClassificationTypes.MethodType];
                    default:
                        return null;
                }
            }
        }
        #endregion
    }
}
