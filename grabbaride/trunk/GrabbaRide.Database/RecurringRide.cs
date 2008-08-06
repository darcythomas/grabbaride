using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GrabbaRide.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Reflection;
    using System.Linq.Expressions;
    using System.ComponentModel;


    public partial class RecurringRide
    {

        

        public RecurringRide(bool mon, bool tues, bool wed, bool thurs, bool fri, 
            bool sat, bool sun, String interval, DateTime endDate)
        {
            this.RecurMon = mon;
            this.RecurTue = tues;
            this.RecurWed = wed;
            this.RecurThu = thurs;
            this.RecurFri = fri;
            this.RecurSat = sat;
            this.RecurSun = fri;
            this.RecurInterval = interval;
            this.RecurEndByDate = endDate;
        }

    }
}
