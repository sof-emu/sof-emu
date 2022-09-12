namespace Communicate.Logics
{
    public class GlobalLogic : Global
    {
        public static void ServerStart()
        {
            MapService.Init();

            InitMainLoop();
        }
    }
}
