using DocRW.Interfaces;

namespace DocRW.Factories
{
    public static class DocumentFactoryProvider
    {
        public static IDocumentFactory GetDocumentFactory(string fileType)
        {
            switch (fileType.ToLower())
            {
                case ".doc": case ".docx":
                    return new WordDocumentFactory();
                case ".xls": case ".xlsx":
                    return new ExcelDocumentFactory();
                case ".odt":
                    return new OpenOfficeDocumentFactory();
                default:
                    throw new NotSupportedException($"Файл типа {fileType} не поддерживается.");
            }
        }
    }
}
