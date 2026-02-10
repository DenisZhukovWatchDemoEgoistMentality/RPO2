using BucketWithBolts.Context;
using BucketWithBolts.Controller.Routers;

namespace BucketWithBolts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var u = new UserRouter(db);
                var r = new ResourseRouter(db);
                var o = new OrderRouter(db);
            }
        }
    }
}
