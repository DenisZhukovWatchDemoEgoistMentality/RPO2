using BucketWithBolts.Context;
using BucketWithBolts.Controller.Routers;

namespace BucketWithBolts.Controller
{
    public class RouterHUB
    {
        private DatabaseContext _db;

        public AdminRouter Admin_router { get; private set; }
        public UserRouter User_router { get; private set; }
        public ResourceRouter Resource_router { get; private set; }
        public OrderRouter Order_router { get; private set; }
        public FeedbackRouter Feedback_router { get; private set; }


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
        }


        public void InitializeRouters()
        {
            Admin_router = new AdminRouter(_db);
            User_router = new UserRouter(_db);
            Resource_router = new ResourceRouter(_db);
            Order_router = new OrderRouter(_db);
            Feedback_router = new FeedbackRouter(_db);
        }
    }
}