using System.Collections.Generic;

namespace T4i_WebAPI.model
{
    public class Works
    {
        public Works() { }

        public Works(int id, int devid)
        {
            this.id = id;
            this.devid = devid;
        }

        public int id { get; set; }

        public int devid { get; set; }

        public Dev dev { get; set; }

        public IEnumerable<ProjetosWorks> projetoWorks { get; set; }
    }
}