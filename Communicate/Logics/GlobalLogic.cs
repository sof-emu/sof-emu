namespace Communicate.Logics
{
    public class GlobalLogic : Global
    {
        public static void ServerStart()
        {
            Data.Data.LoadAll();

            MapService.Init();

            InitMainLoop();
        }
    }
}
