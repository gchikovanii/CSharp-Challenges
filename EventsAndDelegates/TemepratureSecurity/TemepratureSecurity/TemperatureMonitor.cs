namespace TemepratureSecurity
{
    //public delegate void TemperatureChangeHandler(string message);
    public class TemeperatureChangedEventArgs : EventArgs
    {
        public int Temperature { get; }
        public TemeperatureChangedEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

    public class TemperatureMonitor
    {
        public event EventHandler<TemeperatureChangedEventArgs> OnTemepratureChanged;
        private int _temeprature;
        public int Treshold { get; set; }
        public int Temperature
        {
            get { return _temeprature; }
            set
            {
                if (_temeprature != value)
                {
                    _temeprature = value;
                    OnEventRaised(new TemeperatureChangedEventArgs(_temeprature));
                }


                //if (_temeprature > Treshold) { 
                //}
                //    OnEventRaised($"Temperature is {_temeprature}, it is more than treshold!");

            }
        }

        public void OnEventRaised(TemeperatureChangedEventArgs e)
        {
            OnTemepratureChanged?.Invoke(this, e);
        }
        //public event TemperatureChangeHandler OnTemepratureChange;   
        //public void OnEventRaised(string message)
        //{
        //    OnTemepratureChange?.Invoke(message);
        //}
    }
    public class AlertControl
    {
        public void Alert(object sender, TemeperatureChangedEventArgs args)
        {
            Console.WriteLine($"Alert: temperature is {args.Temperature}, sent by: {sender}");
        }
        //public void Alert(string message)
        //{
        //    Console.WriteLine("Alert: " + message);
        //}
    }

    public class Security
    {
        public void SecurityAction(string message)
        {
            Console.WriteLine("We will cool the temeprature automatically!");
        }
    }

}
