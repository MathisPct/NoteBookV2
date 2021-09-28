using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Unit : PedagocicalElement
    {
        /// <summary>
        /// List of mudules that unit contains
        /// </summary>
        private List<Module> modules; 

        /// <summary>
        /// Initialize list
        /// </summary>
        public Unit()
        {
            this.modules = new List<Module>();
        }

        public Module[] ListModules()
        {
            return modules.ToArray();
        }
    }
}
