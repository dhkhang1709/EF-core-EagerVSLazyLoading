using EagerVSLazyLoading.Database;
using EagerVSLazyLoading.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EagerVSLazyLoading.Query
{
    internal class DepartmentQuery
    {
        private readonly LazyDbContext _lazyDbContext;
        private readonly EagerDbContext _eagerDbContext;

        internal DepartmentQuery(EagerDbContext eagerDbContext, LazyDbContext lazyDbContext)
        {
            _eagerDbContext = eagerDbContext;
            _lazyDbContext = lazyDbContext;
        }

        internal Department GetDepartmentById_Eager(int id)
        {
            var result = _eagerDbContext.Departments.FirstOrDefault(x => x.Id == id);
            return result;
        }

        internal Department GetDepartmentById_Lazy(int id)
        {
            var result = _lazyDbContext.Departments.FirstOrDefault(x => x.Id == id);
            return result;
        }

        internal Department GetDepartmentByIdInclude_Eager(int id)
        {
            var result = _eagerDbContext.Departments.Include(x => x.Users).FirstOrDefault(x => x.Id == id);
            return result;
        }

        internal Department GetDepartmentByIdInclude_Lazy(int id)
        {
            var result = _lazyDbContext.Departments.Include(x => x.Users).FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
