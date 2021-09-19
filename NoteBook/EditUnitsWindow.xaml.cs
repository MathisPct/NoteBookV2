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

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Logic.NoteBook notebook;

        public EditUnitsWindow(Logic.NoteBook nb)
        {
            this.notebook = nb;
            InitializeComponent();
            DrawUnits();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Initialize listItems
        /// </summary>
        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            listUnits.Items.Clear();
            foreach (var item in list)
                listUnits.Items.Add(item);
        }
    }
}
