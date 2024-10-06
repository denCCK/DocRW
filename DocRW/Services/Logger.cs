using DocRW.Data;

namespace DocRW.Services
{
    internal class Logger
    {
        private DBManager dbManager;

        public Logger(DBManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void Log(string message)
        {
            dbManager.InsertLog(message);
        }

        public void ShowLogs()
        {
            var logs = dbManager.GetLogs();
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine();
        }
    }
}
