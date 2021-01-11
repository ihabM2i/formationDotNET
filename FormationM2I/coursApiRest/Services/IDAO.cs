using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Services
{
    public interface IDAO<T>
    {
        List<T> GetAll();
        List<T> Search(string filter);
        T Get(int id);
        bool Save(T element);

        bool Update();
    }
}
