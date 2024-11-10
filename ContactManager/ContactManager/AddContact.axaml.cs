using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ContactManager;

public partial class AddContact : Window
{
    public AddContact()
    {
        InitializeComponent();
    }

    private void SendKontakt(object? sender, RoutedEventArgs e)
    {
        var mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow;

        if (Imie.Text == "" || Nazwisko.Text == "" || NrTel.Text == "" || Email.Text == "") return;
        mainWindow?.DodajKontakt(Imie.Text!, Nazwisko.Text!, NrTel.Text!, Email.Text!);
        Close();

    }
}