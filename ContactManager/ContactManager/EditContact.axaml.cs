using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ContactManager;

public partial class EditContact : Window
{
    public object? ParentObject;
    
    public EditContact()
    {
        InitializeComponent();
    }

    public void ShowKontakt(object? parent, string imieOld, string nazwiskoOld, string nrTelOld, string emailOld)
    {
        Imie.Text = imieOld;
        Nazwisko.Text = nazwiskoOld;
        NrTel.Text = nrTelOld;
        Email.Text = emailOld;
        ParentObject = parent;
    }

    private void EditKontakt(object? sender, RoutedEventArgs e)
    {
        var mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow;

        if (Imie.Text == "" || Nazwisko.Text == "" || NrTel.Text == "" || Email.Text == "") return;
        mainWindow?.EditContact(ParentObject, Imie.Text!, Nazwisko.Text!, NrTel.Text!, Email.Text!);
        Close();
    }
}