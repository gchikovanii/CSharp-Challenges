namespace UniversityManager
{
    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int UniversityId { get; set; }
        public void Print()
        {
            Console.WriteLine("{0}----{1}, with age: {2} and gender {3} studies at: {4}",Id,Name,Age, nameof(Gender),UniversityId);
        }
    }
}
