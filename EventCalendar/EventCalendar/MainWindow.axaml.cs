using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace EventCalendar;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DodajWydarzenie(object? sender, RoutedEventArgs e)
    {
        if ((DniTygodnia.SelectedItem as ComboBoxItem)?.Content?.ToString() != "Dni Tygodnia" && WydarzenieName.Text != "" && WydarzenieOpis.Text != "")
        {
            if (WydarzenieOpis.Text!.Length >= 10)
            {
                ListaWydarzen.Items.Add(
                    new ListBoxItem
                    {
                        Content = new StackPanel
                        {
                            Children =
                            {
                                new TextBlock
                                {
                                    Text = WydarzenieName.Text,
                                    FontWeight = FontWeight.Bold,
                                    FontSize = 18
                                },
                                new TextBlock { Text = (DniTygodnia.SelectedItem as ComboBoxItem)?.Content?.ToString() },
                                new TextBlock { Text = $"{WydarzenieOpis.Text?[0..10]}..." },
                                new TextBlock { Text = WydarzenieOpis.Text, IsVisible = false },
                                new CheckBox { Content = "Ulubione" }
                            }
                        }
                    }
                );
            }
            else
            {
                ListaWydarzen.Items.Add(
                    new ListBoxItem
                    {
                        Content = new StackPanel
                        {
                            Children =
                            {
                                new TextBlock
                                {
                                    Text = WydarzenieName.Text,
                                    FontWeight = FontWeight.Bold,
                                    FontSize = 18
                                },
                                new TextBlock { Text = (DniTygodnia.SelectedItem as ComboBoxItem)?.Content?.ToString() },
                                new TextBlock { Text = $"{WydarzenieOpis.Text}" },
                                new TextBlock { Text = WydarzenieOpis.Text, IsVisible = false },
                                new CheckBox { Content = "Ulubione" }
                            }
                        }
                    }
                );
            }

            WydarzenieName.Text = "";
            WydarzenieOpis.Text = "";
            DniTygodnia.SelectedIndex = 7;
        }
    }

    private void ShowWydarzenie(object? sender, TappedEventArgs e)
    {
        if (ListaWydarzen.SelectedItem is ListBoxItem selectedItem)
        {
            var staticPanel = selectedItem.GetVisualDescendants().OfType<StackPanel>().First();
            var nazwa = staticPanel.Children.OfType<TextBlock>().First().Text;
            var dzienTyg = staticPanel.Children.OfType<TextBlock>().Skip(1).First().Text;
            var opis = staticPanel.Children.OfType<TextBlock>().Skip(3).First().Text;
            var ulubione = staticPanel.Children.OfType<CheckBox>().First().IsChecked!.Value;

            new FullWydarzenie(nazwa!, dzienTyg!, opis!, ulubione).ShowDialog(this);
        }
    }
}