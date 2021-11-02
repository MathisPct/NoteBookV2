using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class JsonStorage : IStorage
    {
        /// <summary>
        /// Name of the file where data are stocked
        /// </summary>
        private string fileName;

        private Logic.NoteBook noteBook;

        public JsonStorage(string fileName)
        {
            this.fileName = fileName;
        }

        public Logic.NoteBook Load()
        {
            try
            {
                using(FileStream flux = new FileStream(fileName, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NoteBook));
                    noteBook = ser.ReadObject(flux) as NoteBook;
                    flux.Close();
                }
            }
            catch
            {
                noteBook = new NoteBook();
            }
            return noteBook;
        }

        public void Save(NoteBook nb)
        {
            FileStream flux = new FileStream(fileName, FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NoteBook));
            ser.WriteObject(flux, nb);
            flux.Close();
        }
    }
}
