using DocRW.Services;
using DocRW;
using DocRW.Data;

class Program
{
    static void Main(string[] args)
    {
        var dbManager = new DBManager("Data Source=logs.db");
        var logger = new Logger(dbManager);
        var documentProcessor = new DocumentProcessor();
        var emailSender = new EmailSender();

        var userInterface = new UserInterface(documentProcessor, logger, emailSender);
        userInterface.Start();
    }
}
