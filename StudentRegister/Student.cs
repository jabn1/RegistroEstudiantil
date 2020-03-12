using System;
using System.Collections.Generic;

namespace Student_Register
{
    [Serializable()]
    public class Student
    {
        private int id;
        private string fullName, documentNumber, career, phone, email;
        private List<int> birthDateList;
        private static string mensajeFullList = "{0, -10}{1,-30}{2,-15}{3,-15}{4,-10}{5,-30}{6,-10}";
        public List<int> BirthDateList { get { return birthDateList; } set { birthDateList = value;  } }

        //metodos Get
        public int Id { get { return this.id; } set { id = value; } }
 
        public string FullName { get { return this.fullName; } set { fullName = value; } }
        public string DocumentNumber { get { return this.documentNumber; } set { documentNumber = value;  } }
        public string Career { get { return this.career; } set { career = value;  } }
        public string Phone { get { return this.phone; } set { phone = value; } }
        public string Email { get { return this.email; } set { email = value;  } }
        public static string MensajeFullList { get { return Student.mensajeFullList; } }

        public DateTime BirthDate()
        {
            return new DateTime(this.birthDateList[2], this.birthDateList[1], this.birthDateList[0]);
        }
        public string BirthDateString()
        {
            return Convert.ToString(this.birthDateList[0]) + "/" + Convert.ToString(this.birthDateList[1]) + "/" + Convert.ToString(this.birthDateList[2]);
        }

        //metodos Set
        public void SetId(int newID)
        {
            this.id = newID;
        }
        public void SetFullName()
        {
            Console.Write("Nombre Completo: ");
            this.fullName = Console.ReadLine();
        }
        public void SetDocumentNumber()
        {
            Console.Write("Cédula: ");
            this.documentNumber = Console.ReadLine();
        }
        public void SetCareer()
        {
            Console.Write("Carrera: ");
            this.career = Console.ReadLine();
        }
        public void SetPhone()
        {
            Console.Write("Teléfono: ");
            this.phone = Console.ReadLine();
        }
        public void SetEmail()
        {
            Console.Write("Email: ");
            this.email = Console.ReadLine();
        }
        public void SetBirthDate()
        {
            Console.Write("Fecha de nacimiento (dd/mm/yyyy): ");
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
            this.birthDateList = dayMonthYear;
        }

        public void PrintAtributes()
        {

            Console.WriteLine("\t" + mensajeFullList, this.id, this.fullName, this.documentNumber, this.phone, this.career, this.email, this.BirthDateString());
            
        }

        public void SetAllAtributes(int newId)
        {
            this.SetId(newId);
            this.SetFullName();
            this.SetDocumentNumber();
            this.SetCareer();
            this.SetPhone();
            this.SetEmail();
            this.SetBirthDate();
        }

    }
}
