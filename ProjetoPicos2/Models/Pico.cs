namespace ProjetoPicos2.Models
{
    public class Pico
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TipoPico Type { get; set; }
        public double Rate { get; set; }
        public Accessibility AccsessType { get; set; }
        //Use google loc api's
        public string Localization { get; set; }
        //Weather Api 
        public bool Active { get; set; }
    }
}