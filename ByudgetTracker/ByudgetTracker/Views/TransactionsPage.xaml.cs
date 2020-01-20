using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ByudgetTracker.Models;
using ByudgetTracker.Views;
using ByudgetTracker.ViewModels;
using ByudgetTracker.Services;

namespace ByudgetTracker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TransactionsPage : ContentPage
    {
        TransactionsViewModel viewModel;
        private IDataStore<Entities.Transaction> _dataStore;
        private AutoMapper.IMapper _mapper;
        public TransactionsPage()
        {
            InitializeComponent();
            _dataStore = DependencyService.Resolve<IDataStore<Entities.Transaction>>();
            _mapper = DependencyService.Resolve<AutoMapper.IMapper>();
            BindingContext = viewModel = new TransactionsViewModel(_dataStore, _mapper);
        }

        async void OnTransactionSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TransactionModel;
            if (item == null)
                return;
            var tdvm = new TransactionsDetailViewModel(_dataStore, _mapper);
            tdvm.SetItem(item);
            await Navigation.PushAsync(new TransactionsDetailPage(tdvm));

            // Manually deselect item.
            TransactionsListView.SelectedItem = null;
        }

        async void AddTransaction_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTransactionPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Transactions.Count == 0)
                viewModel.LoadTransactionsCommand.Execute(null);
        }
    }
}