using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Student_Register
{
    class Program
    {
        static StudentList Students;
        static SubjectList Subjects;
        static SubjectRegisterList SubjectsRegister;

        //Funciones nuevas para serializar/deserializar

        static void ClearRegisterObjects() //Limpia objetos y guarda los cambios
        {
            Students = new StudentList();
            Subjects = new SubjectList();
            SubjectsRegister = new SubjectRegisterList();
            Serialize();

        }
        static void DeserializeStudents() //Deserializa el objeto Students 
        {
            try
            {
                using (Stream stream = File.Open("studentsBinary.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    Students = (StudentList)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                Students = new StudentList();
            }
        }
        static void JsonImport()
        {
            var json = System.IO.File.ReadAllText("Files/Template.json");
            Students = JsonConvert.DeserializeObject<StudentList>(json);
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Importado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            ImportExportStudentMenu();
            // SerializeStudents();
        }
        static void XmlImport()
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(StudentList));
            StreamReader newtw = new StreamReader("Files/Template.xml");
            Students = (StudentList)writer.Deserialize(newtw);
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Importado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            ImportExportStudentMenu();
            // SerializeStudents();

        }
        static void DeserializeSubjects() //Deserializa el objeto Subjects
        {
            try
            {
                using (Stream stream = File.Open("subjectsBinary.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    Subjects = (SubjectList)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                Subjects = new SubjectList();
            }
        }

        static void DeserializeSubjectsRegister() //Deserializa el objeto SubjectsRegister
        {
            try
            {
                using (Stream stream = File.Open("subjectRegisterBinary.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    SubjectsRegister = (SubjectRegisterList)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                SubjectsRegister = new SubjectRegisterList();
            }
        }
        static void Deserialize() //Funcion unificada deserializar para iniciar el programa
        {
            DeserializeStudents();
            DeserializeSubjects();
            DeserializeSubjectsRegister();
        }

        // Se debe incluir la funcion serializar correspondiente despues de invocar un metodo que hace cambios
        // sobre los objetos Students, Subjects, SubjectsRegister
        static void SerializeStudents() //Serializa el objeto Students
        {
            try
            {
                using (Stream stream = File.Open("studentsBinary.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Students);
                }
            }
            catch (IOException) { }            
        }
        static void JsonExport()
        {
            string JsonStudents = JsonConvert.SerializeObject(Students);
            System.IO.File.WriteAllText("Files/Estudiantes.json", JsonStudents);
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Exportado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            ImportExportStudentMenu();
        }
        static void XmlExport()
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(StudentList));
            TextWriter newsw = new StreamWriter("Files/test.xml");
            writer.Serialize(newsw, Students);
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Exportado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            ImportExportStudentMenu();
        }
        static void ExcelExport()
        {
            Console.Clear();
            var sub = SubjectsRegister.SearchAndReturnSubjectRegisterForReport();
            if (sub != null)
            {
                FilesReport.ExportExcel(sub);
            } else
            {
                ExcelExport();
            }
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Generado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            GenerateDocumentMenu();
        }
        static void PdfExport()
        {
            Console.Clear();
            var sub = SubjectsRegister.SearchAndReturnSubjectRegisterForReport();
            if (sub != null)
            {
                FilesReport.ExportPdf(sub);
            } else
            {
                PdfExport();
            }
            Console.Clear();
            Console.WriteLine("\n **************************************************");
            Console.Write("\t Documeto Generado Exitosamente");
            Console.WriteLine("\n **************************************************");
            Console.WriteLine(" Presione Cualquier tecla para continuar ");
            Console.ReadKey();
            GenerateDocumentMenu();
        }
        static void SerializeSubjects() //Serializa el objeto Subjects
        {
            try
            {
                using (Stream stream = File.Open("subjectsBinary.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Subjects);
                }
            }
            catch (IOException) { }
        }
        static void SerializeSubjectsRegister() //Serializa el objeto SubjectsRegister
        {
            try
            {
                using (Stream stream = File.Open("subjectRegisterBinary.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, SubjectsRegister);
                }
            }
            catch (IOException) { }
        }
        static void Serialize()
        {
            SerializeStudents();
            SerializeSubjects();
            SerializeSubjectsRegister();  
        }

        // ********************************


        static void MainMenu()
        {
            int menuOption = 0;
            Console.Clear();

            while (menuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Estudiantes ");
                Console.WriteLine(" 2- Asignaturas ");
                Console.WriteLine(" 3- Registro de Asignaturas ");
                Console.WriteLine(" 4- Importat/Exportar Estudiantes");
                Console.WriteLine(" 5- Generar Documento Registro de Asignaturas ");
                Console.WriteLine(" 6- Eliminar Base de Datos ");
                Console.WriteLine(" 7- Salir ");
                Console.Write("\n Elija una opción: ");
                menuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch(menuOption)
                {
                    case 1:
                        StudentMenu();
                        break;
                    case 2:
                        SubjectMenu();
                        break;
                    case 3:
                        SubjectRegisterMenu();
                        break;
                    case 4:
                        ImportExportStudentMenu();
                        break;
                    case 5:
                        GenerateDocumentMenu();
                        break;
                    case 6:
                        DropDataBase();
                        break;
                    case 7:
                        Exit();
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }

        }
        static void ImportExportStudentMenu()
        {
            int importExportMenuOption = 0;
            Console.Clear();

            while (importExportMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Importar JSON ");
                Console.WriteLine(" 2- Exportar JSON ");
                Console.WriteLine(" 3- Importar XML ");
                Console.WriteLine(" 4- Exportar XML ");
                Console.WriteLine(" 5- Volver al Menu Principal ");
                Console.Write("\n Elija una opción: ");
                importExportMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (importExportMenuOption)
                {
                    case 1:
                        JsonImport();
                        break;
                    case 2:
                        JsonExport();
                        break;
                    case 3:
                        XmlImport();
                        break;
                    case 4:
                        XmlExport();
                        break;
                    case 5:
                        MainMenu();
                        break;
                    default:
                        ImportExportStudentMenu();
                        break;
                }
            }

        }
        static void GenerateDocumentMenu()
        {
            int documentMenuOption = 0;
            Console.Clear();

            while (documentMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Generar Excel ");
                Console.WriteLine(" 2- Generar PDF ");
                Console.WriteLine(" 3- Menu Principal ");
                Console.Write("\n Elija una opción: ");
                documentMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch(documentMenuOption)
                {
                    case 1:
                        ExcelExport();
                        break;
                    case 2:
                        PdfExport();
                        break;
                    case 3:
                        MainMenu();
                        break;
                    default:
                        GenerateDocumentMenu();
                        break;
                }
            }

        }

        static void StudentMenu()
        {
            int studentMenuOption = 0;
            Console.Clear();

            while (studentMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Listar Estudiante ");
                Console.WriteLine(" 2- Agregar Estudiante ");
                Console.WriteLine(" 3- Editar Estudiante ");
                Console.WriteLine(" 4- Borrar Estudiante ");
                Console.WriteLine(" 5- Buscar Estudiante ");
                Console.WriteLine(" 6- Volver al Menu Principal");
                Console.Write("\n Elija una opción: ");
                studentMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (studentMenuOption)
                {
                    case 1:
                        ListStudent();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        EditStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        SearchStudent();
                        break;
                    case 6:
                        MainMenu();
                        break;
                    default:
                        StudentMenu();
                        break;
                }
            }

        }
        static void SubjectMenu()
        {
            int subjectMenuOption = 0;
            Console.Clear();

            while (subjectMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Listar Asignatura ");
                Console.WriteLine(" 2- Agregar Asignatura ");
                Console.WriteLine(" 3- Editar Asignatura ");
                Console.WriteLine(" 4- Borrar Asignatura ");
                Console.WriteLine(" 5- Buscar Asignatura ");
                Console.WriteLine(" 6- Volver al Menu Principal");
                Console.Write("\n Elija una opción: ");
                subjectMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectMenuOption)
                {
                    case 1:
                        ListSubject();
                        break;
                    case 2:
                        AddSubject();
                        break;
                    case 3:
                        EditSubject();
                        break;
                    case 4:
                        DeleteSubject();
                        break;
                    case 5:
                        SearchSubject();
                        break;
                    case 6:
                        MainMenu();
                        break;
                    default:
                        SubjectMenu();
                        break;
                }
            }
        }
        static void SubjectRegisterMenu()
        {
            int subjectRegisterMenuOption = 0;
            Console.Clear();

            while (subjectRegisterMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Listar Registro de Asignaturas ");
                Console.WriteLine(" 2- Agregar Registro de Asignatura ");
                Console.WriteLine(" 3- Editar Registro de Asignatura ");
                Console.WriteLine(" 4- Borrar Registro de Asignatura ");
                Console.WriteLine(" 5- Buscar Registro de Asignatura ");
                Console.WriteLine(" 6- Volver al Menu Principal");
                Console.Write("\n Elija una opción: ");
                subjectRegisterMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectRegisterMenuOption)
                {
                    case 1:
                        ListSubjectRegister();
                        break;
                    case 2:
                        AddSubjectRegister();
                        break;
                    case 3:
                        EditSubjectRegister();
                        break;
                    case 4:
                        DeleteSubjectRegister();
                        break;
                    case 5:
                        SearchSubjectRegister();
                        break;
                    case 6:
                        MainMenu();
                        break;
                    default:
                        SubjectRegisterMenu();
                        break;
                }
            }
        }
        static void ListStudent()
        {
            Console.Clear();

            Students.ListStudents();

            Console.WriteLine("\n\n ¿Qué desea hacer? \n");
            Console.WriteLine("1- Mantenerse en Lista");
            Console.WriteLine("2- Menú Estudiantes");
            Console.Write("\n Elija una opción: ");

            int studentListOption = Convert.ToInt32("0" + Console.ReadLine());
            switch(studentListOption)
            {
                case 2:
                    StudentMenu();
                    break;
                default:
                    ListStudent();
                    break;
            }
        }
        static void ListSubject()
        {
            Console.Clear();
            Subjects.ListSubjects();

            Console.WriteLine("\n\n ¿Qué desea hacer? \n");
            Console.WriteLine("1- Mantenerse en Lista");
            Console.WriteLine("2- Menú Asignaturas");
            Console.Write("\n Elija una opción: ");

            int subjectListOption = Convert.ToInt32("0" + Console.ReadLine());
            switch (subjectListOption)
            {
                case 2:
                    SubjectMenu();
                    break;
                default:
                    ListSubject();
                    break;
            }
        }
        static void ListSubjectRegister()
        {
            Console.Clear();
            SubjectsRegister.ListSubjectRegister();

            Console.WriteLine("\n\n ¿Qué desea hacer? \n");
            Console.WriteLine("1- Mantenerse en Lista");
            Console.WriteLine("2- Menú Registro Asignaturas");
            Console.Write("\n Elija una opción: ");

            int subjectRegisterListOption = Convert.ToInt32("0" + Console.ReadLine());
            switch (subjectRegisterListOption)
            {
                case 2:
                    SubjectRegisterMenu();
                    break;
                default:
                    ListSubjectRegister();
                    break;
            }
        }
        static void AddStudent()
        {
            int studentAddOption = 1;
            Console.Clear();

            while (studentAddOption == 1)
            {
                Students.AddStudent();
                SerializeStudents();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Agregar otro estudiante");
                Console.WriteLine("2- Menú Estudiantes");
                Console.Write("\n Elija una opción: ");
                studentAddOption = Convert.ToInt32("0" + Console.ReadLine());
                switch(studentAddOption)
                {
                    case 1:
                        AddStudent();
                        break;
                    default:
                        StudentMenu();
                        break;
                }
            }
        }
        static void AddSubject()
        {
            int subjectAddOption = 1;
            Console.Clear();

            while (subjectAddOption == 1)
            {
                Subjects.AddSubject();
                SerializeSubjects();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Agregar otra asignatura");
                Console.WriteLine("2- Menú Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectAddOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectAddOption)
                {
                    case 1:
                        AddSubject();
                        break;
                    default:
                        SubjectMenu();
                        break;
                }
            }
        }
        static void AddSubjectRegister()
        {
            int subjectRegisterAddOption = 1;
            Console.Clear();

            while (subjectRegisterAddOption == 1)
            {
                SubjectsRegister.AddSubjectRegister(Subjects);
                SerializeSubjectsRegister();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Agregar otro Registro de asignatura");
                Console.WriteLine("2- Menú Registro de Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectRegisterAddOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectRegisterAddOption)
                {
                    case 1:
                        AddSubjectRegister();
                        break;
                    default:
                        SubjectRegisterMenu();
                        break;
                }
            }
        }
        static void EditStudent()
        {
            int studentEditOption = 1;
            Console.Clear();

            while (studentEditOption == 1)
            {
                Students.EditStudent();
                SerializeStudents();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Editar otro estudiante");
                Console.WriteLine("2- Menú Estudiantes");
                Console.Write("\n Elija una opción: ");
                studentEditOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (studentEditOption)
                {
                    case 1:
                        EditStudent();
                        break;
                    default:
                        StudentMenu();
                        break;
                }
            }
        }
        static void EditSubject()
        {
            int subjectEditOption = 1;
            Console.Clear();

            while(subjectEditOption == 1)
            {
                Subjects.EditSubject();
                SerializeSubjects();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Editar otra asignatura");
                Console.WriteLine("2- Menú Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectEditOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectEditOption)
                {
                    case 1:
                        EditSubject();
                        break;
                    default:
                        SubjectMenu();
                        break;
                }
            }
        }
        static void EditSubjectRegister()
        {
            int subjectRegisterMenuOption = 0;
            Console.Clear();

            while (subjectRegisterMenuOption == 0)
            {
                Console.Clear();
                Console.WriteLine("\n ***********************************");
                Console.Write("\t Menú de Opciones");
                Console.WriteLine("\n ***********************************");
                Console.WriteLine(" 1- Listar Estudiantes ");
                Console.WriteLine(" 2- Agregar Estudiantes ");
                Console.WriteLine(" 3- Borrar Estudiantes ");
                Console.WriteLine(" 4- Menu Registros de Asignatura");
                Console.Write("\n Elija una opción: ");
                subjectRegisterMenuOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectRegisterMenuOption)
                {
                    case 1:
                        Console.Clear();
                        SubjectsRegister.ListStudentsFromSubjectRegister(Students);
                        Console.WriteLine("\n \n *Presione cualquier tecla para volver al menú* ");
                        Console.ReadKey();
                        EditSubjectRegister();
                        break;
                    case 2:
                        Console.Clear();
                        SubjectsRegister.AddStudentToRegister(Students);
                        SerializeSubjectsRegister();
                        Console.WriteLine("\n \n *Presione cualquier tecla para volver al menú* ");
                        Console.ReadKey();
                        EditSubjectRegister();
                        break;
                    case 3:
                        Console.Clear();
                        SubjectsRegister.DeleteStudentFromSubjectRegister(Students);
                        SerializeSubjectsRegister();
                        Console.WriteLine("\n \n *Presione cualquier tecla para volver al menú* ");
                        Console.ReadKey();
                        EditSubjectRegister();
                        break;
                    case 4:
                        Console.Clear();
                        SubjectRegisterMenu();
                        break;
                    default:
                        Console.Clear();
                        EditSubjectRegister();
                        break;
                }
            }
        }
        static void DeleteStudent()
        {
            int studentDeleteOption = 1;
            Console.Clear();
            while (studentDeleteOption == 1)
            {
                Students.DeleteStudent();
                SerializeStudents();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Eliminar otro estudiante");
                Console.WriteLine("2- Menú Estudiantes");
                Console.Write("\n Elija una opción: ");
                studentDeleteOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (studentDeleteOption)
                {
                    case 1:
                        DeleteStudent();
                        break;
                    default:
                        StudentMenu();
                        break;
                }
            }

        }
        static void DeleteSubject()
        {
            int subjectDeleteOption = 1;
            Console.Clear();

            while (subjectDeleteOption == 1)
            {
                Subjects.DeleteSubject();
                SerializeSubjects();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Eliminar otra asignatura");
                Console.WriteLine("2- Menú Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectDeleteOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectDeleteOption)
                {
                    case 1:
                        DeleteSubject();
                        break;
                    default:
                        SubjectMenu();
                        break;
                }
            }
        }
        static void DeleteSubjectRegister()
        {
            int subjectRegisterDeleteOption = 1;
            Console.Clear();

            while (subjectRegisterDeleteOption == 1)
            {
                SubjectsRegister.DeleteSubjectRegister();
                SerializeSubjectsRegister();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Eliminar otro Registro asignatura");
                Console.WriteLine("2- Menú Registro de Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectRegisterDeleteOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectRegisterDeleteOption)
                {
                    case 1:
                        DeleteSubjectRegister();
                        break;
                    default:
                        SubjectRegisterMenu();
                        break;
                }
            }
        }
        static void SearchStudent()
        {
            int studentSearchOption = 1;
            Console.Clear();
            while (studentSearchOption == 1)
            {
                Students.SearchStudent();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Buscar otro estudiante");
                Console.WriteLine("2- Menú Estudiantes");
                Console.Write("\n Elija una opción: ");
                studentSearchOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (studentSearchOption)
                {
                    case 1:
                        SearchStudent();
                        break;
                    default:
                        StudentMenu();
                        break;
                }
            }
        }
        static void SearchSubject()
        {
            int subjectSearchOption = 1;
            Console.Clear();

            while (subjectSearchOption == 1)
            {
                Subjects.SearchSubject();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Buscar otra asignatura");
                Console.WriteLine("2- Menú Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectSearchOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectSearchOption)
                {
                    case 1:
                        SearchSubject();
                        break;
                    default:
                        SubjectMenu();
                        break;
                }
            }
        }
        static void SearchSubjectRegister()
        {
            int subjectRegisterSearchOption = 1;
            Console.Clear();

            while (subjectRegisterSearchOption == 1)
            {
                SubjectsRegister.SearchSubjectRegister();

                Console.WriteLine("\n ¿Qué desea hacer? \n");
                Console.WriteLine("1- Buscar otro Registro de asignatura");
                Console.WriteLine("2- Menú Registro de Asignaturas");
                Console.Write("\n Elija una opción: ");
                subjectRegisterSearchOption = Convert.ToInt32("0" + Console.ReadLine());
                switch (subjectRegisterSearchOption)
                {
                    case 1:
                        SearchSubjectRegister();
                        break;
                    default:
                        SubjectRegisterMenu();
                        break;
                }
            }
        }
        static void DropDataBase()
        {
            int option = 0;
            Console.WriteLine("\n ¿Seguro que quiere eliminar la base de datos? \n");
            Console.WriteLine("1- Si");
            Console.WriteLine("2- No");
            Console.Write("Elije una opción: ");
            option = Convert.ToInt32("0" + Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    ClearRegisterObjects();
                    Console.WriteLine("\n **************************************************");
                    Console.Write("\t Base de datos borrada correctamente");
                    Console.WriteLine("\n **************************************************");
                    Console.ReadKey();
                    MainMenu();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        static void Exit()
        {
            int option = 0;
            Console.WriteLine("\n ¿Seguro que quiere salir del programa? \n");
            Console.WriteLine("1- Si");
            Console.WriteLine("2- No");
            Console.Write("Elije una opción: ");
            option = Convert.ToInt32("0" + Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n ***********************************");
                    Console.Write("\t Hasta Luego");
                    Console.WriteLine("\n ***********************************");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                default:
                    MainMenu();
                    break;
            }

        }
        static void Main()
        {
            Deserialize(); //Extrae datos de los archivos .bin correspondientes a 
                           //los objetos Students, Subjects y SubjectsRegister para iniciar el programa
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetWindowSize(135, 40);
            MainMenu();
        }
    }
}
