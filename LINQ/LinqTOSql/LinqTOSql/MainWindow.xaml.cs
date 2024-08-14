using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LinqTOSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string connection = ConfigurationManager.ConnectionStrings["LinqTOSqL.Properties.Settings.TestConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connection);
            //InsertUniversites();
            //InsertStudent();
            //InsertLectures();
            //InsertStudentLectureAssociations();
            //GetUniversityOfStudent("Giorgi");
            //GetLecturesFromStudent("Giorgi");
            //GetAllStudentsFromUniversity("btu");
            //GetAllUniversitiesWithGender("male");
            //GetAllLecturesFromUniversity("btu");
            //UpdateStudentName("Giorgi", "Gio");
            DeleteUser("Gio");
        }
        public void InsertUniversites()
        {
            University btu = new University();
            btu.Name = "BTU";
            University cu = new University();
            cu.Name = "CU";
            University ibsu = new University();
            ibsu.Name = "IBSU";
            dataContext.Universities.InsertOnSubmit(btu);
            dataContext.Universities.InsertOnSubmit(cu);
            dataContext.Universities.InsertOnSubmit(ibsu);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Universities;

        }
        public void InsertStudent()
        {
            University btu = dataContext.Universities.First(i => i.Name.ToLower() == "btu");
            University cu = dataContext.Universities.First(i => i.Name.ToLower() == "cu");
            University ibsu = dataContext.Universities.First(i => i.Name.ToLower() == "ibsu");

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Giorgi", Gender = "Male", UniversityId = btu.Id });
            students.Add(new Student { Name = "Lelya", Gender = "Female", UniversityId = btu.Id });
            students.Add(new Student { Name = "James", Gender = "Male", UniversityId = cu.Id });
            students.Add(new Student { Name = "Anastasia", Gender = "Female", UniversityId = ibsu.Id });
            students.Add(new Student { Name = "Shaqro", Gender = "Male", UniversityId = ibsu.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }
        public void InsertLectures()
        {
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "English" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "History" });

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentLectureAssociations()
        {
            List<Student> students = new List<Student>();
            students.AddRange(dataContext.Students.ToList());

            List<Lecture> lectures = new List<Lecture>();
            lectures.AddRange(dataContext.Lectures.ToList());

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[0] , Lecture = lectures[0] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[0] , Lecture = lectures[1] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[0] , Lecture = lectures[2] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[1] , Lecture = lectures[1] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[2] , Lecture = lectures[2] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[3] , Lecture = lectures[1] });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = students[4] , Lecture = lectures[2] });

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.StudentLectures;

        }
        public void GetUniversityOfStudent(string name)
        {
            Student student = dataContext.Students.First(i => i.Name == name);  
            University university = student.University;
            List<University> unis = new List<University>();
            unis.Add(university);
            MainDataGrid.ItemsSource = unis;
        }
        public void GetLecturesFromStudent(string name)
        {
            Student student = dataContext.Students.First(i => i.Name == name);
            //var studentLectures = from sl in student.StudentLectures select sl.Lecture;
            var studentLectures = student.StudentLectures.Select(i => i.Lecture);
            MainDataGrid.ItemsSource = studentLectures;
        }
    
        public void GetAllStudentsFromUniversity(string universityName)
        {
            var students = dataContext.Students.Where(i => i.University.Name.ToLower() == universityName.ToLower()).ToList();
            MainDataGrid.ItemsSource = students;
        }

        public void GetAllUniversitiesWithGender(string gender)
        {
            //var genStudents = from student in dataContext.Students
            //                  join university in dataContext.Universities
            //                  on student.UniversityId equals university.Id
            //                  where student.Gender == gender
            //                  select university;
            var genderStudents = dataContext.Students.Join(dataContext.Universities,
                student => student.UniversityId,
                university => university.Id,
                (student, university) => new { student, university }).Where(i => i.student.Gender.ToLower() == gender.ToLower()).Select(i => i.university);

            MainDataGrid.ItemsSource = genderStudents;
        }
        public void GetAllLecturesFromUniversity(string university)
        {
            //var lecutures = from sl in dataContext.StudentLectures
            //                join student in dataContext.Students
            //                on sl.StudentId equals student.Id
            //                where student.University.Name.ToLower() == university.ToLower()
            //                select sl.Lecture;
            var lectures = dataContext.StudentLectures.Join(dataContext.Students,
                studentLecture => studentLecture.StudentId,
                student => student.Id,
                (studentLecture, student) => new { studentLecture, student })
                .Where(i => i.student.University.Name.ToLower() == university.ToLower()).Select(i => i.studentLecture.Lecture).Distinct();
            MainDataGrid.ItemsSource = lectures;
        }

        public void UpdateStudentName(string studentName, string newName)
        {
            Student student = dataContext.Students.FirstOrDefault(i => i.Name == studentName);
            student.Name = newName;
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;

        }

        public void DeleteUser(string studentName)
        {
            Student student = dataContext.Students.FirstOrDefault(i => i.Name == studentName);
            dataContext.Students.DeleteOnSubmit(student);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
