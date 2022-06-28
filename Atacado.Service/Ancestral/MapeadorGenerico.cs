using AutoMapper;

namespace Atacado.Service.Ancestral
{
    public class MapeadorGenerico <TPoco, TDom> 
        where TPoco : class 
        where TDom : class
    {
        private IMapper mecanismo;

        public IMapper Mecanismo
        {
            get
            {
                if(this.mecanismo == null)
                {
                        var configuration = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<TDom, TPoco>();


                            cfg.CreateMap<TPoco, TDom>();

                        });
                    this.mecanismo = configuration.CreateMapper();
                        
                }
                return this.mecanismo;

            }
        }
        public MapeadorGenerico()
        { }
    }
}
