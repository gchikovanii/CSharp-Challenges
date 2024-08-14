namespace UniversityManager
{
    public class UniManager
    {
        public List<University> Universities;
        public List<Student> Students;
        public UniManager()
        {
            var universities = new List<University>();
            var students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "BTU" });
            universities.Add(new University { Id = 2, Name = "CAU" });
            universities.Add(new University { Id = 3, Name = "TSU" });

            students.Add(new Student { Id = 1, Name = "Giorgi", Age = 23, Gender = Gender.Male, UniversityId = 1 });
            students.Add(new Student { Id = 1, Name = "Zurabi", Age = 21, Gender = Gender.Male, UniversityId = 2 });
            students.Add(new Student { Id = 1, Name = "Anastasia", Age = 18, Gender = Gender.Female, UniversityId = 2 });
            students.Add(new Student { Id = 1, Name = "Erekle", Age = 25, Gender = Gender.Male, UniversityId = 3 });
            students.Add(new Student { Id = 1, Name = "Ermalo", Age = 27, Gender = Gender.Male, UniversityId = 1 });
            students.Add(new Student { Id = 1, Name = "Ekaterine", Age = 19, Gender = Gender.Female, UniversityId = 3 });

            Universities = universities;
            Students = students;
        }


        public void GetByGender(Gender gender)
        {
            //IEnumerable<Student> onlyMales = from maleStudent in Students where maleStudent.Gender.ToString() == gender.ToString() select maleStudent;
            
            //method syntax
            IEnumerable<Student> onlyMales = Students.Where(i => i.Gender == gender);
            foreach (Student student in onlyMales)
            {
                student.Print();
            }
        }
        public void SortStudentsByAge()
        {
            //var students = from student in Students orderby student.Age descending select student;
            /*var students = Students.OrderBy(i => i.Age);*/ //by ascending
            var students = Students.OrderByDescending(i => i.Age);
            foreach (var std in students)
            {
                std.Print();
            }
        }
        public void AllStudentsFrom(string univeristyName)
        {
            //var students = from student in Students
            //             join university in Universities
            //             on student.UniversityId equals university.Id
            //             where university.Name.ToLower() == univeristyName.ToLower()
            //             select student;
            var students = Students.Join(Universities, student => student.UniversityId, uni => uni.Id,
                (student,uni) => new {student,uni}).Where(i => i.uni.Name.ToLower() == univeristyName.ToLower()).Select(i => i.student);
            Console.WriteLine("Students from {0}", univeristyName);
            foreach (var std in students)
            {
                std.Print();
            }
        }
        public void JoinUniAndStudent()
        {
            //var studentWithUni = from student in Students
            //                     join university in Universities
            //                     on student.UniversityId equals university.Id
            //                     orderby student.Name
            //                     select new { StudentName = student.Name, StudentAge = student.Age, StudentGender = student.Gender, UniveristyName = university.Name };

            var studentWithUni = Students.Join(Universities, student => student.UniversityId, uni => uni.Id,
                (student, uni) => new { student, uni }).OrderBy(i => i.student.Name).Select(i => new
                {
                    StudentName = i.student.Name,
                    StudentAge = i.student.Age,
                    StudentGender = i.student.Gender,
                    UniversityName = i.uni.Name
                });
            foreach (var su in studentWithUni)
            {
                Console.WriteLine("{0} is: {1} years old {2}. Studies at: {3}",su.StudentName,su.StudentAge,su.StudentGender,su.UniversityName);
            }
        }
    }
}
