using System.Threading.Tasks;

namespace Service
{
    public interface IFileService
    {
        Task InsertFilesBatchAsync(string[] files);
    }
}
