using Memento;
using static Memento.AddEmployeeToManagerList;

CommandManager commandManager = new();
IEmployeeRepository employeeRepository = new EmployeeRepository();
commandManager.Invoke(new AddEmployeeToManagerList(employeeRepository, 1, new Employee(251, "chiko")));
employeeRepository.WriteDataStore();

commandManager.Undo();
employeeRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(employeeRepository, 2, new Employee(252, "rap")));
employeeRepository.WriteDataStore();

commandManager.Undo();
employeeRepository.WriteDataStore();

