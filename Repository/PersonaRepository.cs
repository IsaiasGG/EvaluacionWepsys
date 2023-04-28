using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiPersona.Entities;

namespace WebApiPersona.Repository
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly ApiDbContext _dbContext;
        public PersonaRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GuardarPersona(persona modelPersona)
        {
            try
            {
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@Nombres", modelPersona.Nombres));
                parameter.Add(new SqlParameter("@Apellidos", modelPersona.Apellidos));
                parameter.Add(new SqlParameter("@Matricula", modelPersona.Matricula));
                parameter.Add(new SqlParameter("@FechaDeNacimiento", modelPersona.FechaDeNacimiento));
                parameter.Add(new SqlParameter("@UbicacionLatitud", modelPersona.UbicacionLatitud));
                parameter.Add(new SqlParameter("@UbicacionLongitud", modelPersona.UbicacionLongitud));
                parameter.Add(new SqlParameter("@UbicacionAltitud", modelPersona.UbicacionAltitud));
                var result = await Task.Run(() => _dbContext.Database
               .ExecuteSqlRawAsync(@"exec GuardarPersona @Nombres, @Apellidos, @Matricula, @FechaDeNacimiento, @UbicacionLatitud, @UbicacionLongitud, @UbicacionAltitud", parameter.ToArray()));
               
                return result;
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Se ha producido una excepción: {ex.Message}");

                return -1;
            }
        }
    }
}
