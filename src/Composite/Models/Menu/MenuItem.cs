using Composite.Abstractions;

namespace Composite.Models.Menu;

public class MenuItem(string title, string url, string icon = "") : MenuComponent(title, icon, true)
{
    public string Url { get; set; } = url;

    public override int CountItems()
    {
        return 1;
    }

    public override void Render(int indent = 0)
    {
        var indentation = new string(' ', indent * 2);
        var activeStatus = IsActive ? "✓" : "✗";
        Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
    }
}
