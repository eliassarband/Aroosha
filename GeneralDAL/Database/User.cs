using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralDAL.Database
{
    [Table("User", Schema = "Sec")]
    public class User
    {
        public int Id { get; set; }

        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [MaxLength(60)]
        public string Username { get; set; }

        [MaxLength(60)]
        public string HashPassword { get; set; }

        public bool Active { get; set; }

        public bool ForceFirstLoginChange { get; set; }

        [MaxLength(200)]
        public string PasswordHint { get; set; }

        [ForeignKey("TenantId")]
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<MenuAccess> MenuAccesses { get; set; }

        public virtual ICollection<MenuActionAccess> MenuActionAccesses{ get; set; }

        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }

        public virtual ICollection<LoginedData> LoginedDatas { get; set; }

        public virtual ICollection<UserSetting> UserSettings { get; set; }

        public virtual ICollection<UserDefaultForm> UserDefaultForms { get; set; }

    }
}
