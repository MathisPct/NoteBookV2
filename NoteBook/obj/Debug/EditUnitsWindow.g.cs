﻿#pragma checksum "..\..\EditUnitsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3443019FA19220300D1C6330471E06BC3D719BBEF49302BD16BCAF551AC0088C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using NoteBook;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NoteBook {
    
    
    /// <summary>
    /// EditUnitsWindow
    /// </summary>
    public partial class EditUnitsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listUnits;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button remove;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listModules;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addModule;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\EditUnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeModule;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NoteBook;component/editunitswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditUnitsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.listUnits = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\EditUnitsWindow.xaml"
            this.listUnits.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.EditUnit);
            
            #line default
            #line hidden
            
            #line 22 "..\..\EditUnitsWindow.xaml"
            this.listUnits.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectUnit);
            
            #line default
            #line hidden
            return;
            case 2:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\EditUnitsWindow.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.AddUnit);
            
            #line default
            #line hidden
            return;
            case 3:
            this.remove = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\EditUnitsWindow.xaml"
            this.remove.Click += new System.Windows.RoutedEventHandler(this.RemoveUnit);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listModules = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\EditUnitsWindow.xaml"
            this.listModules.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.EditModule);
            
            #line default
            #line hidden
            return;
            case 5:
            this.addModule = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\EditUnitsWindow.xaml"
            this.addModule.Click += new System.Windows.RoutedEventHandler(this.AddModule);
            
            #line default
            #line hidden
            return;
            case 6:
            this.removeModule = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\EditUnitsWindow.xaml"
            this.removeModule.Click += new System.Windows.RoutedEventHandler(this.RemoveModule);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

