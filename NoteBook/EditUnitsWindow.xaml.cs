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

        /// <summary>
        /// Allow to modify list element. When the modif is finish, list of units
        /// is refreshed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if(listUnits.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if(third.ShowDialog() == true)
                {
                    //refresh of list
                    DrawUnits();
                }
            }
        }

        /// <summary>
        /// Open a modal window to add unit in list container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                //if window is closed
                if(third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                }
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
            
        /// <summary>
        /// Remove element which is selected in list units container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if(listUnits.SelectedItem is Unit unit)
                {
                    this.notebook.RemoveUnit(unit);
                    DrawUnits();
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Allow to add module in Notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModule(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Modify list element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModule(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Allow to remove module from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {

        }
    }
}
