namespace TennisClub.AppCore.model.interfaces
{
    public interface ICachedGroup : IBaseId
    {
        public IGroup Group { get; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int ChildrenAmount { get; set; }
    }
}