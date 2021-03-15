using NUnit.Framework;

namespace logica.tests
{
    public class Tests
    {
        private Numero _numero;
        [SetUp]
        public void Setup()
        {
            _numero = new Numero();
        }

        [Test]
        public void Test1()
        {
            var result = _numero.Teste();
            Assert.AreEqual(1, result);
        }
    }
}