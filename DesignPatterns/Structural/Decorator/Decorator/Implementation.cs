namespace Decorator
{
    public class Implementation
    {
        public interface IMailService
        {
            bool SendMail(string message);
        }

        public class CloudMailService : IMailService
        {
            public bool SendMail(string message)
            {
                Console.WriteLine(message + "Cloud Mail Sent");
                return true;
            }
        }
        public class OnPermissionMailServie : IMailService
        {
            public bool SendMail(string message)
            {
                Console.WriteLine(message + " Permission Mail Sent");
                return true;
            }
        }
        public abstract class MailServiceDecoratorBase: IMailService
        {
            private readonly IMailService _mailService;

            public MailServiceDecoratorBase(IMailService mailService)
            {
                _mailService = mailService;
            }

            public virtual bool SendMail(string message)
            {
                return _mailService.SendMail(message);
            }
        }

        public class StatisticsDecorator : MailServiceDecoratorBase
        {
            public StatisticsDecorator(IMailService mailService) : base(mailService)
            {
            }
            public override bool SendMail(string message)
            {
                Console.WriteLine($"Statistics of {nameof(StatisticsDecorator)}");
                return base.SendMail(message);
            }
        }
        public class DatabaseDecorator : MailServiceDecoratorBase
        {
            public List<string> SentMessages { get; private set; } = new List<string>();
            public DatabaseDecorator(IMailService mailService) : base(mailService)
            {
            }

            public override bool SendMail(string message)
            {
                if (base.SendMail(message))
                {
                    SentMessages.Add(message);
                    return true;
                }
                return false;
            }
        }
    }
}
