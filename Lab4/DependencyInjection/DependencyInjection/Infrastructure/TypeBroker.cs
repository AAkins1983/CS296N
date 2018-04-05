using DependencyInjection.Models;
using System;

namespace DependencyInjection.Infrastructure
{
    //Define a Repository property that returns teh IRepository interface
    //The implementation class used by the Repository property is determined
    //by the value of the repoType field, which defaults to Memory Repository 
    //but which can be changed by calling the SetRepositoryType method
    public static class TypeBroker
    {
        private static Type repoType = typeof(MemoryRepository);
        private static IRepository testRepo;

        public static IRepository Repository =>
            testRepo ?? Activator.CreateInstance(repoType) as IRepository;

        public static void SetRepositoryType<T>() where T : IRepository =>
            repoType = typeof(T);

        //To support unit testing, this method allows a specific object to be used
        //The HomeController obtains the repo object
        public static void SetTestObject(IRepository repo)
        {
            testRepo = repo;
        }
    }
}
