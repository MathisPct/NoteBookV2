using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        /// <summary>
        /// Current notebook of main window
        /// </summary>
        private Logic.NoteBook nb;

        private IStorage storage;

        /// <summary>
        /// Constructor initialize
        /// </summary>
        /// <param name="nb">Current notebook of application</param>
        public ListExamsWindow(Logic.NoteBook nb, IStorage storage)
        {
            InitializeComponent();
            this.nb = nb;
            this.storage = storage;
            DrawExams();
        }

        private void DrawExams()
        {
            scores.Items.Clear();
            exams.Items.Clear();
            foreach(AvgScore avg in nb.ComputeScores())
            {
                scores.Items.Add(avg);
            }
            foreach(Exam exam in nb.ListExams())
            {
                exams.Items.Add(exam);
            }
        }

        private void EditExam(object sender, MouseButtonEventArgs e)
        {
            if (exams.SelectedItem is Exam exam)
            {
                EditExamWindow third = new EditExamWindow(nb, exam);
                if (third.ShowDialog() == true)
                {
                    storage.Save(nb);
                    nb.ComputeScores();
                    //refresh of list
                    DrawExams();
                }
            }
        }
    }
}
