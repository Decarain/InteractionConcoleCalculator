namespace InteractionConcoleCalculator.BLL
{
    public interface IArithmeticOperationHandler
    {
        double Invoke(string name, double[] args);

        string[] GetOperationNames();
    }
}
