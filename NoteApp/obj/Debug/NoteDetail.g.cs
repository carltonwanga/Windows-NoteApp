﻿

#pragma checksum "c:\users\ericsson6\documents\visual studio 2015\Projects\NoteApp\NoteApp\NoteDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BA25926AE1A003A7B6063BC1A19D8C78"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoteApp
{
    partial class NoteDetail : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\NoteDetail.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.tbTitle_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 16 "..\..\NoteDetail.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.lblLong_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 18 "..\..\NoteDetail.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.tbLong_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

