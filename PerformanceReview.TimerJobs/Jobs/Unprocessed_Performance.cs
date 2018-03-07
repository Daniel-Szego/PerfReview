using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Axalta.EMEA.PerformanceReview.TimerJobs.Jobs
{
    class Unprocessed_Performance:SPJobDefinition
    {
        public Unprocessed_Performance() : base() { }

           public Unprocessed_Performance(string jobName, SPService service)
                    : base(jobName, service, null, SPJobLockType.None)
         {
             this.Title = "Unprocessed_Performance";
          }
           public Unprocessed_Performance(string jobName, SPWebApplication webapp)
            : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
        {
            this.Title = "Unprocessed_Performance";
        }
       public override void Execute(Guid targetInstanceId)
        {
           // ClosingDateNotify();
        }
    }
}
