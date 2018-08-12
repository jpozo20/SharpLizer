using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer.Classification
{
    internal static class ClassificationTypes
    {
        public static class AbstractionTypes
        {
            public const string AbstractionKeywords = "SharpLizer.AbstractionKeywords";
            public const string AbstractKeyword = "SharpLizer.AbstractKeyword";
            public const string AsyncKeyword = "SharpLizer.AsyncKeyword";
            public const string NewKeyword = "SharpLizer.NewKeyword";
            public const string OverrideKeyword = "SharpLizer.OverrideKeyword";
            public const string SealedKeyword = "SharpLizer.SealedKeyword";
            public const string VirtualKeyword = "SharpLizer.VirtualKeyword";
        }

        public static class DeclarationTypes
        {
            public const string DeclarationKeywords = "SharpLizer.DeclarationKeywords";
            public const string ClassKeyword = "SharpLizer.ClassKeyword";
            public const string DelegateKeyword = "SharpLizer.DelegateKeyword";
            public const string EnumKeyword = "SharpLizer.EnumKeyword";
            public const string InterfaceKeyword = "SharpLizer.InterfaceKeyword";
            public const string NamespaceKeyword = "SharpLizer.NamespaceKeyword";
            public const string StructKeyword = "SharpLizer.StructKeyword";
        }

        public const string FieldType = "SharpLizer.FieldType";
        public const string MethodType = "SharpLizer.MethodType";
        public const string ConstantFieldType = "SharpLizer.ConstantFieldType";

    }
}
