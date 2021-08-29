namespace T4i_WebAPI.model
{
    public class ProjetosWorks
    {
        public ProjetosWorks()
        {

        }
        public ProjetosWorks(Projeto projeto, int worksId)
        {
            this.projetoId = projetoId;    
            this.worksId = worksId;          
        }
        public int projetoId { get; set; }
        public Projeto projeto { get; set; }

        public int worksId { get; set; }
        public Works works { get; set; }


    }
}