namespace Command
{
    public class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Manager : Employee
    {
        public Manager(int id, string name) : base(id, name)
        {
        }
        public List<Employee> Employees = new();
    }
    public interface IEmployeeRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Manager> _managers = new() { new Manager(1, "Giorgi"), new Manager(2, "Mar") };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(i => i.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(i => i.Id == managerId).Employees.Any(i => i.Id == employeeId);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(i => i.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id} - {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var emp in manager.Employees)
                    {
                        Console.WriteLine($"  Employee {emp.Id} - {emp.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("N/A");
                }
            }
        }

    }
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeRepository _managerRepository;
        private readonly int _managerId;
        private readonly Employee? _employee;

        public AddEmployeeToManagerList(IEmployeeRepository managerRepository, int managerId, Employee? employee)
        {
            _managerRepository = managerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public bool CanExecute()
        {
            if (_employee == null)
                return false;
            if (_managerRepository.HasEmployee(_managerId, _employee.Id))
                return false;
            return true;
        }

        public void Execute()
        {
            if (_employee == null)
                return;
            _managerRepository.AddEmployee(_managerId, _employee);
        }
        public void Undo()
        {
            if (_employee == null)
                return;
            _managerRepository.RemoveEmployee(_managerId, _employee);
        }
        public class CommandManager
        {
            private readonly Stack<ICommand> _commands = new Stack<ICommand>();
            public void Invoke(ICommand command)
            {
                if (command.CanExecute())
                {
                    command.Execute();
                    _commands.Push(command);
                }

            }
            public void Undo()
            {
                if (_commands.Any())
                {
                    _commands.Pop()?.Undo();
                }
            }
            public void UndoAll()
            {
                while (_commands.Any())
                {
                    _commands.Pop()?.Undo();
                }
            }
        }
    }

}
