using AnimeQuotes.Models;
using AnimeQuotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AnimeQuotes.ViewModels
{
    public partial class AvailableOptionsToChooseViewModel : ObservableObject
    {
        public ObservableCollection<AnimeModel> AvailableAnimes { get; } = new();

        AnimeQuoteService service = new AnimeQuoteService();

        [ObservableProperty]
        bool isBusy = true;

        [RelayCommand]
        async Task GetAvailableAnimes()
        {
            try
            {

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                var listOfAnimes = await service.GetAvailableAnimes();

                Console.WriteLine(listOfAnimes);


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                isBusy = false;
            }
        }

    }
}
