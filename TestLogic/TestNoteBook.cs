using System;
using System.Collections.Generic;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestNoteBook
    {
        [Fact]
        public void TestListUnits()
        {
            //Instantiation 
            NoteBook nB = new NoteBook();

            Assert.NotNull(nB.ListUnits());
            Assert.Empty(nB.ListUnits());
        }

        [Fact]
        public void AddUnit()
        {
            //test of add element
            NoteBook nb = new NoteBook();
            Unit u = new Unit();
            u.Coef = 2;
            u.Name = "Méthodes";
            nb.AddUnit(u);
            Assert.True(nb.ListUnits()[0] == u);

            //test of add an element which already exists in list of units
            Assert.Throws<Exception>(() => { nb.AddUnit(u); });
            Unit u2 = new Unit();
            u2.Name = "test";
            u2.Coef = 3;
            Unit u3 = new Unit();
            u3.Coef = 2;
            u3.Name = "test";
            nb.AddUnit(u2);
            Assert.Throws<Exception>(() => { nb.AddUnit(u3); });
        }

        [Fact]
        public void RemoveUnit()
        {
            NoteBook nb = new NoteBook();
            Unit u = new Unit();
            nb.AddUnit(u);
            nb.RemoveUnit(u);
            Assert.Empty(nb.ListUnits());
        }

        [Fact]
        public void ListModules()
        {
            NoteBook nb = new NoteBook();
            //create two different units 
            Unit u1 = new Unit();
            u1.Name = "u1";
            Unit u2 = new Unit();
            u2.Name = "u2";
            nb.AddUnit(u1);
            nb.AddUnit(u2);
            //add modules in each of units
            Module m1 = new Module();
            Module m2 = new Module();
            u1.Add(m1);
            u2.Add(m2);
            //list of modules which is except
            List<Module> modulesExcept = new List<Module>();
            modulesExcept.Add(m1);
            modulesExcept.Add(m2);
            
            Assert.NotNull(nb.ListModules());
            Assert.Equal(modulesExcept.ToArray(), nb.ListModules());
        }
    }
}
