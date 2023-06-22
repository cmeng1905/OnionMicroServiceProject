using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Domain.Entities.User
{
    public class Role
    {
        public Role()
        {
            AspNetUserRoles = new List<UserRole>();
        }
        public Guid ID { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<UserRole> AspNetUserRoles { get; set; }

    }
}
