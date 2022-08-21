using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneralDAL.Database
{
    [Table("PCPosSetting", Schema = "Gnr")]
    public class PCPosSetting
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ComputerName { get; set; }

        [MaxLength(50)]
        public string PosType { get; set; }

        [MaxLength(20)]
        public string ConnectionType { get; set; }

        [MaxLength(20)]
        public string IPAddress { get; set; }

        public int PortNumber { get; set; }

        [MaxLength(20)]
        public string? ComPortName { get; set; }

        public int? ComBaudRate { get; set; }

        public int ConnectionTimeout { get; set; }

        public int ResponceTimeout { get; set; }

        [MaxLength(200)]
        public string? OptionalData { get; set; }

        [MaxLength(50)]
        public  string? TerminalSerialID { get; set; }

        [MaxLength(50)]
        public string? AcceptorID { get; set; }

        [MaxLength(50)]
        public string? TerminalID { get; set; }

    }
}
