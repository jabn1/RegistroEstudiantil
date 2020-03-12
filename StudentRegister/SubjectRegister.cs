using System;
using System.Collections.Generic;

namespace Student_Register
{
    [Serializable()]
    class SubjectRegister
    {
        private int id;
        private List<int> startDate = new List<int>() { 0, 0, 0};
        private List<int> endDate = new List<int>() { 0, 0, 0};
        private string classRoom, professor;
        private StudentList subjectRegisterStudents = new StudentList();
        private Subject subject;
        private static string shortFormat = "{0,-10}{1,-20}{2,-20}{3,-15}";
        private static string longFormat = "{0,-10}{1,-20}{2,-20}{3,-30}{4,-20}{5,-25}{6,-20}";

        public static string ShortFormat { get { return SubjectRegister.shortFormat; } }
        public static string LongFormat { get { return SubjectRegister.longFormat; } }
        public int Id { get { return this.id; } }
        public string Code { get { return subject.Code; } }
        public string Subject { get { return this.subject.Name; } }
        public string ClassRoom { get { return this.classRoom; } }
        public string Professor { get { return this.professor; } }
        public List<Student> GetStudentList()
        {
            return subjectRegisterStudents.GetStudents();
        }
        public DateTime StartDate()
        {
            return new DateTime(this.startDate[2], this.startDate[1], this.startDate[0]);
        }
        public string StartDateString()
        {
            return Convert.ToString(this.startDate[0]) + "/" + Convert.ToString(this.startDate[1]) + "/" + Convert.ToString(this.startDate[2]);
        }
        public DateTime EndDate()
        {
            return new DateTime(this.endDate[2], this.endDate[1], this.endDate[0]);
        }
        public string EndDateString()
        {
            return Convert.ToString(this.endDate[0]) + "/" + Convert.ToString(this.endDate[1]) + "/" + Convert.ToString(this.endDate[2]);
        }

        public void SetId(int newId)
        {
            this.id = newId;           
        }
        public void SetStartDate()
        {
            SetDate("Fecha de inicio: ", this.startDate);
        }
        public void SetEndeDate()
        {
            SetDate("Fecha de finalizacion: ", this.endDate);
        }
        public void SetClassroom()
        {
            Console.Write("Aula: ");
            this.classRoom = Console.ReadLine();
        }
        public void SetProfessor()
        {
            Console.Write("Profesor: ");
            this.professor = Console.ReadLine();
        }
        public void SetSubject(Subject aSubject)
        {
            this.subject = aSubject;
        }

        private void SetDate(string prompt, List<int> dateList)
        {
            Console.Write(prompt);
            string captureData = Console.ReadLine() + "$";
            List<int> dayMonthYear = new List<int>() { 0, 0, 0 };
            int position = 0;
            string numbers = "";

            foreach (var number in captureData)
            {
                if (number == '/')
                {
                    dayMonthYear[position] = Convert.ToInt32(numbers);
                    numbers = "";
                    position++;
                    if (position > dayMonthYear.Count - 1) { break; }
                }
                else if (!Char.IsDigit(number) & number != '\n' & number != '/')
                {
                    if (numbers != "") { dayMonthYear[position] = Convert.ToInt32(numbers); }
                    break;
                }
                else { numbers += Convert.ToString(number); }
            }
            dateList[0] = dayMonthYear[0];
            dateList[1] = dayMonthYear[1];
            dateList[2] = dayMonthYear[2];
        }
        public void SetAtributes(int newId)
        {
            SetId(newId);
            SetStartDate();
            SetEndeDate();
            SetProfessor();
            SetClassroom();
        }
        public void PrintAtributesShortFormat()
        {
            Console.WriteLine("\t" + SubjectRegister.shortFormat, this.id, this.subject.Name, this.professor, this.subjectRegisterStudents.getCount());
        }
        public void PrintAtributesLongFormat()
        {
            Console.WriteLine("\t" + SubjectRegister.longFormat, this.id, this.subject.Name, this.professor, this.subjectRegisterStudents.getCount(), this.StartDateString(), this.EndDateString(), this.classRoom);
        }
        public Student SearchAndReturnStudent(int id)
        {
            return this.subjectRegisterStudents.SearchAndReturn(id);
        }
        public void AddStudentToSubjectRegister(Student aStudent)
        {
            this.subjectRegisterStudents.AddStudentToList(aStudent);
        }
        public void DeleteStudentFromRegister()
        {
            this.subjectRegisterStudents.DeleteStudent();
        }
        public void ListStudentsFromRegister()
        {
            this.subjectRegisterStudents.ListStudents();
        }
    }
}
