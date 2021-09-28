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
            Assert.NotNull(u1.ListModules());
            Assert.Empty(u1.ListModules());
        }

        [Fact]
        public void TestAddModules()
        {
            Unit u1 = new Unit();
            Module m1 = new Module();
            Module m2 = new Module();
            u1.Add(m1);
            u1.Add(m2);
            Assert.Equal(2 ,u1.ListModules().Length);
            Assert.Same(u1.ListModules()[0], m1);
        }

        [Fact]
        public void TestRemoveModule()
        {
            Unit u = new Unit();
            Module m1 = new Module();
            u.Add(m1);
            //list must be not empty
            Assert.NotEmpty(u.ListModules());
            u.Remove(m1);
            //list must be empty after removing
            Assert.Empty(u.ListModules());
        }
    }
}
