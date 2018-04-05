using Streamline.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamline.Repositories
{
    public class KiddoRepository : IKiddoRepository
    {
        private ApplicationDbContext context;

        public KiddoRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Kiddo> GetAllKiddos()
        {
            return context.Kiddos.ToList<Kiddo>();
        }

        public Kiddo GetBookByName(string name)
        {
            return context.Kiddos.First(k => k.Name == name);
        }

        public Kiddo GetKiddoByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetTasksByKiddo(Kiddo kiddo)
        {
            throw new NotImplementedException();
        }

        //public List<TaskItem> GetTasksByKiddo(TaskItem task)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
