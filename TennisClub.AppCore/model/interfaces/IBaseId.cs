using System;

namespace TennisClub.AppCore.model.interfaces
{
    public interface IBaseId<out TK>
    {
        public TK Id { get; } 
    }
}
