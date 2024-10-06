using DocRW.Factories;
using DocRW.Interfaces;
using DocRW.Templates;

namespace DocRW
{
    internal class DocumentProcessor
    {

        private IDocumentTemplate documentTemplate;
        private IDocumentFactory documentFactory;
        public string fileType;
        public string fileTemplate;
        public string originalFileName;

        public void LoadDocument(string filePath, string fileTemplate)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл по пути {filePath} не найден.");
            }

            fileType = Path.GetExtension(filePath).ToLower();

            if (fileType == ".doc" || fileType == ".docx" || fileType == ".xls" || fileType == ".xlsx" || fileType == ".odt")
            {
                this.fileTemplate = fileTemplate;
                originalFileName = Path.GetFileNameWithoutExtension(filePath);

                documentFactory = DocumentFactoryProvider.GetDocumentFactory(fileType);
                documentTemplate = DocumentTemplateProvider.GetDocumentTemplate(fileTemplate, documentFactory);
            }
            else
            {
                throw new NotSupportedException($"Файл с расширением {fileType} не поддерживается.");
            }
        }

        public string SaveDocument(string outputPath)
        {
            if (!Directory.Exists(outputPath))
            {
                throw new DirectoryNotFoundException($"Директория {outputPath} не найдена.");
            }

            string fileName = $"{originalFileName}_{fileTemplate}_заполненнный{fileType}";
            return Path.Combine(outputPath, fileName);
        }

        public void FillTemplate(Dictionary<string, string> fieldValues)
        {
            documentTemplate.FillFields(fieldValues);
        }

        public List<string> GetFillableFields()
        {
            return documentTemplate.GetFillableFields();
        }
    }

}
