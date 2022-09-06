namespace ASM2Templatemethod
{
    public class PoorStudent : CheckStudent
    {
        protected override void Payfee(Student student, bool result)
        {
            if (result==true)
            {   
                student.Fee = student.Fee - (student.Fee*0.9);
                Console.WriteLine("Student has to pay 10% of fee");
            }
            else
            {
                Console.WriteLine("Student pay standard fee");
            }
        }
    }
}