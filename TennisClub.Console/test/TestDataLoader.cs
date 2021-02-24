using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;

namespace TennisClub.Console.test
{
    class TestDataLoader
    {
        public List<Child> InitTestData()
        {
            List<Child> list = new List<Child>();
            // capacity test
            list.Add(new Child("John", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Alice", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Ivan", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Bon", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Claire", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Mary", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            // day of week test
            list.Add(new Child("Vova", "Tennis", GameLevel.Average, DayOfWeek.Tuesday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Petya", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            // age test
            list.Add(new Child("Vasya", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Jora", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2012, 12, 1)));
            list.Add(new Child("Helen", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2013, 12, 1)));
            list.Add(new Child("Joseline", "Tennis", GameLevel.Average, DayOfWeek.Sunday, new DateTime(2015, 12, 1)));
            // preferences test
            list.Add(new Child("Jolene", "Tennis", GameLevel.Beginner, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Timur", "Tennis", GameLevel.Average, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            list.Add(new Child("Nadya", "Tennis", GameLevel.Beginner, DayOfWeek.Monday, new DateTime(2010, 12, 1)));
            // age
            list.Add(new Child("Gena", "Tennis", GameLevel.Professional, DayOfWeek.Tuesday, new DateTime(1998, 12, 1)));
            return list;
        }
    }
}
