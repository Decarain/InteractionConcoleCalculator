using InteractionConcoleCalculator.BLL;

namespace InteractionConcoleCalculator.DLL
{
    public interface IOperationDictionaryRepository
    {
        Dictionary<string, IOperation> GetDictionary();
    }
}