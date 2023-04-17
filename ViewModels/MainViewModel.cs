using CommunityToolkit.Mvvm.ComponentModel;
using AnimeQuotes.Services;
using CommunityToolkit.Mvvm.Input;
using AnimeQuotes.Models;
using System.Diagnostics;

namespace AnimeQuotes.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        QuoteModel animeQuotes;

        AnimeQuoteService service = new AnimeQuoteService();

        [RelayCommand]
        async Task GetQuotes()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }


                var data = await service.GetQuotes();
                AnimeQuotes = data;


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
