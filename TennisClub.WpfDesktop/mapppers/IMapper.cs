namespace TennisClub.WpfDesktop.mapppers
{
    public interface IMapper<in TI, out TO>
    {
        public TO Map(TI entity);
    }
}