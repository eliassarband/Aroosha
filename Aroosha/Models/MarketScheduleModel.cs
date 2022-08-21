using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MarketScheduleModel
    {
        public int MarketScheduleId { get; set; }

        public int MarketScheduleDetailId { get; set; }

        public int MarketId { get; set; }

        public string MarketName { get; set; }

        public string MarketScheduleDescription { get; set; }

        public string MarketScheduleDate { get; set; }

        public string ComboDescription { get; set; }

    }
}
