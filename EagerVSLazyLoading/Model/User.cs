using System.ComponentModel.DataAnnotations;

namespace EagerVSLazyLoading.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public User()
        {
        }

        public User(string name, int departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }
    }
}
