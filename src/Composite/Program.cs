using Composite.Models.Menu;

// DESAFIO: Sistema de Menus Hierárquicos
// PROBLEMA: Um sistema de gestão de conteúdo precisa construir menus com itens simples e submenus aninhados
// O código atual trata itens individuais e grupos de forma diferente, complicando operações recursivas

// Contexto: Sistema CMS que precisa renderizar menus complexos com múltiplos níveis
// Alguns itens são links simples, outros são menus que contêm mais itens


Console.WriteLine("=== Sistema de Menus CMS ===\n");

var mainMenu = new MenuGroup("Menu Principal", "📋");

var home = new MenuItem("Home", "/", "🏠");
mainMenu.AddChild(home);

var productsMenu = new MenuGroup("Produtos", "📦");
productsMenu.AddChild(new MenuItem("Todos", "/produtos"));
productsMenu.AddChild(new MenuItem("Categorias", "/categorias"));
productsMenu.AddChild(new MenuItem("Ofertas", "/ofertas"));

var clothingMenu = new MenuGroup("Roupas", "👕");
clothingMenu.AddChild(new MenuItem("Camisetas", "/roupas/camisetas"));
clothingMenu.AddChild(new MenuItem("Calças", "/roupas/calcas"));
productsMenu.AddChild(clothingMenu);

mainMenu.AddChild(productsMenu);

var adminMenu = new MenuGroup("Administração", "⚙️");
adminMenu.AddChild(new MenuItem("Usuários", "/admin/usuarios"));
adminMenu.AddChild(new MenuItem("Configurações", "/admin/config"));
mainMenu.AddChild(adminMenu);

mainMenu.Render();

Console.WriteLine();

Console.WriteLine("=== Contando itens no menu ===");
Console.WriteLine($"\nTotal de itens no menu: {mainMenu.CountItems()}");


Console.WriteLine("=== Procurando item por URL ===");
string url = "/roupas/camisetas";

Console.WriteLine($"Procurando por URL: {url}");
var item = mainMenu.FindItemByUrl(url);

if (item is null)
{
    Console.WriteLine($"\n✗ Item não encontrado para a URL: {url}");
}
else
{
    Console.WriteLine($"\n✓ Item encontrado: {item.Title}");
}