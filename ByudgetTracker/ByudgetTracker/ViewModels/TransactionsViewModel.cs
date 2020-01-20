using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ByudgetTracker.Models;
using ByudgetTracker.Views;
using ByudgetTracker.Services;
using System.Collections.Generic;

namespace ByudgetTracker.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        public ObservableCollection<TransactionModel> Transactions { get; set; }
        public Command LoadTransactionsCommand { get; set; }

        public TransactionsViewModel(IDataStore<Entities.Transaction> dataStore, AutoMapper.IMapper mapper) : base(dataStore, mapper)
        {
            Title = "Browse";
            Transactions = new ObservableCollection<TransactionModel>();
            LoadTransactionsCommand = new Command(async () => await ExecuteLoadTransactionsCommand());

            MessagingCenter.Subscribe<NewTransactionPage, TransactionModel>(this, "AddTransaction", async (obj, item) =>
            {
                var newItem = item as TransactionModel;
                Transactions.Add(newItem);
                var entity = _mapper.Map<Entities.Transaction>(newItem);
                await DataStore.AddAsync(entity);
            });
        }

        async Task ExecuteLoadTransactionsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Transactions.Clear();
                var items = _mapper.Map<IEnumerable<TransactionModel>>(await DataStore.GetAsync(true));
                foreach (var item in items)
                {
                    Transactions.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}