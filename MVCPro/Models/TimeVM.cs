using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class TimeVM
    {
        public List<TimeSpanVM> SelectableTimes => new List<TimeSpanVM>()
                    {
                           new TimeSpanVM{Value = new TimeSpan(0, 0, 0) , Label = new TimeSpan(0, 0, 0).ToString("hh\\:mm")},
                           new TimeSpanVM{Value = new TimeSpan(0, 15, 0) , Label = new TimeSpan(0, 15, 0).ToString("hh\\:mm")},
                           new TimeSpanVM{Value = new TimeSpan(0, 30, 0) , Label = new TimeSpan(0, 30, 0).ToString("hh\\:mm")}
                    };

        public TimeSpan TimeFrom { get; set; } = new TimeSpan(0, 15, 0);

        public List<string> SelectableTimes1 => new List<string>()
                    {
                          new TimeSpan(0, 0, 0).ToString("hh\\:mm"),
                          new TimeSpan(0, 15, 0).ToString("hh\\:mm"),
                          new TimeSpan(0, 30, 0).ToString("hh\\:mm")
                    };

        public TimeSpan TimeFrom1 { get; set; } = new TimeSpan(0, 15, 0);

    }

    public class TimeSpanVM
    {
        public TimeSpan Value { get; set; }
        public string Label { get; set; }
    }

}
