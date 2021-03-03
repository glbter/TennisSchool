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
            DaoObject dao = new DaoObject();
            IChildPipeline<Guid> childLine = new ChildPipeline<Guid>(dao);

            (new TestDataLoader()).InitTestData()
                .ForEach(it => childLine.AddChild(it));

            DaoPrinter printer = new DaoPrinter();
            //dao.ChildDao.GetAll().ForEach(PrintChild);
            System.Console.WriteLine("groups");
            dao.GroupDao.GetAll().ForEach(printer.PrintGroup);
            System.Console.WriteLine("cached groups");
            dao.CachedGroupDao.GetAll().ForEach(printer.PrintCachedGroup);
        }
    }
}
