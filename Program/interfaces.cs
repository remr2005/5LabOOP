namespace Program
{
    /// <summary>
    /// Интерфейс товара
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { get; }
        /// <summary>
        /// Название товара
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Продавец
        /// </summary>
        IUser Seller { get; }
        /// <summary>
        /// Цена
        /// </summary>
        decimal Price { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
    }
    /// <summary>
    /// Интерфейс юзера системы
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Имя юзера
        /// </summary>
        string Name { get; }
        /// <summary>
        /// электронная почта
        /// </summary>
        string Email { get; }
        /// <summary>
        /// заказ
        /// </summary>
        List<IOrder> Orders { get; }
        /// <summary>
        /// Баланс
        /// </summary>
        decimal Balance { get; set; }
        /// <summary>
        /// Обновляет баланс
        /// </summary>
        void UpdateBalance(decimal Sum);
    }
    /// <summary>
    /// Итерфейс Товара
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        int OrderId { get; }
        /// <summary>
        /// Юзер
        /// </summary>
        IUser Customer { get; }
        /// <summary>
        /// Список продуктов
        /// </summary>
        List<IProduct> Products { get; }
        /// <summary>
        /// Добавить товар в заказ
        /// </summary>
        void AddToOrder(IProduct product);
        /// <summary>
        /// Финальный счет
        /// </summary>
        decimal TotalAmount { get; }
        /// <summary>
        /// Обработать заказ
        /// </summary>
        void ProcessOrder();
    }
}
