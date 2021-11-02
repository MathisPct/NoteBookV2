using Logic;
using Storage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic.NoteBook notebook;

        private IStorage storage;

        public MainWindow()
        {
            storage = new JsonStorage("data");
            this.notebook = storage.Load();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Open second window to see different units
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            try
            {
                EditUnitsWindow second = new EditUnitsWindow(notebook, storage);
                second.ShowDialog();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Open new window of edit exam
        /// Throw exception if no modules are exists in application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            try
            {
                EditExamWindow second = new EditExamWindow(notebook, storage);
                second.ShowDialog();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Open new window of edit exam
        /// Throw exception if no exams are exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPrintAverage(object sender, RoutedEventArgs e)
        {
            try
            {
                ListExamsWindow secondWindow = new ListExamsWindow(notebook);
                secondWindow.ShowDialog();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
