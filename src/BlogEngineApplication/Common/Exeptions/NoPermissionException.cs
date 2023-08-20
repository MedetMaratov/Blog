namespace BlogEngineApplication.Common.Exeptions
{
    public class NotPermissionException : Exception
    {
        public NotPermissionException(string message) : base(message) { }
    }
}
