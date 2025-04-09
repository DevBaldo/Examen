using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CultureService : ICultureService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public CultureService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo= unidadDeTrabajo;
        }

        Culture Convertir (CultureDTO culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }
            else
            {
                return new Culture
                {
                    CultureId = culture.CultureId,
                    Name = culture.Name,
                    ModifiedDate = culture.ModifiedDate
                };
            }
                
        }
        CultureDTO Convertir(Culture culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }
            else
            {
                return new CultureDTO
                {
                    CultureId = culture.CultureId,
                    Name = culture.Name,
                    ModifiedDate = culture.ModifiedDate
                };
            }
        }

        public void AddCulture(CultureDTO culture)
        {

            var cultureEntity = Convertir(culture);

            _unidadDeTrabajo.CultureDAL.Add(cultureEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteCulture(string id)
        {
            var culture = new Culture { CultureId=id };
            _unidadDeTrabajo.CultureDAL.Remove(culture);
            _unidadDeTrabajo.Complete();
        }

        public List<CultureDTO> GetCultures()
        {
            var result = _unidadDeTrabajo.CultureDAL.GetAll();

            List<CultureDTO> cultures = new List<CultureDTO>();
            foreach (var item in result)
            {
                cultures
                    .Add(Convertir(item));
            }
            return cultures;
        }

        public void UpdateCulture(CultureDTO culture)
        {
            var cultureEntity = Convertir(culture);
            _unidadDeTrabajo.CultureDAL.Update(cultureEntity);
            _unidadDeTrabajo.Complete();
        }

        public CultureDTO GetCultureById(string id)
        {
            var result = _unidadDeTrabajo.CultureDAL.Get(id);
            return Convertir(result);

        }
    }
}
