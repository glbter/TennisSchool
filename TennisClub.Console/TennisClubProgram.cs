using System;
using System.Configuration;
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

            //dao.ChildDao.GetAll().ForEach(PrintChild);
            System.Console.WriteLine("groups");
            //dao.GroupDao.GetAll().ForEach(PrintGroup);
            System.Console.WriteLine("cached groups");
            //dao.CachedGroupDao.GetAll().ForEach(PrintCachedGroup);
            System.Console.WriteLine(ConfigurationManager.GetSection("appSettings"));
            var key = "maxAmountOfChildrenInGroup";
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  
                string result = appSettings[key] ?? "Not Found";  
                System.Console.WriteLine(result);  
            }  
            catch (ConfigurationErrorsException)  
            {  
                System.Console.WriteLine("Error reading app settings");  
            }  
        } 
        static void PrintChild(IChild<Guid> child)
        {
            System.Console.WriteLine($"{child.FirstName}, {child.LastName}, {child.Age.ToString()}");
        }

        static void PrintGroup(IGroup<Guid> group)
        {
           System.Console.WriteLine($"{group.GameLevel.ToString()}, {group.LessonsDay.ToString()} "); 
        }
        
        static void PrintCachedGroup(ICachedGroup<Guid> group)
        {
            System.Console.WriteLine($"{group.ChildrenAmount.ToString()}, {group.MinAge.ToString()}, {group.MaxAge.ToString()} {group.Group.GameLevel} {group.Group.LessonsDay} "); 
        }
    }
}
