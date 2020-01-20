using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ByudgetTracker.Models;
using ByudgetTracker.ViewModels;

namespace ByudgetTracker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TransactionsDetailPage : ContentPage
    {
        TransactionsDetailViewModel viewModel;

        public TransactionsDetailPage(TransactionsDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}