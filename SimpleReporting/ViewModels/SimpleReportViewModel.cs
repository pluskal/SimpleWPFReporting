using System;
using System.Windows.Controls;
using System.Windows.Input;
using SimpleReporting.Models;
using SimpleWPFReporting;

namespace SimpleReporting.ViewModels
{
    public class SimpleReportViewModel
    {
        public SimpleReportViewModel()
        {
            this.PersonDetail = new Person()
            {
                Name = "Jan",
                Surname = "Novak",
                Email = "jan.novak@gmail.com",
                Phone = "+420 721 123 456"
            };
            this.PrintPdfCommand = new PrintPdfCommand(this);
        }
        public Person PersonDetail { get; }
        public ICommand PrintPdfCommand { get; }
    }

    public class PrintPdfCommand : ICommand
    {
        private object _dataContext;

        public PrintPdfCommand(object dataContext)
        {
            this._dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private void Execute(StackPanel parameter)
        {
            if(parameter ==null) return;
            SimpleWPFReporting.Report.ExportReportAsPdf(
                parameter,
                this._dataContext,
                ReportOrientation.Portrait);
        }
        public void Execute(object parameter)
        {
            var stackPanel = parameter as StackPanel;
            this.Execute(stackPanel);
        }

        public event EventHandler CanExecuteChanged;
    }
}