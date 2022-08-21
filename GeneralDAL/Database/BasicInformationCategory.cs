using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("BasicInformationCategory", Schema = "Gnr")]
    public class BasicInformationCategory
    {

        public int Id { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool Viewable { get; set; }

        [ForeignKey("RelatedCategoryId")]
        public int? RelatedCategoryId { get; set; }
        public virtual BasicInformationCategory RelatedCategory { get; set; }

        public virtual ICollection<BasicInformationCategory> BasicInformationCategories { get; set; }

        public virtual ICollection<BasicInformation> BasicInformations { get; set; }

    }
}