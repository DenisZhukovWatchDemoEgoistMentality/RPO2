namespace BucketWithBolts.Services
{
    /// <summary>
    /// Сервис, посылающий сообщения в консоль
    /// </summary>
    public static class InfoMessager
    {
        /// <summary>
        /// Настройка сообщения
        /// </summary>
        private static string GetString(string message, string sender, ConsoleColor textcolor)
        {
            Console.ForegroundColor = textcolor;

            if (sender == "")
                return $"System: {message}";

            return $"{sender}: {message}";
        }

        /// <summary>
        /// Обычное сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="sender">Откуда сообщение</param>
        /// <param name="textcolor">Цвет сообщения</param>
        public static void CreateMessage(string message, string sender = "", ConsoleColor textcolor = ConsoleColor.White)
        {
            Console.Write(GetString(message, sender, textcolor));
            Console.ResetColor();
        }

        /// <summary>
        /// Сообщение об успешном выполнении
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="sender">Откуда сообщение</param>
        /// <param name="textcolor">Цвет сообщения</param>
        public static void CreateSuccessMessage(string message, string sender = "", ConsoleColor textcolor = ConsoleColor.Green)
        {
            Console.Write(GetString(message, sender, textcolor));
            Console.ResetColor();
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="sender">Откуда сообщение</param>
        /// <param name="textcolor">Цвет сообщения</param>
        public static void CreateErrorMessage(string message, string sender = "", ConsoleColor textcolor = ConsoleColor.Red)
        {
            Console.Write(GetString(message, sender, textcolor));
            Console.ResetColor();
        }
    }
}