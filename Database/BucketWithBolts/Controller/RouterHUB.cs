using BucketWithBolts.Context;
using BucketWithBolts.Controller.Routers;

namespace BucketWithBolts.Controller
{
    /// <summary>
    /// HUB для всех роутеров
    /// </summary>
    public class RouterHUB
    {
        private DatabaseContext _db;

        /// <summary>
        /// Роутер таблицы Admins
        /// </summary>
        public AdminRouter Admin_router { get; private set; }
        /// <summary>
        /// Роутер таблицы Users
        /// </summary>
        public UserRouter User_router { get; private set; }
        /// <summary>
        /// Роутер таблицы Resources
        /// </summary>
        public ResourceRouter Resource_router { get; private set; }
        /// <summary>
        /// Роутер таблицы Orders
        /// </summary>
        public OrderRouter Order_router { get; private set; }
        /// <summary>
        /// Роутер таблицы Feedbacks
        /// </summary>
        public FeedbackRouter Feedback_router { get; private set; }
        /// <summary>
        /// Роутер таблицы Images
        /// </summary>
        public ImageRouter Image_Router { get; private set; }
        /// <summary>
        /// Роутер таблицы Resource_Images
        /// </summary>
        public ResourceImageRouter Resource_Image_Router { get; private set; }
        /// <summary>
        /// Роутер таблицы Correspodences
        /// </summary>
        public CorrespondenceRouter Correspondence_router { get; private set; }


        public RouterHUB(DatabaseContext db)
        {
            // Если база не передана, бросаем ошибку сразу
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // Инициализация сразу в конструкторе
            Admin_router = new AdminRouter(_db);
            User_router = new UserRouter(_db);
            Resource_router = new ResourceRouter(_db);
            Order_router = new OrderRouter(_db);
            Feedback_router = new FeedbackRouter(_db);
            Image_Router = new ImageRouter(_db);
            Resource_Image_Router = new ResourceImageRouter(_db);
            Correspondence_router = new CorrespondenceRouter(_db);
        }
    }
}