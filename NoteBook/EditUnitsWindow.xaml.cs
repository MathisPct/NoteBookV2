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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Logic.NoteBook notebook;

        private IStorage storage;

        public EditUnitsWindow(Logic.NoteBook nb, IStorage storage)
        {
            this.notebook = nb;
            this.storage = storage;
            InitializeComponent();
            DrawUnits();
        }

        /// <summary>
        /// Initialize listUnits
        /// </summary>
        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            listUnits.Items.Clear();
            foreach (var item in list)
                listUnits.Items.Add(item);
        }

        /// <summary>
        /// Initialize listModule according to unit which is selected
        /// </summary>
        private void DrawModules()
        {
            listModules.Items.Clear();
            if (listUnits.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                foreach (Module m in list)
                    listModules.Items.Add(m);
            }
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
                    storage.Save(notebook);
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
                    storage.Save(notebook);
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
                    MessageBoxResult messageBoxResult = MessageBox.Show("Delete selected unit?", "Delete confirmation", System.Windows.MessageBoxButton.YesNo);
                    if(messageBoxResult == MessageBoxResult.Yes)
                    {
                        this.notebook.RemoveUnit(unit);
                        DrawUnits();
                        DrawModules();
                        storage.Save(notebook);
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Modify list element. Open Edit window of the element which is 
        /// selected on list of module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModule(object sender, RoutedEventArgs e)
        {
            if(listModules.SelectedItem is Module m)
            {
                EditElementWindow third = new EditElementWindow(m);
                // TODO: résoudre soucis de la logique dans l'IHM
                List<Exam> examToModify = notebook.ListExams().Where(exam => exam.Module.Equals(m)).ToList();
                if (third.ShowDialog() == true)
                {
                    examToModify.ForEach(exam => exam.Module = m);
                    storage.Save(notebook);
                    //refresh of list
                    DrawModules();
                }
            }
        }

        /// <summary>
        /// Remove module which is selected in list of modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listModules.SelectedItem is Module m)
                {
                    Unit u = (Unit)(this.listUnits.SelectedItem);
                    MessageBoxResult messageBoxResult = MessageBox.Show("Delete selected module?", "Delete confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        u.Remove(m);
                        storage.Save(notebook);
                        DrawModules();
                    }
                }
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        /// <summary>
        /// Allow to add module in Unit
        /// Throw exception if unit is not selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listUnits.SelectedItem is Unit unit)
                {
                    Module newModule = new Module();
                    EditElementWindow third = new EditElementWindow(newModule);
                    //if window is closed
                    if (third.ShowDialog() == true)
                    {
                        unit.Add(newModule);
                        storage.Save(notebook);
                        DrawModules();
                    }
                }
                else
                {
                    throw new Exception("Please select Unit to add Module");
                }
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
