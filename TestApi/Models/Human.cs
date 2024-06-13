namespace TestApi.Models
{
    public class Human
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SexEnum Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; } 
        public decimal Weight { get; set; }  
    }
}
