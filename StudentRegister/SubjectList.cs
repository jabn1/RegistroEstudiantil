using System;
using System.Collections.Generic;

namespace Student_Register
{
    [Serializable()]
    class SubjectList
    {
        private List<Subject> subjects = new List<Subject>();
        private int lastId = 0;

        public List<int> GetIdList()
        {
            var idList = new List<int>();
            foreach (var element in subjects)
            {
                idList.Add(element.Id);
            }
            return idList;
        }

        private bool SubjectHeaderAtributes()
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No posee datos actualmente");
                Console.WriteLine("\n ******************************************");
                return false;
            }
            else
            {
                Console.WriteLine("\n" + "\t" + Subject.MensajeFullList, "ID:", "Nombre de asignatura:", "Carrera de asignatura:", "Codigo de asignatura" + "\n");
                foreach (var subject in subjects)
                {
                    subject.PrintAtributes();
                }
                return true;
            }
            
        }
        public void ListSubjects()
        {
            if (SubjectHeaderAtributes())
            {
                return;
            }
        }
        public int getCount()
        {
            return this.subjects.Count;
        }
        public void DeleteSubject()
        {
            if(SubjectHeaderAtributes())
            {
                Console.Write("\n Escriba el ID de la asignatura que desea eliminar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine()); ;
                foreach (var subject in subjects)
                {
                    if (subject.Id == id)
                    {
                        subjects.Remove(subject);
                        break;
                    }
                }
            }
        }

        public void AddSubject()
        {
            Subject newSubject = new Subject();
            Console.WriteLine("\n Ingrese los datos de la asignatura \n");
            newSubject.SetAllAtributes(lastId + 1);
            subjects.Add(newSubject);
            lastId++;
        }
        public Subject SearchAndReturn(int id)
        {
            foreach (var subject in this.subjects)
            {
                if(subject.Id == id)
                {
                    return subject;
                }             
            }
            return null;
        }
        public void SearchSubject()
        {
            Console.WriteLine("\n ¿Por qué opción desea buscar? \n");
            Console.WriteLine("1- Por Nombre");
            Console.WriteLine("2- Por Carrera");
            Console.Write("Elija una opción: ");
            int sOpt = Convert.ToInt32("0" + Console.ReadLine());
            Console.Write("Digite el valor de busqueda: ");
            string searchValue = Console.ReadLine();
            SubjectList searchResults = new SubjectList();
            foreach (var subject in subjects)
            {
                switch (sOpt)
                {
                    case 1:
                        if (subject.Name.Contains(searchValue))
                        {
                            searchResults.subjects.Add(subject);
                        }
                        break;
                    case 2:
                        if (subject.Career.Contains(searchValue))
                        {
                            searchResults.subjects.Add(subject);
                        }
                        break;
                }
            }
            if (searchResults.subjects.Count == 0)
            {
                Console.WriteLine("\n ******************************************");
                Console.Write("\t No se encontraron registros");
                Console.WriteLine("\n ******************************************");
            }
            else
            {
                searchResults.ListSubjects();
            }
        }
        public void EditSubject()
        {
            if (this.SubjectHeaderAtributes())
            {
                Console.Write("\n Escriba el ID de la asignatura que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());

                Console.WriteLine("\n Ingrese los nuevos datos de la asignatura \n");
                foreach (var subject in subjects)
                {
                    if (subject.Id == id)
                    {
                        subject.SetAllAtributes(id);
                        break;
                    }
                }
            }
        }
        public void EditSubjectByField()
        {
            if (this.SubjectHeaderAtributes())
            {
                Console.Write("\n Escriba el ID de la asignatura que desea editar: ");
                int id = Convert.ToInt32("0" + Console.ReadLine());

                Console.WriteLine("\n Ingrese los nuevos datos de la asignatura \n");
                foreach (var subject in subjects)
                {
                    if (subject.Id == id)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            subject.SequencialGet(i);
                            Console.Write("     [1] Conservar valor   [2] Modificar valor   Elija una opcion: ");
                            int opcionModifcar = Convert.ToInt32(Console.ReadLine());
                            if (opcionModifcar == 1) { continue; }
                            else if (opcionModifcar == 2)
                            {
                                subject.SequencialSet(i);
                            }
                        }
                        break;
                    }
                }
            }
        }
        
    }
}
