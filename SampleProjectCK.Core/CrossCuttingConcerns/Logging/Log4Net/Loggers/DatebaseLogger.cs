using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatebaseLogger : LoggerService
    {
        public DatebaseLogger():base(LogManager.GetLogger("DatabaseLogger"))
        {
                
        }
    }
}
