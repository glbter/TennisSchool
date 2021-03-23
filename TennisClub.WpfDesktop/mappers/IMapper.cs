namespace TennisClub.WpfDesktop.mappers
{
    public interface IMapper<in TI, out TO>
    {
        public TO Map(TI entity);
    }
}