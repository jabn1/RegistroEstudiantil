using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Student_Register
{
    [Serializable()]
    public class StudentList
    {
        private List<Student> students = new List<Student>();
        private int lastId = 0;

        public List<Student> GetList { get { return students; } }
        public int LastId { get { return lastId; } set { lastId = value;  } }

        public List<int> GetIdList()
        {
            var idList = new List<int>();
            foreach (var element in students)
            {
                idList.Add(element.Id);
            }
            return idList;
        }

        public void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos actualmente");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                Console.WriteLine("\n" + "\t" + Student.MensajeFullList, "ID:", "Nombre Completo:", "Cédula:", "Celular:", "Carrera:", "Email:", "Fecha de Nacimiento:" + "\n");
                foreach (var student in students)
                {
                    student.PrintAtributes();
                }
            }
        }

        public List<Student> GetStudents()
        {
            return new List<Student>(students);
        }

        public void AddStudent()
        {
            Student newStudent = new Student();
            Console.WriteLine("\n Ingrese los datos del estudiante \n");
            newStudent.SetAllAtributes(lastId + 1);
            students.Add(newStudent);
            lastId++;
        }

        public void EditStudent()
        {
            Console.WriteLine("\n Editar estudiantes \n");
            if (students.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos para editar");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                string mensaje = "{0, -10}{1,-30}";
                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:" + "\n");

                foreach (var student in students)
                {
                    Console.WriteLine("\t" + mensaje, student.Id, student.FullName);
                }

                Console.Write("\n Escriba el ID del estudiante que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());

                Console.WriteLine("\n Ingrese los nuevos datos del estudiante \n");
                foreach (var student in students)
                {
                    if (student.Id == id)
                    {
                        student.SetAllAtributes(id);
                        break;
                    }
                }
            }
        }

        public void DeleteStudent()
        {
            Console.WriteLine("\n Eliminar estudiantes \n");
            if (students.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos para borrar");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                string mensaje = "{0, -10}{1,-30}";
                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:" + "\n");

                foreach (var student in students)
                {
                    Console.WriteLine("\t" + mensaje, student.Id, student.FullName);
                }

                Console.Write("\n Escriba el ID del estudiante que desea eliminar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var student in students)
                {
                    if (student.Id == id)
                    {
                        students.Remove(student);
                        break;
                    }
                }
            }
        }

        public Student SearchAndReturn(int id)
        {
            foreach (var student in this.students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
        public int getCount()
        {
            return this.students.Count;
        }
        public void PrintListIdNameCareer()
        {
            string mensaje = "{0, -10}{1,-30}{2,-10}";
            Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:", "Carrera:" + "\n");
            foreach(var student in students)
            {
                Console.WriteLine("\t" + mensaje, student.Id, student.FullName, student.Career);
            }
            
        }
        public void SearchStudent()
        {
            Console.WriteLine("\n ¿Por qué opción desea buscar? \n");
            Console.WriteLine("1- Por ID");
            Console.WriteLine("2- Por Nombre");
            Console.WriteLine("3- Por Carrera");
            Console.Write("Elija una opción: ");
            int sOpt = Convert.ToInt32("0" + Console.ReadLine());
            Console.Write("Digite el valor de busqueda: ");
            string searchValue = Console.ReadLine();
            bool flagSearch = true;
            bool flagHeader = true;
            for (var s = 0; s < students.Count; s++)
            {
                switch (sOpt)
                {
                    case 1:
                        if (Convert.ToString(students[s].Id).Contains(searchValue))
                        {
                            flagSearch = false;
                            string mensaje = "{0, -10}{1,-30}{2,-10}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:", "Carrera:" + "\n");
                                flagHeader = false;
                            }

                            Console.WriteLine("\t" + mensaje, students[s].Id, students[s].FullName, students[s].Career);
                        }
                        break;
                    case 2:
                        if (students[s].FullName.Contains(searchValue))
                        {
                            flagSearch = false;
                            string mensaje = "{0, -10}{1,-30}{2,-10}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:", "Carrera:" + "\n");
                                flagHeader = false;
                            }
                            Console.WriteLine("\t" + mensaje, students[s].Id, students[s].FullName, students[s].Career);
                        }
                        break;
                    case 3:
                        if (students[s].Career.Contains(searchValue))
                        {
                            flagSearch = false;
                            string mensaje = "{0, -10}{1,-30}{2,-10}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje,  "ID:", "Nombre Completo:", "Carrera:" + "\n");
                                flagHeader = false;
                            }
                            Console.WriteLine("\t" + mensaje, students[s].Id, students[s].FullName, students[s].Career);
                        }
                        break;
                }
            }
            if (flagSearch)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No se encontraron registros");
                Console.WriteLine("\n ******************************************");
            }
        }

        //Metodos relacionados a SubjectRegisterList
        public void AddStudentToList(Student newStudent)
        {
            this.students.Add(newStudent);
        }
        public void PrintIdName()
        {
            string mensaje = "{0, -10}{1,-30}";
            Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Nombre Completo:" + "\n");

            foreach (var student in students)
            {
                Console.WriteLine("\t" + mensaje, student.Id, student.FullName);
            }
        }
        
    }
}
