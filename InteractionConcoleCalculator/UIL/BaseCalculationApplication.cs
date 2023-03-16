using InteractionConcoleCalculator.BLL;
using InteractionConcoleCalculator.DLL;
using InteractionConcoleCalculator.Resources;

namespace InteractionConcoleCalculator.UIL
{
    public class BaseCalculationApplication
    {
        private readonly IArithmeticOperationHandler _arithmeticOperationHandler;
        private string[] _operationNames;

        public BaseCalculationApplication(IOperationDictionaryRepository? operationDictionaryRepository = null, IArithmeticOperationHandler? arithmeticOperationHandler = null)
        {
            var _operationDictionaryRepository = operationDictionaryRepository ?? new OperationDictionaryRepository();

            _arithmeticOperationHandler = arithmeticOperationHandler ?? new ArithmeticOperationHandler(_operationDictionaryRepository);
            _operationNames = _arithmeticOperationHandler.GetOperationNames();
        }

        public void Calculate()
        {
            while (true)
            {
                try
                {
                    var inputName = InputCommandName();

                    if (!_operationNames.Contains(inputName))
                    {
                        InvalidOperationNameRespond();
                        continue;
                    }

                    var commandArguments = InputCommandArguments();
                    var operationAnswer = _arithmeticOperationHandler.Invoke(inputName, commandArguments);
                    OperationSuccessRespond(operationAnswer);
                }
                catch (OperationException ex)
                {
                    OperationFailedRespond(ex.Message);
                }
                catch (Exception)
                {
                    OperationFailedRespond();
                }
            }
        }

        protected virtual void InvalidOperationNameRespond()
        {
            Console.WriteLine(Constants.INVALID_OPERATION_NAME_ERROR_MESSAGE);
        }


        protected virtual void OperationFailedRespond()
        {
            Console.WriteLine($"{Constants.OPERATION_FAILED_ERROR_MESSAGE}: {Constants.OPERATION_FAILED_UNKNOWN_ERROR_MESSAGE}.");
        }

        protected virtual void OperationFailedRespond(string message)
        {
            Console.WriteLine($"{Constants.OPERATION_FAILED_ERROR_MESSAGE}: {message}.");
        }

        protected virtual void OperationSuccessRespond(double answer)
        {
            Console.WriteLine($"{Constants.ANSWER_CONSOLE_MESSAGE}: {answer}.");
        }


        protected virtual string InputCommandName()
        {
            Console.WriteLine(Constants.ENTER_COMMAND_NAME_CONSOLE_MESSAGE);
            return Console.ReadLine()!.ToUpper();
        }

        protected virtual double[] InputCommandArguments()
        {
            Console.WriteLine(Constants.ENTER_COMMAND_ARGUMENTS_CONSOLE_MESSAGE);
            var inputArguments = Console.ReadLine()!;
            var commandArguments = GetArguments(inputArguments);
            return commandArguments;
        }


        private double[] GetArguments(string inputArguments)
        {
            var splitArguments = inputArguments.Split(new char[] { '\t', ' ' }).Where(x => x.Length > 0);
            var doubleList = new List<double>();

            foreach (var arg in splitArguments)
            {
                if (double.TryParse(arg, out double parsedArg))
                {
                    doubleList.Add(parsedArg);
                }
            }

            return doubleList.ToArray();
        }

    }
}
