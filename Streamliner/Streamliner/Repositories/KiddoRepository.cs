using Microsoft.EntityFrameworkCore;
using Streamliner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamliner.Repositories
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
            List<Kiddo> kiddos = context.Kiddos.ToList<Kiddo>();
            return kiddos;
        }

        public Kiddo GetKiddoByName(string name)
        {
            throw new NotImplementedException();
        }

        public Kiddo GetKiddoById(int id)
        {
            return context.Kiddos.First(k => k.KiddoID == id);
        }

        public int Add(Kiddo kiddo)
        {
            context.Kiddos.Add(kiddo);
            return context.SaveChanges();
        }

        public int Edit(Kiddo kiddo)
        {
            //var kiddoFromDb = GetKiddoById(kiddo.KiddoID);
            //kiddoFromDb.Name = kiddo.Name;
            //kiddoFromDb.TaskID = kiddo.TaskID;
            context.Kiddos.Update(kiddo);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var kiddoFromDb = context.Kiddos.First(k => k.KiddoID == id);
            context.Remove(kiddoFromDb);
            return context.SaveChanges();
        }
    }
}