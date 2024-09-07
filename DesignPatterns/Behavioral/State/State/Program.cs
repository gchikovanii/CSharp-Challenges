
using State;

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.WithDraw(500);
bankAccount.WithDraw(200);

bankAccount.Deposit(5000);
bankAccount.Deposit(200);
bankAccount.WithDraw(3000);
bankAccount.Deposit(3000);
bankAccount.Deposit(200);
