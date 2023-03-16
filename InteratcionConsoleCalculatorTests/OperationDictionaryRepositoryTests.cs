using NUnit.Framework;
using InteractionConcoleCalculator.DLL;
using InteractionConcoleCalculator.Resources;

namespace InteratcionConsoleCalculatorTests
{
    [TestFixture]
    public class OperationDictionaryRepositoryTests
    {
        private OperationDictionaryRepository _operationDictionaryRepository;
        private const double PRECISION = 0.000000001;

        [SetUp]
        public void SepUp()
        {
            _operationDictionaryRepository = new OperationDictionaryRepository();
        }

        [TestCase("SUM", new double[] { 1.0001, 0.001 }, 1.0011)]
        [TestCase("DIFF", new double[] { 2414.232, 202.22 }, 2212.012)]
        [TestCase("MULT", new double[] { 0.1, 20321 }, 2032.1)]
        [TestCase("ABS", new double[] { -14.1 }, 14.1)]
        [TestCase("SIN", new double[] { 1.57079632679 }, 1)]
        [TestCase("COS", new double[] { 1.57079632679 }, 0)]
        [TestCase("TAN", new double[] { 1.57079632679 }, 204223803255.9733)]
        [TestCase("POW", new double[] { 4, 4.4 }, 445.721888408)]
        public void OperationDictionaryRepository_OperationWithCorrectArray_ReturnValue(string name, double[] args, double expected)
        {
            var operation = _operationDictionaryRepository.GetDictionary().Where(x => x.Key == name).First().Value;
            var actual = operation.Call(args);

            Assert.AreEqual(expected, actual, PRECISION);
        }

        [TestCase("SUM", new double[] { 1.0001, 0.001, 32.32, 325, 6.56546, 785 }, 1.0011)]
        [TestCase("DIFF", new double[] { 2414.232, 202.22, 1, 1, 1, double.NaN }, 2212.012)]
        [TestCase("MULT", new double[] { 0.1, 20321, 3485 }, 2032.1)]
        [TestCase("ABS", new double[] { -14.1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 14.1)]
        public void OperationDictionaryRepository_OperationArrayIsMoreThanRequired_ReturnValue(string name, double[] args, double expected)
        {
            var operation = _operationDictionaryRepository.GetDictionary().Where(x => x.Key == name).First().Value;
            var actual = operation.Call(args);

            Assert.AreEqual(expected, actual, PRECISION);
        }

        [TestCase("SUM", new double[] { })]
        [TestCase("DIFF", new double[] { 1 })]
        [TestCase("POW", new double[] { })]
        [TestCase("POW", new double[] { 0 })]
        public void OperationDictionaryRepository_OperationArrayIsLessThanRequired_ThrowOperationException(string name, double[] args)
        {
            var expectedMessage = "is less than reqied ";
            var ex = Assert.Throws<OperationException>(() =>
            {
                var operation = _operationDictionaryRepository.GetDictionary().Where(x => x.Key == name).First().Value;
                var actual = operation.Call(args);
            });
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [TestCase("SUM", null)]
        [TestCase("DIFF", null)]
        [TestCase("POW", null)]
        public void OperationDictionaryRepository_OperationArrayIsNull_ThrowOperationException(string name, double[] args)
        {
            var expectedMessage = "Array can't be null.";
            var ex = Assert.Throws<OperationException>(() =>
            {
                var operation = _operationDictionaryRepository.GetDictionary().Where(x => x.Key == name).First().Value;
                var actual = operation.Call(args);
            });
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [TestCase("POW", new double[] { 1000000, 100000 })]
        [TestCase("ABS", new double[] { double.NegativeInfinity })]
        [TestCase("SIN", new double[] { double.NaN })]
        [TestCase("SUM", new double[] { double.NaN, 10 })]
        public void OperationDictionaryRepository_OperationAnswerIsNotFinite_ThrowOperationException(string name, double[] args)
        {
            var expectedMessage = "Answer can't be calculated.";
            var ex = Assert.Throws<OperationException>(() =>
            {
                var operation = _operationDictionaryRepository.GetDictionary().Where(x => x.Key == name).First().Value;
                var actual = operation.Call(args);
            });
            StringAssert.Contains(expectedMessage, ex.Message);
        }

    }
}