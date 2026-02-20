using BucketWithBolts.Context;
using BucketWithBolts.Controller;

namespace BucketWithBolts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                RouterHUB hub = new RouterHUB(db);
                
            }

        }
    }
}
