namespace TennisClub.AppCore.model.interfaces
{
    public interface ICachedGroup<out TK> : IBaseId<TK>
    {
        public IGroup<TK> Group { get; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int ChildrenAmount { get; set; }
    }
}