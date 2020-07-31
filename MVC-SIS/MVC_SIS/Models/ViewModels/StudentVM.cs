namespace Exercises.Models.ViewModels
{
    public class StudentVM
    {
        public AddStudentVM AddStudentVM { get; set; }
        public AddAddressVM AddAddressVM { get; set; }

        public StudentVM()
        {
            AddStudentVM = new AddStudentVM();
            AddAddressVM = new AddAddressVM();
        }
    }
}