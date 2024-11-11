using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EventCalendar;

public partial class FullWydarzenie : Window
{
    public FullWydarzenie(string nazwa, string dzienTyg, string opis, bool isUlubione)
    {
        InitializeComponent();
        Nazwa.Text = nazwa;
        DzienTyg.Text = dzienTyg;
        Opis.Text = opis;
        Ulubione.IsChecked = isUlubione;

    }
    
    
}