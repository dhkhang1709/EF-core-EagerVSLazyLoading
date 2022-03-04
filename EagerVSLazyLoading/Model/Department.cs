using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EagerVSLazyLoading.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }
    }
}
