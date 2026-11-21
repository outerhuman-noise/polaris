using Avalonia.Controls;

namespace Polaris.Models;

public class Character
{
    public string Name { get; set; } = "New Character";
    public string Race { get; set; } = "";
    public string Class { get; set; } = "";
    public int Level { get; set; } = 1;
    public string Summary { get; set; } = "tbd";
}