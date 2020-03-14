using NUnit.Framework;
using System.Collections.Generic;

namespace Jumper.Core.Tests
{
    public class Tests
    {
        private Calculator Calculator { get; set; }
        [SetUp]
        public void Setup()
        {
            this.Calculator = new Calculator();
        }

        [Test]
        [TestCaseSource("CanBeCompletedTestData")]
        public void CanBeCompteted(List<int> data, bool expected)
        {
            var actual = this.Calculator.HasPathToFirstElement(data);
            Assert.AreEqual(actual, expected);
        }

        public static IEnumerable<TestCaseData> CanBeCompletedTestData()
        {
            yield return new TestCaseData(new List<int> { 0 }, true);
            yield return new TestCaseData(new List<int> { 1, 0 }, true);
            yield return new TestCaseData(new List<int> { 2, 0 }, true);
            yield return new TestCaseData(new List<int> { 1, 1, 0 }, true);
            yield return new TestCaseData(new List<int> { 2, 0, 0 }, true);
            yield return new TestCaseData(new List<int> { 2, 1, 0 }, true);
            yield return new TestCaseData(new List<int> { 3, 0, 0 }, true);
            yield return new TestCaseData(new List<int> { 1, -1, 0 }, false);
            yield return new TestCaseData(new List<int> { 2, -1, 0 }, true);
            yield return new TestCaseData(new List<int> { 2, 0, 0, 0 }, false);
            yield return new TestCaseData(new List<int> { 2, 1, 0, 0 }, false);
            yield return new TestCaseData(new List<int> { 1, 2, 0, 0 }, true);
            yield return new TestCaseData(new List<int> { 1, 2, 0, 3, 0, 2, 0 }, true);
            yield return new TestCaseData(new List<int> { 1, 2, 0, 1, 0, 2, 0 }, false);
            yield return new TestCaseData(new List<int> { 1, 2, 0, -1, 0, 2, 0 }, false);
            yield return new TestCaseData(new List<int> { 1, 2, 1, -1, 0, 2, 0 }, false);

        }

        [Test]
        [TestCaseSource("GetLongestPathTestData")]
        public void GetLongestPath(List<int> data, Dictionary<int, int> expected)
        {
            var actual = this.Calculator.GetLongestPath(data);
            Assert.AreEqual(actual, expected);
        }

        public static IEnumerable<TestCaseData> GetLongestPathTestData()
        {
            yield return new TestCaseData(new List<int> { 0 }, new Dictionary<int, int> { { 0, 0 } });
            yield return new TestCaseData(new List<int> { 1, 0 }, new Dictionary<int, int> { { 1, 0 }, { 0, 1 } });
            yield return new TestCaseData(new List<int> { 2, 0 }, new Dictionary<int, int> { { 1, 0 }, { 0, 1 } });
            yield return new TestCaseData(new List<int> { 2, 1, 0 }, new Dictionary<int, int> { { 2, 0 }, { 1, 1 }, { 0, 1 } });
            yield return new TestCaseData(new List<int> { 2, 0, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } });
            yield return new TestCaseData(new List<int> { 3, 0, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } });
            yield return new TestCaseData(new List<int> { 1, -1, 0 }, null);
            yield return new TestCaseData(new List<int> { 2, -1, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } });
            yield return new TestCaseData(new List<int> { 2, 0, 0, 0 }, null);
            yield return new TestCaseData(new List<int> { 2, 1, 0, 0 }, null);
            yield return new TestCaseData(new List<int> { 1, 2, 0, 0 }, new Dictionary<int, int> { { 3, 0 }, { 1, 2 }, { 0, 1 } });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 3, 0, 2, 0 }, new Dictionary<int, int> { { 6, 0 }, { 5, 1 }, { 3, 2 }, { 1, 2 }, { 0, 1 } });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 1, 2, 0, -1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 1, 2, 1, -1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 6, 1, 1, 1, 1, 1, 6 }, new Dictionary<int, int> { { 6, 6 }, { 5, 1 }, { 4, 1 }, { 3, 1 }, { 2, 1 }, { 1, 1 }, { 0, 1 } });

        }

        [Test]
        [TestCaseSource("GetShortestPathTestData")]
        public void GetShortestPath(List<int> data, Dictionary<int, int> longestPath, List<int> expected)
        {
            var actual = this.Calculator.GetShortestPath(data, longestPath);
            Assert.AreEqual(actual, expected);
        }

        public static IEnumerable<TestCaseData> GetShortestPathTestData()
        {
            yield return new TestCaseData(new List<int> { 0 }, new Dictionary<int, int> { { 0, 0 } }, new List<int> { 0 });
            yield return new TestCaseData(new List<int> { 1, 0 }, new Dictionary<int, int> { { 1, 0 }, { 0, 1 } }, new List<int> { 0, 1 });
            yield return new TestCaseData(new List<int> { 2, 0 }, new Dictionary<int, int> { { 1, 0 }, { 0, 1 } }, new List<int> { 0, 1 });
            yield return new TestCaseData(new List<int> { 2, 1, 0 }, new Dictionary<int, int> { { 2, 0 }, { 1, 1 }, { 0, 1 } }, new List<int> { 0, 2 });
            yield return new TestCaseData(new List<int> { 2, 0, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } }, new List<int> { 0, 2 });
            yield return new TestCaseData(new List<int> { 3, 0, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } }, new List<int> { 0, 2 });
            yield return new TestCaseData(new List<int> { 2, -1, 0 }, new Dictionary<int, int> { { 2, 0 }, { 0, 2 } }, new List<int> { 0, 2 });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 0 }, new Dictionary<int, int> { { 3, 0 }, { 1, 2 }, { 0, 1 } }, new List<int> { 0, 1, 3 });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 3, 0, 2, 0 }, new Dictionary<int, int> { { 6, 0 }, { 5, 1 }, { 3, 2 }, { 1, 2 }, { 0, 1 } }, new List<int> { 0, 1, 3, 6 });
            yield return new TestCaseData(new List<int> { 6, 1, 1, 1, 1, 1, 6 }, new Dictionary<int, int> { { 6, 6 }, { 5, 1 }, { 4, 1 }, { 3, 1 }, { 2, 1 }, { 1, 1 }, { 0, 1 } }, new List<int> { 0, 6 });
            yield return new TestCaseData(new List<int> { 3, 1, 1, 2, 1, 1, 6 }, new Dictionary<int, int> { { 6, 6 }, { 5, 1 }, { 4, 1 }, { 3, 1 }, { 2, 1 }, { 1, 1 }, { 0, 1 } }, new List<int> { 0, 3, 5, 6 });

        }

        [Test]
        [TestCaseSource("GetShortestPathChainTestData")]
        public void GetShortestPathChain(List<int> data, List<int> expected)
        {
            var actual = this.Calculator.GetShortestPath(data);
            Assert.AreEqual(actual, expected);
        }
        public static IEnumerable<TestCaseData> GetShortestPathChainTestData()
        {
            yield return new TestCaseData(new List<int> { 0 }, new List<int> { 0 });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 1, 2, 0, -1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 1, 2, 1, -1, 0, 2, 0 }, null);
            yield return new TestCaseData(new List<int> { 6, 1, 1, 1, 1, 1, 6 }, new List<int> { 0, 6 });
            yield return new TestCaseData(new List<int> { 3, 1, 1, 2, 1, 1, 6 }, new List<int> { 0, 3, 5, 6 });

        }
    }
}