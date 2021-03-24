namespace TennisClub.WpfUi.mappers
{
    public interface IMapper<in TI, out TO>
    {
        TO Map(TI entity);
    }
}