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

        /// <summary>
        /// Ajoute un module à la liste des modules courante contenue dans une unité
        /// </summary>
        /// <param name="m">Module à ajouter</param>
        public void Add(Module m)
        {
            this.modules.Add(m);
        }

        /// <summary>
        /// Remove module in list of module
        /// </summary>
        /// <param name="m">Module to delete</param>
        public void Remove(Module m)
        {
            this.modules.Remove(m);
        }

        public override bool Equals(object obj)
        {
            return obj is Unit unit &&
                   Name == unit.Name;
        }
    }
}
