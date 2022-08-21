using GeneralDAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public class EFGeneralRepository:IGeneralRepository
    {
        private readonly ArooshaContext context;

        public EFGeneralRepository(ArooshaContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<JobGroup> JobGroups {
            get { return context.JobGroups.Include(g => g.Jobs); }
        }

        public IEnumerable<Job> Jobs {
            get { return context.Jobs.Include(j => j.JobGroup); }
        }

        public IEnumerable<BasicInformation> BasicInformations {
            get { return context.BasicInformations.Include(b => b.Category); } 
        }

        public IEnumerable<BasicInformationCategory> BasicInformationCategories
        {
            get { return context.BasicInformationCategories.Include(b => b.BasicInformations); }
        }

        public bool DeleteJobGroup(IEnumerable<JobGroup> jobGroups)
        {
            try
            {
                foreach (var group in jobGroups)
                {
                    var jobs = group.Jobs;
                    foreach (var job in jobs)
                    {
                        context.Jobs.Remove(job);
                    }

                    context.JobGroups.Remove(group);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveJobGroup(JobGroup jobGroup)
        {
            try
            {
                if (jobGroup.Id > 0)
                {
                    var p = context.JobGroups.FirstOrDefault(x => x.Id == jobGroup.Id);
                    if (p != null)
                    {
                        p.Code = jobGroup.Code;
                        p.Name = jobGroup.Name;
                        p.Jobs = jobGroup.Jobs;
                    }
                }
                else
                    context.JobGroups.Add(jobGroup);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteJob(IEnumerable<Job> jobs)
        {
            try
            {
                foreach (var job in jobs)
                {
                    
                    context.Jobs.Remove(job);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveJob(Job job)
        {
            try
            {
                if (job.Id > 0)
                {
                    var p = context.Jobs.FirstOrDefault(x => x.Id == job.Id);
                    if (p != null)
                    {
                        p.Code = job.Code;
                        p.Name = job.Name;
                        p.JobGroupId = job.JobGroupId;
                    }
                }
                else
                    context.Jobs.Add(job);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Region> Regions {
            get { return context.Regions.Include(r => r.Parent); }
        }

        public IEnumerable<PCPosSetting> PCPosSettings 
        {
            get { return context.PCPosSettings; }
        }

        public IEnumerable<PrinterSetting> PrinterSettings 
        {
            get { return context.PrinterSettings; }
        }

        public bool SavePrinterSetting(PrinterSetting printerSetting)
        {
            try
            {
                if (printerSetting.Id > 0)
                {
                    var p = context.PrinterSettings.FirstOrDefault(x => x.Id == printerSetting.Id);
                    if (p != null)
                    {
                        p.ComputerName = printerSetting.ComputerName;
                        p.PrinterName = printerSetting.PrinterName;
                        
                    }
                }
                else
                    context.PrinterSettings.Add(printerSetting);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<PrintTemplate> PrintTemplates 
        {
            get { return context.PrintTemplates; }
        }

        public bool SavePrintTemplate(PrintTemplate printTemplate)
        {
            try
            {
                if (printTemplate.Id > 0)
                {
                    var p = context.PrintTemplates.FirstOrDefault(x => x.Id == printTemplate.Id);
                    if (p != null)
                    {
                        p.Code = printTemplate.Code;
                        p.Name = printTemplate.Name;
                        p.Content = printTemplate.Content;
                    }
                }
                else
                    context.PrintTemplates.Add(printTemplate);

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
