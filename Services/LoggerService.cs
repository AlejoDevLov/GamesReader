using GamesReader.Utils.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Services;

internal class LoggerService(ILogger logger) 
{
    private readonly ILogger _logger = logger;
    internal void Log(LogEntry log)
    {
      _logger.Log(log);
    }

}
