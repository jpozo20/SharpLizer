using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SharpLizer.Classification
{
    #region Abstraction Keywords Colors
    
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [Name(ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [UserVisible(false)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class AbstractionKeywordsClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractionKeywordsClassification"/> class.
        /// </summary>
        public AbstractionKeywordsClassification()
        {
            this.DisplayName = "SharpLizer: Abstraction Keywords"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.AbstractKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class AbstractKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractKeywordClassification"/> class.
        /// </summary>
        public AbstractKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Abstract Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AsyncKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.AsyncKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class AsyncKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncKeywordClassification"/> class.
        /// </summary>
        public AsyncKeywordClassification()
        {
          this.DisplayName = "SharpLizer: Async Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.NewKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.NewKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers


    internal sealed class NewKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewKeywordClassification"/> class.
        /// </summary>
        public NewKeywordClassification()
        {
            this.DisplayName = "SharpLizer: New Keyword";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.OverrideKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.OverrideKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class OverrideKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverrideKeywordClassification"/> class.
        /// </summary>
        public OverrideKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Override Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.SealedKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.SealedKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class SealedKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SealedKeywordClassification"/> class.
        /// </summary>
        public SealedKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Sealed Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.VirtualKeyword)]
    [Name(ClassificationTypes.AbstractionTypes.VirtualKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class VirtualKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualKeywordClassification"/> class.
        /// </summary>
        public VirtualKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Virtual Keyword"; 
        }
    }

    #endregion

    #region Declaration Keywords Colors

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
    [Name(ClassificationTypes.DeclarationTypes.DeclarationKeywords)]
    [UserVisible(false)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DeclarationKeywordsClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeclarationKeywordsClassification"/> class.
        /// </summary>
        public DeclarationKeywordsClassification()
        {
            this.DisplayName = "SharpLizer: Declaration Keywords"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.ClassKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.ClassKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ClassKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassKeywordClassification"/> class.
        /// </summary>
        public ClassKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Class Keyword";
            this.ForegroundColor = Colors.Purple;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.DelegateKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.DelegateKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DelegateKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateKeywordClassification"/> class.
        /// </summary>
        public DelegateKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Delegate Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EnumKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.EnumKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EnumKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumKeywordClassification"/> class.
        /// </summary>
        public EnumKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Enum Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.InterfaceKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class InterfaceKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceKeywordClassification"/> class.
        /// </summary>
        public InterfaceKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Interface Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.NamespaceKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class NamespaceKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceKeywordClassification"/> class.
        /// </summary>
        public NamespaceKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Namespace Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.StructKeyword)]
    [Name(ClassificationTypes.DeclarationTypes.StructKeyword)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers

    internal sealed class StructKeywordClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructKeywordClassification"/> class.
        /// </summary>
        public StructKeywordClassification()
        {
            this.DisplayName = "SharpLizer: Struct Keyword"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
    [Name(ClassificationTypes.DeclarationTypes.EncapsulationKeywords)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EncapsulationKeywordsClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncapsulationKeywordsClassification"/> class.
        /// </summary>
        public EncapsulationKeywordsClassification()
        {
            this.DisplayName = "SharpLizer: Encapsulation Keywords"; 
        }
    }

    #endregion

    #region Identifiers Colors
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributeIdentifier)]
    [Name(ClassificationTypes.Identifiers.AttributeIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class AttributeIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeIdentifierClassification"/> class.
        /// </summary>
        public AttributeIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Attribute Identifier";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
    [Name(ClassificationTypes.Identifiers.AttributePropertyIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class AttributePropertyIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributePropertyIdentifierClassification"/> class.
        /// </summary>
        public AttributePropertyIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Attribute Property Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ClassIdentifier)]
    [Name(ClassificationTypes.Identifiers.ClassIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ClassIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassIdentifierClassification"/> class.
        /// </summary>
        public ClassIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Class Identifier";
            this.ForegroundColor = Colors.Tomato;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.ConstructorIdentifier)]
    [Name(ClassificationTypes.Identifiers.ConstructorIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ConstructorIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorIdentifierClassification"/> class.
        /// </summary>
        public ConstructorIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Constructor Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.DelegateIdentifier)]
    [Name(ClassificationTypes.Identifiers.DelegateIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DelegateIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassIdentifierClassification"/> class.
        /// </summary>
        public DelegateIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Delegate Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.EnumIdentifier)]
    [Name(ClassificationTypes.Identifiers.EnumIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EnumIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumIdentifierClassification"/> class.
        /// </summary>
        public EnumIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Enum Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.InterfaceIdentifier)]
    [Name(ClassificationTypes.Identifiers.InterfaceIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class InterfaceIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceIdentifierClassification"/> class.
        /// </summary>
        public InterfaceIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Interface Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.MethodIdentifier)]
    [Name(ClassificationTypes.Identifiers.MethodIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class MethodIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodIdentifierClassification"/> class.
        /// </summary>
        public MethodIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Method Identifier"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.NamespaceIdentifier)]
    [Name(ClassificationTypes.Identifiers.NamespaceIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class NamespaceIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceIdentifierClassification"/> class.
        /// </summary>
        public NamespaceIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Namespace Identifier"; 
        }
    }


    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.StructIdentifier)]
    [Name(ClassificationTypes.Identifiers.StructIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class StructIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceIdentifierClassification"/> class.
        /// </summary>
        public StructIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Struct Identifier"; 
        }
    }

    #endregion

    #region Fields Colors
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.Field)]
    [Name(ClassificationTypes.Fields.Field)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class FieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldClassification"/> class.
        /// </summary>
        public FieldClassification()
        {
            this.DisplayName = "SharpLizer: Field"; 
        }
    }
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.BooleanField)]
    [Name(ClassificationTypes.Fields.BooleanField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class BooleanFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanFieldClassification"/> class.
        /// </summary>
        public BooleanFieldClassification()
        {
            this.DisplayName = "SharpLizer: Boolean Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ByteField)]
    [Name(ClassificationTypes.Fields.ByteField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ByteFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ByteFieldClassification"/> class.
        /// </summary>
        public ByteFieldClassification()
        {
            this.DisplayName = "SharpLizer: Byte Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.CharField)]
    [Name(ClassificationTypes.Fields.CharField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class CharFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharFieldClassification"/> class.
        /// </summary>
        public CharFieldClassification()
        {
            this.DisplayName = "SharpLizer: Char Field"; 
         }
    }



    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.ConstantField)]
    [Name(ClassificationTypes.Fields.ConstantField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ConstantFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantFieldClassification"/> class.
        /// </summary>
        public ConstantFieldClassification()
        {
            this.DisplayName = "SharpLizer: Constant Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.DateTimeField)]
    [Name(ClassificationTypes.Fields.DateTimeField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DateTimeFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeFieldClassification"/> class.
        /// </summary>
        public DateTimeFieldClassification()
        {
            this.DisplayName = "SharpLizer: DateTime Field"; 
        }
    }



    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EnumField)]
    [Name(ClassificationTypes.Fields.EnumField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EnumFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumFieldClassification"/> class.
        /// </summary>
        public EnumFieldClassification()
        {
            this.DisplayName = "SharpLizer: Enum Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.EventHandler)]
    [Name(ClassificationTypes.Fields.EventHandler)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EventHandlerClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlerClassification"/> class.
        /// </summary>
        public EventHandlerClassification()
        {
            this.DisplayName = "SharpLizer: Event Handler Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.NumericField)]
    [Name(ClassificationTypes.Fields.NumericField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class NumericFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFieldClassification"/> class.
        /// </summary>
        public NumericFieldClassification()
        {
            this.DisplayName = "SharpLizer: Numeric Field"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Fields.StringField)]
    [Name(ClassificationTypes.Fields.StringField)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class StringFieldClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringFieldClassification"/> class.
        /// </summary>
        public StringFieldClassification()
        {
            this.DisplayName = "SharpLizer: String Field"; 
        }
    }

    #endregion

    #region Properties Colors
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.Property)]
    [Name(ClassificationTypes.Properties.Property)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class PropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyClassification"/> class.
        /// </summary>
        public PropertyClassification()
        {
            this.DisplayName = "SharpLizer: Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.BooleanProperty)]
    [Name(ClassificationTypes.Properties.BooleanProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class BooleanPropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanPropertyClassification"/> class.
        /// </summary>
        public BooleanPropertyClassification()
        {
            this.DisplayName = "SharpLizer: Boolean Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.ByteProperty)]
    [Name(ClassificationTypes.Properties.ByteProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class BytePropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BytePropertyClassification"/> class.
        /// </summary>
        public BytePropertyClassification()
        {
            this.DisplayName = "SharpLizer: Byte Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.CharProperty)]
    [Name(ClassificationTypes.Properties.CharProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class CharPropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharPropertyClassification"/> class.
        /// </summary>
        public CharPropertyClassification()
        {
            this.DisplayName = "SharpLizer: Char Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.DateTimeProperty)]
    [Name(ClassificationTypes.Properties.DateTimeProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DateTimePropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePropertyClassification"/> class.
        /// </summary>
        public DateTimePropertyClassification()
        {
            this.DisplayName = "SharpLizer: DateTime Property"; 
        }
    }


    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.EnumProperty)]
    [Name(ClassificationTypes.Properties.EnumProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EnumPropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumPropertyClassification"/> class.
        /// </summary>
        public EnumPropertyClassification()
        {
            this.DisplayName = "SharpLizer: Enum Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.NumericProperty)]
    [Name(ClassificationTypes.Properties.NumericProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class NumericPropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericPropertyClassification"/> class.
        /// </summary>
        public NumericPropertyClassification()
        {
            this.DisplayName = "SharpLizer: Numeric Property"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Properties.StringProperty)]
    [Name(ClassificationTypes.Properties.StringProperty)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class StringPropertyClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringPropertyClassification"/> class.
        /// </summary>
        public StringPropertyClassification()
        {
            this.DisplayName = "SharpLizer: String Property"; 
        }
    }
    #endregion

    #region Variables Colors
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.LocalVariable)]
    [Name(ClassificationTypes.Variables.LocalVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class LocalVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalVariableClassification"/> class.
        /// </summary>
        public LocalVariableClassification()
        {
            this.DisplayName = "SharpLizer: Local Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.BooleanVariable)]
    [Name(ClassificationTypes.Variables.BooleanVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class BooleanVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanVariableClassification"/> class.
        /// </summary>
        public BooleanVariableClassification()
        {
            this.DisplayName = "SharpLizer: Boolean Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.ByteVariable)]
    [Name(ClassificationTypes.Variables.ByteVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class ByteVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ByteVariableClassification"/> class.
        /// </summary>
        public ByteVariableClassification()
        {
            this.DisplayName = "SharpLizer: Byte Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.CharVariable)]
    [Name(ClassificationTypes.Variables.CharVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class CharVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharVariableClassification"/> class.
        /// </summary>
        public CharVariableClassification()
        {
            this.DisplayName = "SharpLizer: Char Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.DateTimeVariable)]
    [Name(ClassificationTypes.Variables.DateTimeVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DateTimeVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeVariableClassification"/> class.
        /// </summary>
        public DateTimeVariableClassification()
        {
            this.DisplayName = "SharpLizer: DateTime Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.EnumVariable)]
    [Name(ClassificationTypes.Variables.EnumVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class EnumVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumVariableClassification"/> class.
        /// </summary>
        public EnumVariableClassification()
        {
            this.DisplayName = "SharpLizer: Enum Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.NumericVariable)]
    [Name(ClassificationTypes.Variables.NumericVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class NumericVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericVariableClassification"/> class.
        /// </summary>
        public NumericVariableClassification()
        {
            this.DisplayName = "SharpLizer: Numeric Variable"; 
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Variables.StringVariable)]
    [Name(ClassificationTypes.Variables.StringVariable)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class StringVariableClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringVariableClassification"/> class.
        /// </summary>
        public StringVariableClassification()
        {
            this.DisplayName = "SharpLizer: String Variable"; 
        }
    }
    #endregion
}