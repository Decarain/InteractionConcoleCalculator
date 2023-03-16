namespace InteractionConcoleCalculator.BLL
{
    public class Operation : IOperation
    {
        private Func<double[], double> _op;
        public Operation(Func<double[], double> op)
        {
            _op = op;
        }
        public double Call(double[] args) => _op(args);
    }
}
