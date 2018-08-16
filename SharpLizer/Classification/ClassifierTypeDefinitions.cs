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

        #region Identifier TypeDefinitions
        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
        [Name(ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
        private static ClassificationTypeDefinition attributeArgumentDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributeIdentifier)]
        [Name(ClassificationTypes.Identifiers.AttributeIdentifier)]
        private static ClassificationTypeDefinition attributeIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ClassIdentifier)]
        [Name(ClassificationTypes.Identifiers.ClassIdentifier)]
        private static ClassificationTypeDefinition classIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ConstructorIdentifier)]
        [Name(ClassificationTypes.Identifiers.ConstructorIdentifier)]
        private static ClassificationTypeDefinition constructorIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.DelegateIdentifier)]
        [Name(ClassificationTypes.Identifiers.DelegateIdentifier)]
        private static ClassificationTypeDefinition delegateIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.EnumIdentifier)]
        [Name(ClassificationTypes.Identifiers.EnumIdentifier)]
        private static ClassificationTypeDefinition enumIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.FieldIdentifier)]
        [Name(ClassificationTypes.Identifiers.FieldIdentifier)]
        private static ClassificationTypeDefinition fieldIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.InterfaceIdentifier)]
        [Name(ClassificationTypes.Identifiers.InterfaceIdentifier)]
        private static ClassificationTypeDefinition interfaceIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.MethodIdentifier)]
        [Name(ClassificationTypes.Identifiers.MethodIdentifier)]
        private static ClassificationTypeDefinition methodIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.NamespaceIdentifier)]
        [Name(ClassificationTypes.Identifiers.NamespaceIdentifier)]
        private static ClassificationTypeDefinition namespaceIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.StructIdentifier)]
        [Name(ClassificationTypes.Identifiers.StructIdentifier)]
        private static ClassificationTypeDefinition structIdentifierDefinition;
        
        #endregion

#pragma warning restore 169
    }
}
