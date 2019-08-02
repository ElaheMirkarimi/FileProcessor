using Service.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IFileStore
    {
        Task SaveDataBatchAsync(List<File> files);
    }
}
