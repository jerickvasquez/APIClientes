using APIClientes.Modelo;
using APIClientes.Modelo.DTo;
using AutoMapper;

namespace APIClientes
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            { 
                //Se encarga del mapeo de las clases ClienteDTo y Cliente
                config.CreateMap<ClienteDTo, Cliente> ();
                config.CreateMap<Cliente, ClienteDTo>();
            });
            return mappingConfig;
        }
    }
}
