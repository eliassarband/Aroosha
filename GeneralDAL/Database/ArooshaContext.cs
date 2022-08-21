using GeneralDAL.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    public class ArooshaContext: DbContext
    {

        public ArooshaContext(DbContextOptions<ArooshaContext> options) : base(options)
        {

        }



        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuAccess> MenuAccesses { get; set; }
        public DbSet<MenuAction> MenuActions { get; set; }
        public DbSet<MenuActionAccess> MenuActionAccesses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<LoginedData> loginedDatas { get; set; }
        public DbSet<BasicInformationCategory> BasicInformationCategories { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobGroup> JobGroups { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopGroup> ShopGroups { get; set; }
        public DbSet<MarketStructure> MarketStructures { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public   DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<MarketSchedule> MarketSchedules { get; set; }
        public  DbSet<MarketScheduleDetail> MarketScheduleDetails { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public  DbSet<Reserve> Reserves { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<UserDefaultForm> UserDefaultForms { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<PCPosSetting> PCPosSettings { get; set; }
        public DbSet<SMSTemplate> SMSTemplates { get; set; }
        public DbSet<SMSMessage> SMSMessages { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PrinterSetting> PrinterSettings { get; set; }
        public DbSet<PrintTemplate> PrintTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Person admin = new Person() { Id = 1, Code = 1, StrCode = "1", FirstName = "مدیر", LastName = "سیستم", Active = true };

            modelBuilder.Entity<Person>().HasData(admin);

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, PersonId = 1, Username = "admin", HashPassword = CryptographyHelper.MD5Hash("Elias 8831"), Active = true ,ForceFirstLoginChange=false,PasswordHint="nothing",TenantId=1});

            modelBuilder.Entity<MenuCategory>().HasData(
                new MenuCategory() { Id = 1, Name = "مدریریت کاربران", ShowInMenu = true, Priority = 2 });

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 1,Code="Users", Name = "تعریف کاربران", ControllerName = "Security", ActionName = "Users", ShowInMenu = true, DialogSize = "medium", Priority = 2, CategoryId = 1 });

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 1, MenuItemId = 1, UserId = 1 });

            modelBuilder.Entity<MenuAction>().HasData(
                new MenuAction() { Id = 1, Name = "New", Title = "تعریف کاربر جدید", ShowInToolbar = true, Priority = 1, MenuItemId = 1 },
                new MenuAction() { Id = 2, Name = "Edit", Title = "ویرایش کاربر", ShowInToolbar = true, Priority = 2, MenuItemId = 1 },
                new MenuAction() { Id = 3, Name = "Delete", Title = "حذف کاربر", ShowInToolbar = true, Priority = 3, MenuItemId = 1 }
            );

            modelBuilder.Entity<MenuActionAccess>().HasData(
               new MenuActionAccess() { Id = 1, MenuActionId = 1, UserId= 1},
               new MenuActionAccess() { Id = 2, MenuActionId = 2, UserId = 1 },
               new MenuActionAccess() { Id = 3, MenuActionId = 3, UserId = 1 }
           );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 2, Code = "UserDefine", Name = "ایجاد و ویرایش کاربران", ControllerName = "Security", ActionName = "UserDefine", ShowInMenu = false, DialogSize = "medium", Priority = 3, CategoryId = 1 });

            modelBuilder.Entity<MenuAccess>().HasData(
               new MenuAccess() { Id = 2, MenuItemId = 2, UserId = 1 });

            modelBuilder.Entity<MenuAction>().HasData(
                new MenuAction() { Id = 4, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 2 },
                new MenuAction() { Id = 6, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 2, MenuItemId = 2 },
                new MenuAction() { Id = 5, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 3, MenuItemId = 2 },
                new MenuAction() { Id = 15, Name = "UserAccess", Title = "مدیریت دسترسی کاربران", ShowInToolbar = true, Priority = 4, MenuItemId = 2 }
            );

            modelBuilder.Entity<MenuActionAccess>().HasData(
               new MenuActionAccess() { Id = 4, MenuActionId = 4, UserId = 1 },
               new MenuActionAccess() { Id = 5, MenuActionId = 5, UserId = 1 },
               new MenuActionAccess() { Id = 6, MenuActionId = 6, UserId = 1 },
               new MenuActionAccess() { Id = 15, MenuActionId = 15, UserId = 1 }
           );

            modelBuilder.Entity<Group>().HasData(
               new Group() { Id = 1, Name = "مدیر سیستم" },
               new Group() { Id = 2, Name = "کاربران عمومی" }
           );

            modelBuilder.Entity<GroupUser>().HasData(
               new GroupUser() { Id = 1, GroupId = 1, UserId = 1 },
               new GroupUser() { Id = 2, GroupId = 2, UserId = 1 }
           );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 3, Code = "Groups", Name = "تعریف گروه‌های کاربری", ControllerName = "Security", ActionName = "Groups", ShowInMenu = true, DialogSize = "medium", Priority = 3, CategoryId = 1 });

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 3, MenuItemId = 3, UserId = 1 });

            modelBuilder.Entity<MenuAction>().HasData(
                new MenuAction() { Id = 7, Name = "New", Title = "تعریف گروه جدید", ShowInToolbar = true, Priority = 1, MenuItemId = 3 },
                new MenuAction() { Id = 8, Name = "Edit", Title = "ویرایش گروه", ShowInToolbar = true, Priority = 2, MenuItemId = 3 },
                new MenuAction() { Id = 9, Name = "Delete", Title = "حذف گروه", ShowInToolbar = true, Priority = 3, MenuItemId = 3 }
            );

            modelBuilder.Entity<MenuActionAccess>().HasData(
               new MenuActionAccess() { Id = 7, MenuActionId = 7, UserId = 1 },
               new MenuActionAccess() { Id = 8, MenuActionId = 8, UserId = 1 },
               new MenuActionAccess() { Id = 9, MenuActionId = 9, UserId = 1 }
           );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 4, Code = "GroupDefine", Name = "ایجاد و ویرایش گروه‌های کاربری", ControllerName = "Security", ActionName = "GroupDefine", DialogSize = "small", ShowInMenu = false, Priority = 4, CategoryId = 1 });

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 4, MenuItemId = 4, UserId = 1 });

            modelBuilder.Entity<MenuAction>().HasData(
               
                new MenuAction() { Id = 12, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 4 },
                new MenuAction() { Id = 14, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 4 },
                new MenuAction() { Id = 13, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 4 },
                new MenuAction() { Id = 16, Name = "GroupAccess", Title = "مدیریت دسترسی گروه های کاربری", ShowInToolbar = true, Priority = 4, MenuItemId = 4 }
            );

            modelBuilder.Entity<MenuActionAccess>().HasData(
               
               new MenuActionAccess() { Id = 12, MenuActionId = 12, UserId = 1 },
               new MenuActionAccess() { Id = 13, MenuActionId = 13, UserId = 1 },
               new MenuActionAccess() { Id = 14, MenuActionId = 14, UserId = 1 },
               new MenuActionAccess() { Id = 16, MenuActionId = 16, UserId = 1 }
           );

           
            modelBuilder.Entity<Tenant>().HasData(
               new Tenant() { Id = 1, Code = 1, Name = "سازمان میادین میوه و تره بار و ساماندهی مشاغل شهری شهرداری اصفهان",ParentId=null },
               new Tenant() { Id = 2, Code = 2, Name = "جمعه بازار بعثت", ParentId = 1 }
           );

            modelBuilder.Entity<BasicInformationCategory>().HasData(
               new BasicInformationCategory() { Id = 1, Code = "RegionType", Name = "نوع منطقه", Viewable = false, RelatedCategoryId = null }
           );

            modelBuilder.Entity<BasicInformation>().HasData(
              new BasicInformation() { Id = 1, Code = 1, StrCode = "Country", Name = "کشور", CategoryId = 1, Priority = 1, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
              new BasicInformation() { Id = 2, Code = 2, StrCode = "Province", Name = "استان", CategoryId = 1, Priority = 2, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
              new BasicInformation() { Id = 3, Code = 3, StrCode = "City", Name = "شهر", CategoryId = 1, Priority = 3, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false }
          );

            modelBuilder.Entity<Region>().HasData(
              new Region() { Id = 1, Code = 1, TypeId = 1, Name = "ایران", ParentId = null },
              new Region() { Id = 2, Code = 4, TypeId = 2, Name = "اصفهان", ParentId = 1 },
              new Region() { Id = 3, Code = 6, TypeId = 3, Name = "اصفهان", ParentId = 2 }
          );


            modelBuilder.Entity<MenuItem>().HasData(
               new MenuItem() { Id = 5, Code = "UserAccess", Name = "مدیریت دسترسی کاربران", ControllerName = "Security", ActionName = "UserAccess", DialogSize = "large", ShowInMenu = false, Priority = 5, CategoryId = 1 },
               new MenuItem() { Id = 6, Code = "GroupAccess", Name = "مدیریت دسترسی گروه های کاربری", ControllerName = "Security", ActionName = "GroupAccess", DialogSize = "large", ShowInMenu = false, Priority = 6, CategoryId = 1 }
               );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 5, MenuItemId = 5, UserId = 1 },
                new MenuAccess() { Id = 6, MenuItemId = 6, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(

                new MenuAction() { Id = 17, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 5 },
                new MenuAction() { Id = 18, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 6 }
            );

            modelBuilder.Entity<MenuActionAccess>().HasData(

               new MenuActionAccess() { Id = 17, MenuActionId = 17, UserId = 1 },
               new MenuActionAccess() { Id = 18, MenuActionId = 18, UserId = 1 }
           );

            modelBuilder.Entity<MenuCategory>().HasData(
               new MenuCategory() { Id = 2, Name = "اطلاعات پایه", ShowInMenu = true, Priority = 1 });

            modelBuilder.Entity<MenuItem>().HasData(
              new MenuItem() { Id = 7, Code = "JobGroups", Name = "مدیریت گروه مشاغل", ControllerName = "General", ActionName = "JobGroups", DialogSize = "medium", ShowInMenu = true, Priority = 3, CategoryId = 2 },
              new MenuItem() { Id = 8, Code = "JobGroupDefine", Name = "تعریف گروه مشاغل", ControllerName = "General", ActionName = "JobGroupDefine", DialogSize = "medium", ShowInMenu = false, Priority = 4, CategoryId = 2 },
              new MenuItem() { Id = 9, Code = "Jobs", Name = "مدیریت مشاغل", ControllerName = "General", ActionName = "Jobs", DialogSize = "medium", ShowInMenu = true, Priority = 5, CategoryId = 2 },
              new MenuItem() { Id = 10, Code = "JobDefine", Name = "تعریف مشاعل", ControllerName = "General", ActionName = "JobDefine", DialogSize = "medium", ShowInMenu = false, Priority = 6, CategoryId = 2 }
              );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 7, MenuItemId = 7, UserId = 1 },
                new MenuAccess() { Id = 8, MenuItemId = 8, UserId = 1 },
                new MenuAccess() { Id = 9, MenuItemId = 9, UserId = 1 },
                new MenuAccess() { Id = 10, MenuItemId = 10, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(
               new MenuAction() { Id = 19, Name = "New", Title = "تعریف گروه مشاغل جدید", ShowInToolbar = true, Priority = 1, MenuItemId = 7 },
               new MenuAction() { Id = 20, Name = "Edit", Title = "ویرایش گروه مشاغل", ShowInToolbar = true, Priority = 2, MenuItemId = 7 },
               new MenuAction() { Id = 21, Name = "Delete", Title = "حذف گروه مشاغل", ShowInToolbar = true, Priority = 3, MenuItemId = 7 },
               new MenuAction() { Id = 22, Name = "Jobs", Title = "تعریف مشاغل گروه", ShowInToolbar = true, Priority = 4, MenuItemId = 7 },

               new MenuAction() { Id = 23, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 8 },
               new MenuAction() { Id = 24, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 8 },
               new MenuAction() { Id = 25, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 8 },
               new MenuAction() { Id = 26, Name = "Jobs", Title = "تعریف مشاغل گروه", ShowInToolbar = true, Priority = 4, MenuItemId = 8 },

               new MenuAction() { Id = 27, Name = "New", Title = "تعریف شغل جدید", ShowInToolbar = true, Priority = 1, MenuItemId = 9 },
               new MenuAction() { Id = 28, Name = "Edit", Title = "ویرایش شغل", ShowInToolbar = true, Priority = 2, MenuItemId = 9 },
               new MenuAction() { Id = 29, Name = "Delete", Title = "حذف شغل", ShowInToolbar = true, Priority = 3, MenuItemId = 9 },

               new MenuAction() { Id = 30, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 10 },
               new MenuAction() { Id = 31, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 10 },
               new MenuAction() { Id = 32, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 10 }

           );

            modelBuilder.Entity<MenuActionAccess>().HasData(

               new MenuActionAccess() { Id = 19, MenuActionId = 19, UserId = 1 },
               new MenuActionAccess() { Id = 20, MenuActionId = 20, UserId = 1 },
               new MenuActionAccess() { Id = 21, MenuActionId = 21, UserId = 1 },
               new MenuActionAccess() { Id = 22, MenuActionId = 22, UserId = 1 },

               new MenuActionAccess() { Id = 23, MenuActionId = 23, UserId = 1 },
               new MenuActionAccess() { Id = 24, MenuActionId = 24, UserId = 1 },
               new MenuActionAccess() { Id = 25, MenuActionId = 25, UserId = 1 },
               new MenuActionAccess() { Id = 26, MenuActionId = 26, UserId = 1 },

               new MenuActionAccess() { Id = 27, MenuActionId = 27, UserId = 1 },
               new MenuActionAccess() { Id = 28, MenuActionId = 28, UserId = 1 },
               new MenuActionAccess() { Id = 29, MenuActionId = 29, UserId = 1 },

               new MenuActionAccess() { Id = 30, MenuActionId = 30, UserId = 1 },
               new MenuActionAccess() { Id = 31, MenuActionId = 31, UserId = 1 },
               new MenuActionAccess() { Id = 32, MenuActionId = 32, UserId = 1 }
           );

            modelBuilder.Entity<MenuCategory>().HasData(
               new MenuCategory() { Id = 3, Name = "مدیریت بازار", ShowInMenu = true, Priority =3 });

            modelBuilder.Entity<MenuItem>().HasData(
              new MenuItem() { Id = 11, Code = "ShopGroups", Name = "گروه غرفات", ControllerName = "Market", ActionName = "ShopGroups", DialogSize = "medium", ShowInMenu = true, Priority = 1, CategoryId = 3 },
              new MenuItem() { Id = 12, Code = "ShopGroupDefine", Name = "تعریف گروه غرفات", ControllerName = "Market", ActionName = "ShopGroupDefine", DialogSize = "medium", ShowInMenu = false, Priority = 2, CategoryId = 3 },
              new MenuItem() { Id = 13, Code = "Shops", Name = "غرفات", ControllerName = "Market", ActionName = "Shops", DialogSize = "large", ShowInMenu = true, Priority = 3, CategoryId = 3 },
              new MenuItem() { Id = 14, Code = "ShopDefine", Name = "تعریف غرفه", ControllerName = "Market", ActionName = "ShopDefine", DialogSize = "medium", ShowInMenu = false, Priority = 4, CategoryId = 3 },

              new MenuItem() { Id = 15, Code = "MarketStructures", Name = "مدیریت ساختار بازارها", ControllerName = "Market", ActionName = "MarketStructures", DialogSize = "medium", ShowInMenu = true, Priority = 5, CategoryId = 3 },
              new MenuItem() { Id = 16, Code = "MarketStructureDefine", Name = "ایجاد و ویرایش ساختار بازار", ControllerName = "Market", ActionName = "MarketStructureDefine", DialogSize = "medium", ShowInMenu = false, Priority = 6, CategoryId = 3 }
              );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 11, MenuItemId = 11, UserId = 1 },
                new MenuAccess() { Id = 12, MenuItemId = 12, UserId = 1 },
                new MenuAccess() { Id = 13, MenuItemId = 13, UserId = 1 },
                new MenuAccess() { Id = 14, MenuItemId = 14, UserId = 1 },

                new MenuAccess() { Id = 15, MenuItemId = 15, UserId = 1 },
                new MenuAccess() { Id = 16, MenuItemId = 16, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(
              new MenuAction() { Id = 33, Name = "New", Title = "تعریف گروه غرفات", ShowInToolbar = true, Priority = 1, MenuItemId = 11 },
              new MenuAction() { Id = 34, Name = "Edit", Title = "ویرایش گروه غرفات", ShowInToolbar = true, Priority = 2, MenuItemId = 11 },
              new MenuAction() { Id = 35, Name = "Delete", Title = "حذف گروه غرفات", ShowInToolbar = true, Priority = 3, MenuItemId = 11 },
              new MenuAction() { Id = 36, Name = "Shops", Title = "غرفه های گروه", ShowInToolbar = true, Priority = 4, MenuItemId = 11 },

              new MenuAction() { Id = 37, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 12 },
              new MenuAction() { Id = 38, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 12 },
              new MenuAction() { Id = 39, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 12 },
              new MenuAction() { Id = 40, Name = "Shops", Title = "غرفه های گروه", ShowInToolbar = true, Priority = 4, MenuItemId = 12 },

              new MenuAction() { Id = 41, Name = "New", Title = "تعریف غرفه", ShowInToolbar = true, Priority = 1, MenuItemId = 13 },
              new MenuAction() { Id = 42, Name = "Edit", Title = "ویرایش غرفه", ShowInToolbar = true, Priority = 2, MenuItemId = 13 },
              new MenuAction() { Id = 43, Name = "Delete", Title = "حذف غرفه", ShowInToolbar = true, Priority = 3, MenuItemId = 13 },

              new MenuAction() { Id = 44, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 14 },
              new MenuAction() { Id = 45, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 14 },
              new MenuAction() { Id = 46, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 14 },

              new MenuAction() { Id = 47, Name = "New", Title = "تعریف ساختار جدید", ShowInToolbar = true, Priority = 1, MenuItemId = 15 },
              new MenuAction() { Id = 48, Name = "Edit", Title = "ویرایش ساختار", ShowInToolbar = true, Priority = 2, MenuItemId = 15 },
              new MenuAction() { Id = 49, Name = "Delete", Title = "حذف ساختار", ShowInToolbar = true, Priority = 3, MenuItemId = 15 },

              new MenuAction() { Id = 50, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 16 },
              new MenuAction() { Id = 51, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 16 },
              new MenuAction() { Id = 52, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 16 }

          );

            modelBuilder.Entity<MenuActionAccess>().HasData(

               new MenuActionAccess() { Id = 33, MenuActionId = 33, UserId = 1 },
               new MenuActionAccess() { Id = 34, MenuActionId = 34, UserId = 1 },
               new MenuActionAccess() { Id = 35, MenuActionId = 35, UserId = 1 },
               new MenuActionAccess() { Id = 36, MenuActionId = 36, UserId = 1 },

               new MenuActionAccess() { Id = 37, MenuActionId = 37, UserId = 1 },
               new MenuActionAccess() { Id = 38, MenuActionId = 38, UserId = 1 },
               new MenuActionAccess() { Id = 39, MenuActionId = 39, UserId = 1 },
               new MenuActionAccess() { Id = 40, MenuActionId = 40, UserId = 1 },

               new MenuActionAccess() { Id = 41, MenuActionId = 41, UserId = 1 },
               new MenuActionAccess() { Id = 42, MenuActionId = 42, UserId = 1 },
               new MenuActionAccess() { Id = 43, MenuActionId = 43, UserId = 1 },

               new MenuActionAccess() { Id = 44, MenuActionId = 44, UserId = 1 },
               new MenuActionAccess() { Id = 45, MenuActionId = 45, UserId = 1 },
               new MenuActionAccess() { Id = 46, MenuActionId = 46, UserId = 1 },

               new MenuActionAccess() { Id = 47, MenuActionId = 47, UserId = 1 },
               new MenuActionAccess() { Id = 48, MenuActionId = 48, UserId = 1 },
               new MenuActionAccess() { Id = 49, MenuActionId = 49, UserId = 1 },

               new MenuActionAccess() { Id = 50, MenuActionId = 50, UserId = 1 },
               new MenuActionAccess() { Id = 51, MenuActionId = 51, UserId = 1 },
               new MenuActionAccess() { Id = 52, MenuActionId = 52, UserId = 1 }
           );

            modelBuilder.Entity<BasicInformationCategory>().HasData(
               new BasicInformationCategory() { Id = 2, Code = "MarketStructure", Name = "ساختار بازار", Viewable = false, RelatedCategoryId = null });


            modelBuilder.Entity<BasicInformation>().HasData(
               new BasicInformation() { Id = 201, Code = 1, StrCode = "Phase", Name = "فاز", CategoryId = 2, Priority = 1, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 202, Code = 2, StrCode = "Zone", Name = "زون", CategoryId = 2, Priority = 2, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 203, Code = 3, StrCode = "Corridor", Name = "تالار", CategoryId = 2, Priority = 3, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 204, Code = 4, StrCode = "Shop", Name = "غرفه", CategoryId = 2, Priority = 4, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false }
               );

            modelBuilder.Entity<BasicInformationCategory>().HasData(
              new BasicInformationCategory() { Id = 3, Code = "ShopType", Name = "نوع غرفه", Viewable = true, RelatedCategoryId = null });


            modelBuilder.Entity<BasicInformation>().HasData(
               new BasicInformation() { Id = 301, Code = 1, StrCode = "S", Name = "مغازه", CategoryId = 3, Priority = 1, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 302, Code = 2, StrCode = "K", Name = "کیوسک", CategoryId = 3, Priority = 2, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 303, Code = 3, StrCode = "C", Name = "کانکس", CategoryId = 3, Priority = 3, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false }
               );


            modelBuilder.Entity<MenuCategory>().HasData(
              new MenuCategory() { Id = 4, Name = "مدیریت رزرو و اجاره", ShowInMenu = true, Priority = 4 });

            modelBuilder.Entity<MenuItem>().HasData(
             new MenuItem() { Id = 17, Code = "Tariffs", Name = "تعرفه ها", ControllerName = "Market", ActionName = "Tariffs", DialogSize = "large", ShowInMenu = true, Priority = 1, CategoryId = 4 },
             new MenuItem() { Id = 18, Code = "TariffDefine", Name = "تعریف تعرفه غرفات", ControllerName = "Market", ActionName = "TariffDefine", DialogSize = "medium", ShowInMenu = false, Priority = 2, CategoryId = 4 }
             );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 17, MenuItemId = 17, UserId = 1 },
                new MenuAccess() { Id = 18, MenuItemId = 18, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(
             new MenuAction() { Id = 53, Name = "New", Title = "تعریف تعرفه", ShowInToolbar = true, Priority = 1, MenuItemId = 17 },
             new MenuAction() { Id = 54, Name = "Edit", Title = "ویرایش تعرفه", ShowInToolbar = true, Priority = 2, MenuItemId = 17 },
             new MenuAction() { Id = 55, Name = "Delete", Title = "حذف تعرفه", ShowInToolbar = true, Priority = 3, MenuItemId = 17 },

             new MenuAction() { Id = 56, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 18 },
             new MenuAction() { Id = 57, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 18 },
             new MenuAction() { Id = 58, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 18 }

         );

            modelBuilder.Entity<MenuActionAccess>().HasData(

               new MenuActionAccess() { Id = 53, MenuActionId = 53, UserId = 1 },
               new MenuActionAccess() { Id = 54, MenuActionId = 54, UserId = 1 },
               new MenuActionAccess() { Id = 55, MenuActionId = 55, UserId = 1 },

               new MenuActionAccess() { Id = 56, MenuActionId = 56, UserId = 1 },
               new MenuActionAccess() { Id = 57, MenuActionId = 57, UserId = 1 },
               new MenuActionAccess() { Id = 58, MenuActionId = 58, UserId = 1 }
           );

            modelBuilder.Entity<MenuCategory>().HasData(
             new MenuCategory() { Id = 5, Name = "مدیریت مشتریان", ShowInMenu = true, Priority = 5 });

            modelBuilder.Entity<MenuItem>().HasData(
             new MenuItem() { Id = 19, Code = "Customers", Name = "مشتریان", ControllerName = "Market", ActionName = "Customers", DialogSize = "large", ShowInMenu = true, Priority = 1, CategoryId = 5 },
             new MenuItem() { Id = 20, Code = "CustomerDefine", Name = "تعریف مشتریان", ControllerName = "Market", ActionName = "CustomerDefine", DialogSize = "medium", ShowInMenu = false, Priority = 2, CategoryId = 5 },
             new MenuItem() { Id = 21, Code = "CustomerCards", Name = "کارت عضویت", ControllerName = "Market", ActionName = "CustomerCards", DialogSize = "medium", ShowInMenu = false, Priority = 3, CategoryId = 5 },
             new MenuItem() { Id = 22, Code = "CustomerCardDefine", Name = "تعریف کارت عضویت", ControllerName = "Market", ActionName = "CustomerCardDefine", DialogSize = "medium", ShowInMenu = false, Priority = 4, CategoryId = 5 }
             );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 19, MenuItemId = 19, UserId = 1 },
                new MenuAccess() { Id = 20, MenuItemId = 20, UserId = 1 },
                new MenuAccess() { Id = 21, MenuItemId = 21, UserId = 1 },
                new MenuAccess() { Id = 22, MenuItemId = 22, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(
            new MenuAction() { Id = 59, Name = "New", Title = "تعریف مشتری", ShowInToolbar = true, Priority = 1, MenuItemId = 19 },
            new MenuAction() { Id = 60, Name = "Edit", Title = "ویرایش مشتری", ShowInToolbar = true, Priority = 2, MenuItemId = 19 },
            new MenuAction() { Id = 61, Name = "Delete", Title = "حذف مشتری", ShowInToolbar = true, Priority = 3, MenuItemId = 19 },

            new MenuAction() { Id = 62, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 20 },
            new MenuAction() { Id = 63, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 20 },
            new MenuAction() { Id = 64, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 20 },
            new MenuAction() { Id = 65, Name = "CustomerCards", Title = "کارت عضویت", ShowInToolbar = true, Priority = 4, MenuItemId = 20 },
            new MenuAction() { Id = 72, Name = "Credits", Title = "شارژهای اعتبار", ShowInToolbar = true, Priority = 5, MenuItemId = 20 },

            new MenuAction() { Id = 66, Name = "New", Title = "تعریف کارت", ShowInToolbar = true, Priority = 1, MenuItemId = 21 },
            new MenuAction() { Id = 67, Name = "Edit", Title = "ویرایش کارت", ShowInToolbar = true, Priority = 2, MenuItemId = 21 },
            new MenuAction() { Id = 68, Name = "Delete", Title = "حذف کارت", ShowInToolbar = true, Priority = 3, MenuItemId = 21 },

            new MenuAction() { Id = 69, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 22 },
            new MenuAction() { Id = 70, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 22 },
            new MenuAction() { Id = 71, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 22 }

        );

            modelBuilder.Entity<MenuActionAccess>().HasData(

              new MenuActionAccess() { Id = 59, MenuActionId = 59, UserId = 1 },
              new MenuActionAccess() { Id = 60, MenuActionId = 60, UserId = 1 },
              new MenuActionAccess() { Id = 61, MenuActionId = 61, UserId = 1 },

              new MenuActionAccess() { Id = 62, MenuActionId = 62, UserId = 1 },
              new MenuActionAccess() { Id = 63, MenuActionId = 63, UserId = 1 },
              new MenuActionAccess() { Id = 64, MenuActionId = 64, UserId = 1 },
              new MenuActionAccess() { Id = 65, MenuActionId = 65, UserId = 1 },
              new MenuActionAccess() { Id = 72, MenuActionId = 72, UserId = 1 },

              new MenuActionAccess() { Id = 66, MenuActionId = 66, UserId = 1 },
              new MenuActionAccess() { Id = 67, MenuActionId = 67, UserId = 1 },
              new MenuActionAccess() { Id = 68, MenuActionId = 68, UserId = 1 },

              new MenuActionAccess() { Id = 69, MenuActionId = 69, UserId = 1 },
              new MenuActionAccess() { Id = 70, MenuActionId = 70, UserId = 1 },
              new MenuActionAccess() { Id = 71, MenuActionId = 71, UserId = 1 }
          );

            modelBuilder.Entity<BasicInformationCategory>().HasData(
              new BasicInformationCategory() { Id = 4, Code = "PaymentType", Name = "نوع پرداخت", Viewable = false, RelatedCategoryId = null });


            modelBuilder.Entity<BasicInformation>().HasData(
               new BasicInformation() { Id = 401, Code = 1, StrCode = "Cash", Name = "نقدی", CategoryId = 4, Priority = 1, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 402, Code = 2, StrCode = "PCPos", Name = "کارتخوان", CategoryId = 4, Priority = 2, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false }
               );

            modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem() { Id = 23, Code = "Credits", Name = "شارژهای اعتبار", ControllerName = "Market", ActionName = "Credits", DialogSize = "large", ShowInMenu = true, Priority = 5, CategoryId = 5 },
            new MenuItem() { Id = 24, Code = "CreditDefine", Name = "ثبت شارژ اعتبار", ControllerName = "Market", ActionName = "CreditDefine", DialogSize = "medium", ShowInMenu = false, Priority = 6, CategoryId = 5 }
            );

            modelBuilder.Entity<MenuAccess>().HasData(
                new MenuAccess() { Id = 23, MenuItemId = 23, UserId = 1 },
                new MenuAccess() { Id = 24, MenuItemId = 24, UserId = 1 }
                );

            modelBuilder.Entity<MenuAction>().HasData(
            new MenuAction() { Id = 73, Name = "New", Title = "تعریف شارژ", ShowInToolbar = true, Priority = 1, MenuItemId = 23 },
            new MenuAction() { Id = 74, Name = "Edit", Title = "ویرایش شارژ", ShowInToolbar = true, Priority = 2, MenuItemId = 23 },
            new MenuAction() { Id = 75, Name = "Delete", Title = "حذف شارژ", ShowInToolbar = true, Priority = 3, MenuItemId = 23 },

            new MenuAction() { Id = 76, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 24 },
            new MenuAction() { Id = 77, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 24 },
            new MenuAction() { Id = 78, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 24 }
            
        );

            modelBuilder.Entity<MenuActionAccess>().HasData(

              new MenuActionAccess() { Id = 73, MenuActionId = 73, UserId = 1 },
              new MenuActionAccess() { Id = 74, MenuActionId = 74, UserId = 1 },
              new MenuActionAccess() { Id = 75, MenuActionId = 75, UserId = 1 },

              new MenuActionAccess() { Id = 76, MenuActionId = 76, UserId = 1 },
              new MenuActionAccess() { Id = 77, MenuActionId = 77, UserId = 1 },
              new MenuActionAccess() { Id = 78, MenuActionId = 78, UserId = 1 }
              
          );


            modelBuilder.Entity<MenuItem>().HasData(
             new MenuItem() { Id = 25, Code = "Rents", Name = "اجاره ها", ControllerName = "Market", ActionName = "Rents", DialogSize = "large", ShowInMenu = true, Priority = 5, CategoryId = 4 },
             new MenuItem() { Id = 26, Code = "RentDefine", Name = "ثبت اجاره غرفه", ControllerName = "Market", ActionName = "RentDefine", DialogSize = "large", ShowInMenu = false, Priority = 6, CategoryId = 4 },
             new MenuItem() { Id = 32, Code = "Reserves", Name = "رزروها", ControllerName = "Market", ActionName = "Reserves", DialogSize = "large", ShowInMenu = true, Priority = 7, CategoryId = 4 },
             new MenuItem() { Id = 33, Code = "ReserveDefine", Name = "ثبت رزرو غرفه", ControllerName = "Market", ActionName = "ReserveDefine", DialogSize = "large", ShowInMenu = false, Priority = 8, CategoryId = 4 }
             );

            modelBuilder.Entity<MenuAction>().HasData(
             new MenuAction() { Id = 79, Name = "New", Title = "ثبت اجاره", ShowInToolbar = true, Priority = 1, MenuItemId = 25 },
             new MenuAction() { Id = 80, Name = "Edit", Title = "ویرایش اجاره", ShowInToolbar = true, Priority = 2, MenuItemId = 25 },
             new MenuAction() { Id = 81, Name = "Delete", Title = "حذف اجاره", ShowInToolbar = true, Priority = 3, MenuItemId = 25 },

              new MenuAction() { Id = 99, Name = "New", Title = "ثبت رزرو", ShowInToolbar = true, Priority = 1, MenuItemId = 32 },
             new MenuAction() { Id = 100, Name = "Edit", Title = "ویرایش رزرو", ShowInToolbar = true, Priority = 2, MenuItemId = 32 },
             new MenuAction() { Id = 101, Name = "Delete", Title = "حذف رزرو", ShowInToolbar = true, Priority = 3, MenuItemId = 32 },

             new MenuAction() { Id = 82, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 26 },
             new MenuAction() { Id = 83, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 26 },
             new MenuAction() { Id = 84, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 26 },

             new MenuAction() { Id = 102, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 33 },
             new MenuAction() { Id = 103, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 33 },
             new MenuAction() { Id = 104, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 33 },

             new MenuAction() { Id = 85, Name = "NewRent", Title = "ثبت اجاره", ShowInToolbar = true, Priority = 4, MenuItemId = 14 },
             new MenuAction() { Id = 86, Name = "NewRent", Title = "ثبت اجاره", ShowInToolbar = true, Priority = 6, MenuItemId = 20 }

             //new MenuAction() { Id = 88, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 27 }
         );

            modelBuilder.Entity<BasicInformationCategory>().HasData(
              new BasicInformationCategory() { Id = 5, Code = "HomeType", Name = "نوع فرم اصلی", Viewable = false, RelatedCategoryId = null });


            modelBuilder.Entity<BasicInformation>().HasData(
               new BasicInformation() { Id = 501, Code = 1, StrCode = "Page", Name = "نمایش فرم ها به صورت Page", CategoryId = 5, Priority = 1, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false },
               new BasicInformation() { Id = 502, Code = 2, StrCode = "Window", Name = "نمایش فرم ها به صورت Window", CategoryId = 5, Priority = 2, RelatedBasicInformationId = null, Active = true, IsDeleted = false, AllowChange = false, AllowDelete = false }
               );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 28, Code = "ChangePassword", Name = "تغییر کلمه عبور", ControllerName = "Security", ActionName = "ChangePassword", ShowInMenu = true, DialogSize = "medium", Priority = 7, CategoryId = 1 },
                new MenuItem() { Id = 29, Code = "UserSetting", Name = "تنظیمات کاربری", ControllerName = "Security", ActionName = "UserSetting", ShowInMenu = true, DialogSize = "medium", Priority = 8, CategoryId = 1 }
                );
                      

            modelBuilder.Entity<MenuAction>().HasData(
                new MenuAction() { Id = 91, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 28 },
                new MenuAction() { Id = 92, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 29 }
            );

            modelBuilder.Entity<Setting>().HasData(
                new Setting() { Id = 1, KeyName = "DefaultDebtCeiling", KeyValue = "0", Active = true },
                new Setting() { Id = 2, KeyName = "MinCardCredit", KeyValue = "0", Active = true }
            );

            modelBuilder.Entity<MenuItem>().HasData(
             new MenuItem() { Id = 30, Code = "Discounts", Name = "تخفیفات", ControllerName = "Market", ActionName = "Discounts", DialogSize = "medium", ShowInMenu = true, Priority = 3, CategoryId = 4 },
             new MenuItem() { Id = 31, Code = "DiscountDefine", Name = "تعریف تخفیف", ControllerName = "Market", ActionName = "DiscountDefine", DialogSize = "medium", ShowInMenu = false, Priority = 4, CategoryId = 4 }
             );

            modelBuilder.Entity<MenuAction>().HasData(
             new MenuAction() { Id = 93, Name = "New", Title = "تعریف تخفیف", ShowInToolbar = true, Priority = 1, MenuItemId = 30 },
             new MenuAction() { Id = 94, Name = "Edit", Title = "ویرایش تخفیف", ShowInToolbar = true, Priority = 2, MenuItemId = 30 },
             new MenuAction() { Id = 95, Name = "Delete", Title = "حذف تخفیف", ShowInToolbar = true, Priority = 3, MenuItemId = 30 },

             new MenuAction() { Id = 96, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 31 },
             new MenuAction() { Id = 97, Name = "SaveAndNew", Title = "ذخیره و جدید", ShowInToolbar = true, Priority = 2, MenuItemId = 31 },
             new MenuAction() { Id = 98, Name = "SaveAndContinue", Title = "ذخیره و ادامه", ShowInToolbar = true, Priority = 3, MenuItemId = 31 }

         );

            modelBuilder.Entity<Person>().HasAlternateKey(p => p.Code).HasName("AK_Person_Code");
            modelBuilder.Entity<Person>().HasAlternateKey(p => p.StrCode).HasName("AK_Person_StrCode");


            modelBuilder.Entity<MenuItem>().HasData(
              new MenuItem() { Id = 34, Code = "PrinterSetting", Name = "تعریف پرینتر", ControllerName = "General", ActionName = "PrinterSetting", DialogSize = "medium", ShowInMenu = true, Priority = 7, CategoryId = 2 },
              new MenuItem() { Id = 35, Code = "PrintTemplate", Name = "تعریف فرمت رسید اجاره و رزرو", ControllerName = "General", ActionName = "PrintTemplate", DialogSize = "medium", ShowInMenu = true, Priority = 8, CategoryId = 2 }
              );

            modelBuilder.Entity<MenuAction>().HasData(
               new MenuAction() { Id = 105, Name = "Save", Title = "ذخیره", ShowInToolbar = true, Priority = 1, MenuItemId = 34 }


           );

            //modelBuilder.Entity<User>().HasAlternateKey(u => u.PersonId).HasName("AK_User_PersonId");
            //modelBuilder.Entity<User>().HasAlternateKey(u => u.Username).HasName("AK_User_Username");

            //modelBuilder.Entity<MenuCategory>().HasAlternateKey(m => m.Name);

            //modelBuilder.Entity<MenuItem>().HasAlternateKey(m => m.Code);
            //modelBuilder.Entity<MenuItem>().HasAlternateKey(m => new { m.Name, m.CategoryId });

            //modelBuilder.Entity<MenuAction>().HasAlternateKey(m => m.Name);
            //modelBuilder.Entity<MenuAction>().HasAlternateKey(m => new { m.Title, m.MenuItemId });

        }

    }
}
