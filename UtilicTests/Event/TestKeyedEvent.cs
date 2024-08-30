using GSR.Utilic.Event;
using GSR.Utilic.Generic;

namespace GSR.Tests.Utilic.Event
{
    [TestClass]
    public class TestKeyedEvent
    {
        [TestMethod]
        public void TestNewKey()
        {
            new KeyedEvent<string, Action>(out _)["n"] += () => Assert.IsTrue(true);
        } // end TestNewKey()

        [TestMethod]
        public void TestExistingKey()
        {
            int i = 0;
            KeyedEvent<string, Action> e = new KeyedEvent<string, Action>(out IDictionary<string, IList<Action>> invokes);
            e["n"] += () => i++;
            e["n"] += () => i++;
            invokes["n"].ForEach((x) => x.Invoke());

            Assert.AreEqual(2, i);
        } // end TestExistingKey()

    } // end class
} // end namespace