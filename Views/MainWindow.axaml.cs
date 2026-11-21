using Avalonia.Controls;
using Avalonia.Input;

namespace Polaris.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Toolbar.PointerPressed += (_, e) =>
        {
            if (e.Source != Toolbar || !e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                return;

            if (e.ClickCount == 2)
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            else
                BeginMoveDrag(e);
        };
    }
}