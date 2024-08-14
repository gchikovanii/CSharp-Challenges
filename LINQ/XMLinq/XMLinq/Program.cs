using System.Xml.Linq;

string studentsXML =
                       @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                                <Knwoladge>
                                    <IQ>100</IQ>
                                    <tech>120</tech>
                                </Knwoladge>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                                <Knwoladge>
                                    <IQ>31</IQ>
                                    <tech>80</tech>
                                </Knwoladge>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                                <Knwoladge>
                                    <IQ>33</IQ>
                                    <tech>99</tech>
                                </Knwoladge>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                                <Knwoladge>
                                    <IQ>1</IQ>
                                    <tech>0</tech>
                                </Knwoladge>
                            </Student>
                        </Students>";

//Descendents and DescendentsNode
XDocument studentXmlDoc = new XDocument();
studentXmlDoc = XDocument.Parse(studentsXML);
//var students = from student in studentXmlDoc.Descendants("Student")
//               select new
//               {
//                   Name = student?.Element("Name")?.Value,
//                   Age = student?.Element("Age")?.Value,
//                   University = student?.Element("University")?.Value,
//               };
var students = studentXmlDoc.Descendants("Student").Select(student => new
{
    Name = student?.Element("Name")?.Value,
    Age = student?.Element("Age")?.Value,
    University = student?.Element("University")?.Value,
    Semester = student?.Element("Semester")?.Value,
    IQ = student?.Element("Knwoladge")?.Element("IQ")?.Value,
    Tech = student?.Element("Knwoladge")?.Element("tech")?.Value
});

foreach (var student in students)
{
    Console.WriteLine("Student {0} with age {1} from University of {2}, Semester: {3}",student.Name,student.Age,student.University,student.Semester);
}

//var sortedStudents = from st in students orderby st.Age ascending select st;
var sortedStudents = students.OrderBy(i => i.Age);
foreach (var student in sortedStudents)
{
    Console.WriteLine("Student {0} with age {1} from University of {2}, Semester: {3}, IQ: {4}/100, Tech Skills: {5}/100", student.Name, student.Age, student.University, student.Semester,student.IQ,student.Tech);
}