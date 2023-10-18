namespace IQ_Class.Data.Commun
{
    public class Result<T> where T : class
    {
        public bool Failure => !Success;

        public bool Success { get; }

        public string? Message { get; }
        public T? Value { get; }

        public Result(T? value, string Message)
        {
            this.Success = value != null;
            this.Value = value;
            this.Message = Message;
        }
        public Result(T? value)
        {
            this.Success = value != null;
            this.Value = value;
        }
        public Result(string Message)
        {
            this.Message = Message;
            this.Success = false;
        }
    }
}
