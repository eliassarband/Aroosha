using Aroosha.Models;
using Aroosha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aroosha.Services
{
    public interface IGeneralService
    {
        IEnumerable<JobGroupModel> GetJobGroups(IGeneralRepository repository);

        JobGroupDefineModel GetJobGroupDefine(IGeneralRepository repository, int Id);

        NotificationModel DeleteJobGroup(IGeneralRepository repository, int JobGroupId);

        NotificationModel SaveJobGroup(IGeneralRepository repository, JobGroupDefineModel jobGroupModel);

        JobDefineModel GetJobDefine(IGeneralRepository repository, int Id, int JobGroupId);

        IEnumerable<JobModel> GetJobs(IGeneralRepository repository,int Id);

        IEnumerable<JobModel> GetJobGroupJobsForCombo(IGeneralRepository repository);

        NotificationModel DeleteJob(IGeneralRepository repository, int JobId);

        NotificationModel SaveJob(IGeneralRepository repository, JobDefineModel jobModel);

        IEnumerable<BasicInformationForComboModel> GetHomeTypeForCombo(IGeneralRepository genRepository);

        IEnumerable<CityForComboModel> GetCityForCombo(IGeneralRepository repository);

        PCPosSettingModel GetPCPosSetting(IGeneralRepository repository, string DeviceName);

        BasicInformationModel GetBasicInformationById(IGeneralRepository repository, int Id);

        PrinterSettingModel GetComputerPrinterSetting(IGeneralRepository repository, string DeviceName);

        NotificationModel SavePrinterSetting(IGeneralRepository repository, PrinterSettingModel printerModel);

        PrintTemplateModel GetPrintTemplate(IGeneralRepository repository, string Code);

        NotificationModel SavePrintTemplate(IGeneralRepository repository, PrintTemplateModel printModel);


    }
}
