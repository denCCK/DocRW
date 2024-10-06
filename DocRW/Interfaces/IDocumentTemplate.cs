namespace DocRW.Interfaces
{
    public interface IDocumentTemplate
    {
        List<string> GetFillableFields();
        void FillFields(Dictionary<string, string> fieldValues);
    }
}
