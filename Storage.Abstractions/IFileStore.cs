using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data
{
    public interface IFileStore
    {
        Task SaveDataAsync(File file);
        Task SaveDataBatchAsync(List<File> files);
    }
}
