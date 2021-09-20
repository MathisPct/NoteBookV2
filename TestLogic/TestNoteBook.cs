using System;
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
    }
}
