using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IFileService
    {
        Task InsertFilesBatchAsync(string[] files);
    }
}
