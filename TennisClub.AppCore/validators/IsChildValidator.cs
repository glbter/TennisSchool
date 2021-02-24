using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.validators
{
    public class IsChildValidator : IValidator<IChild>
    {
        public bool Validate(IChild child)
        {
            return child.Age < 18;
        }
    }
}
