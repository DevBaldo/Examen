using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICultureService
    {

        void AddCulture(CultureDTO Culture);
        void UpdateCulture(CultureDTO Culture);
        void DeleteCulture(string id);
        List<CultureDTO> GetCultures();
        CultureDTO GetCultureById(string id);
    }
}
