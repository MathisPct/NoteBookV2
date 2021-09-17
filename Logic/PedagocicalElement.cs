using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PedagocicalElement
    {
        /// <summary>
        /// Name of the element
        /// </summary>
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == null) throw new Exception("The name must be not empty");
                this.name = value;
            }
        }

        /// <summary>
        /// Coef of the element
        /// </summary>
        private float coef;
        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("The coef must be >0");
                coef = value;
            }
        }
    }
}
