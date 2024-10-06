using System.Data.SQLite;

namespace DocRW.Data
{
    public class DBManager
    {
        private SQLiteConnection connection;

        public DBManager(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            CreateLogsTableIfNotExists();
        }

        private void CreateLogsTableIfNotExists()
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Logs (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Message TEXT NOT NULL,
                    Date DATETIME NOT NULL
                )";

            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertLog(string message)
        {
            string insertQuery = "INSERT INTO Logs (Message, Date) VALUES (@message, @date)";

            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@message", message);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetLogs()
        {
            var logs = new List<string>();

            string selectQuery = "SELECT * FROM Logs";

            using (var command = new SQLiteCommand(selectQuery, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    logs.Add($"[{reader["Date"]}] {reader["Message"]}");
                }
            }

            return logs;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
