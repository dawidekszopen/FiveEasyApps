using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace ToDoList;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ToDoText.Text = "";
    }
    
    private ListBoxItem ToDoPresset(string? text, bool isDone = false)
    {
        var item = new ListBoxItem
        {
            Content = new WrapPanel
            {
                Children =
                {
                    new TextBlock{Classes = { "TodoText" }, Text = text},
                    new CheckBox {IsChecked = isDone}
                }
            }
        };

        return item;
    }

    private void AddTodo(object? sender, RoutedEventArgs e)
    {
        if (ToDoText.Text != "")
        {
            ToDoList.Items.Add(ToDoPresset(ToDoText.Text));
            ToDoText.Text = "";
        }
    }

    private void ShowFiltry(object? sender, RoutedEventArgs e)
    {
        switch ((Filter.SelectedItem as ComboBoxItem)?.Content?.ToString())
        {
            case "Wszystko":
                foreach (var item in ToDoList.Items)
                {
                    (item as ListBoxItem)!.IsVisible = true;
                }
                break;
            case "Zrobione":
                foreach (var item in ToDoList.Items)
                {
                    (item as ListBoxItem)!.IsVisible = true;

                    var wrapPanels = (item as ListBoxItem)?.GetVisualDescendants().OfType<WrapPanel>().FirstOrDefault();

                    if (wrapPanels != null)
                    {
                        var checkBoxTodo = wrapPanels.Children.OfType<CheckBox>().FirstOrDefault();
                        
                        if (checkBoxTodo != null)
                        {
                            if (checkBoxTodo.IsChecked == false)
                            {
                                (wrapPanels.Parent as ListBoxItem)!.IsVisible = false;
                            }
                        }
                    }
 
                }
                break;
            case "Do zrobienia":
                foreach (var item in ToDoList.Items)
                {
                    (item as ListBoxItem)!.IsVisible = true;

                    var wrapPanels = (item as ListBoxItem)?.GetVisualDescendants().OfType<WrapPanel>().FirstOrDefault();

                    if (wrapPanels != null)
                    {
                        var checkBoxTodo = wrapPanels.Children.OfType<CheckBox>().FirstOrDefault();
                        
                        if (checkBoxTodo != null)
                        {
                            if (checkBoxTodo.IsChecked == true)
                            {
                                (wrapPanels.Parent as ListBoxItem)!.IsVisible = false;
                            }
                        }
                    }
 
                }
                break;
        }
    }

    private void DeleteTodo(object? sender, TappedEventArgs e)
    {
        if (ToDoList.SelectedItem is ListBoxItem selectedItem)
        {
            ToDoList.Items.Remove(selectedItem);
        }
    }
}