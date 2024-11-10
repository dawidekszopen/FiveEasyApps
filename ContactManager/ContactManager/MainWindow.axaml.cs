using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace ContactManager;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DodajKontaktPopUp(object? sender, RoutedEventArgs e)
    {
        new AddContact().ShowDialog(this);
    }

    
    
    public void DodajKontakt(string imie, string nazwisko, string nrTel, string email)
    {
        ListaKontaktow.Items.Add(
            new ListBoxItem
            {
                Content = new StackPanel
                {
                    Children =
                    {
                        new StackPanel
                        {  
                            Children =
                            {
                                new TextBlock{Text = "Imie:", FontWeight = FontWeight.Bold},
                                new TextBlock{Text = $"{imie}"},
                            }
                        },                        
                        new StackPanel
                        {  
                            Children =
                            {
                                new TextBlock{Text = "Nazwisko:", FontWeight = FontWeight.Bold},
                                new TextBlock{Text = $"{nazwisko}"},
                            }
                        },                        
                        new StackPanel
                        {  
                            Children =
                            {
                                new TextBlock{Text = "Numer Telefonu:", FontWeight = FontWeight.Bold},
                                new TextBlock{Text = $"{nrTel}"},
                            }
                        },                        
                        new StackPanel
                        {  
                            Children =
                            {
                                new TextBlock{Text = "Email:", FontWeight = FontWeight.Bold},
                                new TextBlock{Text = $"{email}"},
                            }
                        },
                        new CheckBox{Content = "Ulubiony kontakt"},
                        new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Children =
                            {
                                new Button{Content = "Edytuj", Margin = new Thickness(0, 0, 20, 0)},
                                new Button{Content = "Usuń", }
                            }
                        }
                    }
                }
            }
        );
    }

    private void DeleteContact(object? sender, RoutedEventArgs e)
    {
        var parentListBoxItem = (((sender as Button)!.Parent as StackPanel)!.Parent as StackPanel)!.Parent as ListBoxItem;

        ListaKontaktow.Items.Remove(parentListBoxItem);
    }

    public void EditContact(object? parentObject, string imieNew, string nazwiskoNew, string nrTelNew, string emailNew)
    {
        var parent = parentObject as StackPanel;

        var imie = parent!.Children.OfType<StackPanel>().First().Children.OfType<TextBlock>().Skip(1).First();
        var nazwisko = parent.Children.OfType<StackPanel>().Skip(1).First().Children.OfType<TextBlock>().Skip(1).First();
        var nrtel = parent.Children.OfType<StackPanel>().Skip(2).First().Children.OfType<TextBlock>().Skip(1).First();
        var email = parent.Children.OfType<StackPanel>().Skip(3).First().Children.OfType<TextBlock>().Skip(1).First();

        imie.Text = imieNew;
        nazwisko.Text = nazwiskoNew;
        nrtel.Text = nrTelNew;
        email.Text = emailNew;
    }

    private void EditKontaktPopUp(object? sender, RoutedEventArgs e)
    {
        var parent = ((sender as Button)!.Parent as StackPanel)!.Parent as StackPanel;

        var imie = parent!.Children.OfType<StackPanel>().First().Children.OfType<TextBlock>().Skip(1).First().Text;
        var nazwisko = parent.Children.OfType<StackPanel>().Skip(1).First().Children.OfType<TextBlock>().Skip(1).First().Text;
        var nrtel = parent.Children.OfType<StackPanel>().Skip(2).First().Children.OfType<TextBlock>().Skip(1).First().Text;
        var email = parent.Children.OfType<StackPanel>().Skip(3).First().Children.OfType<TextBlock>().Skip(1).First().Text;
        
        var editKontaktPopUp = new EditContact();
        
        editKontaktPopUp.ShowDialog(this);
        editKontaktPopUp.ShowKontakt(parent, imie!, nazwisko!, nrtel!, email!);
    }

    private void Filtruj(object? sender, RoutedEventArgs e)
    {
        switch ((Filtry.SelectedItem as ComboBoxItem)?.Content?.ToString())
        {
            case "Wszystko":
                foreach (var kontakt  in ListaKontaktow.Items)
                {
                    (kontakt as ListBoxItem)!.IsVisible = true;
                }
                break;
            case "Ulubione":
                foreach (var kontakt  in ListaKontaktow.Items)
                {
                    (kontakt as ListBoxItem)!.IsVisible = false;

                    var staticPanel = (kontakt as ListBoxItem)?.GetVisualDescendants().OfType<StackPanel>().First();

                    var chceckBox = staticPanel?.Children.OfType<CheckBox>().First();

                    if (chceckBox?.IsChecked == true)
                    {
                        (kontakt as ListBoxItem)!.IsVisible = true;
                    }
                    else
                    {
                        (kontakt as ListBoxItem)!.IsVisible = false;
                    }
                }
                break;
        }
    }
}