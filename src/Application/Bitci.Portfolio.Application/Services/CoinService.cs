using AutoMapper;
using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Common.Interfaces;
using Bitci.Portfolio.Application.Common.Repositories;

namespace Bitci.Portfolio.Application.Services
{
    public class CoinService : ICoinService
    {
        private readonly ICoinRepository _coinRepository;
        private IMapper _mapper;
        public CoinService(ICoinRepository coinRepository, IMapper mapper)
        {
            _coinRepository = coinRepository;
            _mapper = mapper;
        }
        public Task Add(CoinDto coin)
        {
            _coinRepository.Add(_mapper.Map<CoinDto, Bitci.Portfolio.Domain.Entities.Coin>(coin));
            return Task.CompletedTask;
        }

        public async Task<CoinDto[]> GetCoinsByUserId(string userId)
        {
            var coins = await _coinRepository.GetCoinsByUserId(userId);
            return _mapper.Map<Bitci.Portfolio.Domain.Entities.Coin[], CoinDto[]>(coins);
        }
    }
}
