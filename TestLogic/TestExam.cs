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

            //cas où le coef change sans exception
            exam.Coef = 5f;
            Assert.Equal(5f, exam.Coef);
        }

        [Fact]
        public void TestScore()
        {
            Exam exam = new Exam();
            //cas par défaut la note est à 0
            Assert.Equal(0, exam.Score);

            //Cas où la note est < 0
            Assert.Throws<Exception>(() => { exam.Score = -5; });

            //Cas où la note est > 20
            Assert.Throws<Exception>(() => { exam.Score = 21; });

            //Cas où la note change sans exception
            exam.Score = 5;
            Assert.Equal(5, exam.Score);
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

        [Fact]
        public void TestEquals()
        {
            Module maths = new Module();
            maths.Coef = 5;
            maths.Name = "Maths";
            Exam e1 = new Exam();
            e1.Module = maths;
            e1.Coef = 3;
            e1.IsAbsent = false;
            e1.Teacher = "Machin";
            e1.Score = 20;
            e1.DateExam = new DateTime(2021, 10, 28, 10, 20, 49);
            Exam e2 = new Exam();
            e2.Module = maths;
            e2.Coef = 3;
            e2.IsAbsent = false;
            e2.Teacher = "Machin";
            e2.Score = 20;
            e2.DateExam = new DateTime(2021, 10, 28, 10, 20, 49);
            Assert.True(e1.Equals(e2));
        }
    }
}
