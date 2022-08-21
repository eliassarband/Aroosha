﻿// <auto-generated />
using System;
using GeneralDAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeneralDAL.Migrations
{
    [DbContext(typeof(ArooshaContext))]
    [Migration("20210203073716_GroupUsers")]
    partial class GroupUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeneralDAL.Database.BasicInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowChange")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowDelete")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedBasicInformationId")
                        .HasColumnType("int");

                    b.Property<string>("StrCode")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RelatedBasicInformationId");

                    b.ToTable("BasicInformation","Gnr");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            AllowChange = false,
                            AllowDelete = false,
                            CategoryId = 1,
                            Code = 1,
                            IsDeleted = false,
                            Name = "کشور",
                            Priority = 1,
                            StrCode = "Country"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            AllowChange = false,
                            AllowDelete = false,
                            CategoryId = 1,
                            Code = 2,
                            IsDeleted = false,
                            Name = "استان",
                            Priority = 2,
                            StrCode = "Province"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            AllowChange = false,
                            AllowDelete = false,
                            CategoryId = 1,
                            Code = 3,
                            IsDeleted = false,
                            Name = "شهر",
                            Priority = 3,
                            StrCode = "City"
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.BasicInformationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("RelatedCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Viewable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RelatedCategoryId");

                    b.ToTable("BasicInformationCategory","Gnr");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "RegionType",
                            Name = "نوع منطقه",
                            Viewable = false
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Group","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "مدیر سیستم"
                        },
                        new
                        {
                            Id = 2,
                            Name = "کاربران عمومی"
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.GroupUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUser","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            GroupId = 2,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.LoginAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientIPAddr")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LoginResult")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Logined")
                        .HasColumnType("bit");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginAttempt","Sec");
                });

            modelBuilder.Entity("GeneralDAL.Database.LoginedData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientIPAddr")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LogoutDate")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LogoutTime")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginedData","Sec");
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("UserId");

                    b.ToTable("MenuAccess","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("ShowInToolbar")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuAction","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            Name = "New",
                            Priority = 1,
                            ShowInToolbar = true,
                            Title = "تعریف کاربر جدید"
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 1,
                            Name = "Edit",
                            Priority = 2,
                            ShowInToolbar = true,
                            Title = "ویرایش کاربر"
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 1,
                            Name = "Delete",
                            Priority = 3,
                            ShowInToolbar = true,
                            Title = "حذف کاربر"
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 2,
                            Name = "Save",
                            Priority = 1,
                            ShowInToolbar = true,
                            Title = "ذخیره"
                        },
                        new
                        {
                            Id = 6,
                            MenuItemId = 2,
                            Name = "SaveAndContinue",
                            Priority = 2,
                            ShowInToolbar = true,
                            Title = "ذخیره و ادامه"
                        },
                        new
                        {
                            Id = 5,
                            MenuItemId = 2,
                            Name = "SaveAndNew",
                            Priority = 3,
                            ShowInToolbar = true,
                            Title = "ذخیره و جدید"
                        },
                        new
                        {
                            Id = 7,
                            MenuItemId = 3,
                            Name = "New",
                            Priority = 1,
                            ShowInToolbar = true,
                            Title = "تعریف گروه جدید"
                        },
                        new
                        {
                            Id = 8,
                            MenuItemId = 3,
                            Name = "Edit",
                            Priority = 2,
                            ShowInToolbar = true,
                            Title = "ویرایش گروه"
                        },
                        new
                        {
                            Id = 9,
                            MenuItemId = 3,
                            Name = "Delete",
                            Priority = 3,
                            ShowInToolbar = true,
                            Title = "حذف گروه"
                        },
                        new
                        {
                            Id = 12,
                            MenuItemId = 4,
                            Name = "Save",
                            Priority = 2,
                            ShowInToolbar = true,
                            Title = "ذخیره"
                        },
                        new
                        {
                            Id = 14,
                            MenuItemId = 4,
                            Name = "SaveAndNew",
                            Priority = 3,
                            ShowInToolbar = true,
                            Title = "ذخیره و جدید"
                        },
                        new
                        {
                            Id = 13,
                            MenuItemId = 4,
                            Name = "SaveAndContinue",
                            Priority = 4,
                            ShowInToolbar = true,
                            Title = "ذخیره و ادامه"
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuActionAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuActionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuActionId");

                    b.HasIndex("UserId");

                    b.ToTable("MenuActionAccess","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuActionId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuActionId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuActionId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuActionId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuActionId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            MenuActionId = 6,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            MenuActionId = 7,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            MenuActionId = 8,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            MenuActionId = 9,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            MenuActionId = 12,
                            UserId = 1
                        },
                        new
                        {
                            Id = 13,
                            MenuActionId = 13,
                            UserId = 1
                        },
                        new
                        {
                            Id = 14,
                            MenuActionId = 14,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("ShowInMenu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MenuCategory","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "مدریریت کاربران",
                            Priority = 2,
                            ShowInMenu = true
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DialogSize")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("ShowInMenu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuItem","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActionName = "Users",
                            CategoryId = 1,
                            Code = "Users",
                            ControllerName = "Security",
                            DialogSize = "medium",
                            Name = "تعریف کاربران",
                            Priority = 2,
                            ShowInMenu = true
                        },
                        new
                        {
                            Id = 2,
                            ActionName = "UserDefine",
                            CategoryId = 1,
                            Code = "UserDefine",
                            ControllerName = "Security",
                            DialogSize = "medium",
                            Name = "ایجاد و ویرایش کاربران",
                            Priority = 3,
                            ShowInMenu = false
                        },
                        new
                        {
                            Id = 3,
                            ActionName = "Groups",
                            CategoryId = 1,
                            Code = "Groups",
                            ControllerName = "Security",
                            DialogSize = "medium",
                            Name = "تعریف گروه‌های کاربری",
                            Priority = 3,
                            ShowInMenu = true
                        },
                        new
                        {
                            Id = 4,
                            ActionName = "GroupDefine",
                            CategoryId = 1,
                            Code = "GroupDefine",
                            ControllerName = "Security",
                            DialogSize = "small",
                            Name = "ایجاد و ویرایش گروه‌های کاربری",
                            Priority = 4,
                            ShowInMenu = false
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("StrCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Person","Gnr");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Code = 1,
                            FirstName = "مدیر",
                            LastName = "سیستم",
                            StrCode = "1"
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("TypeId");

                    b.ToTable("Region","Gnr");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "ایران",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Code = 4,
                            Name = "اصفهان",
                            ParentId = 1,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Code = 6,
                            Name = "اصفهان",
                            ParentId = 2,
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Tenant","Gnr");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "سازمان میادین میوه و تره بار و ساماندهی مشاغل شهری شهرداری اصفهان"
                        },
                        new
                        {
                            Id = 2,
                            Code = 2,
                            Name = "جمعه بازار بعثت",
                            ParentId = 1
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("ForceFirstLoginChange")
                        .HasColumnType("bit");

                    b.Property<string>("HashPassword")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("PasswordHint")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TenantId");

                    b.ToTable("User","Sec");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            ForceFirstLoginChange = false,
                            HashPassword = "65bb559e8ed079554da6b55d4b6fec00",
                            PasswordHint = "nothing",
                            PersonId = 1,
                            TenantId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("GeneralDAL.Database.BasicInformation", b =>
                {
                    b.HasOne("GeneralDAL.Database.BasicInformationCategory", "Category")
                        .WithMany("BasicInformations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralDAL.Database.BasicInformation", "RelatedBasicInformation")
                        .WithMany("BasicInformations")
                        .HasForeignKey("RelatedBasicInformationId");
                });

            modelBuilder.Entity("GeneralDAL.Database.BasicInformationCategory", b =>
                {
                    b.HasOne("GeneralDAL.Database.BasicInformationCategory", "RelatedCategory")
                        .WithMany("BasicInformationCategories")
                        .HasForeignKey("RelatedCategoryId");
                });

            modelBuilder.Entity("GeneralDAL.Database.GroupUser", b =>
                {
                    b.HasOne("GeneralDAL.Database.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralDAL.Database.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.LoginAttempt", b =>
                {
                    b.HasOne("GeneralDAL.Database.User", "User")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GeneralDAL.Database.LoginedData", b =>
                {
                    b.HasOne("GeneralDAL.Database.User", "User")
                        .WithMany("LoginedDatas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuAccess", b =>
                {
                    b.HasOne("GeneralDAL.Database.MenuItem", "MenuItem")
                        .WithMany("MenuAccesses")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralDAL.Database.User", "User")
                        .WithMany("MenuAccesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuAction", b =>
                {
                    b.HasOne("GeneralDAL.Database.MenuItem", "MenuItem")
                        .WithMany("MenuActions")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuActionAccess", b =>
                {
                    b.HasOne("GeneralDAL.Database.MenuAction", "MenuAction")
                        .WithMany("MenuActionAccesses")
                        .HasForeignKey("MenuActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralDAL.Database.User", "User")
                        .WithMany("MenuActionAccesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.MenuItem", b =>
                {
                    b.HasOne("GeneralDAL.Database.MenuCategory", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.Region", b =>
                {
                    b.HasOne("GeneralDAL.Database.Region", "Parent")
                        .WithMany("Regions")
                        .HasForeignKey("ParentId");

                    b.HasOne("GeneralDAL.Database.BasicInformation", "Type")
                        .WithMany("Regions")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralDAL.Database.Tenant", b =>
                {
                    b.HasOne("GeneralDAL.Database.Tenant", "Parent")
                        .WithMany("Tenants")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("GeneralDAL.Database.User", b =>
                {
                    b.HasOne("GeneralDAL.Database.Person", "Person")
                        .WithMany("PersonUser")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralDAL.Database.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
