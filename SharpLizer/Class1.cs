using SharpLizer.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer
{
    class Class1
    {
        private int uno = 0;

        private string dos = "dos";
        private DateTime date = DateTime.Now;
        private ColorSettings _colorSettings;
        private char charito = 'a';
        private byte bytecito = 0;
        private bool bebe = false;
        public int Pepito { get; set; }
        public Class1()
        {
            uno = 2;
            dos = "";
            var pepe = 2;
            Pepito = MyInteger;
        }

        public string MyString { get; set; }
        public int MyInteger { get; set; }
        public DateTime MyDate { get; set; }
        public bool MyBool { get; set; }

        public byte MyByte { get; set; }
        public char MyChar { get; set; }
    }

    struct Strucito
    {
        int a;
        int b;
    }

    enum Enum2
    {

    }

    interface interfacita
    {

    }
}
