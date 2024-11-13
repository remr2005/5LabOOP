namespace Program
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        decimal Price { get; }
        string ISBN { get; }
    }

    public interface ICustomer
    {
        string Name { get; }
        string Email { get; }
        void AddToCart(IBook book);
        void RemoveFromCart(IBook book);
        decimal Checkout();
    }

    public interface IOrder
    {
        int OrderId { get; }
        ICustomer Customer { get; }
        List<IBook> Books { get; }
        decimal TotalAmount { get; }
        void ProcessOrder();
    }

}
