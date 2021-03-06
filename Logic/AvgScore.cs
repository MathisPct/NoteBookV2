using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Allow to calculate average in each modules,
    /// educational element and global average of notebook
    /// </summary>
    public class AvgScore
    {
        /// <summary>
        /// Average of educational element
        /// </summary>
        private float average;
        public float Average
        {
            get => average;
            set
            {
                average = value;
            }
        }

        /// <summary>
        /// Name of element
        /// </summary>
        public string ElementName
        {
            get => Element.Name;
        }

        /// <summary>
        /// Element which we will calculate average of exams
        /// </summary>
        private PedagocicalElement element;
        public PedagocicalElement Element { get => element; set => element = value; }
        public PedagocicalElement GetPedagocicalElement()
        {
            return Element;
        }

        public AvgScore(float average, PedagocicalElement pedagocicalElement)
        {
            this.Element = pedagocicalElement;
            this.average = average;
        }

        /// <summary>
        /// String of average
        /// </summary>
        /// <returns>Average: value</returns>
        public override string ToString()
        {
            return "Name: " + ElementName + ", Average: " + average;
        }
    }
}
