using EagerVSLazyLoading.Database;
using EagerVSLazyLoading.Query;
using System;
using System.Linq;

namespace EagerVSLazyLoading
{
    class Program
    {
        private static void Test_1()
        {
            var lazyDbContext = new LazyDbContext();
            var eagerDbContext = new EagerDbContext();
            var query = new DepartmentQuery(eagerDbContext, lazyDbContext);

            var eagerResult = query.GetDepartmentById_Eager(3);
            try
            {
                // This code will throw exception since the query didn't get the users
                Console.WriteLine(eagerResult.Users.First().Name);
            }
            catch
            {
                // This code should be reached
                Console.WriteLine("Exception!!!");
            }

            var lazyResult = query.GetDepartmentById_Lazy(3);
            try
            {
                // This code won't exception since the query didn't get the users
                // However, the lazyloading proxy will fetch the users automatically if we call it
                Console.WriteLine(lazyResult.Users.First().Name);
            }
            catch
            {
                // This code shouldn't be reached
                Console.WriteLine("Exception!!!");
            }
            lazyDbContext.Dispose();
        }

        private static void Test_2()
        {
            var lazyDbContext = new LazyDbContext();
            var eagerDbContext = new EagerDbContext();
            var query = new DepartmentQuery(eagerDbContext, lazyDbContext);

            var eagerResult = query.GetDepartmentById_Eager(3);
            try
            {
                // This code will throw exception since the query didn't get the users
                Console.WriteLine(eagerResult.Users.First().Name);
            }
            catch
            {
                // This code should be reached
                Console.WriteLine("Exception!!!");
            }

            var lazyResult = query.GetDepartmentById_Lazy(3);
            lazyDbContext.Dispose();

            try
            {
                // This code will now cause an exception since the query didn't get the users
                // The DB context was disposed as well so the lazyloading proxy cannot fetch the users automatically if we call it
                Console.WriteLine(lazyResult.Users.First().Name);
            }
            catch
            {
                // This code should be reached
                Console.WriteLine("Exception!!!");
            }
            lazyDbContext.Dispose();
        }

        private static void Test_3()
        {
            var lazyDbContext = new LazyDbContext();
            var eagerDbContext = new EagerDbContext();
            var query = new DepartmentQuery(eagerDbContext, lazyDbContext);

            var eagerResult = query.GetDepartmentByIdInclude_Eager(3);
            try
            {
                // This code won't throw exception since the query already include get the users to the result
                Console.WriteLine(eagerResult.Users.First().Name);
            }
            catch
            {
                // This code shouldn't be reached
                Console.WriteLine("Exception!!!");
            }

            var lazyResult = query.GetDepartmentByIdInclude_Lazy(3);
            lazyDbContext.Dispose();

            try
            {
                // This code won't cause an exception since the query already get the users
                Console.WriteLine(lazyResult.Users.First().Name);
            }
            catch
            {
                // This code shouldn't be reached
                Console.WriteLine("Exception!!!");
            }
            lazyDbContext.Dispose();
        }

        static void Main(string[] args)
        {
            // Go through test 1-by-1 by un-comment the following code
            //Test_1();
            //Test_2();
            //Test_3();
        }
    }
}
