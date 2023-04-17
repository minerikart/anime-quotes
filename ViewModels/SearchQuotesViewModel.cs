using AnimeQuotes.Models;
using AnimeQuotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AnimeQuotes.ViewModels
{
    public partial class SearchQuotesViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string name;

        public ObservableCollection<QuoteModel> TenQuotes { get; set; } = new();

        AnimeQuoteService service = new AnimeQuoteService();

        [RelayCommand]
        async Task GetTenQuotesOfAnAnime()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                if(TenQuotes is not null || TenQuotes.Count is not 0)
                {
                    TenQuotes.Clear();
                }

                if (Name != null)
                {
                    service.animeName = Name;
                }
                else
                {
                    return;
                }

                var listOfQuotes = await service.GetTenQuotesFromAnAnime();

                if(listOfQuotes is null)
                {
                    await Shell.Current.DisplayAlert("Failed!", "No record of this series", "OK");
                    return;
                }

                foreach (var quote in listOfQuotes)
                {



                    //if (Enumerable.SequenceEqual(TenQuotes, listOfQuotes))
                    //{
                    //    await Shell.Current.DisplayAlert("Failed!", "You already saw all the" +
                    //        " quotes of this series!", "Ok");
                    //    return;
                    //}

                    TenQuotes.Add(quote);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
