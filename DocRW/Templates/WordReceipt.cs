using DocRW.Interfaces;

namespace DocRW.Templates
{
    internal class WordReceipt : IDocumentTemplate
    {
        public List<string> GetFillableFields()
        {
            Console.WriteLine("Загружены поля шаблона квитанции формата Word\n");
            return new List<string>();
        }

        public void FillFields(Dictionary<string, string> fieldValues)
        {
        }
    }
}
