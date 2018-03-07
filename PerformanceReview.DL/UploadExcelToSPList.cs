using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceReview.DL
{
  public class UploadExcelToSPList
    {
        public string ProcessedCount { get; set; }
        public int UnProcessedCount { get; set; }
        public int rowCount { get; set; }
        public string User { get; set; }
        public StringBuilder processbatch { get; set; }
    }
}
