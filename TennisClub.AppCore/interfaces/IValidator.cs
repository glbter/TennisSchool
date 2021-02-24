

namespace TennisClub.AppCore.interfaces
{
    public interface IValidator<T>
    {
        public bool Validate(T entity);
    }
}
