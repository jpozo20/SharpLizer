using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SharpLizer.Classification
{
    /// <summary>
    /// Classifier provider. It adds the classifier to the set of classifiers.
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [Export(typeof(ClassifierProvider))]
    [ContentType("CSharp")] // This classifier applies to all text files.
    internal class ClassifierProvider : IClassifierProvider
    {
        // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.
#pragma warning disable 649

        /// <summary>
        /// Classification registry to be used for getting a reference
        /// to the custom classification types later.
        /// </summary>
        [Import]
        private IClassificationTypeRegistryService _classificationRegistry;

        [Import]
        private readonly IClassificationFormatMapService _classificationFormatMapService;


        private IClassifier _classifier;

#pragma warning restore 649

        #region IClassifierProvider

        /// <summary>
        /// Gets a classifier for the given text buffer.
        /// </summary>
        /// <param name="textBuffer">The <see cref="ITextBuffer"/> to classify.</param>
        /// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.</returns>
        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            IDictionary<string, IClassificationType> classificationTypes = GetClassificationTypes();
            _classifier = textBuffer.Properties.GetOrCreateSingletonProperty(creator: () => new EditorClassifier(_classificationRegistry, textBuffer, classificationTypes));
            return _classifier;
        }

        public IClassificationTypeRegistryService GetTypeRegistryService()
        {
            return _classificationRegistry;
        }
        public IClassificationFormatMapService GetClassificationFormatMapService()
        {
            return _classificationFormatMapService;
        }

        private IDictionary<string, IClassificationType> GetClassificationTypes()
        {
            Dictionary<string, IClassificationType> classificationTypes = new Dictionary<string, IClassificationType>();

            #region Abstraction

            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractionKeywords, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractionKeywords));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AsyncKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AsyncKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.NewKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.NewKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.OverrideKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.OverrideKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.SealedKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.SealedKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.VirtualKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.VirtualKeyword));

            #endregion Abstraction

            #region Declaration Types

            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DeclarationKeywords, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DeclarationKeywords));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.ClassKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.ClassKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DelegateKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DelegateKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.EnumKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.EnumKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.InterfaceKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.InterfaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.NamespaceKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.NamespaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.StructKeyword, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.StructKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.EncapsulationKeywords, _classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.EncapsulationKeywords));

            #endregion Declaration Types

            #region Identifiers

            classificationTypes.Add(ClassificationTypes.Identifiers.AttributeIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributeIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.AttributePropertyIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributePropertyIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ClassIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ClassIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ConstructorIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ConstructorIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.DelegateIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.DelegateIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.EnumIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.EnumIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.InterfaceIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.InterfaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.MethodIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.MethodIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.NamespaceIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.NamespaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.StructIdentifier, _classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.StructIdentifier));

            #endregion Identifiers

            #region Fields

            classificationTypes.Add(ClassificationTypes.Fields.BooleanField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.BooleanField));
            classificationTypes.Add(ClassificationTypes.Fields.ByteField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.ByteField));
            classificationTypes.Add(ClassificationTypes.Fields.CharField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.CharField));
            classificationTypes.Add(ClassificationTypes.Fields.ConstantField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.ConstantField));
            classificationTypes.Add(ClassificationTypes.Fields.DateTimeField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.DateTimeField));
            classificationTypes.Add(ClassificationTypes.Fields.EnumField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.EnumField));
            classificationTypes.Add(ClassificationTypes.Fields.EventHandler, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.EventHandler));
            classificationTypes.Add(ClassificationTypes.Fields.Field, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.Field));
            classificationTypes.Add(ClassificationTypes.Fields.NumericField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.NumericField));
            classificationTypes.Add(ClassificationTypes.Fields.StringField, _classificationRegistry.GetClassificationType(ClassificationTypes.Fields.StringField));

            #endregion Fields

            #region Properties

            classificationTypes.Add(ClassificationTypes.Properties.Property, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.Property));
            classificationTypes.Add(ClassificationTypes.Properties.BooleanProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.BooleanProperty));
            classificationTypes.Add(ClassificationTypes.Properties.ByteProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.ByteProperty));
            classificationTypes.Add(ClassificationTypes.Properties.CharProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.CharProperty));
            classificationTypes.Add(ClassificationTypes.Properties.DateTimeProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.DateTimeProperty));
            classificationTypes.Add(ClassificationTypes.Properties.EnumProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.EnumProperty));
            classificationTypes.Add(ClassificationTypes.Properties.NumericProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.NumericProperty));
            classificationTypes.Add(ClassificationTypes.Properties.StringProperty, _classificationRegistry.GetClassificationType(ClassificationTypes.Properties.StringProperty));

            #endregion Properties

            #region Variables

            classificationTypes.Add(ClassificationTypes.Variables.LocalVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.LocalVariable));
            classificationTypes.Add(ClassificationTypes.Variables.BooleanVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.BooleanVariable));
            classificationTypes.Add(ClassificationTypes.Variables.ByteVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.ByteVariable));
            classificationTypes.Add(ClassificationTypes.Variables.CharVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.CharVariable));
            classificationTypes.Add(ClassificationTypes.Variables.DateTimeVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.DateTimeVariable));
            classificationTypes.Add(ClassificationTypes.Variables.EnumVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.EnumVariable));
            classificationTypes.Add(ClassificationTypes.Variables.NumericVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.NumericVariable));
            classificationTypes.Add(ClassificationTypes.Variables.StringVariable, _classificationRegistry.GetClassificationType(ClassificationTypes.Variables.StringVariable));

            #endregion Variables

            return classificationTypes;
        }

        #endregion IClassifierProvider
    }
}