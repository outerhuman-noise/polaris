using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Polaris.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isSidebarOpen = true;
    [ObservableProperty] private SidebarEntry? _SelectedEntry;
    [ObservableProperty] private string _SearchText = "";
}
