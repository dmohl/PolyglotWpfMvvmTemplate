namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Xml
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel
open System.Collections.ObjectModel
open FSharpWpfMvvmTemplate.Model

type ExpenseItHomeViewModel =   
    [<DefaultValue(false)>] val mutable _collectionView : ICollectionView
    [<DefaultValue(false)>] val mutable _expenseReports : ObservableCollection<ExpenseReport>
    new () as x = {_expenseReports = new ObservableCollection<ExpenseReport>(); 
                   _collectionView = null} then x.Initialize()
    inherit ViewModelBase
    member x.Initialize() =
        x._expenseReports <- x.BuildExpenseReports()
        x._collectionView <- CollectionViewSource.GetDefaultView(x._expenseReports)
        x._collectionView.CurrentChanged.AddHandler(
            new EventHandler(fun s e -> x.OnPropertyChanged "SelectedExpenseReport")) 
    member x.BuildExpenseReports() = 
        let collection = new ObservableCollection<ExpenseReport>()
        let mike = {Name="Mike" 
                    Department="Legal" 
                    ExpenseLineItems = 
                        [{ExpenseType="Lunch" 
                          ExpenseAmount="50"};
                        {ExpenseType="Transportation" 
                         ExpenseAmount="50"}]}
        collection.Add(mike)
        let lisa = {Name="Lisa"
                    Department="Marketing" 
                    ExpenseLineItems = 
                        [{ExpenseType="Document printing" 
                          ExpenseAmount="50"};
                        {ExpenseType="Gift" 
                         ExpenseAmount="125"}]}
        collection.Add(lisa)
        let john = {Name="John" 
                    Department="Engineering"
                    ExpenseLineItems = 
                        [{ExpenseType="Magazine subscription" 
                          ExpenseAmount="50"};
                        {ExpenseType="New machine" 
                         ExpenseAmount="600"};
                        {ExpenseType="Software" 
                         ExpenseAmount="500"}]}
        collection.Add(john)
        let mary = {Name="Mary"
                    Department="Finance"
                    ExpenseLineItems = 
                        [{ExpenseType="Dinner" 
                          ExpenseAmount="100"}]}
        collection.Add(mary)
        collection
    member x.ExpenseReports : ObservableCollection<ExpenseReport> = x._expenseReports
    member x.ApproveExpenseReportCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ApproveExpenseReport)) 
    member x.SelectedExpenseReport =
        x._collectionView.CurrentItem :?> ExpenseReport
    member x.ApproveExpenseReport = 
        MessageBox.Show(sprintf "Expense report approved for %s" x.SelectedExpenseReport.Name) |> ignore
