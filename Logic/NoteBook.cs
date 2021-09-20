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
            foreach(var item in this.units)
            {
                if (unit.Name == item.Name) throw new Exception("Unit name is already exist");
            }
            this.units.Add(unit);
        }
    }
}
