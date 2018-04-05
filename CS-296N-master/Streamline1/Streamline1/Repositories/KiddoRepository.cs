using Streamline1.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Streamline1.Models
{
    public class KiddoRepository : IKiddoRepository
    {
        private readonly ApplicationDbContext context;

        public KiddoRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        /* Interface method implementations */

        public List<Kiddo> GetAllKiddos()
        {
            return context.Kiddos.Include(k => k.TaskItems).ToList();
        }

        public Kiddo GetKiddoByName(string name)
        {
            return context.Kiddos.Include(t => t.TaskItems).First(k => k.Name == name);
        }

        public Kiddo GetKiddoById(int id)
        {
            return context.Kiddos.Include("TaskItems").First(k => k.KiddoID == id);
        }

        public int AddKiddo(Kiddo kiddo)
        {
            // Add the kid to the database
            context.Kiddos.Update(kiddo);
            // Save the kid so that it gets an ID (primary key value)
            context.SaveChanges();

            // Give each task object a FK for the kid
            // and add it to the database
            foreach (TaskItem t in kiddo.TaskItems)
            {
                t.KiddoID = kiddo.KiddoID;
                context.TaskItems.Update(t);
            }

            return context.SaveChanges();
        }

        public int Edit(Kiddo kiddo)
        {
            context.Kiddos.Update(kiddo);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var kiddoFromDb = context.Kiddos.First(t => t.KiddoID == id);
            context.Remove(kiddoFromDb);
            return context.SaveChanges();
        }
    }
}
