using WebApiPersona.Entities;

namespace WebApiPersona.Repository
{
    public interface IPersonaRepository
    {
        Task<int> GuardarPersona(persona modelPersona);
    }
}
