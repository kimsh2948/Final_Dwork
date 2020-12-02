using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWork
{
    public class WorkCategory
    {
        public int id { get; set; }
        public string day { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string MainCategory { get; set; }
        public string MiddleCategory { get; set; }
        public string SubCategory { get; set; }

    }
}
