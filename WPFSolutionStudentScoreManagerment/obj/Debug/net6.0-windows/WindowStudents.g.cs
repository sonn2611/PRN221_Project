﻿#pragma checksum "..\..\..\WindowStudents.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5FD33588F9AE78D1707363B5FC50C8E826A0BA2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WPFSolutionStudentScoreManagerment;


namespace WPFSolutionStudentScoreManagerment {
    
    
    /// <summary>
    /// WindowStudents
    /// </summary>
    public partial class WindowStudents : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Code;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Name;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Address;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_Classcode;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Add;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Edit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Delete;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Close;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_Students;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\WindowStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Search;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFSolutionStudentScoreManagerment;component/windowstudents.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowStudents.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_Code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_Address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cbx_Classcode = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btn_Add = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\WindowStudents.xaml"
            this.btn_Add.Click += new System.Windows.RoutedEventHandler(this.btn_Add_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_Edit = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\WindowStudents.xaml"
            this.btn_Edit.Click += new System.Windows.RoutedEventHandler(this.btn_Edit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Delete = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\WindowStudents.xaml"
            this.btn_Delete.Click += new System.Windows.RoutedEventHandler(this.btn_Delete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Close = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\WindowStudents.xaml"
            this.btn_Close.Click += new System.Windows.RoutedEventHandler(this.btn_Close_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dtg_Students = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\WindowStudents.xaml"
            this.dtg_Students.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtg_Students_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\WindowStudents.xaml"
            this.txt_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

