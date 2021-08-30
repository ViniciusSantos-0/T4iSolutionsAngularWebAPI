using System.Collections.Generic;

namespace T4i_WebAPI.model
{
    public class Works
    {   
        public Works()
        {
            
        }
        public Works(int id, int idDev)
        {
            this.id = id;
            this.idDev = idDev;
        }
        public int id { get; set; }

        public int idDev { get; set; }

        public Dev dev { get; set; }

        public IEnumerable<ProjetosWorks> projetoWorks {get; set;}
    }
}