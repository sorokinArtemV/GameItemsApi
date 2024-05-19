﻿using AutoMapper;
using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Armors.Commands.CreateArmorCommand;

namespace ItemsService.ItemsServiceApplication.Armors.DTO;

public class ArmorsProfile : Profile
{
    public ArmorsProfile()
    {
        // CreateArmorCommand to Armor
        CreateMap<CreateArmorCommand, Armor>()
            .ForMember(d => d.PrimaryStats, opt => opt.MapFrom(src => src.PrimaryStats))
            .ForMember(d => d.SecondaryStats, opt => opt.MapFrom(src => src.SecondaryStats))
            .ForMember(d => d.SpecialEffects, opt => opt.MapFrom(src => src.SpecialEffects));
        
        // Armor to ArmorDto
        CreateMap<Armor, ArmorDto>()
            .ForMember(dto => dto.PrimaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Armor, ArmorDto, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Armor, ArmorDto, SecondaryStats>(w => w.SecondaryStats!)));
    }
}