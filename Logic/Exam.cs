using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Exam
    {
        /// <summary>
        /// Name of teacher concern by the exam
        /// </summary>
        private string teacher;
        public string Teacher { get => teacher; set => teacher = value; }

        /// <summary>
        /// Date of the exam
        /// </summary>
        private DateTime dateExam = DateTime.Now;

        public DateTime DateExam { get => dateExam; set => dateExam = value; }

        /// <summary>
        /// Coef of the exam
        /// </summary>
        private float coef;

        public float Coef { 
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("Coef must be >0");
                coef = value;
            }
        }

        /// <summary>
        /// Allow to know if person is absent
        /// </summary>
        private bool isAbsent;

        public bool IsAbsent { get => isAbsent; set => isAbsent = value; }

        /// <summary>
        /// Score getting in exam
        /// </summary>
        private float score;
        public float Score { 
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("Note must be between 0 and 20");
                score = value;
            }
        }

        private Module module;

        public Module Module { 
            get => module;
            set
            {
                if (module == null) throw new Exception("Module must be not null");
                module = value;
            }
        }

        public Exam()
        {
            this.dateExam = DateTime.Now;
            this.coef = 1;
            this.isAbsent = true;
            this.score = 0;
            this.module = new Module();
        }

    }
}
