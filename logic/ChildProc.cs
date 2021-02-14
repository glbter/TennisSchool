﻿using Lab1.dao;
using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    class ChildProc : IChildProc
    {
        private readonly DaoObject dao;
        public ChildProc(DaoObject dao)
        {
            this.dao = dao;
        }

        public bool IsChild(Child child)
        {
            return child.Age < 18;
        }
    }
}