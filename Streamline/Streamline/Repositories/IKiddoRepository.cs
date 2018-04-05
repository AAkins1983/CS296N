using Streamline.Models;
using System.Collections.Generic;

namespace Streamline.Repositories
{
    public interface IKiddoRepository
    {
        List<Kiddo> GetAllKiddos();
        Kiddo GetKiddoByName(string name);
        List<TaskItem> GetTasksByKiddo(Kiddo kiddo);
    }
}
