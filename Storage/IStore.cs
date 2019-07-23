using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStore
    {
        Task saveData(FilesEntity entity);
    }
}
