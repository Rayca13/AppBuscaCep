namespace AppBuscaCep.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Menu : ContentPage
{
    public Menu()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(
        new Views.BuscaCepPorLogradouro2());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}