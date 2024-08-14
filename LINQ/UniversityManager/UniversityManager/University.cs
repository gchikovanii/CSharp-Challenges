namespace UniversityManager
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine("{0}----University {1} ",Id,Name);
        }
    }
}
