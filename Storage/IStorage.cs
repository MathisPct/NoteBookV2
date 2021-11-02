using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorage
    {
        /// <summary>
        /// Load a Notebook
        /// </summary>
        /// <returns>Notebook loaded</returns>
        NoteBook Load();
        
        /// <summary>
        ///Save a notebook 
        /// </summary>
        /// <param name="nb">Save a notebook</param>
        void Save(NoteBook nb);
    }
}
