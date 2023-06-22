using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class BaseArguments
    {
        public required IServiceScopeFactory scopefactory { get; init; }

        public required ILoggerFactory loggerFactory { get; init; }
    }
}
