using DocRW.Interfaces;
using DocRW.Templates;

namespace DocRW.Factories
{
    public class ExcelDocumentFactory : IDocumentFactory
    {
        public IDocumentTemplate CreateLeaveApplication()
        {
            return new ExcelLeaveApplication();
        }

        public IDocumentTemplate CreateReceipt()
        {
            return new ExcelReceipt();
        }
    }

}
