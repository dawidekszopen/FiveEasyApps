using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace ProductCatalog;

public partial class EditWindow : Window
{
    private object? senderButton;
    public EditWindow()
    {
        InitializeComponent();
    }

    public void ShowOldProdukt(string nazwaOld, string cenaOld, string kategoriaOld, bool dostepnyOld, IImage imageOld, object sender)
    {
        Image.Source = imageOld;
        Nazwa.Text = nazwaOld;
        Cena.Text = cenaOld;
        Kategoria.Text = kategoriaOld;
        Dostępny.IsChecked = dostepnyOld;
        senderButton = sender;
    }

    private void EdytujProdukt(object? sender, RoutedEventArgs e)
    {
        var mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow;

        mainWindow?.EditProdukt(senderButton, Nazwa.Text!, Cena.Text!, Kategoria.Text!, Dostępny.IsChecked!.Value);
        this.Close();
    }
}