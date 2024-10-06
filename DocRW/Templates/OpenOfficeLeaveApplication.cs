using DocRW.Interfaces;

namespace DocRW.Templates
{
    internal class OpenOfficeLeaveApplication : IDocumentTemplate
    {
        public List<string> GetFillableFields()
        {
            Console.WriteLine("Загружены поля шаблона заявления на отпуск формата OpenOffice\n");
            return new List<string>();
        }

        public void FillFields(Dictionary<string, string> fieldValues)
        {
        }
    }
}
