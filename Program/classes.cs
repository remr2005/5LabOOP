namespace Program
{
    public class Book : IBook
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public string ISBN { get; private set; }

        public Book(string title, string author, decimal price, string isbn)
        {
            Title = title;
            Author = author;
            Price = price;
            ISBN = isbn;
        }
    }

    public class Customer : ICustomer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        private List<IBook> cart;

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            cart = new List<IBook>();
        }

        public void AddToCart(IBook book)
        {
            cart.Add(book);
        }

        public void RemoveFromCart(IBook book)
        {
            cart.Remove(book);
        }

        public decimal Checkout()
        {
            decimal total = cart.Sum(book => book.Price);
            cart.Clear();
            return total;
        }
    }

    public class Order : IOrder
    {
        private static int _orderCounter = 0;
        public int OrderId { get; private set; }
        public ICustomer Customer { get; private set; }
        public List<IBook> Books { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Order(ICustomer customer, List<IBook> books)
        {
            OrderId = ++_orderCounter;
            Customer = customer;
            Books = new List<IBook>(books);
            TotalAmount = books.Sum(book => book.Price);
        }

        public void ProcessOrder()
        {
            // Пример логики обработки заказа
            Console.WriteLine($"Заказ #{OrderId} на сумму {TotalAmount:C} успешно обработан.");
        }
    }
}
