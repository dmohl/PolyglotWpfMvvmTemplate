using FSharpWpfMvvmTemplate;

namespace WpfMvvmTemplate.View
{
    public partial class App
    {
        static App()
        {
            FSharpIoC.IoC.GetIoC.Register<Repository.ExpenseReportRepository, Repository.ExpenseReportRepository>();
        }
    }
}
