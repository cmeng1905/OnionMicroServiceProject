using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Domain.Entities.User
{
    public class UserRole
    {
        [Column("UserID", Order = 0), Key]
        public Guid UserID { get; set; }
        [Column("RoleID", Order = 1), Key]
        public Guid? RoleID { get; set; }

        [ForeignKey("UserID")]
        public virtual User AspNetUser { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role AspNetRole { get; set; }

    }
}
