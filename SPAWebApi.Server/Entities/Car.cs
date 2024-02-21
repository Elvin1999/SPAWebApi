namespace SPAWebApi.Server.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string ?Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public double EngineVolume { get; set; }
        public string? Color { get; set; }
        public int Distance { get; set; }
    }
}
