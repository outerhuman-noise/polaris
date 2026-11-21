using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Polaris.ViewModels;

// ----------------- SIDEBAR -----------------

public abstract class SidebarEntry
{
    public virtual bool isSelectable => true;
}

public sealed class SidebarHeader(string title) : SidebarEntry
{
    public String Title { get; } = title;
    public override bool isSelectable => false;
}

public sealed class SidebarItem(string label, Geometry icon, int count) : SidebarEntry
{
    
}

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isSidebarOpen = true;
    [ObservableProperty] private SidebarEntry? _SelectedEntry;
    [ObservableProperty] private string _SearchText = "";
}
