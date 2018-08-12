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
            public const string AbstractionKeywords = "SharpLizer.AbstractionKeyword";
            public const string AbstractKeyword = "SharpLizer.AbstractKeyword";
            public const string AsyncKeyword = "SharpLizer.AsyncKeyword";
            public const string NewKeyword = "SharpLizer.NewKeyword";
            public const string OverrideKeyword = "SharpLizer.OverrideKeyword";
            public const string SealedKeyword = "SharpLizer.SealedKeyword";
            public const string VirtualKeyword = "SharpLizer.VirtualKeyword";
        }

        public const string FieldType = "SharpLizer.FieldType";
        public const string MethodType = "SharpLizer.MethodType";
        public const string ConstantFieldType = "SharpLizer.ConstantFieldType";

    }
}
