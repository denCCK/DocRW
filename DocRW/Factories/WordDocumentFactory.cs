using DocRW.Interfaces;
using DocRW.Templates;

namespace DocRW.Factories
{
    public class WordDocumentFactory : IDocumentFactory
    {
        public IDocumentTemplate CreateLeaveApplication()
        {
            return new WordLeaveApplication();
        }

        public IDocumentTemplate CreateReceipt()
        {
            return new WordReceipt();
        }
    }

}
