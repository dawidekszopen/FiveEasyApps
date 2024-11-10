using System;
using System.Linq;
using System.Net.Mime;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace ProductCatalog;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Search(object? sender, RoutedEventArgs e)
    {
        foreach (var produkty in ProduktyLista.Items)
        {
            if (produkty is not ListBoxItem item) continue;
            
            item.IsVisible = false;
            //
            // var texts = item!.GetVisualDescendants().OfType<StackPanel>().FirstOrDefault()!.GetVisualDescendants()
            //     .OfType<StackPanel>().FirstOrDefault();
            //
            // foreach (var text in texts!.GetVisualDescendants().OfType<TextBlock>())
            // {
            //     if (text.Classes.Count < 1) continue;
            //     if (text.Classes[0] != "NazwaProduktu") continue;
            //     if (text.Text!.ToLower() != Wyszukaj.Text) continue;
            //     item!.IsVisible = true;
            // }
            // var firstStackPanel = item.GetVisualChildren().OfType<StackPanel>().FirstOrDefault();
            // if(firstStackPanel == null) continue;
            if (item.Content is StackPanel firstStackPanel)
            {
                var secondStackPanel = firstStackPanel.Children.OfType<StackPanel>().Skip(1).FirstOrDefault();
                if (secondStackPanel == null) continue;

                var nazwaProduktu = secondStackPanel.Children.OfType<TextBlock>()
                    .FirstOrDefault(block => block.Classes.Contains("NazwaProduktu"));

                if (nazwaProduktu != null && nazwaProduktu.Text?.ToLower().Contains(Wyszukaj.Text!.ToLower()) == true)
                {
                    item.IsVisible = true;
                }
            }
        }
    }

    private void EditProduktClick(object? sender, RoutedEventArgs e)
    {
        var parent = (sender as Button)!.Parent as StackPanel;

        var image = (parent!.Parent as StackPanel)!.Children.OfType<Image>().First().Source;
        
        var nazwa = parent!.Children.OfType<TextBlock>().FirstOrDefault()!.Text;

        var cena = parent.Children.OfType<StackPanel>().First().Children.OfType<TextBlock>().Skip(1).First().Text;
        var kategoria = parent.Children.OfType<StackPanel>().Skip(1).FirstOrDefault()!.Children.OfType<TextBlock>().Skip(1).First().Text;
        var dostepny = parent.Children.OfType<StackPanel>().Skip(2).FirstOrDefault()!.Children.OfType<CheckBox>().FirstOrDefault()!.IsChecked!.Value;
        
        var editProduktPopUp = new EditWindow();
        editProduktPopUp.ShowDialog(this);
        editProduktPopUp.ShowOldProdukt(nazwa!, cena!, kategoria!, dostepny, image!, sender);

    }
    
    public void EditProdukt(object? sender, string nazwaNew, string cenaNew, string kategoriaNew, bool dostepnyNew)
    {
        var parent = (sender as Button)!.Parent as StackPanel;

        var image = (parent!.Parent as StackPanel)!.Children.OfType<Image>().First().Source;
        
        var nazwa = parent!.Children.OfType<TextBlock>().FirstOrDefault();

        var cena = parent.Children.OfType<StackPanel>().First().Children.OfType<TextBlock>().Skip(1).First();
        var kategoria = parent.Children.OfType<StackPanel>().Skip(1).FirstOrDefault()!.Children.OfType<TextBlock>().Skip(1).First();
        var dostepny = parent.Children.OfType<StackPanel>().Skip(2).FirstOrDefault()!.Children.OfType<CheckBox>().FirstOrDefault();


        nazwa!.Text = nazwaNew;
        cena!.Text = cenaNew;
        kategoria!.Text = kategoriaNew;
        dostepny!.IsChecked = dostepnyNew;
    }
}