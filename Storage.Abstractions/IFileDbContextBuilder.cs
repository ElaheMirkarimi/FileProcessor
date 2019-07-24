using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public interface IFileDbContextBuilder
    {
        DbContext Build();
    }
}