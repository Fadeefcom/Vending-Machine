using DataProvider;
using DataProvider.Handler;

namespace ApplicationCore
{
    public class AppBaseArguments : BaseArguments
    {
        public required IDataProvider dataProvider { get; init; }
    }
}
