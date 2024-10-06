using DocRW.Interfaces;

namespace DocRW.Templates
{
    internal class ExcelReceipt : IDocumentTemplate
    {
        public List<string> GetFillableFields()
        {
            Console.WriteLine("Загружены поля шаблона квитанции формата Excel\n");
            return new List<string>();
        }

        public void FillFields(Dictionary<string, string> fieldValues)
        {
        }
    }
}
