﻿module FSharpWpfMvvmTemplate

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FSharpWpfMvvmTemplate.ViewModel

// Create the View and bind it to the View Model
let mainWindowViewModel = Application.LoadComponent(
                             new System.Uri("/FSharpWpfMvvmTemplate.App;component/mainwindow.xaml", UriKind.Relative)) :?> Window
mainWindowViewModel.DataContext <- new MainWindowViewModel() :> obj

// Application Entry point
[<STAThread>]
[<EntryPoint>]
let main(_) = (new Application()).Run(mainWindowViewModel)