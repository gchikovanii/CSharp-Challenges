using TemepratureSecurity;

TemperatureMonitor temperatureMonitor = new TemperatureMonitor();
AlertControl alertControl = new AlertControl();
Security security = new Security();
Random random = new Random();

//temperatureMonitor.OnTemepratureChange += alertControl.Alert;
//temperatureMonitor.OnTemepratureChange += security.SecurityAction;
//temperatureMonitor.Treshold = 30;

temperatureMonitor.OnTemepratureChanged += alertControl.Alert;
temperatureMonitor.Temperature = random.Next(20, 50);


