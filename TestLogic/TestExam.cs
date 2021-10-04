using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestExam
    {
        [Fact]
        public void TestCoef()
        {
            Exam exam = new Exam();
            //cas où le coef = 0
            Assert.Throws<Exception>(() => {exam.Coef = 0; });

            //cas où le coef < 0
            Assert.Throws<Exception>(() => { exam.Coef = -5f; });

            //cas où le coef > 0
            exam.Coef = 5f;
            Assert.True(exam.Coef > 0);
        }

        [Fact]
        public void TestScore()
        {
            Exam exam = new Exam();

            //Cas où la note est < 0
            Assert.Throws<Exception>(() => { exam.Score = -5; });

            //Cas où la note est > 20
            Assert.Throws<Exception>(() => { exam.Score = 21; });

            //Cas où la note = 20, =0 0<=note<=20
            exam.Coef = 5;
            Assert.True(exam.Coef <= 20 && exam.Coef >= 0);
        }

        [Fact]
        public void TestConstructor()
        {
            Exam exam = new Exam();

            //test date qui doit être égale à la date du jour par défaut
            Assert.Equal(DateTime.Now.Date, exam.DateExam.Date);

            //valeur du coef par défaut à 1
            Assert.Equal(1f, exam.Coef);

            //élève absent par défaut
            Assert.Equal(true, exam.IsAbsent);

            //note à 0 par défaut
            Assert.Equal(0f, exam.Score);

            //module non nul
            Assert.NotNull(exam.Module);
        }
    }
}
