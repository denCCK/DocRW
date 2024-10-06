using DocRW.Interfaces;

namespace DocRW.Templates
{
    public static class DocumentTemplateProvider
    {
        public static IDocumentTemplate GetDocumentTemplate(string documentType, IDocumentFactory documentFactory)
        {
            switch (documentType.ToLower())
            {
                case "заявление на отпуск":
                    return documentFactory.CreateLeaveApplication();
                case "квитанция":
                    return documentFactory.CreateReceipt();
                default:
                    throw new NotSupportedException($"Тип документа {documentType} не поддерживается.");
            }
        }
    }
}
