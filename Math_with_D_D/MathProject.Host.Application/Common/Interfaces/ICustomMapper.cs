using AutoMapper;

namespace MathProject.Host.Application.Common.Interfaces;

public interface ICustomMapper
{
    //TODO:Добавить свой кастомный маппер профиль
    //CpuMapperProfile CpuMapperProfile { get; }
    IMapper AutoMapper { get; }
}