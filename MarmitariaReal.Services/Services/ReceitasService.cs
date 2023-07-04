using AutoMapper;
using MarmitariaReal.Domain.Configuration;
using MarmitariaReal.Domain.Entities;
using MarmitariaReal.Domain.Interfaces.Repositories;
using MarmitariaReal.Domain.Interfaces.Services;
using MarmitariaReal.Domain.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MarmitariaReal.Services.Services
{
    public class ReceitasService : IReceitasService
    {
        private readonly IReceitasRepository _receitasRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorageRepository _azureBlobStorageRepository;
        private readonly AppSettings _appSettings;

        public ReceitasService(IReceitasRepository receitasRepository, IMapper mapper, IAzureBlobStorageRepository azureBlobStorageRepository,
            AppSettings appSettings)
        {
            _receitasRepository = receitasRepository;
            _azureBlobStorageRepository = azureBlobStorageRepository;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        public async Task<int> Delete(Guid id)
        {
            var file = await _receitasRepository.GetById(id);
            await _azureBlobStorageRepository.DeleteBlobFromUri(file.UrlImagem);
            return await _receitasRepository.Delete(id);
        }

        public async Task<int> Insert(ReceitaViewModel receitaViewModel)
        {
            receitaViewModel.UrlImagem = await UploadImagem(receitaViewModel.Imagens);
            return await _receitasRepository.Insert(_mapper.Map<Receita>(receitaViewModel));
        }

        public async Task<int> Update(ReceitaEditViewModel receitaViewModel)
        {
            if(receitaViewModel.Imagens != null)
            {
                var file = await _receitasRepository.GetById(receitaViewModel.ReceitaId);
                await _azureBlobStorageRepository.DeleteBlobFromUri(file.UrlImagem);
                receitaViewModel.UrlImagem = await UploadImagem(receitaViewModel.Imagens);
            }
            else
            {
                receitaViewModel.UrlImagem = (await _receitasRepository.GetById(receitaViewModel.ReceitaId)).UrlImagem;
            }
            return await _receitasRepository.Update(_mapper.Map<Receita>(receitaViewModel));
        }

        private async Task<string> UploadImagem(IFormFile Imagens)
        {
            using var stream = Imagens.OpenReadStream();
            var fileName = Guid.NewGuid().ToString() + "_" + Imagens.FileName;
            return await _azureBlobStorageRepository.UploadFileToStorage(stream, fileName, _appSettings.AzureStorageBlobOptions.ContainerReceitas);
        }

        public async Task<List<ReceitaViewModel>> GetAll()
        {
            var result = await _receitasRepository.GetAll();
            return result.Select(a => _mapper.Map<ReceitaViewModel>(a)).ToList();
        }

        public async Task<ReceitaViewModel> GetById(Guid id)
        {
            return _mapper.Map<ReceitaViewModel>(await _receitasRepository.GetById(id));
        }
    }
}
