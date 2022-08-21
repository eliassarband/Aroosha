using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public interface ISecurityRepository
    {
        IEnumerable<MenuCategory>  MenuCategories { get; }
        IEnumerable<MenuItem> MenuItems { get; }
        IEnumerable<MenuAccess> MenuAccesses { get; }

        IEnumerable<MenuCategory> AllMenuItems { get; }

        IEnumerable<MenuCategory> UserMenuItems { get; }

        IEnumerable<User> Users { get; }

        IEnumerable<Person> Persons { get; }

        IEnumerable<MenuAction> MenuActions { get; }

        IEnumerable<MenuActionAccess> MenuActionAccesses { get; }

        bool DeleteMenuActionAccess(IEnumerable<MenuActionAccess> accesses);

        bool DeleteMenuAccess(IEnumerable<MenuAccess> accesses);

        bool DeleteUser(IEnumerable<User> users);

        bool DeletePerson(IEnumerable<Person> persons);

        bool SavePerson(Person person);

        bool SaveUser(User user);

        IEnumerable<Group> Groups { get; }

        IEnumerable<GroupUser> GroupUsers { get; }

        bool DeleteGroup(IEnumerable<Group> groups);

        bool SaveGroup(Group group);

        bool DeleteGroupUsers(IEnumerable<GroupUser> groupUsers);

        bool SaveGroupUsers(IEnumerable<GroupUser> groupUsers);

        IEnumerable<User> UserLoginAttempts { get; }

        IEnumerable<User> UserLoginedDatas { get; }

        IEnumerable<Tenant> Tenants { get;  }

        IEnumerable<Tenant> TenantsStructure { get; }

        bool SaveMenuAccess(IEnumerable<MenuAccess> menuAccesses);

        bool SaveMenuActionAccess(IEnumerable<MenuActionAccess> menuActionAccesses);

        bool ChangePassword(User user);

        bool SaveUserSetting(UserSetting userSetting);

        void SaveChanges();
    }
}
