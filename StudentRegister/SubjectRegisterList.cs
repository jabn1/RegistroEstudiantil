using System;
using System.Collections.Generic;

namespace Student_Register
{
    [Serializable()]
    class SubjectRegisterList
    {
        private List<SubjectRegister> subjectRegisters = new List<SubjectRegister>();
        private int lastId = 0;

        public List<int> GetIdList()
        {
            var idList = new List<int>();
            foreach (var element in subjectRegisters)
            {
                idList.Add(element.Id);
            }
            return idList;
        }

        public SubjectRegister SearchAndReturnSubjectRegisterForReport()
        {
            Console.WriteLine("\n Elegir Registro de Asignaturas \n");
            if (subjectRegisters.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos ");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                Console.WriteLine("\n" + "\t" + SubjectRegister.ShortFormat, "ID:", "Asignatura:", "Profesor:", "Cantidad de estudiantes:" + "\n");
                foreach (var subjectRegister in subjectRegisters)
                {
                    subjectRegister.PrintAtributesShortFormat();
                }

                Console.Write("\n Escriba el ID del registro para generar reporte: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var register in subjectRegisters)
                {
                    if (register.Id == id)
                    {
                        return register;
                    }
                }
            }
            return null;
        }
        private bool SubjectRegisterHeaderAtributes()
        {
            if (subjectRegisters.Count == 0)
            {
                Console.WriteLine("\n ********************************************************************");
                Console.Write("\t No posee datos de registro de asignatura actualmente");
                Console.WriteLine("\n ********************************************************************");
                return false;
            }
            else
            {
                Console.WriteLine("\n" + "\t" + SubjectRegister.ShortFormat, "ID:", "Asignatura:", "Profesor:", "Cantidad de estudiantes:" + "\n");
                foreach (var subjectRegister in subjectRegisters)
                {
                    subjectRegister.PrintAtributesShortFormat();
                }
                return true;
            }
        }
        public void AddSubjectRegister(SubjectList aSubjectList)
        {
            if (aSubjectList.getCount() == 0)
            {
                Console.WriteLine("\n ************************************************************************");
                Console.WriteLine("\t Para utilizar esta opcion debe agregar asignaturas.");
                Console.WriteLine("\n ************************************************************************");
            }
            else
            {
                var newSubjectRegister = new SubjectRegister();

                Console.WriteLine("\n Agregar registro de asignatura \n");
                Console.WriteLine("\t Asignaturas disponibles para creacion de registro de asignatura: \n");
                aSubjectList.ListSubjects();
                Console.Write("\n \n Escriba el ID de la asignatura con que desea crear nuevo registro de asignatura: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                if (aSubjectList.GetIdList().Contains(id))
                {
                    newSubjectRegister.SetSubject(aSubjectList.SearchAndReturn(id));

                    newSubjectRegister.SetAtributes(lastId + 1);
                    lastId++;

                    this.subjectRegisters.Add(newSubjectRegister);
                }
                else
                {
                    Console.WriteLine("Id invalido.");
                }
            }
        }

        public void AddStudentToRegister(StudentList aStudentList)
        {
            if (aStudentList.getCount() == 0)
            {
                Console.WriteLine("\n *********************************************************");
                Console.WriteLine("\t No hay datos de estudiante.");
                Console.WriteLine("\n *********************************************************");
                
            }
            else if (this.SubjectRegisterHeaderAtributes())
            {
                Console.Write("\n Escriba el ID del registro de asignatura que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var subjectRegister in subjectRegisters)
                {
                    if (subjectRegister.Id == id)
                    {
                        Console.WriteLine("\n Agregar estudiante a registro de asignatura \n");
                        Console.WriteLine("\t Estudiantes disponibles para agregar a registro de asignatura: \n");
                        aStudentList.PrintListIdNameCareer();
                        Console.Write("\n Escriba el ID del estudiante que desea agregar al registro de asignatura: ");
                        int idEst = Convert.ToInt32("0" + Console.ReadLine());
                        if (aStudentList.GetIdList().Contains(idEst))
                        {
                            subjectRegister.AddStudentToSubjectRegister(aStudentList.SearchAndReturn(idEst));
                        }
                        break;
                    }
                }
            }

        }
        public void DeleteStudentFromSubjectRegister(StudentList aStudentList)
        {
            if (aStudentList.getCount() == 0)
            {
                Console.WriteLine("\n *********************************************************");
                Console.WriteLine("\t No hay datos de estudiante.");
                Console.WriteLine("\n *********************************************************");
                return;
            }
            else if (this.SubjectRegisterHeaderAtributes())
            {
                Console.Write("\n Escriba el ID del registro de asignatura que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var subjectRegister in subjectRegisters)
                {
                    if (subjectRegister.Id == id)
                    {
                        subjectRegister.DeleteStudentFromRegister();
                        return;
                    }
                }
            }
        }
        public void DeleteSubjectRegister()
        {
            Console.WriteLine("\n Eliminar Registro de Asignaturas \n");
            if (subjectRegisters.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos para borrar");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                Console.WriteLine("\n" + "\t" + SubjectRegister.ShortFormat, "ID:", "Asignatura:", "Profesor:", "Cantidad de estudiantes:" + "\n");
                foreach (var subjectRegister in subjectRegisters)
                {
                    subjectRegister.PrintAtributesShortFormat();
                }

                Console.Write("\n Escriba el ID del registro que desea eliminar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var registers in subjectRegisters)
                {
                    if (registers.Id == id)
                    {
                        subjectRegisters.Remove(registers);
                        break;
                    }
                }
            }
        }
        public void ListStudentsFromSubjectRegister(StudentList aStudentList)
        {
            if (aStudentList.getCount() == 0)
            {
                Console.WriteLine("\n *********************************************************");
                Console.WriteLine("\t No hay datos de estudiante.");
                Console.WriteLine("\n *********************************************************");
                return;
            }
            else if (this.SubjectRegisterHeaderAtributes())
            {
                Console.Write("\n Escriba el ID del registro de asignatura que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());
                foreach (var subjectRegister in subjectRegisters)
                {
                    if (subjectRegister.Id == id)
                    {
                        subjectRegister.ListStudentsFromRegister();
                        return;
                    }
                }
            }
        }
        public void ListSubjectRegister()
        {
            if (subjectRegisters.Count == 0)
            {
                Console.WriteLine("\n ********************************************************************");
                Console.Write("\t No posee datos de registro de asignatura actualmente");
                Console.WriteLine("\n ********************************************************************");
            }
            else
            {
                Console.WriteLine("\n" + "\t" + SubjectRegister.LongFormat, "ID:", "Asignatura:", "Profesor:", "Cantidad de estudiantes:", "Fecha de Inicio:", "Fecha Finalización:", "Aula:" + "\n");
                foreach (var subjectRegister in subjectRegisters)
                {
                    subjectRegister.PrintAtributesLongFormat();
                }
            }
        }
        public void SearchSubjectRegister()
        {
            Console.WriteLine("\n ¿Por qué opción desea buscar? \n");
            Console.WriteLine("1- Por ID");
            Console.WriteLine("2- Por Asignatura");
            Console.WriteLine("3- Por Profesor");
            Console.Write("Elija una opción: ");
            int sOpt = Convert.ToInt32("0" + Console.ReadLine());
            Console.Write("Digite el valor de busqueda: ");
            string searchValue = Console.ReadLine();
            bool flagSearch = true;
            bool flagHeader = true;
            for (var s = 0; s < subjectRegisters.Count; s++)
            {
                switch (sOpt)
                {
                    case 1:
                        if (Convert.ToString(subjectRegisters[s].Id).Contains(searchValue))
                        {
                            flagSearch = false;
                            string mensaje = "{0,-10}{1,-20}{2,-20}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Asignatura:", "Profesor:" + "\n");
                                flagHeader = false;
                            }
                            Console.WriteLine("\t" + mensaje, subjectRegisters[s].Id, subjectRegisters[s].Subject, subjectRegisters[s].Professor);
                        }
                        break;
                    case 2:
                        if (subjectRegisters[s].Subject.Contains(searchValue))
                        {

                            flagSearch = false;
                            string mensaje = "{0,-10}{1,-20}{2,-20}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Asignatura:", "Profesor:" + "\n");
                                flagHeader = false;
                            }
                            Console.WriteLine("\t" + mensaje, subjectRegisters[s].Id, subjectRegisters[s].Subject, subjectRegisters[s].Professor);
                        }
                        break;
                    case 3:
                        if (subjectRegisters[s].Professor.Contains(searchValue))
                        {

                            flagSearch = false;
                            string mensaje = "{0,-10}{1,-20}{2,-20}";
                            if (flagHeader)
                            {
                                Console.WriteLine("\n" + "\t" + mensaje, "ID:", "Asignatura:", "Profesor:" + "\n");
                                flagHeader = false;
                            }
                            Console.WriteLine("\t" + mensaje, subjectRegisters[s].Id, subjectRegisters[s].Subject, subjectRegisters[s].Professor);
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
    }
}
