using BucketWithBolts.Context;
using BucketWithBolts.Controller;

namespace BucketWithBolts
{
    internal class Program
    {
        private static DatabaseContext _db = new DatabaseContext();
        private static RouterHUB _routerHUB; 


        static void Main(string[] args)
        {
            _routerHUB = new RouterHUB(_db);
            _routerHUB.InitializeRouters();
        }
    }
}
