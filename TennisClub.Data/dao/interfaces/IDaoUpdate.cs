namespace TennisClub.Data.dao.interfaces
{
    public interface IDaoUpdate<in T>
    {
        public void Update(T entity);
    }
}
