namespace ASM2Templatemethod
{
    public class SimpleStudent : CheckStudent
    {
        protected override void Payfee(Student student, bool result)
        {
            if (result==false)
            {   
                Console.WriteLine("Student pay standard fee");
            }
            else
            {
                student.Fee = student.Fee - (student.Fee*0.9);
                Console.WriteLine("Student has to pay 10% of fee");
            }
        }
    }
}