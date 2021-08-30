using System.Collections.Generic;

namespace T4i_WebAPI.model
{
    public class Dev
    {
        public Dev()
        {
            
        }
        public Dev(int id, string name, string position)
        {
            this.id = id;
            this.name = name;
            this.position = position;

        }
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }

        public IEnumerable<Works> works {get; set;}
    }
}
