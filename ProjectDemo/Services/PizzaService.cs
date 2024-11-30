namespace ProjectDemo.Services;

public class PizzaService
{
    private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
    {
        new Pizza
        {
            Name = "Pizza 1",
            Image = "pizza_1.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 2",
            Image = "pizza_2.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 3",
            Image = "pizza_3.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 4",
            Image = "pizza_4.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 5",
            Image = "pizza_5.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 6",
            Image = "pizza_6.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 7",
            Image = "pizza_7.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 8",
            Image = "pizza_8.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 9",
            Image = "pizza_9.png",
            Price = 69
        }, 
        new Pizza
        {
            Name = "Pizza 10",
            Image = "pizza_10.png",
            Price = 69
        }
        
    };
    public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
    
    public IEnumerable<Pizza> GetPopularPizzas(int count = 6) =>
        _pizzas.OrderBy(p => Guid.NewGuid())
        .Take(count);
    
    public IEnumerable<Pizza> SearchPizzas(string searchTerm) =>
        string.IsNullOrWhiteSpace(searchTerm)
        ? _pizzas
        : _pizzas.Where(p=>p.Name.Contains(searchTerm,
        StringComparison.OrdinalIgnoreCase));
}


