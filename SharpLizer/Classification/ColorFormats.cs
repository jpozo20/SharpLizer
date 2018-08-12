using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SharpLizer.Classification
{
    /// <summary>
    /// Defines an editor format for the EditorClassifier type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.FieldType)]
    [Name(ClassificationTypes.FieldType)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class FieldTypeClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldTypeClassification"/> class.
        /// </summary>
        public FieldTypeClassification()
        {
            this.DisplayName = "SharpLizer: Field Type"; // Human readable version of the name
            this.BackgroundColor = Colors.Red;
            this.ForegroundColor = Colors.Black;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.MethodType)]
    [Name(ClassificationTypes.MethodType)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class MethodTypeClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodTypeClassification"/> class.
        /// </summary>
        public MethodTypeClassification()
        {
            this.DisplayName = "SharpLizer: Method Type"; // Human readable version of the name
            this.BackgroundColor = Colors.Red;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    #region Abstraction Keywords Colors

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [Name(ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [UserVisible(true)] // This should be visible to the end user
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
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class DeclarationKeywordsClassification : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeclarationKeywordsClassification"/> class.
        /// </summary>
        public DeclarationKeywordsClassification()
        {
            this.DisplayName = "SharpLizer: Class Keyword"; // Human readable version of the name
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

    #endregion
}
