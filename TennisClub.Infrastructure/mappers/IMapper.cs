namespace TennisClub.Infrastructure.Mappers
{
    public interface IMapper<in TI, out TO>
    {
        public TO Map(TI entity);
    }
}