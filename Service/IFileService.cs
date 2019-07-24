using System.Threading.Tasks;

namespace Service
{
    public interface IFileService
    {
        Task InsertFilesAsync(string[] files);
    }
}
