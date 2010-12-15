using TestTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace TestTestTest
{
    
    
    /// <summary>
    ///This is a test class for FooTest and is intended
    ///to contain all FooTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FooTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DoFoo
        ///</summary>
        [TestMethod()]
        public void DoFooTest()
        {
            var barMock = new Mock<Bar>();
            barMock.Setup(b => b.DoBar());

            var boingMock = new Mock<Boing>();
            boingMock.Setup(b => b.DoBoing(10));

            Foo target = new Foo(barMock.Object, boingMock.Object); // TODO: Initialize to an appropriate value
            target.DoFoo();

            barMock.Verify(b => b.DoBar(), Times.Exactly(1));
            boingMock.Verify(b => b.DoBoing(10), Times.Exactly(1));
        }

        /// <summary>
        ///A test for GetFoo
        ///</summary>
        [TestMethod()]
        public void GetFooTest()
        {
            var boingMock = new Mock<Boing>();
            boingMock.Setup(b => b.GetNumber()).Returns(10);

            Foo target = new Foo(new Baz("blabla"), boingMock.Object); // TODO: Initialize to an appropriate value
            string expected = "blabla10"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetFoo();
            Assert.AreEqual(expected, actual);
        }
    }
}
