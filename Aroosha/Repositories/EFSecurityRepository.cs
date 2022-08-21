using GeneralDAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public class EFSecurityRepository:ISecurityRepository
    {
        private readonly ArooshaContext context;

        public EFSecurityRepository(ArooshaContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<MenuCategory> MenuCategories
        {
            get { return context.MenuCategories; }
        }

        public IEnumerable<MenuItem> MenuItems
        {
            get { return context.MenuItems.Include("MenuAccesses"); }
        }

        public IEnumerable<MenuAccess> MenuAccesses
        {
            get { return context.MenuAccesses; }
        }

        public IEnumerable<MenuCategory> AllMenuItems
        {
            get { return context.MenuCategories.Include("MenuItems"); }
        }

        public IEnumerable<MenuCategory> UserMenuItems
        {
            get { return context.MenuCategories.Include(mi => mi.MenuItems); }
        }

        public IEnumerable<User> Users
        {
            get { return context.Users.Include(mi => mi.Person).Include(u => u.UserSettings).ThenInclude(us =>us.HomeType); }
        }

        public IEnumerable<Person> Persons
        {
            get { return context.Persons.Include(p => p.PersonUser); }
        }

        public IEnumerable<MenuAction> MenuActions
        {
            get { return context.MenuActions.Include(mi => mi.MenuItem).Include(mi => mi.MenuActionAccesses); }
        }

        public IEnumerable<MenuActionAccess> MenuActionAccesses
        {
            get { return context.MenuActionAccesses; }
        }

        public bool DeleteMenuActionAccess(IEnumerable<MenuActionAccess> accesses)
        {
            try
            {
                foreach (var access in accesses)
                {
                    var ma = context.MenuActionAccesses.FirstOrDefault(g => g.Id == access.Id);

                    if (ma != null)
                        context.MenuActionAccesses.Remove(ma);
                    //context.MenuActionAccesses.Remove(access);
                }
                
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMenuAccess(IEnumerable<MenuAccess> accesses)
        {
            try
            {
                foreach (var access in accesses)
                {
                    var ma = context.MenuAccesses.FirstOrDefault(g => g.Id == access.Id);

                    if (ma != null)
                        context.MenuAccesses.Remove(ma);
                    //context.MenuAccesses.Remove(access);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUser(IEnumerable<User> users)
        {
            try
            {
                foreach (var user in users)
                {
                    context.Users.Remove(user);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletePerson(IEnumerable<Person> persons)
        {
            try
            {
                foreach (var person in persons)
                {
                    context.Persons.Remove(person);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SavePerson(Person person)
        {
            try
            {
                if (person.Id > 0)
                {
                    var p = context.Persons.FirstOrDefault(x => x.Id == person.Id);
                    if (p != null)
                    {
                        p.Code = person.Code;
                        p.StrCode = person.StrCode;
                        p.FirstName = person.FirstName;
                        p.LastName = person.LastName;
                        p.Active = person.Active;
                    }
                }
                else
                    context.Persons.Add(person);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveUser(User user)
        {
            try
            {
                if (user.Id > 0)
                {
                    var u = context.Users.FirstOrDefault(x => x.Id == user.Id);
                    u.PersonId = user.PersonId;
                    u.Username = user.Username;
                    u.HashPassword = user.HashPassword;
                    u.Active = user.Active;
                    u.ForceFirstLoginChange = user.ForceFirstLoginChange;
                    u.PasswordHint = user.PasswordHint;
                    u.TenantId = user.TenantId;
                }
                else
                    context.Users.Add(user);
                
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Group> Groups {
            get { return context.Groups.Include(mi => mi.GroupUsers); }
        }

        public IEnumerable<GroupUser> GroupUsers
        {
            get { return context.GroupUsers.Include(mi => mi.Group); }
        }

        public bool DeleteGroup(IEnumerable<Group> groups)
        {
            try
            {
                foreach (var group in groups)
                {
                    context.Groups.Remove(group);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

       

        public bool SaveGroup(Group group)
        {
            try
            {
                if (group.Id > 0)
                {
                    var g = context.Groups.FirstOrDefault(x => x.Id == group.Id);
                    g.Name = group.Name;

                }
                else
                    context.Groups.Add(group);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteGroupUsers(IEnumerable<GroupUser> groupUsers)
        {
            try
            {
                foreach (var groupUser in groupUsers)
                {
                    var gu = context.GroupUsers.FirstOrDefault(g => g.Id == groupUser.Id);

                    if (gu != null)
                        context.GroupUsers.Remove(gu);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveGroupUsers(IEnumerable<GroupUser> groupUsers)
        {
            try
            {

               

                foreach (var groupUser in groupUsers)
                {
                    if (groupUser.Id > 0)
                    {
                        var g = context.GroupUsers.FirstOrDefault(x => x.Id == groupUser.Id);
                        g.UserId = groupUser.UserId;
                        g.GroupId = groupUser.GroupId;

                    }
                    else
                        context.GroupUsers.Add(groupUser);
                }


                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<User> UserLoginAttempts {
            get { return context.Users.Include(u => u.LoginAttempts); }
        }

        public IEnumerable<User> UserLoginedDatas {
            get { return context.Users.Include(u => u.LoginedDatas); }
        }

        public IEnumerable<Tenant> Tenants
        {
            get { return context.Tenants.Include(t => t.Users); }
         }

        public IEnumerable<Tenant> TenantsStructure
        {
            get { return context.Tenants.Include(t => t.Tenants); }
        }

        public bool SaveMenuAccess(IEnumerable<MenuAccess> menuAccesses)
        {

            try
            {

                foreach (var access in menuAccesses)
                {
                    if (access.Id>0)
                    {
                        var g = context.MenuAccesses.FirstOrDefault(x => x.Id == access.Id);

                        g.MenuItemId = access.MenuItemId;
                        g.UserId = access.UserId;
                        g.GroupId = access.GroupId;

                    }
                    else
                        context.MenuAccesses.Add(access);
                }


                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    
        public bool SaveMenuActionAccess(IEnumerable<MenuActionAccess> menuActionAccesses)
        {
            try
            {

                foreach (var access in menuActionAccesses)
                {
                    if (access.Id > 0)
                    {
                        var g = context.MenuActionAccesses.FirstOrDefault(x => x.Id == access.Id);

                        g.MenuActionId = access.MenuActionId;
                        g.UserId = access.UserId;
                        g.GroupId = access.GroupId;

                    }
                    else
                        context.MenuActionAccesses.Add(access);
                }


                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ChangePassword(User user)
        {
            try
            {
                var u = context.Users.FirstOrDefault(u => u.Id == user.Id);

                if (u != null)
                {
                    u.PasswordHint = user.PasswordHint;
                    u.HashPassword = user.HashPassword;
                    u.ForceFirstLoginChange = false;
                }
               


                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveUserSetting(UserSetting userSetting)
        {
            try
            {
                var setting = context.UserSettings.FirstOrDefault(us => us.UserId == userSetting.UserId);
                if (setting != null)
                {
                    setting.UserId = userSetting.UserId;
                    setting.HomeTypeId = userSetting.HomeTypeId;
                }
               else
                {
                    context.UserSettings.Add(userSetting);
                }



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
