using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace SurveyCreator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void NewPytanieNewPytanie(object? sender, RoutedEventArgs e)
    {
        var popUpNewPytanie = new NewPytanie();
        popUpNewPytanie.ShowDialog(this);
    }

    
    
    public void NewPytanie(string pytanie, string kategoria,List<string> odpowiedzi, int typOdpoweidz, int ID)
    {
        
        switch (typOdpoweidz)
        {
            case 1:
                Ankieta.Items.Add(
                    new ListBoxItem
                    {
                        Classes = { kategoria, "Wszystko" },
                        Content = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            Children =
                            {
                                new TextBlock{Text = pytanie, FontWeight = FontWeight.Bold, FontSize = 18},
                                new TextBlock{Text = kategoria, FontStyle = FontStyle.Italic, FontSize = 15},
                                new RadioButton{Content = odpowiedzi[0], GroupName = $"pytanie{ID}", Name = $"odpowiedzi1{ID}"},
                                new RadioButton{Content = odpowiedzi[1], GroupName = $"pytanie{ID}", Name = $"odpowiedzi2{ID}"},
                                new RadioButton{Content = odpowiedzi[2], GroupName = $"pytanie{ID}", Name = $"odpowiedzi3{ID}"},
                                new RadioButton{Content = odpowiedzi[3], GroupName = $"pytanie{ID}", Name = $"odpowiedzi4{ID}"},
                            }
                        }
                    }
                    );
                break;
            case 2:
                Ankieta.Items.Add(
                    new ListBoxItem
                    {
                        Classes = { kategoria, "Wszystko" },
                        Content = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            Children =
                            {
                                new TextBlock{Text = pytanie, FontWeight = FontWeight.Bold, FontSize = 18},
                                new TextBlock{Text = kategoria, FontStyle = FontStyle.Italic, FontSize = 15},
                                new CheckBox{Content = odpowiedzi[0], Name = $"odpowiedzi1{ID}"},
                                new CheckBox(){Content = odpowiedzi[1], Name = $"odpowiedzi2{ID}"},
                                new CheckBox(){Content = odpowiedzi[2], Name = $"odpowiedzi3{ID}"},
                                new CheckBox(){Content = odpowiedzi[3], Name = $"odpowiedzi4{ID}"},
                            }
                        }
                    }
                );
                break;
        }

        if (!KategoriaComboBox.Items.Contains(kategoria))
        {
            KategoriaComboBox.Items.Add(kategoria);
        }
    }

    private void PokazFiltry(object? sender, RoutedEventArgs e)
    {
        foreach (var item in Ankieta.Items)
        {
            (item as ListBoxItem)!.IsVisible = true;

            Console.WriteLine((KategoriaComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString());

            if ((KategoriaComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() != "Wszystko")
            {
                if ((item as ListBoxItem)!.Classes.Contains((KategoriaComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty) == false)
                {
                    (item as ListBoxItem)!.IsVisible = false;
                }
                
                foreach (var i in (item as ListBoxItem)!.Classes)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}