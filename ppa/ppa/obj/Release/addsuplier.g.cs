﻿#pragma checksum "..\..\addsuplier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B5CFC92D82DE28A4E582B3EC09640FB49E07DB8D609E21EC20681DC575500204"
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
using ppa;


namespace ppa {
    
    
    /// <summary>
    /// addsuplier
    /// </summary>
    public partial class addsuplier : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 167 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email_txt;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_txt;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox category;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox first_combo;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox second_combo;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox third_combo;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox fourth_combo;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox qty;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox contact_txt;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox show_id;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\addsuplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price_txt;
        
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
            System.Uri resourceLocater = new System.Uri("/ppa;component/addsuplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addsuplier.xaml"
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
            this.email_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.name_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.category = ((System.Windows.Controls.ComboBox)(target));
            
            #line 169 "..\..\addsuplier.xaml"
            this.category.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.category_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.first_combo = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.second_combo = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.third_combo = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.fourth_combo = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            
            #line 174 "..\..\addsuplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.qty = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.contact_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.show_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 224 "..\..\addsuplier.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.button_Click_1);
            
            #line default
            #line hidden
            return;
            case 13:
            this.price_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

