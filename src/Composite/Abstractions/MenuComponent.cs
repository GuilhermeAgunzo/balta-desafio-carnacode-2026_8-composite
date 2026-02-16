namespace Composite.Abstractions;

public abstract class MenuComponent(string title, string icon, bool isActive)
{
    public string Title { get; set; } = title;
    public string Icon { get; set; } = icon;
    public bool IsActive { get; set; } = isActive;

    public abstract void Render(int indent = 0);
    public abstract int CountItems();
}
