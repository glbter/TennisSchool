using TennisClub.Console.test;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.pipelines;

namespace TennisClub.Console
{
    class TennisClubProgram
    {
        static void Main(string[] args)
        {
            DaoObject dao = new DaoObject();
            ChildPipeline childLine = new ChildPipeline(dao);

            (new TestDataLoader()).InitTestData()
                .ForEach(it => childLine.AddChild(it));
        } 
    }
}
