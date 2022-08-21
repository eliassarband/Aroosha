using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Customer", Schema = "Mrk")]
    public class Customer
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string? NationalCode { get; set; }

        public long? IdentityNumber { get; set; }

        [MaxLength(50)]
        public string? FatherName { get; set; }

        [MaxLength(11)]
        public string? MobileNumber { get; set; }

        [MaxLength(1000)]
        public  string? WorkAddress { get; set; }

        [MaxLength(11)]
        public string? WorkPhone { get; set; }

        [MaxLength(1000)]
        public string? HomeAddress { get; set; }

        [MaxLength(11)]
        public string? HomePhone { get; set; }

        public bool Gender { get; set; }

        [Range(1250,1500)]
        public int? BirthYear { get; set; }

        [ForeignKey("BirthCityId")]
        public int? BirthCityId { get; set; }
        public virtual Region BirthCity { get; set; }

        [ForeignKey("IssuanceCityId")]
        public int? IssuanceCityId { get; set; }
        public virtual Region IssuanceCity { get; set; }

        [ForeignKey("JobGroupId")]
        public int? JobGroupId { get; set; }
        public virtual JobGroup JobGroup { get; set; }

        [ForeignKey("JobId")]
        public int? JobId { get; set; }
        public virtual Job Job { get; set; }

        public int? AccountBalance { get; set; }

        public int? AppAccountBalance { get; set; }

        public int? TotalRentsAmount { get; set; }

        public int? TotalPaymentsAmount { get; set; }

        public int? DebtCeiling { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string RevFullName
        {
            get { return LastName + " " + FirstName; }
        }

        public virtual ICollection<CustomerCard> CustomerCards { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
