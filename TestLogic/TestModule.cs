using System;
using Xunit;
using Logic;
using System.Collections.Generic;

namespace TestLogic
{
    public class TestModule
    {
        [Fact]
        public void ComputeAverage()
        {
            //test with no exams
            Module maths = new Module();
            maths.Name = "Maths";
            List<Exam> exams = new List<Exam>();
            Assert.Null(maths.ComputeAverage(exams.ToArray()));


            //test with one exam which no belongs to module which we compute average 
            Module francais = new Module();
            francais.Name = "Francais";
            Exam examFr = new Exam();
            examFr.Score = 15;
            examFr.Coef = 2;
            examFr.Module = francais;
            Assert.Null(maths.ComputeAverage(exams.ToArray()));

            //test of average with one exam belongs to module which we compute average 
            Exam e1 = new Exam();
            AvgScore exceptAvgScore = new AvgScore(12f, maths);
            e1.Score = 12;
            e1.Coef = 2.5f;
            e1.Module = maths;
            exams.Add(e1);
            Assert.Equal(exceptAvgScore.Average, maths.ComputeAverage(exams.ToArray()).Average, 2);

            //test of average with two exams belongs to module which we compute average 
            exceptAvgScore = new AvgScore(13.09f, maths);
            Exam e2 = new Exam();
            e2.Score = 14;
            e2.Coef = 3f;
            e2.Module = maths;
            exams.Add(e2);
            Assert.Equal(exceptAvgScore.Average, maths.ComputeAverage(exams.ToArray()).Average, 2);
        }

    }
}
