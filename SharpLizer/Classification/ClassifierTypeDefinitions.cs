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
        private static ClassificationTypeDefinition abstractionKeywordsDefinition;

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

        #region Declaration Keywords TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
        [Name(ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
        private static ClassificationTypeDefinition declarationKeywordsDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.ClassKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.ClassKeyword)]
        private static ClassificationTypeDefinition classKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DelegateKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.DelegateKeyword)]
        private static ClassificationTypeDefinition delegateKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EnumKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.EnumKeyword)]
        private static ClassificationTypeDefinition enumKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
        private static ClassificationTypeDefinition interfaceKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
        private static ClassificationTypeDefinition namespaceKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.StructKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.StructKeyword)]
        private static ClassificationTypeDefinition structKeywordDefinition;

        #endregion

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.EncapsulationKeywords)]
        [Name(ClassificationTypes.EncapsulationKeywords)]
        private static ClassificationTypeDefinition encapsulationKeywordsDefinition;

#pragma warning restore 169
    }
}
