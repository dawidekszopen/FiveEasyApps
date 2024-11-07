using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace SurveyCreator;

public partial class NewPytanie : Window
{

    public NewPytanie()
    {
        InitializeComponent();
    }

    private void SendPytanie(object? sender, RoutedEventArgs e)
    {
        var mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow;
        if (mainWindow != null && Odp1.Text != null && Odp2.Text != null && Odp3.Text != null && Odp4.Text != null && Pytanie.Text != null && Kategoria.Text != null)
        {
 
            List<string> odpList = [
                Odp1.Text,
                Odp2.Text,
                Odp3.Text,
                Odp4.Text,
            ];
            
            
            var radioGroup = this.GetLogicalDescendants().OfType<RadioButton>().FirstOrDefault(rb => rb is { GroupName: "Options", IsChecked: true });
            

            if (radioGroup?.Content?.ToString() == "jednokrotnego wyboru")
            {
                mainWindow.NewPytanie(Pytanie.Text, Kategoria.Text, odpList, 1, mainWindow.Ankieta.Items.Count);
            }
            else
            {
                mainWindow.NewPytanie(Pytanie.Text, Kategoria.Text, odpList, 2, mainWindow.Ankieta.Items.Count);
            }

            this.Close();
            
        }
    }
}