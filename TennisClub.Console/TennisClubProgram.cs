using System;
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
        } 
    }
}
