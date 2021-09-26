using System;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Interface
{
    public interface ICommand<TModel>
    {
        TModel CommandHandler(TModel model);
        Task<TModel> CommandHandlerAsync(TModel model);
    }
}
