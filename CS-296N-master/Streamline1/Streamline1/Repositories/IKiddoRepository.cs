using Streamline1.Models;
using System.Collections.Generic;

namespace Streamline1.Repositories
{
    public interface IKiddoRepository
    {
        List<Kiddo> GetAllKiddos();
        Kiddo GetKiddoByName(string name);
        Kiddo GetKiddoById(int id);
        int AddKiddo(Kiddo kiddo);
        int Edit(Kiddo kiddo);
        int Delete(int id);
    }
}
