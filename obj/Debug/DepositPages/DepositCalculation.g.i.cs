﻿#pragma checksum "..\..\..\DepositPages\DepositCalculation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "59125A986238F63C5B126483DCFA2884B6284C8ACE7C18773BA2A814421AF3E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Olump2018;
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


namespace Olump2018.DepositPages {
    
    
    /// <summary>
    /// DepositCalculation
    /// </summary>
    public partial class DepositCalculation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\DepositPages\DepositCalculation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepositIncomeStable;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\DepositPages\DepositCalculation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepositIncomeOptimal;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DepositPages\DepositCalculation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepositIncomeStandard;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\DepositPages\DepositCalculation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxSum;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\DepositPages\DepositCalculation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPeriod;
        
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
            System.Uri resourceLocater = new System.Uri("/Olump2018;component/depositpages/depositcalculation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DepositPages\DepositCalculation.xaml"
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
            this.DepositIncomeStable = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.DepositIncomeOptimal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DepositIncomeStandard = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 27 "..\..\..\DepositPages\DepositCalculation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxSum = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\DepositPages\DepositCalculation.xaml"
            this.TextBoxSum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxSum_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\DepositPages\DepositCalculation.xaml"
            this.TextBoxSum.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxSum_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBoxPeriod = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\DepositPages\DepositCalculation.xaml"
            this.TextBoxPeriod.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxPeriod_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\DepositPages\DepositCalculation.xaml"
            this.TextBoxPeriod.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxPeriod_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

