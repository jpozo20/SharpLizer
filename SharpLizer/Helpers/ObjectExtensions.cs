﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer.Helpers
{
    public static class ObjectExtensions
    {
        public static T JsonClone<T>(this T source)
        {
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(source);
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serializedObject);
            return deserializedObject;
        }
    }
}
