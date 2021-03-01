using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.validators
{
    public class IsChildValidator<TK> : IValidator<IChild<TK>>
    {
        public bool Validate(IChild<TK> child)
        {
            return child.Age < 18;
        }
    }
}
