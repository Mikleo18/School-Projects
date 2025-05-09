using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher rifat = new Teacher(mediator);
            rifat.Name = "Rıdvan";

            mediator.Teacher = rifat;

            Student student = new Student(mediator);
            student.Name = "ZenciMusa";

            Student student2 = new Student(mediator);
            student.Name = "Nejat İşler";

            mediator.Students = new List<Student> {student,student2};

            rifat.SendNewImageUrl("Nig,jpg");
            rifat.RecieveQuestion("is it true",student);

            Console.ReadLine();



        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator):base(mediator)
        {

        }
        internal void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher Recieved a Question From {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(String url)
        {
            Console.WriteLine("Teacher Changed Slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher Answered {0},{1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public String Name { get; set; }
        public Student(Mediator mediator) : base(mediator)
        {

        }

        internal void RecieveImage(string url)
        {
            Console.WriteLine("{1} Received image : {0}",url,Name);
        }

        internal void ReceiveAnswer(string answer)
        {
            Console.WriteLine("{1} Received answer {0}",answer,Name);
        }

        
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(String question, Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(String answer,Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
