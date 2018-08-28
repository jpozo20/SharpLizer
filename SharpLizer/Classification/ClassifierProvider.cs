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

            #region Abstraction
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractionKeywords, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractionKeywords));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AbstractKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AbstractKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.AsyncKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.AsyncKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.NewKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.NewKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.OverrideKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.OverrideKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.SealedKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.SealedKeyword));
            classificationTypes.Add(ClassificationTypes.AbstractionTypes.VirtualKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.AbstractionTypes.VirtualKeyword));
            #endregion

            #region Declaration Types
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DeclarationKeywords, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DeclarationKeywords));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.ClassKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.ClassKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.DelegateKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.DelegateKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.EnumKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.EnumKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.InterfaceKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.InterfaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.NamespaceKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.NamespaceKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.StructKeyword, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.StructKeyword));
            classificationTypes.Add(ClassificationTypes.DeclarationTypes.EncapsulationKeywords, classificationRegistry.GetClassificationType(ClassificationTypes.DeclarationTypes.EncapsulationKeywords));
            #endregion

            #region Identifiers
            classificationTypes.Add(ClassificationTypes.Identifiers.AttributeIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributeIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.AttributePropertyIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributePropertyIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ClassIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ClassIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ConstructorIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ConstructorIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.DelegateIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.DelegateIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.EnumIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.EnumIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.InterfaceIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.InterfaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.MethodIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.MethodIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.NamespaceIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.NamespaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.StructIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.StructIdentifier));
            #endregion

            #region Fields
            classificationTypes.Add(ClassificationTypes.Fields.BooleanField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.BooleanField));
            classificationTypes.Add(ClassificationTypes.Fields.ByteField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.ByteField));
            classificationTypes.Add(ClassificationTypes.Fields.CharField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.CharField));
            classificationTypes.Add(ClassificationTypes.Fields.ConstantField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.ConstantField));
            classificationTypes.Add(ClassificationTypes.Fields.DateTimeField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.DateTimeField));
            classificationTypes.Add(ClassificationTypes.Fields.EnumField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.EnumField));
            classificationTypes.Add(ClassificationTypes.Fields.EventHandler, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.EventHandler));
            classificationTypes.Add(ClassificationTypes.Fields.Field, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.Field));
            classificationTypes.Add(ClassificationTypes.Fields.NumericField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.NumericField));
            classificationTypes.Add(ClassificationTypes.Fields.StringField, classificationRegistry.GetClassificationType(ClassificationTypes.Fields.StringField));
            #endregion

            #region Properties
            classificationTypes.Add(ClassificationTypes.Properties.Property, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.Property));
            classificationTypes.Add(ClassificationTypes.Properties.BooleanProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.BooleanProperty));
            classificationTypes.Add(ClassificationTypes.Properties.ByteProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.ByteProperty));
            classificationTypes.Add(ClassificationTypes.Properties.CharProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.CharProperty));
            classificationTypes.Add(ClassificationTypes.Properties.DateTimeProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.DateTimeProperty));
            classificationTypes.Add(ClassificationTypes.Properties.EnumProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.EnumProperty));
            classificationTypes.Add(ClassificationTypes.Properties.NumericProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.NumericProperty));
            classificationTypes.Add(ClassificationTypes.Properties.StringProperty, classificationRegistry.GetClassificationType(ClassificationTypes.Properties.StringProperty));
            #endregion

            #region Properties
            classificationTypes.Add(ClassificationTypes.Variables.LocalVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.LocalVariable));
            classificationTypes.Add(ClassificationTypes.Variables.BooleanVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.BooleanVariable));
            classificationTypes.Add(ClassificationTypes.Variables.ByteVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.ByteVariable));
            classificationTypes.Add(ClassificationTypes.Variables.CharVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.CharVariable));
            classificationTypes.Add(ClassificationTypes.Variables.DateTimeVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.DateTimeVariable));
            classificationTypes.Add(ClassificationTypes.Variables.EnumVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.EnumVariable));
            classificationTypes.Add(ClassificationTypes.Variables.NumericVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.NumericVariable));
            classificationTypes.Add(ClassificationTypes.Variables.StringVariable, classificationRegistry.GetClassificationType(ClassificationTypes.Variables.StringVariable));
            #endregion

            classificationTypes.Add(ClassificationTypes.Identifiers.AttributeIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributeIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.AttributePropertyIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.AttributePropertyIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ClassIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ClassIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.ConstructorIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.ConstructorIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.DelegateIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.DelegateIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.EnumIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.EnumIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.InterfaceIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.InterfaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.MethodIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.MethodIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.NamespaceIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.NamespaceIdentifier));
            classificationTypes.Add(ClassificationTypes.Identifiers.StructIdentifier, classificationRegistry.GetClassificationType(ClassificationTypes.Identifiers.StructIdentifier));

            return classificationTypes;
        }

        #endregion
    }
}