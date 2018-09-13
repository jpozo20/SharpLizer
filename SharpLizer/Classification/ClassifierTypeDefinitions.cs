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
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
        [Name(ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
        private static ClassificationTypeDefinition encapsulationKeywordsDefinition;

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
        
        #region Field TypeDefinitions
        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.BooleanField)]
        [Name(ClassificationTypes.Fields.BooleanField)]
        private static ClassificationTypeDefinition booleanFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ByteField)]
        [Name(ClassificationTypes.Fields.ByteField)]
        private static ClassificationTypeDefinition byteFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.CharField)]
        [Name(ClassificationTypes.Fields.CharField)]
        private static ClassificationTypeDefinition charFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]

        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ConstantField)]
        [Name(ClassificationTypes.Fields.ConstantField)]
        private static ClassificationTypeDefinition constantFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.DateTimeField)]
        [Name(ClassificationTypes.Fields.DateTimeField)]
        private static ClassificationTypeDefinition dateTimeFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EnumField)]
        [Name(ClassificationTypes.Fields.EnumField)]
        private static ClassificationTypeDefinition enumFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EventHandler)]
        [Name(ClassificationTypes.Fields.EventHandler)]
        private static ClassificationTypeDefinition eventHandlerFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.Field)]
        [Name(ClassificationTypes.Fields.Field)]
        private static ClassificationTypeDefinition fieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.NumericField)]
        [Name(ClassificationTypes.Fields.NumericField)]
        private static ClassificationTypeDefinition numericFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.StringField)]
        [Name(ClassificationTypes.Fields.StringField)]
        private static ClassificationTypeDefinition stringFieldDefinition;

        #endregion
                
        #region Property TypeDefinitions
        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.Property)]
        [Name(ClassificationTypes.Properties.Property)]
        private static ClassificationTypeDefinition propertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.BooleanProperty)]
        [Name(ClassificationTypes.Properties.BooleanProperty)]
        private static ClassificationTypeDefinition booleanPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.ByteProperty)]
        [Name(ClassificationTypes.Properties.ByteProperty)]
        private static ClassificationTypeDefinition bytePropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.CharProperty)]
        [Name(ClassificationTypes.Properties.CharProperty)]
        private static ClassificationTypeDefinition charPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.DateTimeProperty)]
        [Name(ClassificationTypes.Properties.DateTimeProperty)]
        private static ClassificationTypeDefinition dateTimePropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.EnumProperty)]
        [Name(ClassificationTypes.Properties.EnumProperty)]
        private static ClassificationTypeDefinition enumPropertyDefinition;


        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.NumericProperty)]
        [Name(ClassificationTypes.Properties.NumericProperty)]
        private static ClassificationTypeDefinition numericPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.StringProperty)]
        [Name(ClassificationTypes.Properties.StringProperty)]
        private static ClassificationTypeDefinition stringPropertyDefinition;
        #endregion

        #region Variable TypeDefinitions
        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.LocalVariable)]
        [Name(ClassificationTypes.Variables.LocalVariable)]
        private static ClassificationTypeDefinition localVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.BooleanVariable)]
        [Name(ClassificationTypes.Variables.BooleanVariable)]
        private static ClassificationTypeDefinition booleanVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.ByteVariable)]
        [Name(ClassificationTypes.Variables.ByteVariable)]
        private static ClassificationTypeDefinition byteVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.CharVariable)]
        [Name(ClassificationTypes.Variables.CharVariable)]
        private static ClassificationTypeDefinition charVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.DateTimeVariable)]
        [Name(ClassificationTypes.Variables.DateTimeVariable)]
        private static ClassificationTypeDefinition dateTimeVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.EnumVariable)]
        [Name(ClassificationTypes.Variables.EnumVariable)]
        private static ClassificationTypeDefinition enumVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.NumericVariable)]
        [Name(ClassificationTypes.Variables.NumericVariable)]
        private static ClassificationTypeDefinition numericVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.StringVariable)]
        [Name(ClassificationTypes.Variables.StringVariable)]
        private static ClassificationTypeDefinition stringVarialeDefinition;
        #endregion        

        #pragma warning restore 169
    }
}