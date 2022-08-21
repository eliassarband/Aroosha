using Aroosha.Models;
using Aroosha.Repositories;
using Aroosha.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    public class GeneralService:IGeneralService
    {

        public IEnumerable<JobGroupModel> GetJobGroups(IGeneralRepository repository)
        {
            List<JobGroupModel> model = new List<JobGroupModel>();

            var groups = repository.JobGroups;

            foreach (var item in groups)
            {
                var jobs = item.Jobs;

                List<JobModel> jModel = new List<JobModel>();

                foreach (var jItem in jobs)
                {
                    jModel.Add(new JobModel()
                    {
                        JobId=jItem.Id,
                        JobCode = jItem.Code,
                        JobName = jItem.Name,
                        JobGroupId=jItem.JobGroupId,
                        JobGroupName=item.Name
                    });
                }

                model.Add(new JobGroupModel()
                {
                    JobGroupId = item.Id,
                    JobGroupCode = item.Code,
                    JobGroupName = item.Name,
                    JobGroupJobCount = item.Jobs.Count(),
                    JobModels=jModel
                });
            }

            return model;
        }

        public JobGroupDefineModel GetJobGroupDefine(IGeneralRepository repository, int Id)
        {
            JobGroupDefineModel model = new JobGroupDefineModel();

            var group = repository.JobGroups.FirstOrDefault(g => g.Id == Id);

            if (group != null)
            {
                var jobs = group.Jobs;


                List<JobModel> jModel = new List<JobModel>();

                foreach (var jItem in jobs)
                {
                    jModel.Add(new JobModel()
                    {
                        JobId = jItem.Id,
                        JobCode = jItem.Code,
                        JobName = jItem.Name,
                        JobGroupId = jItem.JobGroupId,
                        JobGroupName = group.Name
                    });
                }

                model.JobGroupDefineId = group.Id;
                model.JobGroupDefineCode = group.Code;
                model.JobGroupDefineName = group.Name;
                model.JobGroupDefineJobCount = group.Jobs.Count();
                model.JobModels = jModel;
            }

            return model;
        }

        public NotificationModel DeleteJobGroup(IGeneralRepository repository, int JobGroupId)
        {

            bool success = true;

            if (success)
            {
                var groups = repository.JobGroups.Where(g => g.Id == JobGroupId);
                success = repository.DeleteJobGroup(groups);
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

        public NotificationModel SaveJobGroup(IGeneralRepository repository, JobGroupDefineModel jobGroupModel)
        {
            bool success = true;
            int JobGroupId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.JobGroups.Where(g => g.Id != jobGroupModel.JobGroupDefineId).Any(g => g.Code == jobGroupModel.JobGroupDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد گروه وارد شده تکراری می باشد";

            }
            else if (repository.JobGroups.Where(g => g.Id != jobGroupModel.JobGroupDefineId).Any(g => g.Name == jobGroupModel.JobGroupDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام گروه وارد شده تکراری می باشد";

            }


            if (success)
            {

                success = repository.SaveJobGroup(new GeneralDAL.Database.JobGroup()
                {
                    Id = jobGroupModel.JobGroupDefineId,
                    Code = jobGroupModel.JobGroupDefineCode,
                    Name = jobGroupModel.JobGroupDefineName
                });

                JobGroupId = repository.JobGroups.Where(g => g.Name == jobGroupModel.JobGroupDefineName && g.Code == jobGroupModel.JobGroupDefineCode).FirstOrDefault().Id;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel model = new NotificationModel()
            {
                Id = JobGroupId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public JobDefineModel GetJobDefine(IGeneralRepository repository, int Id,int JobGroupId)
        {
            JobDefineModel model = new JobDefineModel();

            if (JobGroupId > 0)
            {
                model.JobGroupId = JobGroupId;
                model.JobGroupName = repository.JobGroups.FirstOrDefault(g => g.Id == JobGroupId).Name;

                var job = repository.Jobs.FirstOrDefault(j => j.Id == Id);
                if (job != null)
                {
                    model.JobDefineId = job.Id;
                    model.JobDefineCode = job.Code;
                    model.JobDefineName = job.Name;
                }
                else
                {
                    model.JobDefineId = 0;
                    model.JobDefineCode = 0;
                    model.JobDefineName = "";
                }
            }
            

            return model;
        }

        

        public IEnumerable<JobModel> GetJobs(IGeneralRepository repository, int Id)
        {
            List<JobModel> model = new List<JobModel>();

            var jobs = repository.Jobs;

            if (Id > 0)
            {
                jobs = repository.Jobs.Where(j => j.JobGroupId == Id);
            } 

            foreach (var jItem in jobs)
            {
                model.Add(new JobModel()
                {
                    JobId = jItem.Id,
                    JobCode = jItem.Code,
                    JobName = jItem.Name,
                    JobGroupId = jItem.JobGroupId,
                    JobGroupName = jItem.JobGroup.Name
                }) ;
            }

            return model;
        }

        public IEnumerable<JobModel> GetJobGroupJobsForCombo(IGeneralRepository repository)
        {
            List<JobModel> model = new List<JobModel>();

            var jobs = repository.Jobs;


            foreach (var jItem in jobs)
            {
                model.Add(new JobModel()
                {
                    JobId = jItem.Id,
                    JobCode = jItem.Code,
                    JobName = jItem.Name,
                    JobGroupId = jItem.JobGroupId,
                    JobGroupName = jItem.JobGroup.Name,
                    JobFullName= jItem.JobGroup.Name + ">>" + jItem.Name
                });
            }

            return model;
        }


        public NotificationModel DeleteJob(IGeneralRepository repository, int JobId)
        {

            bool success = true;

            if (success)
            {
                var jobs = repository.Jobs.Where(g => g.Id == JobId);
                success = repository.DeleteJob(jobs);
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

        public NotificationModel SaveJob(IGeneralRepository repository, JobDefineModel jobModel)
        {
            bool success = true;
            int JobId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Jobs.Where(g => g.Id != jobModel.JobDefineId).Any(g => g.Code == jobModel.JobDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد شغل وارد شده تکراری می باشد";

            }
            else if (repository.Jobs.Where(g => g.Id != jobModel.JobDefineId).Any(g => g.Name == jobModel.JobDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام شغل وارد شده تکراری می باشد";

            }


            if (success)
            {

                success = repository.SaveJob(new GeneralDAL.Database.Job()
                {
                    Id = jobModel.JobDefineId,
                    Code = jobModel.JobDefineCode,
                    Name = jobModel.JobDefineName,
                    JobGroupId= jobModel.JobGroupId
                });

                JobId = repository.Jobs.Where(g => g.Name == jobModel.JobDefineName && g.Code == jobModel.JobDefineCode).FirstOrDefault().Id;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel model = new NotificationModel()
            {
                Id = JobId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public IEnumerable<BasicInformationForComboModel> GetHomeTypeForCombo(IGeneralRepository genRepository)
        {
            List<BasicInformationForComboModel> model = new List<BasicInformationForComboModel>();

            var types = genRepository.BasicInformations.Where(b => b.Category.Code == "HomeType").OrderBy(b => b.Priority);

            foreach (var type in types)
            {
                model.Add(new BasicInformationForComboModel()
                {
                    Id = type.Id,
                    Code = type.Code,
                    StrCode = type.StrCode,
                    Name = type.Name,
                    Priority = type.Priority
                });
            }

            return model;
        }

        public IEnumerable<CityForComboModel> GetCityForCombo(IGeneralRepository repository)
        {
            List<CityForComboModel> model = new List<CityForComboModel>();

            var cities = repository.Regions.Where(r => r.TypeId == 3).OrderBy(r => r.Name);

            foreach (var city in cities)
            {
                model.Add(new CityForComboModel()
                {
                    Id = city.Id,
                    Code = city.Code,
                    Name = city.Name,
                    ProvinceId = city.Parent.Id,
                    ProvinceCode = city.Parent.Code,
                    ProvinceName = city.Parent.Name,
                    CityFullName = city.Parent.Name + ">>" + city.Name
                });
            }

            return model;
        }

        public PCPosSettingModel GetPCPosSetting(IGeneralRepository repository, string DeviceName)
        {
            PCPosSettingModel model = new PCPosSettingModel();

            var pcPos = repository.PCPosSettings.FirstOrDefault(p => p.ComputerName == DeviceName);

            if (pcPos != null)
            {
                model = new PCPosSettingModel()
                {
                    Id=pcPos.Id,
                    PosType= pcPos.PosType,
                    ConnectionType= pcPos.ConnectionType,
                    IPAddress= pcPos.IPAddress,
                    PortNumber= pcPos.PortNumber,
                    ComPortName= pcPos.ComPortName,
                    ComBaudRate= pcPos.ComBaudRate,
                    ConnectionTimeout= pcPos.ConnectionTimeout,
                    ResponceTimeout= pcPos.ResponceTimeout,
                    OptionalData= pcPos.OptionalData,
                    TerminalID= pcPos.TerminalID,
                    TerminalSerialID= pcPos.TerminalSerialID,
                    AcceptorID= pcPos.AcceptorID
                };
            }

            return model;
        }

        public BasicInformationModel GetBasicInformationById(IGeneralRepository repository, int Id)
        {
            BasicInformationModel model = new BasicInformationModel();

            var basicInformation = repository.BasicInformations.FirstOrDefault(b => b.Id == Id);

            if (basicInformation != null)
            {
                model = new BasicInformationModel()
                {
                    Id=basicInformation.Id,
                    Code= basicInformation.Code,
                    StrCode= basicInformation.StrCode,
                    Name=basicInformation.Name,
                    Priority= basicInformation.Priority
                };
            }

            return model;
        }

        public PrinterSettingModel GetComputerPrinterSetting(IGeneralRepository repository, string DeviceName)
        {
            PrinterSettingModel model = new PrinterSettingModel();

            var printer = repository.PrinterSettings.FirstOrDefault(p => p.ComputerName == DeviceName);

            if (printer != null)
            {
                model = new PrinterSettingModel()
                {
                    Id = printer.Id,
                    ComputerName = printer.ComputerName,
                    PrinterName = printer.PrinterName
                };
            }
            else
            {
                model = new PrinterSettingModel()
                {
                    Id = 0,
                    ComputerName = DeviceName,
                    PrinterName = ""
                };
            }

            return model;
        }

        public NotificationModel SavePrinterSetting(IGeneralRepository repository, PrinterSettingModel printerModel)
        {
            bool success = true;
            int PrinterId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var printer = repository.PrinterSettings.FirstOrDefault(p => p.ComputerName == printerModel.ComputerName);

            if (printer != null && printerModel.Id == 0)
            {
                printerModel.Id = printer.Id;
            }


            if (success)
            {

                success = repository.SavePrinterSetting(new GeneralDAL.Database.PrinterSetting()
                {
                    Id = printerModel.Id,
                    ComputerName = printerModel.ComputerName,
                    PrinterName = printerModel.PrinterName
                });

                PrinterId = repository.PrinterSettings.FirstOrDefault(p => p.ComputerName== printerModel.ComputerName).Id;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel model = new NotificationModel()
            {
                Id = PrinterId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }

        public PrintTemplateModel GetPrintTemplate(IGeneralRepository repository, string Code)
        {
            PrintTemplateModel model = new PrintTemplateModel();

            var template = repository.PrintTemplates.FirstOrDefault(p => p.Code == Code);

            if (template != null)
            {
                model = new PrintTemplateModel()
                {
                    Id = template.Id,
                    Code = template.Code,
                    Name = template.Name,
                    Content = template.Content
                };
            }
            else
            {
                model = new PrintTemplateModel()
                {
                    Id = 0,
                    Code = Code,
                    Name = "",
                    Content = null
                };
            }

            return model;
        }

        public NotificationModel SavePrintTemplate(IGeneralRepository repository, PrintTemplateModel printModel)
        {
            bool success = true;
            int PrintId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var print = repository.PrintTemplates.FirstOrDefault(p => p.Code== printModel.Code);

            if (print != null && printModel.Id == 0)
            {
                printModel.Id = print.Id;
            }


            if (success)
            {

                success = repository.SavePrintTemplate(new GeneralDAL.Database.PrintTemplate()
                {
                    Id = printModel.Id,
                    Code = printModel.Code,
                    Name = printModel.Name,
                    Content= printModel.Content
                });

                PrintId = repository.PrintTemplates.FirstOrDefault(p => p.Code== printModel.Code).Id;

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel model = new NotificationModel()
            {
                Id = PrintId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return model;
        }
    }
}
