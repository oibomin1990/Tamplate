namespace MFU.Logger
{
    public abstract class LoggerBase
    {
        protected readonly object lockObj = new object();
        public LoggerLevel Level { get; set; }
        public abstract void Log(string message);
    }
}