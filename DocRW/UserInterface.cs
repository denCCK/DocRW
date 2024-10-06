using DocRW.Services;

namespace DocRW
{
    internal class UserInterface
    {
        private DocumentProcessor documentProcessor;
        private Logger logger;
        private EmailSender emailSender;

        private bool isExit = false;

        public UserInterface(DocumentProcessor documentProcessor, Logger logger, EmailSender emailSender)
        {
            this.documentProcessor = documentProcessor;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в систему заполнения шаблонных документов!");

            while (!isExit)
            {
                Console.WriteLine("Выберите опции (1 - Заполнение шаблона; 2 - Просмотр логов; 0 - Выход)");

                switch (Console.ReadLine())
                {
                    case "1":
                        ProcessDocumentTemplate();
                        break;

                    case "2":
                        ProcessLogs();
                        break;

                    case "0":
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод! Попробуйте ещё раз.");
                        break;
                }
            }
        }

        private void ProcessLogs()
        {
            Console.Clear();
            Console.WriteLine("=== Просмотр логов ===\n");
            logger.ShowLogs();
            Console.WriteLine();
        }

        private void ProcessDocumentTemplate()
        {
            Console.Clear();
            Console.WriteLine("=== Заполнение документа ===\n");

            string fileTemplate = GetFileTemplate();
            string fileFullInputPath = GetFileInputPath();

            try
            {
                documentProcessor.LoadDocument(fileFullInputPath, fileTemplate);
                Console.WriteLine($"Шаблон {fileTemplate} {fileFullInputPath} загружен\n");
                logger.Log($"Шаблон {fileTemplate} {fileFullInputPath} загружен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки документа: {ex.Message}\n");
                logger.Log($"Ошибка загрузки документа: {ex.Message}");
                return;
            }

            documentProcessor.FillTemplate(GetFieldValues());
            logger.Log($"Шаблон {fileFullInputPath} заполнен.");

            string fileFullOutputPath = documentProcessor.SaveDocument(GetOutputPath());
            Console.WriteLine($"Документ сохранен по пути {fileFullOutputPath}\n");
            logger.Log($"Документ сохранен по пути {fileFullOutputPath}");

            Console.WriteLine("Отправить документ по электронной почте? (да/нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Введите email получателя:");
                string recipientEmail = GetEmail();

                Console.WriteLine("Введите email отправителя:");
                string senderEmail = GetEmail();

                emailSender.SendEmail(recipientEmail, senderEmail, documentProcessor.fileTemplate, fileFullOutputPath);
                Console.WriteLine($"Документ отправлен на {recipientEmail} c {senderEmail}\n");
                logger.Log($"Документ отправлен на {recipientEmail} c {senderEmail}");
            }
        }

        private string GetFileTemplate()
        {
            string documentType = string.Empty;

            Console.WriteLine("============================");
            Console.WriteLine("Введите тип документа (заявление на отпуск, квитанция)");
            while (string.IsNullOrEmpty(documentType))
            {
                documentType = Console.ReadLine().ToLower();

                if (documentType != "заявление на отпуск" && documentType != "квитанция")
                {
                    Console.WriteLine("Неверный тип документа. Пожалуйста, выберите из предложенных.");
                    documentType = string.Empty;
                }
            }
            Console.WriteLine("============================\n");

            return documentType;
        }

        private string GetFileInputPath()
        {
            string filePath = string.Empty;

            Console.WriteLine("============================");
            Console.WriteLine("Введите полный путь к файлу шаблона");
            while (string.IsNullOrEmpty(filePath))
            {
                filePath = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден. Убедитесь, что указали правильный путь.");
                    filePath = string.Empty;
                }
            }
            Console.WriteLine("============================\n");

            return filePath;
        }

        private string GetOutputPath()
        {
            string outputPath = string.Empty;

            Console.WriteLine("============================");
            Console.WriteLine("Введите путь к папке для сохранения заполненного документа:");
            while (string.IsNullOrEmpty(outputPath))
            {
                outputPath = Console.ReadLine();

                if (!Directory.Exists(outputPath))
                {
                    Console.WriteLine("Папка не найдена. Убедитесь, что указали правильный путь.");
                    outputPath = string.Empty;
                }
            }
            Console.WriteLine("============================\n");

            return outputPath;
        }

        private Dictionary<string, string> GetFieldValues()
        {
            Console.WriteLine("============================");
            Console.WriteLine("Заполняемые поля:");

            var fields = documentProcessor.GetFillableFields();
            var fieldValues = new Dictionary<string, string>();

            foreach (var field in fields)
            {
                Console.WriteLine($"Введите значение для {field}:");
                fieldValues[field] = Console.ReadLine();
            }

            Console.WriteLine("============================\n");
            return fieldValues;
        }

        private string GetEmail()
        {
            string email = string.Empty;

            while (string.IsNullOrEmpty(email))
            {
                email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Неверный формат email. Попробуйте еще раз.");
                    email = string.Empty;
                }
            }

            return email;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
