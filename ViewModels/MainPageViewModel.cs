using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotivateMe.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Net;
using MotivateMe.Models;

namespace MotivateMe.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainPageViewModel 
    {
        private IQuoteService _quoteService;

        [ObservableProperty]
        private Quote quote;

        public MainPageViewModel(IQuoteService quoteService)
        {
            _quoteService = quoteService;
            StartUpCommand.Execute(null);
        }

        [ICommand]
        async Task StartUp()
        {
            var ret = await _quoteService.GetRandomQuoteAsync();
            if(ret.Status == ((int)HttpStatusCode.OK) && ret.Count == 1)
            {
                Quote = ret.Quotes.FirstOrDefault();
            }
        }
    }
}
