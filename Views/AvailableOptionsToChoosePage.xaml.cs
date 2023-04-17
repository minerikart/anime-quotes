using AnimeQuotes.ViewModels;

namespace AnimeQuotes.Views;

public partial class AvailableOptionsToChoosePage : ContentPage
{
	public AvailableOptionsToChoosePage()
	{
		InitializeComponent();
		BindingContext = new AvailableOptionsToChooseViewModel();
	}
}