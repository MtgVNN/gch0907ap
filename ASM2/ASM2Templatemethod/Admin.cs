using System;
using System.Collections.Generic;

namespace ASM2Templatemethod
{
    public class Admin
    {
        private const int ADD_STUDENT = 1;
        private const int REMOVE_STUDENT = 2;
        private const int PRINT_ALL = 3;
        private const int EXIT = 0;
        private const int POOR_STUDENT = 1;
        private const int SIMPLE_STUDENT = 2;
        private List<Student> poor_students;
        private List<Student> simple_students;
        CheckStudent checking; // tao doi tuong checking cua lop CheckStudent, define hoac declare 
        public Admin()
        {
            poor_students = new List<Student>();
            simple_students = new List<Student>();
        }
        private void printMenu()
        {   
            Console.WriteLine("1. Add new student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. PrintAll");
            Console.WriteLine("0. Exit");
        }
        private int GetChoice()
        {
            
            Console.Write("Enter your task: ");
            bool invalidChoice = true;
            int choice = 0;
            while (invalidChoice)
            {
                choice = int.Parse(Console.ReadLine());
                invalidChoice = choice < 0 || choice > 3;
                if (invalidChoice)
                {
                    Console.Write("Invalid choice. Please choose again: ");
                }
            }
            return choice;
        }
        
        public void Run()
        {   
            bool running = true;
            while (running)
            {
                printMenu();
                int choice = GetChoice();   
                DoTask(choice);
                running = choice != EXIT;             
            }
        }
        private void DoTask(int choice)
        {
            switch (choice)
            {
                case ADD_STUDENT:AddStudent(); break;
                case REMOVE_STUDENT:RemoveStudent(); break;
                case PRINT_ALL: PrintAll(); break;
                case EXIT: Console.WriteLine("Exit"); break;
            }
        }
        private void AddStudent()
        {   
            Console.WriteLine("Which type of student do you want to add?");
            Console.WriteLine("1. Poor student");
            Console.WriteLine("2. Simple student");
            int type = int.Parse(Console.ReadLine());
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student fee: ");
            double fee = double.Parse(Console.ReadLine());
            Console.Write("Enter student confirmation status: ");
            bool confirmationStatus = bool.Parse(Console.ReadLine());
            Student student = new Student(name, fee, confirmationStatus);
            if(type == POOR_STUDENT)
            {
                checking = new PoorStudent(); 
            }
            else if (type == SIMPLE_STUDENT)
            {
                checking = new SimpleStudent(); // khoi tao voi constructure cua SimpleStudent (DynamicTyping)
            }
            bool result = checking.Check(student);
            if(result == true)
            {
                Console.WriteLine("Poor student, your fee is {0}", student.Fee);
                poor_students.Add(student);
            }
            else
            {
                Console.WriteLine("Simple student, your fee is {0}", student.Fee);
                simple_students.Add(student);
            }
        }
        private void RemoveStudent()
        {
            if (CheckNumber() == true)
            {
                return;
            }
            Console.WriteLine("Which type of student do you want to remove?");
            Console.WriteLine("1. Poor student");
            Console.WriteLine("2. Simple student");
            int type = int.Parse(Console.ReadLine());
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            bool found = false;
            if(type == POOR_STUDENT)
            {
                for(int i = 0; i < poor_students.Count; i++)
                {
                    if(poor_students[i].Name.Equals(name))
                    {
                        found = true;
                        poor_students.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (type == SIMPLE_STUDENT)
            {
                for(int i = 0; i < simple_students.Count; i++)
                {
                    if(simple_students[i].Name.Equals(name))
                    {
                        found = true;
                        simple_students.RemoveAt(i);
                        break;
                    }
                }
            }
            if(found == true)
            {
                Console.WriteLine("Remove student successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
        private void PrintAll()
        {
            if (CheckNumber() == true)
            {
                return;
            }
            Console.WriteLine("Poor students: ");
            foreach(Student student in poor_students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Id);
                Console.WriteLine(student.Fee);
                Console.WriteLine("Poor student");
            }
            Console.WriteLine("Simple students: ");
            foreach(Student student in simple_students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Id);
                Console.WriteLine(student.Fee);
                Console.WriteLine("Simple student");
            }
        }
        private bool CheckNumber()
        {
            if(poor_students.Count == 0 && simple_students.Count == 0)
            {
                Console.WriteLine("No student yet");
                return true;
            }
            return false;
        }
    }
}