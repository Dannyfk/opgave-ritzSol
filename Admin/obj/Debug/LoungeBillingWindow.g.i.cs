﻿#pragma checksum "..\..\LoungeBillingWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "27C22C04EC2FE9F2006C8ACF93F7CEC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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


namespace Admin {
    
    
    /// <summary>
    /// LoungeBillingWindow
    /// </summary>
    public partial class LoungeBillingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cBoxRoomNumbers;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRoomNumbers;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSoldItem;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowDay;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowWeek;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowMonth;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\LoungeBillingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Admin;component/loungebillingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoungeBillingWindow.xaml"
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
            this.cBoxRoomNumbers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 6 "..\..\LoungeBillingWindow.xaml"
            this.cBoxRoomNumbers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cBoxRoomNumbers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblRoomNumbers = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.lblSoldItem = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnShowDay = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\LoungeBillingWindow.xaml"
            this.btnShowDay.Click += new System.Windows.RoutedEventHandler(this.btnShowDay_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnShowWeek = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\LoungeBillingWindow.xaml"
            this.btnShowWeek.Click += new System.Windows.RoutedEventHandler(this.btnShowWeek_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnShowMonth = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\LoungeBillingWindow.xaml"
            this.btnShowMonth.Click += new System.Windows.RoutedEventHandler(this.btnShowMonth_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\LoungeBillingWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
