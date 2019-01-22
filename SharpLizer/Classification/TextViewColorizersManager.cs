using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer.Classification
{
    [Export]
    internal class TextViewColorizersManager
    {
        ICollection<TextViewColorizer> Colorizers { get; set; }

        public TextViewColorizersManager()
        {
            Colorizers = new List<TextViewColorizer>();
        }

        internal void AddColorizer(TextViewColorizer colorizer)
        {
            
            Colorizers.Add(colorizer);
        }

        internal IEnumerable<TextViewColorizer> GetColorizers()
        {
            return Colorizers;
        }
    }
}
