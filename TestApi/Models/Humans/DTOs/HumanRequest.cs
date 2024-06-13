using TestApi.Models.Humans;

namespace TestApi.Models.Humans.DTOs
{
    public class HumanRequest
    {
        public string Name { get; set; }
        public SexEnum Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
