using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// A module is a root pedagogical element
    /// </summary>
    public class Module : PedagocicalElement
    {
        public AvgScore ComputeAverage(Exam[] exams)
        {
            AvgScore avgScore = null;
            float scoreSum = 0;
            float coefSum = 0;
            float avg;
            bool canCalculate = false;
            //iterate all exam 
            foreach (Exam exam in exams)
            {
                //exams of current module
                if(exam.Module == this)
                {
                    canCalculate = true;
                    scoreSum += (float)exam.Score * exam.Coef;
                    coefSum += exam.Coef; 
                }
            }
            if (canCalculate)
            {
                avg = (float)scoreSum / coefSum;
                avgScore = new AvgScore(avg, this);
            }
            return avgScore;
        }
    }
}
