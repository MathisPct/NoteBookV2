using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestAvgScore
    {
        [Fact]
        public void ElementName()
        {
            PedagocicalElement e = new Module();
            e.Name = "Test";

            AvgScore avg = new AvgScore(15.3f, e);
            Assert.Equal("Test", avg.ElementName);
        }

        [Fact]
        public void Average()
        {
            AvgScore avg = new AvgScore(13.3f, new PedagocicalElement());
            Assert.Equal(13.3f, avg.Average);
        }

        [Fact]
        public void TestString()
        {
            PedagocicalElement e = new PedagocicalElement();
            e.Name = "Maths";
            AvgScore avg = new AvgScore(10f, e);
            Assert.Equal("Name: Maths, Average: 10", avg.ToString());
        }
    }
}
