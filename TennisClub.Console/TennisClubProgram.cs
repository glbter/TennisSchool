using System;
//using System.Configuration;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Console.test;
using TennisClub.Data.context;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.pipelines;
using TennisClub.Infrastructure.interfaces;

namespace TennisClub.Console
{
    class TennisClubProgram
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost; Port=5432; User Id=postgres;Password=123;Database=tennis-club;";
            //"Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123";
            UnitOfWork unitOfWork = new UnitOfWork(connectionString, ProviderDb.Npgsql);
            IChildFacade childLine = new ChildFacade(unitOfWork);
        
            (new TestDataLoader()).InitTestData()
                .ForEach(it => childLine.AddChild(it));
        
            DaoPrinter printer = new DaoPrinter();
            System.Console.WriteLine("groups");
            System.Console.WriteLine("cached groups");
            unitOfWork.Dispose();
        }
    }
}
