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

#pragma warning restore 169
    }
}
