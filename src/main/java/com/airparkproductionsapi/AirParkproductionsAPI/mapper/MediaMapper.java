package com.airparkproductionsapi.AirParkproductionsAPI.mapper;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.media.MediaDto;
import com.airparkproductionsapi.AirParkproductionsAPI.entity.Media;
import org.mapstruct.Mapper;
import org.mapstruct.MappingConstants;

import java.util.List;

@Mapper(componentModel = MappingConstants.ComponentModel.SPRING)
public interface MediaMapper {

    public MediaDto toDto(Media mediaEntity);

    public Media toEntity(MediaDto mediaDto);

    public List<MediaDto> toDtos(List<Media> mediasEntities);

    public List<Media> toEntities(List<MediaDto> mediaDtos);
}
