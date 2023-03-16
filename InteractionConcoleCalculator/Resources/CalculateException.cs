namespace InteractionConcoleCalculator.Resources
{
    public sealed class OperationException : Exception
    {
        public OperationException() : base()
        {
        }

        public OperationException(string? message) : base(message)
        {
        }
    }
}
