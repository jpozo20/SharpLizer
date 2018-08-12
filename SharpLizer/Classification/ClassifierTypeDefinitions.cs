using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SharpLizer.Classification
{
    /// <summary>
    /// Classification type definition export for EditorClassifier
    /// </summary>
    internal static class ClassifierTypeDefinitions
    {
        // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

        /// <summary>
        /// Defines the "EditorClassifier" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.FieldType)]
        [Name(ClassificationTypes.FieldType)]
        private static ClassificationTypeDefinition fieldTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.MethodType)]
        [Name(ClassificationTypes.MethodType)]
        private static ClassificationTypeDefinition methodTypeDefinition;

        #region Abstraction Keywords TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
        [Name(ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
        private static ClassificationTypeDefinition abstractionKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.AbstractKeyword)]
        private static ClassificationTypeDefinition abstractKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AsyncKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.AsyncKeyword)]
        private static ClassificationTypeDefinition asyncKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.NewKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.NewKeyword)]
        private static ClassificationTypeDefinition newKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.OverrideKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.OverrideKeyword)]
        private static ClassificationTypeDefinition overrideKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.SealedKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.SealedKeyword)]
        private static ClassificationTypeDefinition sealedKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.VirtualKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.VirtualKeyword)]
        private static ClassificationTypeDefinition virtualKeywordDefinition;

        #endregion

#pragma warning restore 169
    }
}
