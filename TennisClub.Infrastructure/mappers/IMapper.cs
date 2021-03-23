namespace TennisClub.Infrastructure.mappers
{
    public interface IMapper<in TI, out TO>
    {
        TO Map(TI entity);
    }
}