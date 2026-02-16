using Composite.Abstractions;

namespace Composite.Models.Menu;

public class MenuGroup(string title, string icon = "") : MenuComponent(title, icon, true)
{
    public List<MenuComponent> Children { get; set; } = [];

    public override int CountItems()
    {
        int count = 0;

        foreach (var child in Children)
        {
            count += child.CountItems();
        }

        return count;
    }

    public override void Render(int indent = 0)
    {
        var indentation = new string(' ', indent * 2);
        var activeStatus = IsActive ? "✓" : "✗";
        Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

        foreach (var child in Children)
        {
            child.Render(indent + 1);
        }
    }

    public void DisableAllItems()
    {
        foreach (var child in Children)
        {
            child.IsActive = false;

            if (child is MenuGroup group)
            {
                group.DisableAllItems();
            }
        }
    }

    public void AddChild(MenuComponent child)
    {
        Children.Add(child);
    }

    public void RemoveChild(MenuComponent child)
    {
        Children.Remove(child);
    }

    public MenuComponent? FindItemByUrl(string url)
    {
        foreach (var child in Children)
        {
            if (child is MenuItem item && item.Url == url)
            {
                Console.WriteLine($"Encontrado: {item.Title} → {item.Url}");
                return item;
            }
            else if (child is MenuGroup group)
            {
                group.FindItemByUrl(url);
            }
        }

        return null;
    }
}
