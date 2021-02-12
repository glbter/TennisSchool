using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.model
{
    public abstract class Base
    {
        public Guid Id { get; } = new Guid();
    }
}
