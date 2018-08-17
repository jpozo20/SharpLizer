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
            this.DisplayName = "SharpLizer: Abstraction Keywords"; // Human readable version of the name
            this.BackgroundColor = Colors.Blue;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Abstract Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.Red;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Async Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.Navy;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: New Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.NavajoWhite;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Override Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.CornflowerBlue;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Sealed Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.DarkBlue;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Virtual Keyword"; // Human readable version of the name
            this.BackgroundColor = Colors.DarkGray;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Declaration Keywords"; // Human readable version of the name
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Class Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.Red;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Delegate Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.YellowGreen;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Enum Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.Tomato;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Interface Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.Violet;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Namespace Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.PaleGreen;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Struct Keyword"; // Human readable version of the name
            this.ForegroundColor = Colors.MediumVioletRed;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Encapsulation Keywords"; // Human readable version of the name
            this.ForegroundColor = Colors.Aqua;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    #endregion

    #region Identifier Colors
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
            this.DisplayName = "SharpLizer: Attribute Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Violet;
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
            this.DisplayName = "SharpLizer: Attribute Property Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Azure;
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
            this.DisplayName = "SharpLizer: Class Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Bisque;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Constructor Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Delegate Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Chocolate;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Enum Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Coral;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.Identifiers.FieldIdentifier)]
    [Name(ClassificationTypes.Identifiers.FieldIdentifier)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class FieldIdentifierClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldIdentifierClassification"/> class.
        /// </summary>
        public FieldIdentifierClassification()
        {
            this.DisplayName = "SharpLizer: Field Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Cornsilk;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Interface Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.Cyan;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Method Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.DarkGoldenrod;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Namespace Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.DarkSalmon;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
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
            this.DisplayName = "SharpLizer: Struct Identifier"; // Human readable version of the name
            this.ForegroundColor = Colors.DarkTurquoise;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    #endregion

    #region Field Colors

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
            this.DisplayName = "SharpLizer: Boolean Field"; // Human readable version of the name
            this.ForegroundColor = Colors.FloralWhite;
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
            this.DisplayName = "SharpLizer: Byte Field"; // Human readable version of the name
            this.ForegroundColor = Colors.MediumAquamarine;
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
            this.DisplayName = "SharpLizer: Char Field"; // Human readable version of the name
            this.ForegroundColor = Colors.Fuchsia;
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
            this.DisplayName = "SharpLizer: Constant Field"; // Human readable version of the name
            this.ForegroundColor = Colors.ForestGreen;
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
            this.DisplayName = "SharpLizer: DateTime Field"; // Human readable version of the name
            this.ForegroundColor = Colors.BlueViolet;
        }
    }

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
            this.DisplayName = "SharpLizer: Field"; // Human readable version of the name
            this.ForegroundColor = Colors.DarkSlateBlue;
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
            this.DisplayName = "SharpLizer: Numeric Field"; // Human readable version of the name
            this.ForegroundColor = Colors.BlanchedAlmond;
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
            this.DisplayName = "SharpLizer: String Field"; // Human readable version of the name
            this.ForegroundColor = Colors.Red;
        }
    }

    #endregion
}
