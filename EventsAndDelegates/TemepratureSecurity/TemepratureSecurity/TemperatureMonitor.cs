namespace TemepratureSecurity
{
    public delegate void TemperatureChangeHandler(string message);

    public class TemperatureMonitor
    {
        private int _temeprature;
        public int Treshold { get; set; }
        public int Temperature { get { return _temeprature; }
            set 
            {
                _temeprature = value;
                if (_temeprature > Treshold)
                    OnEventRaised($"Temperature is {_temeprature}, it is more than treshold!");

            } 
        }
        public event TemperatureChangeHandler OnTemepratureChange;   
        public void OnEventRaised(string message)
        {
            OnTemepratureChange?.Invoke(message);
        }
    }
    public class AlertControl
    {
        public void Alert(string message)
        {
            Console.WriteLine("Alert: " + message);
        }
    }

    public class Security
    {
        public void SecurityAction(string message)
        {
            Console.WriteLine("We will cool the temeprature automatically!");
        }
    }

}
