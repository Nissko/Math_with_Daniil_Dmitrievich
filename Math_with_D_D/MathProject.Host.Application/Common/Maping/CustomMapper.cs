using AutoMapper;
using MathProject.Host.Application.Common.Interfaces;

namespace MathProject.Host.Application.Common.Maping;

public class CustomMapper : ICustomMapper
{
    //TODO:Зарегистировать свой кастомный маппер
    //private readonly CpuMapperProfile _cpuMapperProfile;
    private readonly IMapper _autoMapper;
        
    public CustomMapper(IMapper autoMapper)
    {
        _autoMapper = autoMapper;
        //_cpuMapperProfile = new CpuMapperProfile();
    }

    //public CpuMapperProfile CpuMapperProfile => _cpuMapperProfile;
    public IMapper AutoMapper => _autoMapper;
}