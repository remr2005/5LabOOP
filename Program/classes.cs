namespace Program
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class Buyer : IUser
    {
        /// <summary>
        /// Имя юзера
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// электронная почта
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// заказы
        /// </summary>
        public List<IOrder> Orders { get; set; }
        /// <summary>
        /// Баланс
        /// </summary>
        public decimal Balance { get; set; } = 0;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="email">email</param>
        public Buyer(string name, string email)
        {
            Name = name;
            Email = email;
            Orders = new List<IOrder>();
        }
        /// <summary>
        /// Обновление баланса на число
        /// </summary>
        /// <param name="Sum">Число</param>
        public void UpdateBalance(decimal Sum)
        {
            Balance += Sum;
        }
    }
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// ID товара
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Продавец
        /// </summary>
        public IUser Seller { get; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Айди товара</param>
        /// <param name="title">Название товара</param>
        /// <param name="seller">Продавец</param>
        /// <param name="price">Цена</param>
        /// <param name="description">Описание</param>
        public Product(string title, Seller seller, decimal price, string description)
        {
            Random random = new Random();

            ID = random.Next(1000000, 9999999);
            Title = title;
            Seller = seller;
            Price = price;
            Description = description;
        }
    }
    /// <summary>
    /// Продавец
    /// </summary>
    public class Seller : Buyer
    {
        /// <summary>
        /// Продукты на продажу
        /// </summary>
        public List<IProduct> Products_to_Sell { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Seller(string name, string email) : base(name, email)
        {
            Products_to_Sell = new List<IProduct>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(IProduct product)
        {
            Products_to_Sell.Add(product);
            Console.WriteLine($"Товар {product.Title} добавлен продавцом {Name}.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(IProduct product)
        {
            Products_to_Sell.Remove(product);
            Console.WriteLine($"Товар {product.Title} удален продавцом {Name}.");
        }
    }
    public class Order : IOrder
    {
        /// <summary>
        /// ID
        /// </summary>
        public int OrderId { get; }
        /// <summary>
        /// Покупатель
        /// </summary>
        public IUser Customer { get; }
        /// <summary>
        /// Товары 
        /// </summary>
        public List<IProduct> Products { get; }
        /// <summary>
        /// Общая сумма товаров
        /// </summary>
        public decimal TotalAmount => Products.Sum(product => product.Price);
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="customer"></param>
        public Order(IUser customer)
        {
            Random random = new Random();

            OrderId = random.Next(1000000, 9999999);
            Customer = customer;
            Products = new List<IProduct>();
        }
        /// <summary>
        /// Добавление продукта
        /// </summary>
        /// <param name="product"></param>
        public void AddToOrder(IProduct product)
        {
            Products.Add(product);
            Console.WriteLine($"Продукт #{product.ID} добавлен в корзину к {Customer.Name}");
        }
        /// <summary>
        /// Обработка заказа
        /// </summary>
        public void ProcessOrder()
        {
            Console.WriteLine($"Выполняем заказ #{OrderId} для {Customer.Name}.");

            if (Customer.Balance >= TotalAmount)
            {
                Customer.Balance -= TotalAmount;

                foreach (var product in Products)
                {
                    if (product.Seller is Seller seller)
                    {
                        seller.UpdateBalance(product.Price);
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Продавец для товара {product.Title} не найден или не является типом Seller.");
                    }
                }

                Customer.Orders.Remove(this); // Удаление текущего заказа из списка заказов пользователя
                Console.WriteLine("Заказ выполнен.");
                return;
            }
            Console.WriteLine("Недостаточно средств. Заказ отклонён.");
        }
    }
}
