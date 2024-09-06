namespace Mediator
{
    public interface IChatRoom
    {
        void Register(TeamMember member);
        void Send(string from, string message);
        void Send(string from, string to, string message);
        void SendTo<T> (string from,  string message) where T : TeamMember;
    }

    public abstract class TeamMember
    {
        private IChatRoom? _room;

        public string Name { get; set; }
        protected TeamMember(string name)
        {
            Name = name;
        }
        internal void SetChatRoom(IChatRoom room)
        {
            _room = room;
        }
        public void Send(string message)
        {
            _room?.Send(Name,message);  
        }
        public void Send(string to, string message)
        {
            _room?.Send(Name,to,message);
        }
        public void SendTo<T>(string message) where T: TeamMember 
        {
            _room?.SendTo<T>(Name, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"Message {from} to {Name} with message: {message}");
        }
       
    }


    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }
    }
    public class Lawyer : TeamMember
    {
        public Lawyer(string name) : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
            base.Receive(from, message);
        }
    }
    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();
        public void Register(TeamMember member)
        {
            member.SetChatRoom(this);
            if(!teamMembers.ContainsKey(member.Name))
                teamMembers.Add(member.Name, member);
        }

        public void Send(string from, string message)
        {
            foreach (var mes in teamMembers.Values)
            {
                mes.Receive(from,message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
            teamMember.Receive(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach (var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Send(from, message);
            }
        }
    }

}
