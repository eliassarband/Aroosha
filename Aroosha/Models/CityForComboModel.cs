using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CityForComboModel
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public int ProvinceCode { get; set; }

        public string ProvinceName { get; set; }

        public string CityFullName { get; set; }

    }
}
