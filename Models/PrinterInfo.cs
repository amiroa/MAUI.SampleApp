using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OA.Public.Maui.SampleApp.Models
{
    public class PrinterInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccessKey { get; set; }

        public string AccessCode { get; set; }

        public bool IsActive { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public PrinterCommunicationType CommunicationType { get; set; }

        public SerialComPort SerialComPort { get; set; }

        public int SerialBaudRate { get; set; }

        public string NetworkIPAddress { get; set; }

        public string NetworkPort { get; set; }

        public bool IsPrinterMonitorAcvtive { get; set; }

        public string Options { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

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
