namespace BucketWithBolts.Models.Constructors
{
    /// <summary>
    /// Псевдо-конструкторы, создающие объекты для заполнения в таблицу 
    /// </summary>
    public static class ModelsConstructors
    {
        /// <summary>
        /// Псевдо-констуктор для объекта Admin
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Объект Admin</returns>
        public static Admin Create_Admin(string login, string password)
        {
            return new Admin() { 
                Login = login,
                Password = password
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Condition
        /// </summary>
        /// <param name="name">Название состояния</param>
        /// <returns>Объект Condition</returns>
        public static Condition Create_Condition(string name)
        {
            return new Condition() { 
                Name = name 
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Correspondence
        /// </summary>
        /// <param name="recipientId">ID получателя</param>
        /// <param name="senderId">ID отправителя</param>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Объект Correspondence</returns>
        public static Correspondence Create_Correspondence(int recipientId, int senderId, string message)
        {
            return new Correspondence()
            {
                Recipient_Id = recipientId,
                Sender_Id = senderId,
                Message = message,
                DateTime = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Feedback
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="stars">Количество звезд</param>
        /// <param name="desc">Текст отзыва (опционально)</param>
        /// <returns>Объект Feedback</returns>
        public static Feedback Create_Feedback(int orderId, int stars, string? desc = null)
        {
            return new Feedback() { 
                Order_id = orderId,
                Stars = stars,
                Description = desc
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Image
        /// </summary>
        /// <param name="imageSrc">Путь или ссылка на изображение</param>
        /// <returns>Объект Image</returns>
        public static Image Create_Image(string imageSrc)
        {
            return new Image()
            {
                Image_src = imageSrc
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Order
        /// </summary>
        /// <param name="resourceId">ID ресурса</param>
        /// <param name="customerId">ID покупателя</param>
        /// <param name="quantity">Количество</param>
        /// <returns>Объект Order</returns>
        public static Order Create_Order(int resourceId, int customerId, int quantity)
        {
            return new Order()
            {
                Resource_id = resourceId,
                Customer_id = customerId,
                Quantity = quantity,
                Status = 1
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта OrderStatus
        /// </summary>
        /// <param name="name">Название статуса</param>
        /// <returns>Объект OrderStatus</returns>
        public static OrderStatus Create_OrderStatus(string name)
        {
            return new OrderStatus()
            {
                Name = name
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта Resource
        /// </summary>
        /// <param name="ownerId">ID владельца</param>
        /// <param name="name">Название ресурса</param>
        /// <param name="price">Цена</param>
        /// <param name="conditionId">ID состояния</param>
        /// <param name="desc">Описание (опционально)</param>
        /// <returns>Объект Resource</returns>
        public static Resource Create_Resource(int ownerId, string name, int price, 
            int conditionId, string? desc = null)
        {
            return new Resource()
            {
                Owner_id = ownerId,
                Name = name,
                Description = desc,
                Price = price,
                Condition = conditionId,
                Status = 1
            };
        }

        /// <summary>
        /// Псевдо-конструктор для связи Resource_Image
        /// </summary>
        /// <param name="resourceId">ID ресурса</param>
        /// <param name="imageId">ID изображения</param>
        /// <returns>Объект Resource_Image</returns>
        public static Resource_Image Create_ResourceImage(int resourceId, int imageId)
        {
            return new Resource_Image()
            {
                Resource_id = resourceId,
                Image_scr_id = imageId
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта ResourceStatus
        /// </summary>
        /// <param name="name">Название статуса</param>
        /// <returns>Объект ResourceStatus</returns>
        public static ResourceStatus Create_ResourceStatus(string name)
        {
            return new ResourceStatus()
            {
                Name = name
            };
        }

        /// <summary>
        /// Псевдо-конструктор для объекта User
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="mail">Почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="balance">Баланс (по умолчанию 0)</param>
        /// <returns>Объект User</returns>
        public static User Create_User(string login, string mail, string password, int balance = 0)
        {
            return new User()
            {
                Login = login,
                Mail = mail,
                Password = password,
                Balance = balance,
                RegistrationDate = DateTime.UtcNow
            };
        }
    }
}