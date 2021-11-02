using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    [KnownType(typeof(Module))]
    [KnownType(typeof(Unit))]
    public class PedagocicalElement
    {
        /// <summary>
        /// Name of the element
        /// </summary>
        [DataMember]
        private string name = "";
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value.Equals("")) throw new Exception("The name must be not empty");
                this.name = value;
            }
        }

        /// <summary>
        /// Coef of the element
        /// </summary>
        [DataMember]
        private float coef = 0;
        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("The coef must be >0");
                coef = value;
            }
        }

        public override string ToString()
        {
            return "Name" + ": " + this.name + "\nCoef: " + this.coef;
        }

        public override bool Equals(object obj)
        {
            return obj is PedagocicalElement element &&
                   name == element.name &&
                   coef == element.coef;
        }
    }
}
