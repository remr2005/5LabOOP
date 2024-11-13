namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99m, "1234567890");
            Book book2 = new Book("1984", "George Orwell", 8.99m, "0987654321");

            Customer customer = new Customer("John Doe", "john.doe@example.com");
            customer.AddToCart(book1);
            customer.AddToCart(book2);

            decimal total = customer.Checkout();
            Console.WriteLine($"Общая сумма к оплате: {total:C}");

            Order order = new Order(customer, new List<IBook> { book1, book2 });
            order.ProcessOrder();
        }
    }
}