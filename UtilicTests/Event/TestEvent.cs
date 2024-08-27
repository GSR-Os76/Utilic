using GSR.Utilic.Event;
using GSR.Utilic.Generic;

namespace UtilicTests.Event
{
    [TestClass]
    public class TestEvent
    {
        [TestMethod]
        [DataRow("nuhi_")]
        public void TestAdd(string expectation)
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;

            Assert.AreEqual(1, handlers.Count);
            handlers.ForEach((x) => x.Invoke(expectation));
        } // end TestAdd()

        [TestMethod]
        [DataRow("nuhi_")]
        public void TestAddI(string expectation)
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;

            Assert.AreEqual(1, handlers.Count);
            handlers.ForEach((x) => x.Invoke(expectation));
        } // end TestAddI()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("nuhi_")]
        public void TestAddDuplicate(string expectation)
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;
            _ = (e) + a;
        } // end TestAddDuplicate()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("nuhi_")]
        public void TestAddDuplicateI(string expectation)
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;
            _ = (e) + a;
        } // end TestAddDuplicateI()



        [TestMethod]
        [DataRow("nuhi_")]
        public void TestRemove(string expectation)
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;
            _ = (e) - a;

            Assert.AreEqual(0, handlers.Count);
        } // end TestRemove()

        [TestMethod]
        [DataRow("nuhi_")]
        public void TestRemoveI(string expectation)
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) + a;
            _ = (e) - a;

            Assert.AreEqual(0, handlers.Count);
        } // end TestRemoveI()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("nuhi_")]
        public void TestRemoveUnadded(string expectation)
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) - a;
        } // end TestRemoveUnadded()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("nuhi_")]
        public void TestRemoveUnaddedI(string expectation)
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, expectation);
            _ = (e) - a;
        } // end TestRemoveUnaddedI()

    } // end class
} // end namespace