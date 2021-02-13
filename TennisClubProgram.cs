using Lab1.dao;
using Lab1.logic;
using Lab1.model;
using Lab1.test;
using System;
using System.Collections.Generic;

namespace Lab1
{
    class TennisClubProgram
    {
        static void Main(string[] args)
        {
            DaoObject dao = new DaoObject();
            ChildPipeline childLine = new ChildPipeline(dao, 5, 3);

            (new TestDataLoader()).InitTestData()
                .ForEach(it => childLine.AddChild(it));
        } 
    }
}
