using InteractionConcoleCalculator.BLL;
using InteractionConcoleCalculator.DLL;

namespace InteratcionConsoleCalculatorTests
{
    public class OperationDictionaryRepositoryMock : IOperationDictionaryRepository
    {
        public Dictionary<string, IOperation> GetDictionary()
        {
            var dict = new Dictionary<string, IOperation>();
            dict.Add("1", new Operation(x => x[0]));
            dict.Add("2", new Operation(x => x[1]));

            return dict;
        }
    }

    public class OperationDictionaryRepositoryMockEmpty : IOperationDictionaryRepository
    {
        public Dictionary<string, IOperation> GetDictionary()
        {
            var dict = new Dictionary<string, IOperation>();

            return dict;
        }
    }

    public class OperationDictionaryRepositoryMockNull : IOperationDictionaryRepository
    {
        public Dictionary<string, IOperation> GetDictionary() => null;
    }
}
