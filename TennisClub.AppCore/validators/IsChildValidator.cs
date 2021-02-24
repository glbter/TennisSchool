using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.validators
{
    public class IsChildAdultValidator : IValidator<IChild>
    {
        public bool Validate(IChild child)
        {
            return child.Age < 18;
        }
    }
}
