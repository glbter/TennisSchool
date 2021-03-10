using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mappers
{
    class ChildMapper
    {
        public IEnumerable<Child> Map()
        {
            List<Child> children = new List<model.Child>
            {
                new Child(1, "John", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(2, "Alice", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(3, "Ivan", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(4, "Bon", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(5, "Claire", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(6, "Mary", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                // day of week test
                new Child(7, "Vova", "Tennis", GameLevel.Average, DayOfWeek.Tuesday, new DateTime(2010, 12, 1)),
                new Child(8, "Petya", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                // age test
                new Child(9, "Vasya", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2010, 12, 1)),
                new Child(10, "Jora", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2012, 12, 1)),
                new Child(11, "Helen", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2013, 12, 1)),
                new Child(12, "Joseline", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2015, 12, 1)),
                // preferences test
                new Child(13, "Jolene", "Tennis", GameLevel.Beginner, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(14, "Timur", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                new Child(15, "Nadya", "Tennis", GameLevel.Beginner, DayOfWeek.Monday, new DateTime(2010, 12, 1)),
                // age
                new Child(16, "Gena", "Tennis", GameLevel.Professional, DayOfWeek.Tuesday, new DateTime(1998, 12, 1))
            };
            return children;
        }
    }
}
