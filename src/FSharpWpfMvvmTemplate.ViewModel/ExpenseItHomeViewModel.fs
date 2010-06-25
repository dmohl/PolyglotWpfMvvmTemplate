namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Xml
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel
open System.Collections.ObjectModel
open FSharpWpfMvvmTemplate.Model
open FSharpWpfMvvmTemplate.Repository

type ExpenseItHomeViewModel =   
    [<DefaultValue(false)>] val mutable _collectionView : ICollectionView
    [<DefaultValue(false)>] val mutable _expenseReports : ObservableCollection<ExpenseReport>
    [<DefaultValue(false)>] val mutable _expenseReportRepository : ExpenseReportRepository
    new () as x = {_expenseReports = new ObservableCollection<ExpenseReport>(); 
                   _collectionView = null; 
                   _expenseReportRepository = FSharpIoC.IoC.GetIoC.Resolve<ExpenseReportRepository>()
                  } then x.Initialize()
    inherit ViewModelBase
    member x.Initialize() =
        x._expenseReports <- new ObservableCollection<ExpenseReport>(x._expenseReportRepository.GetAllExpenseReports())
        x._collectionView <- CollectionViewSource.GetDefaultView(x._expenseReports)
        x._collectionView.CurrentChanged.AddHandler(
            new EventHandler(fun s e -> x.OnPropertyChanged "SelectedExpenseReport")) 
    member x.ExpenseReports : ObservableCollection<ExpenseReport> = x._expenseReports
    member x.ApproveExpenseReportCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ApproveExpenseReport)) 
    member x.SelectedExpenseReport =
        x._collectionView.CurrentItem :?> ExpenseReport
    member x.ApproveExpenseReport = 
        MessageBox.Show(sprintf "Expense report approved for %s" x.SelectedExpenseReport.Name) |> ignore

