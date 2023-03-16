using InteractionConcoleCalculator.DLL;
using InteractionConcoleCalculator.Resources;

namespace InteractionConcoleCalculator.BLL
{
    public class ArithmeticOperationHandler : IArithmeticOperationHandler
    {
        private readonly Dictionary<string, IOperation> _operationDictionary = new();

        public ArithmeticOperationHandler()
        {
            _operationDictionary = new OperationDictionaryRepository().GetDictionary();
        }

        public ArithmeticOperationHandler(IOperationDictionaryRepository operationDictionaryRepository)
        {
            _operationDictionary = operationDictionaryRepository.GetDictionary();
        }

        public double Invoke(string name, double[] args)
        {
            try
            {
                return _operationDictionary[name].Call(args);
            }
            catch (OperationException)
            {
                throw;
            }
        }

        public string[] GetOperationNames() => _operationDictionary.Select(x => x.Key).ToArray();
    }
}
