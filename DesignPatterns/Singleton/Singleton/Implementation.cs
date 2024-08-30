namespace Singleton
{
    /// <summary>
    ///  Singleton Patterns
    /// </summary>
    public class Logger
    {
        //private static Logger? _instance;

        //Thread safe way
        private static Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());
        public static Logger Instance { get { return _lazyLogger.Value; } }
        //public static Logger Instance 
        //{
        //    get
        //    {
        //        if( _instance == null )
        //            _instance = new Logger();
        //        return _instance;
        //    }
        //}

        protected Logger()
        {
        }
        public void Log(string message)
        {
            Console.WriteLine("Logging message to log: {0}",message);
        }

    }
}
