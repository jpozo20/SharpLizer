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
        private readonly IClassificationType fieldClassification;
        private readonly IClassificationType methodClassification;
        private readonly IClassificationTypeRegistryService _registryService;

        private Document _document;
        private SemanticModel _semanticModel;
        private CompilationUnitSyntax _documentRoot;


        /// <summary>
        /// Initializes a new instance of the <see cref="EditorClassifier"/> class.
        /// </summary>
        /// <param name="registry">Classification registry.</param>
        internal EditorClassifier(IClassificationTypeRegistryService registry, Dictionary<string,IClassificationType> classifications)
        {
            _registryService = registry;
            fieldClassification = classifications[ClassificationTypes.FieldType];
            methodClassification = classifications[ClassificationTypes.MethodType];
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

            var result = new List<ClassificationSpan>();
            //new ClassificationSpan(new SnapshotSpan(snapshotSpan, span.Start, span.Length), classificationType);

            // Get a snaphot of the current document
            var snapshot = span.Snapshot;

            // Get the Workspace belonging to the document
            var workspace = snapshot.TextBuffer.GetWorkspace();
            if (workspace == null) return new List<ClassificationSpan>();

            // Get the current document and its model
            if (_document == null) _document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
            if (_semanticModel == null) _semanticModel = _document.GetSemanticModelAsync().Result;
            if(_documentRoot == null) _documentRoot = _semanticModel.SyntaxTree.GetCompilationUnitRoot();

            var currentDocumentSpan = new TextSpan(span.Start.Position, span.Length);
            var classifiedSpans = Classifier.GetClassifiedSpans(_semanticModel, currentDocumentSpan,workspace);

            foreach (var classifiedSpan in classifiedSpans)
            {
                var classificationSpan = GetClassificationSpan(snapshot, classifiedSpan, _documentRoot, _semanticModel);
                result.Add(classificationSpan);

            }
            return result;
        }

        private ClassificationSpan GetClassificationSpan(ITextSnapshot snapshot, ClassifiedSpan currentSpan, CompilationUnitSyntax documentRoot, SemanticModel semanticModel) {

            var classificationType = GetClassificationType(currentSpan, snapshot, documentRoot, semanticModel);
            return new ClassificationSpan(new SnapshotSpan(snapshot, currentSpan.TextSpan.Start, currentSpan.TextSpan.Length), classificationType);
        }

        private IClassificationType GetClassificationType(ClassifiedSpan currentSpan, ITextSnapshot snapshot, CompilationUnitSyntax documentRoot, SemanticModel semanticModel)
        {
            // Get the innermost span, which corresponds to the span being proccessed
            var node = documentRoot.FindNode(currentSpan.TextSpan, true, true);

            var type = currentSpan.ClassificationType;
            var kind = node.Kind();

            var symbol = semanticModel.GetSymbolInfo(node).Symbol;
            if (symbol == null) symbol = semanticModel.GetDeclaredSymbol(node);


            switch (kind)
            {
                case SyntaxKind.MethodDeclaration:
                    //result.Add(new ClassificationSpan(new SnapshotSpan(snapshot, classifiedSpan.TextSpan.Start, classifiedSpan.TextSpan.Length), methodClassification));
                    break;
                default: break;
            }

            return null;
        }

        
        #endregion
    }


}
