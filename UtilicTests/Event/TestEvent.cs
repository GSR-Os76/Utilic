using GSR.Utilic.Event;
using GSR.Utilic.Generic;

namespace GSR.Tests.Utilic.Event
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
        public void TestAddDuplicate()
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            _ = (e) + a;
            _ = (e) + a;
        } // end TestAddDuplicate()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddDuplicateI()
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            _ = (e) + a;
            _ = (e) + a;
        } // end TestAddDuplicateI()



        [TestMethod]
        public void TestRemove()
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            _ = (e) + a;
            _ = (e) - a;

            Assert.AreEqual(0, handlers.Count);
        } // end TestRemove()

        [TestMethod]
        public void TestRemoveI()
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            e += a;
            e -= a;

            Assert.AreEqual(0, handlers.Count);
        } // end TestRemoveI()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveUnadded()
        {
            Event<Action<string>> e = new(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            e -= a;
        } // end TestRemoveUnadded()

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveUnaddedI()
        {
            IEvent<Action<string>> e = new Event<Action<string>>(out IList<Action<string>> handlers);
            Action<string> a = (s) => Assert.AreEqual(s, s);
            e -= a;
        } // end TestRemoveUnaddedI()

    } // end class
} // end namespace