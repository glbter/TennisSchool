using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.Console.test
{
    public class DaoPrinter
    {
        public void PrintChild(Child child)
        {
            System.Console.WriteLine($"{child.FirstName}, {child.LastName}, {child.Age.ToString()}");
        }

        public void PrintGroup(Group group)
        {
            System.Console.WriteLine($"{group.GameLevel.ToString()}, {group.LessonsDay.ToString()} "); 
        }
    }
}