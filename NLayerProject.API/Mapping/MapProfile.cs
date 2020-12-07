﻿using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;

namespace NLayerProject.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
        
    }
}