using Aroosha.Models;
using Aroosha.Repositories;
using Aroosha.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    public class SecurityService:ISecurityService
    {
        public IEnumerable<MenuCategoryItemModel> GetAllMenu(ISecurityRepository repository)
        {
            List<MenuCategoryItemModel> model = new List<MenuCategoryItemModel>();

            var categories = repository.AllMenuItems.OrderBy(m => m.Priority).ToList();

            foreach(var item in categories)
            {
                var mItems = repository.MenuItems.Where(x => x.CategoryId == item.Id).OrderBy(m => m.Priority).ToList();

                List<MenuItemModel> modelItems = new List<MenuItemModel>();

                foreach (var mItem in mItems)
                {
                    modelItems.Add(new MenuItemModel
                    {
                        Id=mItem.Id,
                        Name=mItem.Name,
                        ControllerName=mItem.ControllerName,
                        ActionName=mItem.ActionName,
                        DialogSize=mItem.DialogSize
                    });
                }

                model.Add(new MenuCategoryItemModel
                {
                    Id = item.Id,
                    Name=item.Name,
                    MenuItems=modelItems
                });

                
            }

            return model;
        }

        public IEnumerable<MenuCategoryItemModel> GetUserMenu(ISecurityRepository repository,int UserId)
        {
            List<MenuCategoryItemModel> model = new List<MenuCategoryItemModel>();
            //var mAccess = repository.MenuAccesses;
            var categories = repository.UserMenuItems.Where(x => x.ShowInMenu == true).OrderBy(m => m.Priority);

            var groups = repository.GroupUsers.Where(g => g.UserId == UserId);

            bool exists = false;

            foreach (var item in categories)
            {
                exists = false;
                var mItems = item.MenuItems.Where(x => x.ShowInMenu == true).OrderBy(m => m.Priority);
                
                List<MenuItemModel> modelItems = new List<MenuItemModel>();

                foreach (var mItem in mItems)
                {
                    var mAccess = repository.MenuAccesses.Where(x => x.MenuItemId == mItem.Id);
                    
                    if (mAccess.Where(x => x.UserId == UserId).Any() || mAccess.Where(m => groups.Any(g => g.GroupId == m.GroupId)).Any())
                    {
                        mAccess = mAccess.Where(x => x.UserId == UserId).ToList();

                        if (mAccess != null)
                        {


                            modelItems.Add(new MenuItemModel
                            {
                                Id = mItem.Id,
                                Name = mItem.Name,
                                ControllerName = mItem.ControllerName,
                                ActionName = mItem.ActionName,
                                DialogSize = mItem.DialogSize
                            });

                            exists = true;
                        }
                    }
                    

                    
                }

                if (exists)
                {
                    model.Add(new MenuCategoryItemModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        MenuItems = modelItems
                    });
                }


            }

            return model;
        }

        public IEnumerable<UserModel> GetUsers(ISecurityRepository repository, int TenantId)
        {

            var tenants = GetTenantChildren(repository, TenantId, true);

            List<UserModel> model= new List<UserModel>();

            var users = repository.Users.Select(u => new {
                                                            u.Id,
                                                            u.PersonId,
                                                            u.Username,
                                                            u.HashPassword,
                                                            u.Active,
                                                            u.ForceFirstLoginChange,
                                                            u.PasswordHint,
                                                            u.Person.Code,
                                                            u.Person.StrCode,
                                                            u.Person.FirstName,
                                                            u.Person.LastName,
                                                            u.Person.FullName,
                                                            u.TenantId,
                                                            TenantName=u.Tenant.Name
                                                        });

            if (users != null)
            {
                foreach (var item in users)
                {
                    if (tenants.Where(t => t.Id == item.TenantId).Count() > 0)
                    {
                        model.Add(new UserModel()
                        {
                            UserId = item.Id,
                            PersonId = item.PersonId,
                            UserUsername = item.Username,
                            UserPassword = item.HashPassword,
                            UserActive = item.Active,
                            UserForceFirstLoginChange = item.ForceFirstLoginChange,
                            UserPasswordHint = item.PasswordHint,
                            UserCode = item.Code,
                            UserStrCode = item.StrCode,
                            UserFirstName = item.FirstName,
                            UserLastName = item.LastName,
                            UserFullName = item.FullName,
                            UserTenantId = item.TenantId,
                            UserTenantName = item.TenantName
                        });
                    }
                }
            }
            
            return (model);

        }

        public UserDefineModel GetUserDefine(ISecurityRepository repository ,int Id)
        {
            UserDefineModel model = new UserDefineModel();

            var users = repository.Users.Select(u => new {
                u.Id,
                u.PersonId,
                u.Username,
                u.HashPassword,
                u.Active,
                u.ForceFirstLoginChange,
                u.PasswordHint,
                u.Person.Code,
                u.Person.StrCode,
                u.Person.FirstName,
                u.Person.LastName,
                u.Person.FullName,
                u.TenantId,
                TenantName = u.Tenant.Name
            }).FirstOrDefault(u => u.Id==Id);

            if (users != null)
            {
                
                model=new UserDefineModel()
                {
                    UserDefineId = users.Id,
                    PersonId = users.PersonId,
                    UserDefineUsername = users.Username,
                    UserDefinePassword = users.HashPassword,
                    UserDefineActive = users.Active,
                    UserDefineForceFirstLoginChange = users.ForceFirstLoginChange,
                    UserDefinePasswordHint = users.PasswordHint,
                    UserDefineCode = users.Code,
                    UserDefineStrCode = users.StrCode,
                    UserDefineFirstName = users.FirstName,
                    UserDefineLastName = users.LastName,
                    UserDefineFullName = users.FullName,
                    UserDefineTenantId = users.TenantId,
                    UserDefineTenantName = users.TenantName
                };
                
            }

            return (model);
        }

        public IEnumerable<MenuActionModel> GetUserMenuAction(ISecurityRepository repository, int UserId, string MenuCode)
        {
            List<MenuActionModel> model = new List<MenuActionModel>();

            var menuActions = repository.MenuActions.Where(x => x.ShowInToolbar == true).Where(x => x.MenuItem.Code == MenuCode);

            var groups = repository.GroupUsers.Where(g => g.UserId == UserId);

            foreach (var item in menuActions)
            {

                
                if (item.MenuActionAccesses.Where(x => x.UserId == UserId).Any() || item.MenuActionAccesses.Where(m => groups.Any(g => g.GroupId == m.GroupId)).Any())
                {
                    var mAccess = item.MenuActionAccesses.Where(x => x.UserId == UserId);
                    if (mAccess != null)
                    {
                        model.Add(new MenuActionModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Title = item.Title,
                            ShowInToolbar = item.ShowInToolbar,
                            Priority = item.Priority,
                            MenuItemId = item.MenuItemId
                        });
                    }

                }
               
                


            }

            return model;
        }

        public NotificationModel DeleteUser(ISecurityRepository repository, int UserId)
        {
            
            bool success = true;

            if (success)
            {
                var menuActionAccess = repository.MenuActionAccesses.Where(x => x.UserId == UserId);
                success = repository.DeleteMenuActionAccess(menuActionAccess);
            }

            if (success)
            {
                var menuAccess = repository.MenuAccesses.Where(x => x.UserId == UserId);
                success = repository.DeleteMenuAccess(menuAccess);
            }

            var PersonId = 0;
            if (success)
            {
                var user = repository.Users.Where(x => x.Id == UserId);
                PersonId = user.FirstOrDefault().PersonId;
                success = repository.DeleteUser(user);
            }

            if (success)
            {
                var person = repository.Persons.Where(p => p.Id == PersonId);
                success = repository.DeletePerson(person);
            }

            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel model = new NotificationModel()
            {
                Id=Id,
                ResultType=ResultType,
                ResultMessage=ResultMessage
            };

            return model;
        }

        public NotificationModel SaveUser(ISecurityRepository repository, UserDefineModel userModel,int TenantId)
        {
            bool success = true;
            int UserId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var PersonId = 0;

            if (repository.Persons.Where(p => p.Id != userModel.PersonId).Any(p => p.Code == userModel.UserDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد کاربر وارد شده تکراری می باشد";

            }
            else if (repository.Persons.Where(p => p.Id != userModel.PersonId).Any(p => p.StrCode == userModel.UserDefineStrCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد کاراکتری کاربر وارد شده تکراری می باشد";
            }
            else if (repository.Users.Where(u => u.Id != userModel.UserDefineId).Any(u => u.PersonId == userModel.PersonId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "برای کاربر وارد شده قبلا اطلاعات شخصی ثبت گردیده است";
            }
            else if (repository.Users.Where(u => u.Id != userModel.UserDefineId).Any(u => u.Username == userModel.UserDefineUsername))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام کاربری وارد شده تکراری می باشد";
            }
            else if (userModel.UserDefineId == 0 && (userModel.UserDefinePassword == "" || userModel.UserDefinePassword == null))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "لطفا کلمه عبور را وارد نمایید";
            }



            if (success)
            {
                success = repository.SavePerson(new GeneralDAL.Database.Person()
                {
                    Id = userModel.PersonId,
                    Code = userModel.UserDefineCode,
                    StrCode = userModel.UserDefineStrCode,
                    FirstName = userModel.UserDefineFirstName,
                    LastName = userModel.UserDefineLastName,
                    Active = userModel.UserDefineActive
                });

                PersonId = repository.Persons.Where(p => p.Code == userModel.UserDefineCode).FirstOrDefault().Id;
                userModel.PersonId = PersonId;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            if (success && PersonId > 0)
            {
                string HashPassword = "";
                if (userModel.UserDefinePassword == "" || userModel.UserDefinePassword == null)
                {
                    if (userModel.UserDefineId > 0)
                    {
                        HashPassword = repository.Users.Where(p => p.Id == userModel.UserDefineId).FirstOrDefault().HashPassword;
                    }
                    else
                    {
                        HashPassword = repository.Users.Where(p => p.Username == userModel.UserDefineUsername).FirstOrDefault().HashPassword;
                    }
                }
                else
                {
                    HashPassword = CryptographyHelper.MD5Hash(userModel.UserDefinePassword);
                }

                userModel.UserDefinePassword = HashPassword;

                success = repository.SaveUser(new GeneralDAL.Database.User()
                {
                    Id = userModel.UserDefineId,
                    PersonId = userModel.PersonId,
                    Username = userModel.UserDefineUsername,
                    HashPassword = userModel.UserDefinePassword,
                    Active = userModel.UserDefineActive,
                    ForceFirstLoginChange = userModel.UserDefineForceFirstLoginChange,
                    PasswordHint = userModel.UserDefinePasswordHint,
                    TenantId=userModel.UserDefineTenantId
                });

                if (repository.Users.Where(p => p.Username == userModel.UserDefineUsername).Count() > 0)
                {
                    UserId = repository.Users.Where(p => p.Username == userModel.UserDefineUsername).FirstOrDefault().Id;
                }
                else
                {
                    UserId = 0;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }





            NotificationModel model = new NotificationModel()
            {
                Id = UserId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public IEnumerable<GroupModel> GetGroups(ISecurityRepository repository)
        {
            List<GroupModel> model = new List<GroupModel>();

            var groups = repository.Groups.Select(u => new {
                u.Id,
                u.Name,
                u.GroupUsers
            });

            if (groups != null)
            {
                foreach (var item in groups)
                {
                    var uItem = item.GroupUsers.Where(x => x.GroupId == item.Id);

                    List<GroupUserModel> modelItems = new List<GroupUserModel>();

                    foreach (var mItem in uItem)
                    {
                        var person = repository.Users.FirstOrDefault(u => u.Id == mItem.UserId).Person;
                        
                        modelItems.Add(new GroupUserModel
                        {
                            GroupUserId = mItem.Id,
                            GroupUserUserId = mItem.UserId,
                            GroupUserFullName = person.FullName,
                            GroupId = mItem.GroupId,
                            GroupName=item.Name
                        });

                        
                    }

                    model.Add(new GroupModel()
                    {
                        GroupId = item.Id,
                        GroupName = item.Name,
                        GroupUserModels=modelItems,
                        GroupUserCount = modelItems.Count
                    });

                }
            }

            return (model);
        }

        public NotificationModel DeleteGroup(ISecurityRepository repository, int GroupId)
        {

            bool success = true;

            if (success)
            {
                var groupUsers = repository.GroupUsers.Where(x => x.GroupId == GroupId);
                success = repository.DeleteGroupUsers(groupUsers);
            }
            
            if (success)
            {
                var groups = repository.Groups.Where(g => g.Id == GroupId);
                success = repository.DeleteGroup(groups);
            }

            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel model = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public GroupDefineModel GetGroupDefine(ISecurityRepository repository, int Id,int TenantId)
        {
            GroupDefineModel model = new GroupDefineModel();

            var tenants = GetTenantChildren(repository, TenantId, true);

            var group = repository.Groups.Where(g => g.Id==Id).Select(u => new {
                u.Id,
                u.Name,
                u.GroupUsers
            }).FirstOrDefault();

            if (group != null)
            {
                var users = repository.Users.Join(
                                                        tenants,
                                                        u => u.TenantId,
                                                        t => t.Id,
                                                        (u,t)=> new
                                                        { 
                                                                UserId=u.Id,
                                                                TenantId=u.TenantId,
                                                                TenantName=t.Name,
                                                                UserFullName=u.Person.FullName
                                                        });
                

                List<GroupUserModel> modelItems = new List<GroupUserModel>();

                int GroupUserId = 0;
                bool Selected = false;
                foreach (var mItem in users)
                {
                    var groupUsers = repository.GroupUsers.FirstOrDefault(u => u.UserId == mItem.UserId && u.GroupId == group.Id);

                    if (groupUsers != null)
                    {
                        GroupUserId = groupUsers.Id;
                        if (GroupUserId > 0)
                            Selected = true;
                    }
                    else
                    {
                        GroupUserId = 0;
                        Selected = false;
                    }
                    modelItems.Add(new GroupUserModel
                    {
                        GroupUserId = GroupUserId,
                        GroupUserUserId = mItem.UserId,
                        GroupUserFullName = mItem.UserFullName,
                        GroupId = group.Id,
                        GroupName = group.Name,
                        GroupUserSelected = Selected
                    });


                }

                model = new GroupDefineModel()
                {
                    GroupDefineId = group.Id,
                    GroupDefineName = group.Name,
                    GroupUserModels = modelItems,
                    GroupDefineUserCount = modelItems.Count
                };
            }

                

            return (model);
        }

        public NotificationModel SaveGroup(ISecurityRepository repository, GroupDefineModel groupModel)
        {
            bool success = true;
            int GroupId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";


            if (repository.Groups.Where(g => g.Id != groupModel.GroupDefineId).Any(g => g.Name == groupModel.GroupDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام گروه وارد شده تکراری می باشد";

            }
            

            if (success)
            {

                success = repository.SaveGroup(new GeneralDAL.Database.Group()
                {
                    Id = groupModel.GroupDefineId,
                    Name = groupModel.GroupDefineName
                });

                GroupId = repository.Groups.Where(g => g.Name == groupModel.GroupDefineName).FirstOrDefault().Id;

                if (success && groupModel.GroupUserModels != null)
                {
                    List<GeneralDAL.Database.GroupUser> groupUserSave = new List<GeneralDAL.Database.GroupUser>();
                    List<GeneralDAL.Database.GroupUser> groupUserDelete = new List<GeneralDAL.Database.GroupUser>();

                    foreach (var item in groupModel.GroupUserModels)
                    {
                        if (item.GroupUserSelected)
                        {
                            groupUserSave.Add(new GeneralDAL.Database.GroupUser()
                            {
                                Id = item.GroupUserId,
                                UserId = item.GroupUserUserId,
                                GroupId=GroupId
                            });
                        }
                        else
                        {
                            groupUserDelete.Add(new GeneralDAL.Database.GroupUser()
                            {
                                Id = item.GroupUserId,
                                UserId = item.GroupUserUserId,
                                GroupId = GroupId
                            });
                        }
                    }

                    success = repository.SaveGroupUsers(groupUserSave);

                    if (success)
                    {
                        success = repository.DeleteGroupUsers(groupUserDelete);
                    }
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }





            NotificationModel model = new NotificationModel()
            {
                Id = GroupId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public LoginedDataModel GetUserLoginedData(ISecurityRepository repository, int LoginedDataId,int UserId)
        {
            LoginedDataModel logined;

            var user = repository.UserLoginedDatas.Where(u => u.Id==UserId).Join(
                                    repository.Persons,
                                    u => u.PersonId,
                                    p => p.Id,
                                    (u, p) => new
                                    {
                                        LoginedDataId = u.LoginedDatas.Where(l => l.Id==LoginedDataId).FirstOrDefault().Id,
                                        UserId = u.Id,
                                        PersonId = u.PersonId,
                                        PersonName = p.FullName,
                                        Username = u.Username,
                                        Date = u.LoginedDatas.Where(l => l.Id == LoginedDataId).FirstOrDefault().Date,
                                        Time = u.LoginedDatas.Where(l => l.Id == LoginedDataId).FirstOrDefault().Time,
                                        DeviceName = u.LoginedDatas.Where(l => l.Id == LoginedDataId).FirstOrDefault().DeviceName,
                                        TenantId=u.TenantId,
                                        ForceFirstLoginChange = u.ForceFirstLoginChange
                                    }
                                ).Join(
                repository.Tenants,
                u => u.TenantId,
                t => t.Id,
                (u,t) =>new
                {
                    LoginedDataId = u.LoginedDataId,
                    UserId = u.UserId,
                    PersonId = u.PersonId,
                    PersonName = u.PersonName,
                    Username = u.Username,
                    Date = u.Date,
                    Time = u.Time,
                    DeviceName = u.DeviceName,
                    TenantId = u.TenantId,
                    TenantCode=t.Code,
                    TenantName=t.Name,
                    ForceFirstLoginChange=u.ForceFirstLoginChange
                }
                ).FirstOrDefault(x => x.UserId == UserId);

            logined = new LoginedDataModel()
            {
                LoginedDataId=user.LoginedDataId,
                UserId=user.UserId,
                PersonId=user.PersonId,
                PersonName=user.PersonName,
                Username=user.Username,
                Date=user.Date,
                Time=user.Time,
                DeviceName=user.DeviceName,
                TenantId=user.TenantId,
                TenantCode=user.TenantCode,
                TenantName=user.TenantName,
                HomeTypeId=0,
                HomeTypeStrCode="",
                ForceFirstLoginChange=user.ForceFirstLoginChange
            };

            if (repository.Users.FirstOrDefault(u => u.Id == UserId).UserSettings != null)
            {
                int HomeTypeId = repository.Users.FirstOrDefault(u => u.Id == UserId).UserSettings.FirstOrDefault().HomeTypeId;
                string HomeTypeStrCode= repository.Users.FirstOrDefault(u => u.Id == UserId).UserSettings.FirstOrDefault().HomeType.StrCode;

                logined.HomeTypeId = HomeTypeId;
                logined.HomeTypeStrCode = HomeTypeStrCode;
            }

            return logined;
        }

        public IEnumerable<TenantModel> GetTenantChildren(ISecurityRepository repository, int TenantId, bool IncludeParent)
        {
            List<TenantModel> tenants = new List<TenantModel>();

            if (IncludeParent)
            {
                var parent = repository.Tenants.FirstOrDefault(testc => testc.Id == TenantId);

                tenants.Add(new TenantModel()
                {
                    Id=parent.Id,
                    Code=parent.Code,
                    Name=parent.Name,
                    ParentId=parent.ParentId
                });
            }

            var children = repository.Tenants.Where(t => t.ParentId == TenantId).ToList();

            foreach (var item in children)
            {
                tenants.Add(new TenantModel()
                {
                    Id=item.Id,
                    Code=item.Code,
                    Name=item.Name,
                    ParentId=item.ParentId
                });
            
            }

            return tenants;
        }

        public IEnumerable<MenuCategoryAccessModel> GetGroupUserAccess(ISecurityRepository repository, int GroupId, int UserId)
        {
            List<MenuCategoryAccessModel> category = new List<MenuCategoryAccessModel>();
            bool CategorySelected = false;
            bool MenuSelecetd = false;
            bool ActionSelecetd = false;

            var cat = repository.AllMenuItems.OrderBy(m => m.Priority);

            foreach (var cItem in cat)
            {
                CategorySelected = true;
                List<MenuAccessModel> menu = new List<MenuAccessModel>();

                foreach (var mItem in cItem.MenuItems.OrderBy(m => m.Priority))
                {
                    MenuSelecetd = false;
                    List<MenuActionAccessModel> action = new List<MenuActionAccessModel>();

                    var act = repository.MenuActions.Where(m => m.MenuItemId == mItem.Id).OrderBy(m => m.Priority);

                    foreach (var aItem in act)
                    {
                        ActionSelecetd = false;
                        var access = repository.MenuActionAccesses.Where(m => m.MenuActionId == aItem.Id).FirstOrDefault(m => m.UserId == UserId || m.GroupId == GroupId);

                        if (access != null)
                        {
                            ActionSelecetd = true;
                            MenuSelecetd = true;
                            
                        }
                        else
                        {
                            ActionSelecetd = false;
                            CategorySelected = false;
                        }

                        action.Add(new MenuActionAccessModel() { 
                            Id=aItem.Id,
                            Title=aItem.Title,
                            Name=aItem.Name,
                            Priority=aItem.Priority,
                            MenuItemId=aItem.MenuItemId,
                            UserId=UserId,
                            GroupId=GroupId,
                            Selected=ActionSelecetd
                        });
                    }

                    menu.Add(new MenuAccessModel()
                    {
                        Id=mItem.Id,
                        Name=mItem.Name,
                        Priority=mItem.Priority,
                        CategoryId=mItem.CategoryId,
                        UserId = UserId,
                        GroupId = GroupId,
                        Selected =MenuSelecetd,
                        MenuActionAccessModels=action
                    });

                }

                category.Add(new MenuCategoryAccessModel()
                {
                    Id=cItem.Id,
                    Name=cItem.Name,
                    Priority=cItem.Priority,
                    UserId = UserId,
                    GroupId = GroupId,
                    Selected =CategorySelected,
                    MenuAccessModels=menu
                });

            }

            return category;
        
        }

        public NotificationModel SaveMenuAccess(ISecurityRepository repository, SaveMenuAccessModel saveMenuAccessModel)
        {
            

            bool success = true;
            string Mode = saveMenuAccessModel.Mode;
            int? GroupId = saveMenuAccessModel.GroupId;
            int? UserId = saveMenuAccessModel.UserId;

            if (Mode == "User")
                GroupId = null;
            else
                UserId = null;

            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            List<GeneralDAL.Database.MenuAccess> saveMenuAccesses = new List<GeneralDAL.Database.MenuAccess>();
            List<GeneralDAL.Database.MenuAccess> deleteMenuAccesses = new List<GeneralDAL.Database.MenuAccess>();
            List<GeneralDAL.Database.MenuActionAccess> saveMenuActionAccesses = new List<GeneralDAL.Database.MenuActionAccess>();
            List<GeneralDAL.Database.MenuActionAccess> deleteMenuActionAccesses = new List<GeneralDAL.Database.MenuActionAccess>();

           
            bool MenuSelected = false;

            foreach (var category in saveMenuAccessModel.MenuCategoryAccessModels)
            {
                
                foreach (var menu in category.MenuAccessModels)
                {
                    MenuSelected = false;                    

                    GeneralDAL.Database.MenuAccess menuAccess = new GeneralDAL.Database.MenuAccess();
                    
                    foreach (var action in menu.MenuActionAccessModels)
                    {
                         
                        
                        GeneralDAL.Database.MenuActionAccess menuActionAccess = new GeneralDAL.Database.MenuActionAccess();
                        var actionAccess = repository.MenuActionAccesses.FirstOrDefault(a => a.MenuActionId == action.Id && (a.UserId == action.UserId || a.GroupId == action.GroupId));

                        
                        menuActionAccess.MenuActionId = action.Id;
                        menuActionAccess.UserId = UserId;
                        menuActionAccess.GroupId = GroupId;

                        if (actionAccess != null && action.Selected)
                        {
                            menuActionAccess.Id = actionAccess.Id;
                            saveMenuActionAccesses.Add(menuActionAccess);
                        }
                        else if (actionAccess == null && action.Selected)
                        {
                            menuActionAccess.Id = 0;
                            saveMenuActionAccesses.Add(menuActionAccess);
                        }
                        else if (actionAccess != null && !action.Selected)
                        {
                            menuActionAccess.Id = actionAccess.Id;
                            deleteMenuActionAccesses.Add(menuActionAccess);
                        }

                        

                        if (action.Selected)
                            MenuSelected = true;

                    }

                    menu.Selected = MenuSelected;

                    var access = repository.MenuAccesses.FirstOrDefault(m => m.MenuItemId == menu.Id && (m.UserId == menu.UserId || m.GroupId == menu.GroupId));
                    
                    menuAccess.MenuItemId = menu.Id;
                    menuAccess.UserId = UserId;
                    menuAccess.GroupId = GroupId;

                    if (Mode == "User")
                    {
                        UserId = menu.UserId;
                    }
                    else
                    {
                        GroupId = menu.GroupId;
                    }

                    if (access != null && menu.Selected)
                    {
                        menuAccess.Id = access.Id;
                        saveMenuAccesses.Add(menuAccess);
                       
                    }
                    else if (access == null && menu.Selected)
                    {
                        menuAccess.Id = 0;
                        saveMenuAccesses.Add(menuAccess);

                    }
                    else if (access != null && !menu.Selected)
                    {
                        menuAccess.Id = access.Id;
                        deleteMenuAccesses.Add(menuAccess);
                    }

                   
                }
            }

            success = repository.SaveMenuAccess(saveMenuAccesses);

            if (success)
                success = repository.DeleteMenuAccess(deleteMenuAccesses);

            if (success)
                success = repository.SaveMenuActionAccess(saveMenuActionAccesses);

            if (success)
                success = repository.DeleteMenuActionAccess(deleteMenuActionAccesses);

            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel model;

            if (Mode == "User")
            {
                model = new NotificationModel()
                {
                    Id = (int)UserId,
                    ResultType = ResultType,
                    ResultMessage = ResultMessage
                };
            }
            else
            {
                model = new NotificationModel()
                {
                    Id = (int)GroupId,
                    ResultType = ResultType,
                    ResultMessage = ResultMessage
                };
            }

            return model;
        }

        public ChangePasswordModel GetUserInfo(ISecurityRepository repository, int UserId)
        {
            ChangePasswordModel model = new ChangePasswordModel();

            var user = repository.Users.FirstOrDefault(u => u.Id == UserId);

            if (user != null)
            {
                model = new ChangePasswordModel()
                {
                    UserId=user.Id,
                    Username=user.Username,
                    UserFullName=user.Person.FullName,
                    PasswordHint=user.PasswordHint
                };
            }

            return model;
        }

        public NotificationModel ChangePassword(ISecurityRepository repository, ChangePasswordModel changePasswordModel)
        {
            bool success = true;
            int UserId = changePasswordModel.UserId;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            
            if (repository.Users.Where(u => u.Id == changePasswordModel.UserId).Any(u => u.HashPassword != CryptographyHelper.MD5Hash(changePasswordModel.CurrentPassword)))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کلمه عبور جاری وارد شده نادرست می باشد";

            }
            else if (changePasswordModel.NewPassword != changePasswordModel.NewPasswordRepetition)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کلمه عبور جدید و تکرار آن مطابقت ندارد";
            }
            else if (changePasswordModel.NewPassword == changePasswordModel.CurrentPassword)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کلمه عبور جدید نمی تواند با کلمه عبور جاری یکسان باشد";
            }


            if (success)
            {

                success = repository.ChangePassword(new GeneralDAL.Database.User()
                {
                    Id = changePasswordModel.UserId,
                    Username = changePasswordModel.Username,
                    HashPassword=CryptographyHelper.MD5Hash(changePasswordModel.NewPassword),
                    PasswordHint=changePasswordModel.PasswordHint
                });


                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }





            NotificationModel model = new NotificationModel()
            {
                Id = UserId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

       

        public UserSettingModel GetUserSetting(ISecurityRepository repository, int UserId)
        {
            UserSettingModel model = new UserSettingModel();

            var user = repository.Users.FirstOrDefault(u => u.Id == UserId);

            if (user != null)
            {
                if (user.UserSettings.Any())
                {
                    model = new UserSettingModel()
                    {
                        Id = user.UserSettings.FirstOrDefault().Id,
                        UserId = user.Id,
                        Username = user.Username,
                        UserFullName = user.Person.FullName,
                        HomeTypeId = user.UserSettings.FirstOrDefault().HomeTypeId,
                        HomeTypeName = user.UserSettings.FirstOrDefault().HomeType.Name
                    };
                }
                else
                {
                    model = new UserSettingModel()
                    {
                        Id = 0,
                        UserId = user.Id,
                        Username = user.Username,
                        UserFullName = user.Person.FullName,
                        HomeTypeId = 0,
                        HomeTypeName = ""
                    };
                }
            }

            return model;
        }

        public NotificationModel SaveUserSetting(ISecurityRepository repository, UserSettingModel userSettingModel)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            
            if (userSettingModel.HomeTypeId==0)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "لطفا نوع صفحه اصلی را انتخاب نمایید";

            }
            


            if (success)
            {

                success = repository.SaveUserSetting(new GeneralDAL.Database.UserSetting()
                {
                    Id = userSettingModel.Id,
                    UserId=userSettingModel.UserId,
                    HomeTypeId=userSettingModel.HomeTypeId
                });

                
                Id = repository.Users.FirstOrDefault(u => u.Id == userSettingModel.UserId).UserSettings.FirstOrDefault().Id;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }





            NotificationModel model = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }
    }
}
