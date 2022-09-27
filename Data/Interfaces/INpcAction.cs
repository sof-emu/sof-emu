namespace Data.Interfaces
{
    public interface INpcAction
    {
        void Process(ISession session, int shopId, int actionId, int tabIndex);
    }
}
