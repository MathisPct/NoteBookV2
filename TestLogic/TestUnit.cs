using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void TestConstructor()
        {
            Unit u1 = new Unit();
        }

        [Fact]
        public void TestListModules()
        {
            Unit u1 = new Unit();
            //Liste des modules pas nulle
            Assert.NotEmpty(u1.ListModules());
        }
    }
}
