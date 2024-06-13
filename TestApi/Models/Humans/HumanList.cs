namespace TestApi.Models.Humans
{
    public class HumanList
    {
        public static Human[] Humans { get; } = new Human[]
        {
            new Human { Id = Guid.NewGuid(), Name = "Alvaro",Sex = SexEnum.Male,Age = 24,Height=1.65m ,Weight = 90.0m},
            new Human { Id = Guid.NewGuid(), Name = "Daniel" ,Sex = SexEnum.Male,Age = 20,Height=1.70m ,Weight = 85.0m},
            new Human { Id = Guid.NewGuid(), Name = "Ezequiel",Sex = SexEnum.Male,Age = 21,Height=1.72m ,Weight = 70.0m },
            new Human { Id = Guid.NewGuid(), Name = "María",Sex = SexEnum.Female,Age = 19,Height=1.55m ,Weight = 60.0m }
        };
    }
}
