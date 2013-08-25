using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CzechLearning.Tests.Models
{
    [TestFixture]
    public class RandomWordProviderTests
    {
        IRandomWordProvider wordProvider;

        [SetUp]
        public void SetUp()
        {
            wordProvider = new WordnikRandomWordProvider();
        }


        [Test]
        public void TestGetRandomWord ()
        {
            var word = wordProvider.GetNext();

            Assert.IsNotNull(word);
        }
    }
}
