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
        /// Initializes a new instance of the <see cref="FieldTypeClassification"/> class.
        /// </summary>
        public MethodTypeClassification()
        {
            this.DisplayName = "SharpLizer: Method Type"; // Human readable version of the name
            this.BackgroundColor = Colors.Red;
            this.ForegroundColor = Colors.Yellow;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }
}
