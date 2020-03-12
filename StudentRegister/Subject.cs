using System;
using System.Collections.Generic;

namespace Student_Register
{
    [Serializable()]
    class Subject
    {
        private int id;
        private string name, career, code;
        private static string mensajeFullList = "{0, -10}{1,-30}{2,-30}{3,-20}";

        //Metodos Get
        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public string Career { get { return this.career; } }
        public string Code { get { return this.code; } }
        public static string MensajeFullList { get { return Subject.mensajeFullList; } }
        
        //Metodos Get
        public void SetId(int newID)
        {
            this.id = newID;
        }
        public void SetName()
        {
            Console.Write("Nombre de asignatura: ");
            this.name = Console.ReadLine();
        }
        public void SetCareer()
        {
            Console.Write("Carrera de asignatura: ");
            this.career = Console.ReadLine();
        }
        public void SetCode()
        {
            Console.Write("Codigo de asignatura ");
            this.code = Console.ReadLine();
        }

        //Otros metodos
        public void SetAllAtributes(int newId)
        {
            this.SetId(newId);
            this.SetName();
            this.SetCareer();
            this.SetCode();
        }
        public void PrintAtributes()
        {
            Console.WriteLine("\t" + mensajeFullList, this.id, this.name, this.career, this.code);
        }
        public void SequencialSet(int atribute)
        {
            if (atribute == 0)
            {
                this.SetName();
            }
            if (atribute == 1)
            {
                this.SetCareer();
            }
            if (atribute == 2)
            {
                this.SetCode();
            }
        }
        public void SequencialGet(int atribute)
        {
            if (atribute == 0)
            {
                Console.Write("Nombre de asignatura: ");
                Console.Write(this.name);
            }
            if (atribute == 1)
            {
                Console.Write("Carrera de asignatura: ");
                Console.Write(this.career);
            }
            if (atribute == 2)
            {
                Console.Write("Codigo de asignatura: ");
                Console.Write(this.code);
            }

        }
    }
}
