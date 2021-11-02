using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    public class Exam
    {
        /// <summary>
        /// Name of teacher concern by the exam
        /// </summary>
        [DataMember]
        private string teacher;
        public string Teacher { get => teacher; set => teacher = value; }

        /// <summary>
        /// Date of the exam
        /// </summary>
        [DataMember]
        private DateTime dateExam = DateTime.Now;

        public DateTime DateExam { get => dateExam; set => dateExam = value; }

        /// <summary>
        /// Coef of the exam
        /// </summary>
        [DataMember]
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
        [DataMember]
        private bool isAbsent;

        public bool IsAbsent { get => isAbsent; set => isAbsent = value; }

        /// <summary>
        /// Score getting in exam
        /// </summary>
        [DataMember]
        private float score;
        public float Score { 
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("Note must be between 0 and 20");
                score = value;
            }
        }
        [DataMember]
        private Module module;

        public Module Module { 
            get => module;
            set
            {
                if (value == null) throw new Exception("Module must be not null");
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

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   teacher == exam.teacher &&
                   dateExam.Year == exam.dateExam.Year &&
                   dateExam.Month == exam.dateExam.Month &&
                   dateExam.Day == exam.dateExam.Day &&
                   dateExam.Hour == exam.dateExam.Hour &&
                   dateExam.Minute == exam.dateExam.Minute &&
                   dateExam.Second == exam.dateExam.Second &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   module.Equals(exam.module);
        }
    }
}
