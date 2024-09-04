namespace TemplateMethod
{
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding Server");
        }
        public abstract void AuthenticateToServer();

        public string ParseHtmlBody(string identifier)
        {
            Console.WriteLine("Parsing html body...");
            return $"This is body of Identifier: {identifier}";
        }

        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing mail body in template method...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlBody(identifier);
        }

    }

    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to exchange");
        }
    }
    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache");
        }
    }

    public class EudoraMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora");
        }
        public override void FindServer()
        {
            Console.WriteLine("Finding eudora server");
        }
    }

}
