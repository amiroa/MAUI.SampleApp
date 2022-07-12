using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace OA.Public.Maui.SampleApp.Models
{
    public class PrinterInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string AccessKey { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string AccessCode { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(512)]
        public string DisplayName { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        public string CommunicationType { get; set; }

        [MaxLength(10)]
        public string SerialComPort { get; set; }

        public int SerialBaudRate { get; set; }

        [MaxLength(15)]
        public string NetworkIPAddress { get; set; }

        [MaxLength(8)]
        public string NetworkPort { get; set; }

        public bool IsPrinterMonitorActive { get; set; }

        public string Options { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
    

    

    public enum PrinterCommunicationType
    {
        Serial = 1,
        
        Network = 2
    }

    public enum SerialComPort
    {
        COM1 = 1,

        COM2 = 2,

        COM3 = 3,

        COM4 = 4,

        COM5 = 5,

        COM6 = 6,

        COM7 = 7,

        COM8 = 8,

        COM9 = 9,

        COM10 = 10,

        COM11 = 11,

        COM12 = 12,
    }
}
