using InteractionConcoleCalculator.BLL;
using InteractionConcoleCalculator.DLL;
using NUnit.Framework;

namespace InteratcionConsoleCalculatorTests
{
    [TestFixture]
    public class ArithmeticOperationHandlerTests
    {
        [TestCaseSource(nameof(TestParams))]
        public void ArithmeticOperationHandler_GetNames_ReturnValue((IOperationDictionaryRepository operationDictionaryRepository, string[] expected) tuple)
        {
            var arithmeticOperationHandler = new ArithmeticOperationHandler(tuple.operationDictionaryRepository);
            Assert.AreEqual(tuple.expected, arithmeticOperationHandler.GetOperationNames());
        }

        public void ArithmeticOperationHandler_DictioanyIsNull_GetNames_ThrowNullException()
        {
            var arithmeticOperationHandler = new ArithmeticOperationHandler(new OperationDictionaryRepositoryMockEmpty());
            Assert.Throws<NullReferenceException>(() => arithmeticOperationHandler.GetOperationNames());
        }

        private static IEnumerable<(IOperationDictionaryRepository, string[])> TestParams()
        {
            yield return (new OperationDictionaryRepositoryMock(), new string[] { "1", "2" });
            yield return (new OperationDictionaryRepositoryMockEmpty(), new string[] { });
        }
    }
}