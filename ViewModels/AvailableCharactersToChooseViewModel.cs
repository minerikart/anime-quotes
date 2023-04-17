using AnimeQuotes.Models;
using AnimeQuotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeQuotes.ViewModels
{
    public partial class AvailableCharactersToChooseViewModel : ObservableObject
    {
        public ObservableCollection<AnimeModel> AvailableChar { get; } = new();

        AnimeQuoteService service = new AnimeQuoteService();

        [ObservableProperty]
        bool isBusy = true;

        [RelayCommand]
        async Task GetAvailableChar()
        {
            try
            {

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                var listOfAnimes = await service.GetAvailableCharacters();

                //foreach (var quote in listOfAnimes)
                //{
                //    AvailableChar.Add(quote);
                //}


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
