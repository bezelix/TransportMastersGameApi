using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class MSQLLogs
    {
        public int id { get; set; }
        public string LogInfo { get; set; }
        public DateTime Date { get; set; }
    }
}
