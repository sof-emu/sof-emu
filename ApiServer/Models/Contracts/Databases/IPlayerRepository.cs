namespace ApiServer.Models.Contracts.Databases
{
    public interface IPlayerRepository
    {
        public bool Exist(string name);
    }
}
