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
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        /// <summary>
        /// Current notebook
        /// </summary>
        private Logic.NoteBook nb;

        /// <summary>
        /// Exam which is associated with this window
        /// </summary>
        private Exam exam;

        private IStorage storage;

        /// <summary>
        /// Constructor initialization
        /// </summary>
        /// <param name="nb">Current notebook of application</param>
        public EditExamWindow(Logic.NoteBook nb, IStorage storage)
        {
            this.nb = nb;
            this.exam = new Exam();
            this.storage = storage;
            InitializeComponent();
            DrawModules(nb.ListModules());
            InitExamComponent();
        }

        /// <summary>
        /// Initialize ComboBox of modules with the modules which are contains
        /// on notebook
        /// </summary>
        /// <param name="modules"></param>
        private void DrawModules(Module[] modules)
        {
            boxModules.Items.Clear();
            foreach(Module m in modules)
            {
                boxModules.Items.Add(m);
            }
        }
        /// <summary>
        /// Initialize all value of component with differents value of 
        /// current exam which is create
        /// </summary>
        private void InitExamComponent()
        {
            dateExam.SelectedDate = exam.DateExam;
            checkAbsent.IsChecked = exam.IsAbsent;
            txtBoxScore.Text = exam.Score.ToString();
            txtBoxCoef.Text = exam.Coef.ToString();
        }

        /// <summary>
        /// Save exam which is created in list of exams contains in notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                exam.Module = (Module)boxModules.SelectedItem;
                exam.DateExam = (DateTime)dateExam.SelectedDate;
                exam.IsAbsent = checkAbsent.IsEnabled;
                exam.Teacher = txtBoxTeacher.Text;
                exam.Score = (float)Convert.ToDouble(txtBoxScore.Text);
                exam.Coef = (float)Convert.ToDouble(txtBoxCoef.Text);
                nb.AddExam(exam);
                storage.Save(nb);
                this.Close();
            }
            catch(Exception X)
            {
                MessageBox.Show(X.Message);
            }
        }

        /// <summary>
        /// Cancel the creation of exam and close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
