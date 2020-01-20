using System;

using ByudgetTracker.Models;
using ByudgetTracker.Services;

namespace ByudgetTracker.ViewModels
{
    public class TransactionsDetailViewModel : BaseViewModel
    {
        public TransactionModel Transaction { get; set; }
        public TransactionsDetailViewModel(IDataStore<Entities.Transaction> dataStore, AutoMapper.IMapper mapper) : base(dataStore, mapper)
        { }
        public void SetItem(TransactionModel item)
        {
            Transaction = item;
        }
    }
}
