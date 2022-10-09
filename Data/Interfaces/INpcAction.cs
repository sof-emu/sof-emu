namespace Data.Interfaces
{
    public interface INpcAction
    {
        void Execute(ISession session, int shopId, int actionId, int tabIndex);
    }
}
