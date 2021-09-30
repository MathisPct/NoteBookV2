using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Is a facade of the logic layer
    /// </summary>
    public class NoteBook
    {
        /// <summary>
        /// store all the units
        /// </summary>
        private List<Unit> units;

        /// <summary>
        /// Contains all the exams
        /// </summary>
        private List<Exam> exams;

        /// <summary>
        /// Initialize all lists
        /// </summary>
        public NoteBook()
        {
            this.units = new List<Unit>();
            this.exams = new List<Exam>();
        }

        /// <summary>
        /// Get list of units
        /// </summary>
        /// <returns>array of units which NoteBook contains</returns>
        public Unit[] ListUnits()
        {
            return this.units.ToArray();
        }

        /// <summary>
        /// Add unit to list of units 
        /// </summary>
        /// <param name="unit">Unit which is added in list of units</param>
        public void AddUnit(Unit unit)
        {
            bool findSame = false;
            int index = 0;
            while((index < ListUnits().Length) && (!findSame))
            {
                if (ListUnits()[index].Equals(unit))
                {
                    findSame = true;
                }
                index++;
            }
            if (findSame) throw new Exception("Unit name is already exist");
            this.units.Add(unit);
        }

        /// <summary>
        /// Remove unit in list which is passed in parameter
        /// </summary>
        /// <param name="u">unit which must be removed in list</param>
        public void RemoveUnit(Unit u)
        {
            this.units.Remove(u);
        }

        /// <summary>
        /// Return array of modules get thanks to list of units. Each of unit contains list
        /// of modules
        /// </summary>
        /// <returns>Array of modules</returns>
        public Module[] ListModules()
        {
            List<Module> modules = new List<Module>();
            if(ListUnits().Length == 0)
            {
                throw new Exception("Notebook contains no units");
            }
            // iterate list of unit to get all modules of this unit
            foreach(var unit in ListUnits())
            {
                modules.AddRange(unit.ListModules());
            }
            return modules.ToArray();
        }
    }
}
