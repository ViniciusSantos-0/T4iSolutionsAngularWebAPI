namespace T4i_WebAPI.model
{
    public class Projeto
    {
        public Projeto()
        {
            
        }
        public Projeto(int myProperty, int id, string description)
        {        
            this.id = id;
            this.description = description;

        }
        public int id { get; set; }
        public string description { get; set; }
    }
}
