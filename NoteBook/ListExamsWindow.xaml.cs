﻿using System;
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
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        /// <summary>
        /// Current notebook of main window
        /// </summary>
        private Logic.NoteBook nb;

        /// <summary>
        /// Constructor initialize
        /// </summary>
        /// <param name="nb">Current notebook of application</param>
        public ListExamsWindow(Logic.NoteBook nb)
        {
            InitializeComponent();
            this.nb = nb;
            DrawExams();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach(Exam e in nb.ListExams())
            {
                exams.Items.Add(e);
            }
        }
    }
}