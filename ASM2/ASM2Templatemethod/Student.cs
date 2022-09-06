namespace ASM2Templatemethod
{
    public class Student
    {   
        int count = 0;
        public string Name { get; set; }
        private int id;
        public int Id
        {
            get { return id; }
        }
        public int Grade { get; set; }
        public double Fee { get; set; }
        public bool ConfirmationStatus { get; set; }
        public Student(string name, double fee, bool confirmationStatus)
        {
            Name = name;
            id = ++count;
            Fee = fee;
            ConfirmationStatus = confirmationStatus;
        }
    }
}