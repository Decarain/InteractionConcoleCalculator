using InteractionConcoleCalculator.BLL;

namespace InteractionConcoleCalculator.DLL
{
    public class OperationDictionaryRepository : IOperationDictionaryRepository
    {
        private readonly Dictionary<string, IOperation> operationDictionary = new();

        public OperationDictionaryRepository()
        {
            operationDictionary.Add("SUM", new Operation(x =>
            {
                ArrayValidation(x, 2);
                var result = x[0] + x[1];
                AnswerIsViniteValidation(result);
                return result;
            }));

            operationDictionary.Add("DIFF", new Operation(x =>
            {
                ArrayValidation(x, 2);
                var result = x[0] - x[1];
                AnswerIsViniteValidation(result);
                return result;
            }));

            operationDictionary.Add("MULT", new Operation(x =>
            {
                ArrayValidation(x, 2);
                var result = x[0] * x[1];
                AnswerIsViniteValidation(result);
                return result;
            }));

            operationDictionary.Add("DIV", new Operation(x =>
            {
                ArrayValidation(x, 2);
                var result = x[0] / x[1];
                AnswerIsViniteValidation(result);

                return result;
            }));

            operationDictionary.Add("ABS", new Operation(x =>
            {
                ArrayValidation(x, 1);
                var result = Math.Abs(x[0]);
                AnswerIsViniteValidation(result);

                return result;
            }));


            operationDictionary.Add("SIN", new Operation(x =>
            {
                ArrayValidation(x, 1);
                var result = Math.Sin(x[0]);
                AnswerIsViniteValidation(result);

                return result;
            }));


            operationDictionary.Add("COS", new Operation(x =>
            {
                ArrayValidation(x, 1);
                var result = Math.Cos(x[0]);
                AnswerIsViniteValidation(result);

                return result;
            }));


            operationDictionary.Add("TAN", new Operation(x =>
            {
                ArrayValidation(x, 1);
                var result = Math.Tan(x[0]);
                AnswerIsViniteValidation(result);

                return result;
            }));


            operationDictionary.Add("POW", new Operation(x =>
            {
                ArrayValidation(x, 2);
                var result = Math.Pow(x[0], x[1]);
                AnswerIsViniteValidation(result);

                return result;
            }));
        }

        public Dictionary<string, IOperation> GetDictionary() => operationDictionary;

        private void ArrayValidation(double[] doubles, int minLength)
        {
            if (doubles is null)
            {
                throw new OperationException("Array can't be null.");
            }
            if (doubles.Length < minLength)
            {
                throw new OperationException($"Array length ({doubles.Length}) is less than reqied ({minLength}).");
            }
        }

        private void AnswerIsViniteValidation(double ans)
        {
            if (!double.IsFinite(ans))
            {
                throw new OperationException("Answer can't be calculated.");
            }
        }
    }
}