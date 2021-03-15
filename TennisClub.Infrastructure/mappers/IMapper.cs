using System.Collections.Generic;

namespace TennisClub.Infrastructure.mappers
{
    public interface IMapper<in TI, out TO>
    {
        public TO Map(TI entity);
    }
}