using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public interface IGeneralRepository
    {
        IEnumerable<JobGroup> JobGroups { get; }

        IEnumerable<Job> Jobs { get; }

        IEnumerable<BasicInformation> BasicInformations { get; }

        IEnumerable<BasicInformationCategory> BasicInformationCategories { get; }

        bool DeleteJobGroup(IEnumerable<JobGroup> jobGroups);

        bool SaveJobGroup(JobGroup jobGroup);

        bool DeleteJob(IEnumerable<Job> jobs);

        bool SaveJob(Job job);

        IEnumerable<Region> Regions { get; }

        IEnumerable<PCPosSetting> PCPosSettings { get; }

        IEnumerable<PrinterSetting> PrinterSettings { get; }

        bool SavePrinterSetting(PrinterSetting printerSetting);

        IEnumerable<PrintTemplate> PrintTemplates { get; }

        bool SavePrintTemplate(PrintTemplate printTemplate);
    }
}
