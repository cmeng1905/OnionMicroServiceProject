using OnionProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PasswordSalt { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? AccountLock { get; set; }

        public bool? ForcePasswordChange { get; set; }

        public int? FailPasswordCount { get; set; }

        public string? Phone { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireDate { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }

}
