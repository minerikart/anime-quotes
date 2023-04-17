using AnimeQuotes.ViewModels;

namespace AnimeQuotes.Views;

public partial class AvailableCharactersToChoosePage : ContentPage
{
	public AvailableCharactersToChoosePage()
	{
		InitializeComponent();
		BindingContext = new AvailableCharactersToChooseViewModel();
	}
}