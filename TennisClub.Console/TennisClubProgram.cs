using System;
//using System.Configuration;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Console.test;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.pipelines;
using TennisClub.Infrastructure.interfaces;

namespace TennisClub.Console
{
    class TennisClubProgram
    {
        static void Main(string[] args)
        {
            var connectionString = "Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123";
            UnitOfWork unitOfWork = new UnitOfWork(connectionString);
            IChildPipeline childLine = new ChildPipeline(unitOfWork);
        
            (new TestDataLoader()).InitTestData()
                .ForEach(it => childLine.AddChild(it));
        
            DaoPrinter printer = new DaoPrinter();
            System.Console.WriteLine("groups");
            System.Console.WriteLine("cached groups");
            unitOfWork.Dispose();
        }
    }
}
