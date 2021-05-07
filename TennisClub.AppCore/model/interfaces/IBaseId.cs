namespace TennisClub.AppCore.Model.interfaces
{
    public interface IBaseId<out TK>
    {
        public TK Id { get; } 
    }
}
