using AnimeQuotes.ViewModels;
using System.Reflection.Metadata;

namespace AnimeQuotes.Views;

public partial class RandomQuotesPage : ContentPage
{

    public RandomQuotesPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        if(quote.Text is null) { return; }

        await DisplayAlert("Quote copied!", "", "Ok");

        await Clipboard.SetTextAsync(quote.Text);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        frame.IsVisible = true;
    }
}