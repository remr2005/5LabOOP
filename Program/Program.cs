namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание продавца
            var seller = new Seller("John Doe", "john@example.com");

            // Создание товаров
            var product1 = new Product("Ноутбук", seller, 1500.00m, "Топ амд амд");
            var product2 = new Product("Хуавей", seller, 800.00m, "Топ китай партия китай партия");

            // Добавление товаров к продавцу
            seller.AddProduct(product1);
            seller.AddProduct(product2);

            // Создание покупателя
            var buyer = new Buyer("Jane Smith", "jane@example.com");
            buyer.UpdateBalance(10000);

            // Создание заказа
            var order = new Order(buyer);
            order.AddToOrder(product1);
            order.AddToOrder(product2);

            // Обработка заказа
            order.ProcessOrder();
            Console.WriteLine($"Окончательная цена заказа: {order.TotalAmount}$");
            Console.WriteLine(seller.Balance);
        }
    }
}