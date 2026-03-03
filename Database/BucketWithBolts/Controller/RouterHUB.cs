using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Routers;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller
{
    /// <summary>
    /// HUB для всех роутеров
    /// </summary>
    public class RouterHUB
    {
        private static RouterHUB _instance;
        private DatabaseContext _db;

        #region -- Роутеры --
        /// <summary>
        /// Роутер таблицы Admins
        /// </summary>
        private AdminRouter Admin_router { get; set; }
        /// <summary>
        /// Роутер таблицы Users
        /// </summary>
        private UserRouter User_router { get; set; }
        /// <summary>
        /// Роутер таблицы Images
        /// </summary>
        private ImageRouter Image_Router { get; set; }
        /// <summary>
        /// Роутер таблицы Resource_Images
        /// </summary>
        private ResourceImageRouter Resource_Image_Router { get; set; }
        /// <summary>
        /// Роутер таблицы Resources
        /// </summary>
        private ResourceRouter Resource_router { get; set; }
        /// <summary>
        /// Роутер таблицы Orders
        /// </summary>
        private OrderRouter Order_router { get; set; }
        /// <summary>
        /// Роутер таблицы Feedbacks
        /// </summary>
        private FeedbackRouter Feedback_router { get; set; }
        /// <summary>
        /// Роутер таблицы Correspodences
        /// </summary>
        private CorrespondenceRouter Correspondence_router { get; set; }
        #endregion

        /// <summary>
        /// Словарь роутеров
        /// </summary>
        private Dictionary<string, IRouter> _routers;


        private RouterHUB(DatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            Admin_router = new AdminRouter(_db);
            User_router = new UserRouter(_db);
            Image_Router = new ImageRouter(_db);
            Resource_Image_Router = new ResourceImageRouter(_db);
            Resource_router = new ResourceRouter(_db);
            Order_router = new OrderRouter(_db);
            Feedback_router = new FeedbackRouter(_db);
            Correspondence_router = new CorrespondenceRouter(_db);

            _routers = new Dictionary<string, IRouter>
            {
                ["Admin"] = Admin_router,
                ["User"] = User_router,
                ["Image"] = Image_Router,
                ["Resource_Image"] = Resource_Image_Router,
                ["Resource"] = Resource_router,
                ["Order"] = Order_router,
                ["Feedbac"] = Feedback_router,
                ["Correspondence"] = Correspondence_router
            };
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db">Модель базы данных</param>
        /// <returns>HUB всех роутеров</returns>
        public static RouterHUB Instance(DatabaseContext db = null)
        {
            if (_instance == null)
            {
                if (db == null)
                    throw new InvalidOperationException("Невозможно создать RouterHUB без контекста БД.");
            
                _instance = new RouterHUB(db);
            }

            return _instance;
        }


        /// <summary>
        /// Получение роутера по используемой им моделью
        /// </summary>
        /// <typeparam name="T">Модель таблицы</typeparam>
        /// <returns>Роутер</returns>
        public IRouter<T>? GetRouter<T>() where T : class
        {
            if (!_routers.TryGetValue(typeof(T).Name, out var router))
            {
                InfoMessager.CreateErrorMessage("Роутер не существует", $"{this.GetType().Name}.GetRouter");
                return null;
            }

            if (router is IRouter<T> typed)
                return typed;

            InfoMessager.CreateErrorMessage($"Тип {typeof(T).Name} не поддерживается", $"{this.GetType().Name}.GetRouter");
            return null;
        }
    }
}