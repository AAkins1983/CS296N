using Streamliner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamliner.Repositories
{
    public interface IKiddoRepository
    {
        List<Kiddo> GetAllKiddos();
        Kiddo GetKiddoByName(string name);
        Kiddo GetKiddoById(int id);
        int Add(Kiddo kiddo);
        int Edit(Kiddo kiddo);
        int Delete(int id);
    }
}
