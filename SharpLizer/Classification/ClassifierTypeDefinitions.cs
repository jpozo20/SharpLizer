using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

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
        private static readonly ClassificationTypeDefinition abstractionKeywordsDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.AbstractKeyword)]
        private static readonly ClassificationTypeDefinition abstractKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AsyncKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.AsyncKeyword)]
        private static readonly ClassificationTypeDefinition asyncKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.NewKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.NewKeyword)]
        private static readonly ClassificationTypeDefinition newKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.OverrideKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.OverrideKeyword)]
        private static readonly ClassificationTypeDefinition overrideKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.SealedKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.SealedKeyword)]
        private static readonly ClassificationTypeDefinition sealedKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.VirtualKeyword)]
        [Name(ClassificationTypes.AbstractionTypes.VirtualKeyword)]
        private static readonly ClassificationTypeDefinition virtualKeywordDefinition;

        #endregion Abstraction Keywords TypeDefinitions

        #region Declaration Keywords TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
        [Name(ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
        private static readonly ClassificationTypeDefinition declarationKeywordsDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
        [Name(ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
        private static readonly ClassificationTypeDefinition encapsulationKeywordsDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.ClassKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.ClassKeyword)]
        private static readonly ClassificationTypeDefinition classKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DelegateKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.DelegateKeyword)]
        private static readonly ClassificationTypeDefinition delegateKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EnumKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.EnumKeyword)]
        private static readonly ClassificationTypeDefinition enumKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
        private static readonly ClassificationTypeDefinition interfaceKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
        private static readonly ClassificationTypeDefinition namespaceKeywordDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.StructKeyword)]
        [Name(ClassificationTypes.DeclarationTypes.StructKeyword)]
        private static readonly ClassificationTypeDefinition structKeywordDefinition;

        #endregion Declaration Keywords TypeDefinitions

        #region Identifier TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
        [Name(ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
        private static readonly ClassificationTypeDefinition attributeArgumentDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributeIdentifier)]
        [Name(ClassificationTypes.Identifiers.AttributeIdentifier)]
        private static readonly ClassificationTypeDefinition attributeIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ClassIdentifier)]
        [Name(ClassificationTypes.Identifiers.ClassIdentifier)]
        private static readonly ClassificationTypeDefinition classIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ConstructorIdentifier)]
        [Name(ClassificationTypes.Identifiers.ConstructorIdentifier)]
        private static readonly ClassificationTypeDefinition constructorIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.DelegateIdentifier)]
        [Name(ClassificationTypes.Identifiers.DelegateIdentifier)]
        private static readonly ClassificationTypeDefinition delegateIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.EnumIdentifier)]
        [Name(ClassificationTypes.Identifiers.EnumIdentifier)]
        private static readonly ClassificationTypeDefinition enumIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.InterfaceIdentifier)]
        [Name(ClassificationTypes.Identifiers.InterfaceIdentifier)]
        private static readonly ClassificationTypeDefinition interfaceIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.MethodIdentifier)]
        [Name(ClassificationTypes.Identifiers.MethodIdentifier)]
        private static readonly ClassificationTypeDefinition methodIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.NamespaceIdentifier)]
        [Name(ClassificationTypes.Identifiers.NamespaceIdentifier)]
        private static readonly ClassificationTypeDefinition namespaceIdentifierDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.StructIdentifier)]
        [Name(ClassificationTypes.Identifiers.StructIdentifier)]
        private static readonly ClassificationTypeDefinition structIdentifierDefinition;

        #endregion Identifier TypeDefinitions

        #region Field TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.BooleanField)]
        [Name(ClassificationTypes.Fields.BooleanField)]
        private static readonly ClassificationTypeDefinition booleanFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ByteField)]
        [Name(ClassificationTypes.Fields.ByteField)]
        private static readonly ClassificationTypeDefinition byteFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.CharField)]
        [Name(ClassificationTypes.Fields.CharField)]
        private static readonly ClassificationTypeDefinition charFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ConstantField)]
        [Name(ClassificationTypes.Fields.ConstantField)]
        private static readonly ClassificationTypeDefinition constantFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.DateTimeField)]
        [Name(ClassificationTypes.Fields.DateTimeField)]
        private static readonly ClassificationTypeDefinition dateTimeFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EnumField)]
        [Name(ClassificationTypes.Fields.EnumField)]
        private static readonly ClassificationTypeDefinition enumFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EventHandler)]
        [Name(ClassificationTypes.Fields.EventHandler)]
        private static readonly ClassificationTypeDefinition eventHandlerFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.Field)]
        [Name(ClassificationTypes.Fields.Field)]
        private static readonly ClassificationTypeDefinition fieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.NumericField)]
        [Name(ClassificationTypes.Fields.NumericField)]
        private static readonly ClassificationTypeDefinition numericFieldDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.StringField)]
        [Name(ClassificationTypes.Fields.StringField)]
        private static readonly ClassificationTypeDefinition stringFieldDefinition;

        #endregion Field TypeDefinitions

        #region Property TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.Property)]
        [Name(ClassificationTypes.Properties.Property)]
        private static readonly ClassificationTypeDefinition propertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.BooleanProperty)]
        [Name(ClassificationTypes.Properties.BooleanProperty)]
        private static readonly ClassificationTypeDefinition booleanPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.ByteProperty)]
        [Name(ClassificationTypes.Properties.ByteProperty)]
        private static readonly ClassificationTypeDefinition bytePropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.CharProperty)]
        [Name(ClassificationTypes.Properties.CharProperty)]
        private static readonly ClassificationTypeDefinition charPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.DateTimeProperty)]
        [Name(ClassificationTypes.Properties.DateTimeProperty)]
        private static readonly ClassificationTypeDefinition dateTimePropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.EnumProperty)]
        [Name(ClassificationTypes.Properties.EnumProperty)]
        private static readonly ClassificationTypeDefinition enumPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.NumericProperty)]
        [Name(ClassificationTypes.Properties.NumericProperty)]
        private static readonly ClassificationTypeDefinition numericPropertyDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.StringProperty)]
        [Name(ClassificationTypes.Properties.StringProperty)]
        private static readonly ClassificationTypeDefinition stringPropertyDefinition;

        #endregion Property TypeDefinitions

        #region Variable TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.LocalVariable)]
        [Name(ClassificationTypes.Variables.LocalVariable)]
        private static readonly ClassificationTypeDefinition localVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.BooleanVariable)]
        [Name(ClassificationTypes.Variables.BooleanVariable)]
        private static readonly ClassificationTypeDefinition booleanVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.ByteVariable)]
        [Name(ClassificationTypes.Variables.ByteVariable)]
        private static readonly ClassificationTypeDefinition byteVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.CharVariable)]
        [Name(ClassificationTypes.Variables.CharVariable)]
        private static readonly ClassificationTypeDefinition charVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.DateTimeVariable)]
        [Name(ClassificationTypes.Variables.DateTimeVariable)]
        private static readonly ClassificationTypeDefinition dateTimeVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.EnumVariable)]
        [Name(ClassificationTypes.Variables.EnumVariable)]
        private static readonly ClassificationTypeDefinition enumVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.NumericVariable)]
        [Name(ClassificationTypes.Variables.NumericVariable)]
        private static readonly ClassificationTypeDefinition numericVarialeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.StringVariable)]
        [Name(ClassificationTypes.Variables.StringVariable)]
        private static readonly ClassificationTypeDefinition stringVarialeDefinition;

        #endregion Variable TypeDefinitions

        #region Parameter TypeDefinitions

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Parameters.ValueParameter)]
        [Name(ClassificationTypes.Parameters.ValueParameter)]
        private static readonly ClassificationTypeDefinition valueParameter;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Parameters.InParameter)]
        [Name(ClassificationTypes.Parameters.InParameter)]
        private static readonly ClassificationTypeDefinition inParameter;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Parameters.OutParameter)]
        [Name(ClassificationTypes.Parameters.OutParameter)]
        private static readonly ClassificationTypeDefinition outParameter;

        [Export(typeof(ClassificationTypeDefinition))]
        [ClassificationType(ClassificationTypeNames = ClassificationTypes.Parameters.RefParameter)]
        [Name(ClassificationTypes.Parameters.RefParameter)]
        private static readonly ClassificationTypeDefinition refParameter;

        #endregion Parameter TypeDefinitions

#pragma warning restore 169
    }
}