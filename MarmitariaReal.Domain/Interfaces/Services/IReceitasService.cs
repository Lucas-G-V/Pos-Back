
using MarmitariaReal.Domain.ViewModels;

namespace MarmitariaReal.Domain.Interfaces.Services
{
    public interface IReceitasService
    {
        Task<ReceitaViewModel> GetById(Guid id);
        Task<List<ReceitaViewModel>> GetAll();
        Task<int> Insert(ReceitaViewModel receitaViewModel);
        Task<int> Update(ReceitaEditViewModel receitaViewModel);
        Task<int> Delete(Guid id);
    }
}
