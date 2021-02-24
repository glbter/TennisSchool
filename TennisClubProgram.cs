using TennisClub.logic;
using TennisClub.TennisCLub.Infrastructure;
using TennisClub.test;

namespace TennisClub
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
