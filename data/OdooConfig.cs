using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooRunner.data
{
    public class OdooConfig
    {
        public string OdooPath { get; set; }
        public List<OdooSetting> OdooSettings { get; set; } = new List<OdooSetting>();
    }

    public class OdooSetting
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

}
