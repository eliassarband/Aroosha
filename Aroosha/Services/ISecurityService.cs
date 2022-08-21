using Aroosha.Models;
using Aroosha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aroosha.Services
{
    public interface ISecurityService
    {
        IEnumerable<MenuCategoryItemModel> GetAllMenu(ISecurityRepository repository);
        IEnumerable<MenuCategoryItemModel> GetUserMenu(ISecurityRepository repository, int UserId);

        IEnumerable<UserModel> GetUsers(ISecurityRepository repository,int TenantId);

        UserDefineModel GetUserDefine(ISecurityRepository repository,int Id);

        IEnumerable<MenuActionModel> GetUserMenuAction(ISecurityRepository repository, int UserId,string MenuCode);

        NotificationModel DeleteUser(ISecurityRepository repository, int UserId);

        NotificationModel SaveUser(ISecurityRepository repository, UserDefineModel model,int TenantId);

        IEnumerable<GroupModel> GetGroups(ISecurityRepository repository);

        NotificationModel DeleteGroup (ISecurityRepository repository, int GroupId);

        GroupDefineModel GetGroupDefine(ISecurityRepository repository, int Id,int TenantId);

        NotificationModel SaveGroup(ISecurityRepository repository, GroupDefineModel model);

        LoginedDataModel GetUserLoginedData(ISecurityRepository repository, int LoginedDataId,int UserId);

        IEnumerable<TenantModel> GetTenantChildren(ISecurityRepository repository, int TenantId, bool IncludeParent);

        IEnumerable<MenuCategoryAccessModel> GetGroupUserAccess(ISecurityRepository repository, int GroupId, int UserId);

        NotificationModel SaveMenuAccess(ISecurityRepository repository, SaveMenuAccessModel saveMenuAccessModel);

        ChangePasswordModel GetUserInfo(ISecurityRepository repository, int UserId);

        NotificationModel ChangePassword(ISecurityRepository repository, ChangePasswordModel changePasswordModel);

        UserSettingModel GetUserSetting(ISecurityRepository repository, int UserId);

        NotificationModel SaveUserSetting(ISecurityRepository repository, UserSettingModel userSettingModel);
    }
}
