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
            /// Cas où le coef = 0
            Assert.Throws<Exception>(() => { pE.Coef = 0.0f; });

            /// cas où le coef < 0
            Assert.Throws<Exception>(() => { pE.Coef = -5f;  });

            ///cas où le coef > 0 
            pE.Coef = 5f;
            Assert.True(pE.Coef > 0);
        }

        [Fact]
        public void TestNameSet()
        {
            PedagocicalElement pE = new PedagocicalElement();
            /// Cas où le nom est vide
            Assert.Throws<Exception>(() => { pE.Name.Equals(""); });

            /// Cas où le nom est null 
            Assert.Throws<Exception>(() => { pE.Name = null; });
        }
    }
}
