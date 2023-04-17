using AnimeQuotes.ViewModels;

namespace AnimeQuotes.Views;

public partial class SearchQuotesPage : ContentPage
{
	public SearchQuotesPage()
	{
		InitializeComponent();
		BindingContext = new SearchQuotesViewModel();
	}
}