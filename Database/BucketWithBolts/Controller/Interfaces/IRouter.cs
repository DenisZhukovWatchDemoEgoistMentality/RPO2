namespace BucketWithBolts.Controller.Interfaces
{
    /// <summary>
    /// Базовый интерфейс роутера таблиц
    /// </summary>
    public interface IRouter { }

    /// <summary>
    /// Интерфейс роутера таблиц
    /// </summary>
    /// <typeparam name="T">Модель таблицы</typeparam>
    public interface IRouter<T> : IRouter where T : class
    {
        /// <summary>
        /// Добавление в таблицу
        /// </summary>
        /// <param name="newItem">Новый предмет</param>
        /// <returns>Прошла ли операция</returns>
        bool Post(T newItem);
        /// <summary>
        /// Получение предмета из таблицы по id
        /// </summary>
        /// <param name="itemId">ID пользователя</param>
        /// <returns>Предмет, при условии что он существует</returns>
        T? GetToId(int itemId);
        /// <summary>
        /// Получение всех предметов таблицы
        /// </summary>
        /// <returns>Список значений таблицы Users</returns>
        List<T>? GetAll();
        /// <summary>
        /// Удаление предмета по id
        /// </summary>
        /// <param name="itemId">ID предмета</param>
        /// <returns>Прошла ли операция</returns>
        bool Delete(int itemId);
    }
}