using AnimeQuotes.Models;
using AnimeQuotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AnimeQuotes.ViewModels
{
    public partial class SearchCharactersQuotesViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string charName;

        public ObservableCollection<QuoteModel> TenCharsQuotes { get; set; } = new();

        AnimeQuoteService service = new AnimeQuoteService();

        [RelayCommand]
        async Task GetTenQuotesOfAChar()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                if (TenCharsQuotes is not null || TenCharsQuotes.Count is not 0)
                {
                    TenCharsQuotes.Clear();
                }

                if (CharName != null)
                {
                    service.animeChar = CharName;
                }
                else
                {
                    return;
                }

                var listOfQuotes = await service.GetTenQuotesFromACharacter();

                if (listOfQuotes is null)
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

                    TenCharsQuotes.Add(quote);
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
