using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    public interface IChildPipeline<TK>
    {
        public bool AddChild(IChild<TK> child);
    }
}
