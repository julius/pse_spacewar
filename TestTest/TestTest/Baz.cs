using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTest
{
    class Baz : Bar
    {
        private string text;

        public Baz(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }

        public void DoBar()
        {
        }
    }
}
