using Jumper.Api.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Jumper.Api.Tests
{
    public class JumperControllerTests
    {
        public JumperController JumperController { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.JumperController = new JumperController(null, new Core.Calculator());
        }


        [Test]
        [TestCaseSource("TestPostData")]
        public void TestPost(List<int> data, List<List<int>> expected)
        {

            var actual = JumperController.Post(new List<List<int>> { data });
            Assert.AreEqual(actual, expected);
        }

        public static IEnumerable<TestCaseData> TestPostData()
        {
            yield return new TestCaseData(new List<int> { 0 }, new List<List<int>> { new List<int> { 0 } });
            yield return new TestCaseData(new List<int> { 1, 2, 0, 1, 0, 2, 0 }, new List<List<int>> { null });
            yield return new TestCaseData(new List<int> { 1, 2, 0, -1, 0, 2, 0 }, new List<List<int>> { null });
            yield return new TestCaseData(new List<int> { 1, 2, 1, -1, 0, 2, 0 }, new List<List<int>> { null });
            yield return new TestCaseData(new List<int> { 6, 1, 1, 1, 1, 1, 6 }, new List<List<int>> { new List<int> { 0, 6 } });
            yield return new TestCaseData(new List<int> { 3, 1, 1, 2, 1, 1, 6 }, new List<List<int>> { new List<int> { 0, 3, 5, 6 } });

        }

        [Test]
        [TestCaseSource("TestPostBatchData")]
        public void TestPostBatch(List<List<int>> data, List<List<int>> expected)
        {

            var actual = JumperController.Post(data);
            Assert.AreEqual(actual, expected);
        }

        public static IEnumerable<TestCaseData> TestPostBatchData()
        {
            yield return new TestCaseData(
                new List<List<int>> { new List<int> { 0 }, new List<int> { 1, 2, 0, 1, 0, 2, 0 }, new List<int> { 3, 1, 1, 2, 1, 1, 6 } },
                new List<List<int>> { new List<int> { 0 }, null, new List<int> { 0, 3, 5, 6 } });
            yield return new TestCaseData(
                new List<List<int>> { new List<int> { 1, 2, 0, -1, 0, 2, 0 }, new List<int> { 1, 2, 1, -1, 0, 2, 0 }, new List<int> { 6, 1, 1, 1, 1, 1, 6 } }, 
                new List<List<int>> { null, null, new List<int> { 0, 6 } });
        }
    }
}