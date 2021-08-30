using System.Collections.Generic;

namespace T4i_WebAPI.model
{
    public class Projeto
    {
        public Projeto()
        {

        }
        public Projeto(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;

        }
        public int id { get; set; }

        public string name { get; set; }
        public string description { get; set; }

       public IEnumerable<ProjetosWorks> projetoWorks {get; set;}
    }
}
