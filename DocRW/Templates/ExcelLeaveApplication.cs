using DocRW.Interfaces;

namespace DocRW.Templates
{
    internal class ExcelLeaveApplication : IDocumentTemplate
    {
        public List<string> GetFillableFields()
        {
            Console.WriteLine("Загружены поля шаблона заявления на отпуск формата Excel\n");
            return new List<string>();
        }

        public void FillFields(Dictionary<string, string> fieldValues)
        {
        }
    }
}
