﻿using System;
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

        /// <summary>
        /// Add exam in current list of exam 
        /// </summary>
        /// <param name="exam"></param>
        public void AddExam(Exam exam)
        {
            if (exams.Exists(item => item.Equals(exam)))
            {
                throw new Exception("Exam is already exist");
            }
            exams.Add(exam);
        }

        /// <summary>
        /// Get all of exams in array
        /// </summary>
        /// <returns>Array of exams</returns>
        public Exam[] ListExams()
        {
            return exams.ToArray();
        }

        public AvgScore[] ComputeScores()
        {
            List<AvgScore> averages = new List<AvgScore>();
            float scoreUnitsSum = 0;
            float coefUnitsSum = 0;
            //iterate all units to get list of modules averages
            foreach (Unit unit in this.units)
            {
                float scoreModuleSum = 0;
                float coefModuleSum = 0;
                //if unit contains averages of modules
                if ((unit.ComputeAverages(exams.ToArray()).Length) > 0)
                {
                    //all average of modules of unit
                    foreach (AvgScore avgModule in unit.ComputeAverages(exams.ToArray()))
                    {
                        //count sum of score and coef of modules
                        if (avgModule != null)
                        {
                            averages.Add(avgModule);
                            scoreModuleSum += avgModule.Average * avgModule.GetPedagocicalElement().Coef;
                            coefModuleSum += avgModule.GetPedagocicalElement().Coef;
                        }
                    }
                    //calculate average of current unit
                    AvgScore avgUnit = new AvgScore(scoreModuleSum / coefModuleSum, unit);
                    averages.Add(avgUnit);
                    //calculate sum of score and sum of coef of units
                    scoreUnitsSum += avgUnit.Average * unit.Coef;
                    coefUnitsSum += unit.Coef;
                }
            }
            if(averages.ToArray().Length > 0)
            {
                PedagocicalElement elementAvgGlobal = new PedagocicalElement();
                elementAvgGlobal.Name = "Global average";
                AvgScore avgGlobal = new AvgScore(scoreUnitsSum / coefUnitsSum, elementAvgGlobal);
                averages.Add(avgGlobal);
            }
            return averages.ToArray();
        }
    }
}
