using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using ByudgetTracker.Models;
using ByudgetTracker.Services;
using ByudgetTracker.Entities;

namespace ByudgetTracker.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IDataStore<Transaction> _dataStore;
        protected AutoMapper.IMapper _mapper;
        public BaseViewModel(IDataStore<Transaction> dataStore, AutoMapper.IMapper mapper)
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }
        
        public IDataStore<Transaction> DataStore => _dataStore;

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
