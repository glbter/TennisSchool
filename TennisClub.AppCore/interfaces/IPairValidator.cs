

namespace TennisClub.AppCore.interfaces
{
    public interface IPairValidator<Fits, To>
    {
        public bool Validate(Fits fits, To to);
    }
}
