using FrameworkVsLibrary.Constants;

namespace FrameworkVsLibrary.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.CustomerTypes CusomterType { get; set; }
        public Address Address { get; set; } 
    }


}
