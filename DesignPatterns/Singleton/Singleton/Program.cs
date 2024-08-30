using Singleton;

//Logger logger = new Logger(); //impossible due to protection level
var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

if(logger1 == logger2 && logger2 == Logger.Instance)
    Console.WriteLine("Instances are same");

logger2.Log($"Message from {nameof(logger1)}");
logger2.Log($"Message from {nameof(logger2)}");