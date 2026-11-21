using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Polaris.Models;

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
    public string Label { get; } = label;
    public Geometry Icon { get; } = icon;
    public int Count { get; } = count;
}

// ----------------- CARDS -----------------

public abstract class CardBase {}

public sealed class NewCharacterCard : CardBase {}

public sealed class CharacterCard(Character character) : CardBase
{
    public Character Character { get; } = character;
    public string Name => Character.Name;
    public string Initial => string.IsNullOrEmpty(Name) ? "?" : Name[..1];
    public string Summary => Character.Summary;
}

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isSidebarOpen = true;
    [ObservableProperty] private SidebarEntry? _SelectedEntry;
    [ObservableProperty] private string _SearchText = "";

    public ObservableCollection<SidebarEntry> SidebarEntries {get;}
    public ObservableCollection<CardBase> Cards { get; } = [ new NewCharacterCard()];

    public MainViewModel()
    {
        SidebarEntries =
        [
            new SidebarHeader("Play Area"),
            new SidebarItem("Characters", Icons.Tray, 2),
            new SidebarItem("Items", Icons.Star, 103),
            new SidebarItem("Magic", Icons.Note, 83),
            new SidebarHeader("Compendium"),
            new SidebarItem("Sources", Icons.Trash, 3),
            new SidebarItem("Homebrew", Icons.Image, 1)
        ];
        SelectedEntry = SidebarEntries[1];

        Cards.Add(new CharacterCard(new Character { Name = "Vivek", Race = "Human", Level = 1, Class = "Warlock"}));
        Cards.Add(new CharacterCard(new Character { Name = "Dylan", Race = "Drow", Level = 1, Class = "Ranger"}));
    }

    [RelayCommand]
    private void CreateCharacter()
    {
        Cards.Insert(1, new CharacterCard(new Character()));
    }

    [RelayCommand]
    private void OpenCharacter(CharacterCard card) {}
}

public static class Icons
{
    public static readonly Geometry Tray  = Geometry.Parse("M3,13 L6,4 H18 L21,13 V20 H3 Z M3,13 H8 L9,15 H15 L16,13 H21");
    public static readonly Geometry Star  = Geometry.Parse("M12,2 L15,9 L22,9.5 L16.5,14 L18.5,21 L12,17 L5.5,21 L7.5,14 L2,9.5 L9,9 Z");
    public static readonly Geometry Trash = Geometry.Parse("M4,6 H20 M9,6 V3 H15 V6 M6,6 L7,21 H17 L18,6");
    public static readonly Geometry Image = Geometry.Parse("M3,4 H21 V20 H3 Z M3,16 L9,10 L14,15 L17,12 L21,16");
    public static readonly Geometry Link  = Geometry.Parse("M10,14 L14,10 M8,12 L5,15 A3,3 0 0 0 9,19 L12,16 M16,12 L19,9 A3,3 0 0 0 15,5 L12,8");
    public static readonly Geometry Quote = Geometry.Parse("M4,10 H10 V18 H4 Z M14,10 H20 V18 H14 Z M4,10 Q4,5 9,5 M14,10 Q14,5 19,5");
    public static readonly Geometry Note  = Geometry.Parse("M5,3 H15 L19,7 V21 H5 Z M8,11 H16 M8,15 H16");
    public static readonly Geometry Code  = Geometry.Parse("M8,7 L3,12 L8,17 M16,7 L21,12 L16,17 M14,4 L10,20");
    public static readonly Geometry Tag   = Geometry.Parse("M3,3 H11 L21,13 L13,21 L3,11 Z M7.5,7.5 H7.6");
}