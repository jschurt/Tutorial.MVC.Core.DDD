﻿using AutoMapper;

namespace Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {

        public static MapperConfiguration RegisterMappings()
        {

            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());
            });

        } //RegisterMappings

    } //class
} //namespace
