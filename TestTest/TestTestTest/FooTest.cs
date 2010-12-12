using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTest;
using Moq;

namespace TestTestTest
{
    [TestClass]
    public class FooTest
    {

        /// <summary>
        ///A test for DoFoo
        ///</summary>
        [TestMethod()]
        public void DoFooTest()
        {
            var barMock = new Mock<Bar>();
            barMock.Setup(bar => bar.DoBar());

            var boingMock = new Mock<IBoing>();
            boingMock.Setup(boing => boing.DoBoing(10));

            Foo target = new Foo(barMock.Object, boingMock.Object); // TODO: Initialize to an appropriate value
            target.DoFoo();

            barMock.Verify(foo => foo.DoBar(), Times.Exactly(1));
            boingMock.Verify(foo => foo.DoBoing(10), Times.Exactly(1));
        }

        /// <summary>
        ///A test for GetFoo
        ///</summary>
        [TestMethod()]
        public void GetFooTest()
        {
            var mock = new Mock<IBoing>();
            mock.Setup(boing => boing.GetNumber()).Returns(10);

            Foo target = new Foo(new Baz("blabla"), mock.Object); // TODO: Initialize to an appropriate value
            string expected = "blabla10"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFoo();
            Assert.AreEqual(expected, actual);
        }
    }
}
