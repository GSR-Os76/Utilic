using GSR.Utilic.Event;
using GSR.Utilic.Generic;

namespace GSR.Tests.Utilic.Event
{
    [TestClass]
    public class TestFixedKeysKeyedEvent
    {
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestInvalidKey()
        {
            new FixedKeysKeyedEvent<string, Action>(Array.Empty<string>(), out _)["n"] += () => Assert.IsTrue(true);
        } // end TestNewKey()

        [TestMethod]
        public void TestValidKey()
        {
            int i = 0;
            FixedKeysKeyedEvent<string, Action> e = new FixedKeysKeyedEvent<string, Action>(new string[] { "" }, out IDictionary<string, IList<Action>> invokes);
            e[""] += () => i++;
            e[""] += () => i++;
            invokes[""].ForEach((x) => x.Invoke());

            Assert.AreEqual(2, i);
        } // end TestExistingKey()

    } // end class
} // end namespace