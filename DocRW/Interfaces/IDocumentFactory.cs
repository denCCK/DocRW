namespace DocRW.Interfaces
{
    public interface IDocumentFactory
    {
        IDocumentTemplate CreateLeaveApplication();
        IDocumentTemplate CreateReceipt();
    }
}
