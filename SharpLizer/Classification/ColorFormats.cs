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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [Name(ClassificationTypes.AbstractionTypes.AbstractionKeywords)]
    [UserVisible(true)] // This should be visible to the end user
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
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
}
