using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTest
{
    class Foo
    {
        public Bar bar;
        public Boing boing;

        public Foo(Bar bar, Boing boing)
        {
            this.bar = bar;
            this.boing = boing;
        }

        public void DoFoo()
        {
            bar.DoBar();
            boing.DoBoing(10);
        }

        public string GetFoo()
        {
            return bar.GetText() + boing.GetNumber().ToString();
                    }
    }
}
