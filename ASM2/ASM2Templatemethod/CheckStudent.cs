namespace ASM2Templatemethod
{
    public abstract class CheckStudent 
    {
        public const double FEE = 1000000;
        public bool Check(Student student)
        {
            bool result = checkIn(student);
            if (result == false)
            {
                Payfee(student, result);
                return false;
            }            
            else
            {   
                Payfee(student, result);
                return true;
            }
        }       
        protected bool checkIn(Student student)
        {
            if (student.ConfirmationStatus==true)
            {
                Console.WriteLine("Student is poor student");
                return true;
            }
            else
            {   
                Console.WriteLine("Student is simple student");
                return false;
            }
        }
        protected abstract void Payfee(Student student, bool result);
    }
}