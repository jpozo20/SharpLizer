using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SharpLizer.Classification
{
    /// <summary>
    /// Classifier provider. It adds the classifier to the set of classifiers.
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")] // This classifier applies to all text files.
    internal class ClassifierProvider : IClassifierProvider
    {
        // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.
#pragma warning disable 649

        /// <summary>
        /// Classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// </summary>
        [Import]
        private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore 649

        #region IClassifierProvider

        /// <summary>
        /// Gets a classifier for the given text buffer.
        /// </summary>
        /// <param name="textBuffer">The <see cref="ITextBuffer"/> to classify.</param>
        /// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.</returns>
        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            var classificationTypes = GetClassificationTypes();
            return textBuffer.Properties.GetOrCreateSingletonProperty<EditorClassifier>(creator: () => new EditorClassifier(this.classificationRegistry,textBuffer,classificationTypes));
        }

        IDictionary<string, IClassificationType> GetClassificationTypes()
        {
            var classificationTypes = new Dictionary<string, IClassificationType>();
            classificationTypes.Add(ClassificationTypes.FieldType, classificationRegistry.GetClassificationType(ClassificationTypes.FieldType));
            classificationTypes.Add(ClassificationTypes.MethodType, classificationRegistry.GetClassificationType(ClassificationTypes.MethodType));

            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractionKeywords, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractionKeywords));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AsyncKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AsyncKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.NewKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.NewKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.OverrideKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.OverrideKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.SealedKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.SealedKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.VirtualKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.VirtualKeyword));

            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DeclarationKeywords, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DeclarationKeywords));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.ClassKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.ClassKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DelegateKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DelegateKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.EnumKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.EnumKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.InterfaceKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.InterfaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.NamespaceKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.NamespaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.StructKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.StructKeyword));

            return classificationTypes;
        }

        #endregion
    }
}
