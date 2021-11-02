using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestPedagogicalElement
    {
        [Fact]
        public void TestCoefSet()
        {
            PedagocicalElement pE = new PedagocicalElement();
            /// cas par défaut coef = 0
            Assert.Equal(0f, pE.Coef, 2);

            /// Cas où le coef = 0
            Assert.Throws<Exception>(() => { pE.Coef = 0.0f; });

            /// cas où le coef < 0
            Assert.Throws<Exception>(() => { pE.Coef = -5f;  });

            ///cas où le coef > 0 
            pE.Coef = 5f;
            Assert.Equal(5f,pE.Coef,2);
        }

        [Fact]
        public void TestNameSet()
        {
            PedagocicalElement pE = new PedagocicalElement();
            /// cas par défaut nom est vide
            Assert.Empty(pE.Name);

            /// Cas où le nom est vide
            Assert.Throws<Exception>(() => { pE.Name = ""; });

            /// Cas où le nom est null 
            Assert.Throws<Exception>(() => { pE.Name = null; });

            ///cas où le nom change
            pE.Name = "test";
            Assert.Equal("test", pE.Name);
        }

        [Fact]
        public void TestToString()
        {
            PedagocicalElement e = new PedagocicalElement();
            e.Name = "Math";
            e.Coef = 5f;
            Assert.Equal("Name: Math\nCoef: 5", e.ToString());
        }

        [Fact]
        public void TestEquals()
        {
            PedagocicalElement e1 = new PedagocicalElement();
            e1.Name = "Français";
            e1.Coef = 3;
            PedagocicalElement e2 = new PedagocicalElement();
            e2.Name = "Français";
            e2.Coef = 3;
            Assert.True(e1.Equals(e2));
        }
    }
}
