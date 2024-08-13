using TemepratureSecurity;

TemperatureMonitor temperatureMonitor = new TemperatureMonitor();
AlertControl alertControl = new AlertControl();
Security security = new Security();

temperatureMonitor.OnTemepratureChange += alertControl.Alert;
temperatureMonitor.OnTemepratureChange += security.SecurityAction;
Random random = new Random();
temperatureMonitor.Treshold = 30;
temperatureMonitor.Temperature = random.Next(20, 50);


