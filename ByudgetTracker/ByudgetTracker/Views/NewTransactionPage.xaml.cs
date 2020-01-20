using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ByudgetTracker.Models;

namespace ByudgetTracker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewTransactionPage : ContentPage
    {
        public TransactionModel Transaction { get; set; }

        public NewTransactionPage()
        {
            InitializeComponent();

            Transaction = new TransactionModel
            {
                Description = "This is an item description.",
                Amount = 0.0M,
                TransactionDate = DateTime.Now,
                Id = 0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTransaction", Transaction);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}