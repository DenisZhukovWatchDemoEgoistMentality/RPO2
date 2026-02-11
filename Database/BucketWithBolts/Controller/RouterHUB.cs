using BucketWithBolts.Context;
using BucketWithBolts.Controller.Routers;

namespace BucketWithBolts.Controller
{
    public class RouterHUB
    {
        private DatabaseContext _db;

        public AdminRouter Admin_router;
        public UserRouter User_router;
        public ResourceRouter Resource_router;
        public OrderRouter Order_router;
        public FeedbackRouter Feedback_router;


        public RouterHUB(DatabaseContext db)
        {
            _db = db;
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