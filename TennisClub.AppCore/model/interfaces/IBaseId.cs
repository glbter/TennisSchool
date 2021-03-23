using System;

namespace TennisClub.AppCore.model.interfaces
{
    public interface IBaseId<out TK>
    {
        TK Id { get; } 
    }
}
