using DocRW.Interfaces;

namespace DocRW.Templates
{
    internal class OpenOfficeReceipt : IDocumentTemplate
    {
        public List<string> GetFillableFields()
        {
            Console.WriteLine("Загружены поля шаблона квитанции формата OpenOffice\n");
            return new List<string>();
        }

        public void FillFields(Dictionary<string, string> fieldValues)
        {
        }
    }
}
