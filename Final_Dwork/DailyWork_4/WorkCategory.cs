﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWork
{
    public class WorkCategory
    {
        public int id { get; set; }
        public DateTime day { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public int maindcategory_id { get; set; }
        public int middlecategory_id { get; set; }
        public int subcategory_id { get; set; }

    }
}
