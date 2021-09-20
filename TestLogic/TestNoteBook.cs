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
    }
}
