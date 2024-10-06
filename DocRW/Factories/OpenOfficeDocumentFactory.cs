using DocRW.Interfaces;
using DocRW.Templates;

namespace DocRW.Factories
{
    public class OpenOfficeDocumentFactory : IDocumentFactory
    {
        public IDocumentTemplate CreateLeaveApplication()
        {
            return new OpenOfficeLeaveApplication();
        }

        public IDocumentTemplate CreateReceipt()
        {
            return new OpenOfficeReceipt();
        }
    }

}
