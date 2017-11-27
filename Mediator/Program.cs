using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher bilal = new Teacher(mediator);
            bilal.Name = "Bilal";

            mediator.Teacher = bilal;

            Student ogrenci1 = new Student(mediator);
            ogrenci1.Name = "Fırat";

            Student ogrenci2 = new Student(mediator);
            ogrenci2.Name = "Veysel";

            mediator.Students = new List<Student>{ogrenci1, ogrenci2};

            bilal.SendImageUrl("slide1.jpg");

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
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void ReciveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recived a question from {0}, {1}", student.Name, question);
        }


        public void SendImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            //mediatore resim url gönderdiğimde mediator tüm öğrencilere gönderecektir.
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {


        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }



        public void ReciveImage(string url)
        {
            Console.WriteLine("{0} Student recived image: {1}", Name,url);
        }



        public void ReciveAnswer(string answer)
        {
            Console.WriteLine("Student recived answer: {0}", answer);

        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }


        public void UpdateImage(string url)
        {// öğretmenin gönderdiği image url tüm öğrencilere gönder
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }

        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReciveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReciveAnswer(answer);
        }
    }
}
