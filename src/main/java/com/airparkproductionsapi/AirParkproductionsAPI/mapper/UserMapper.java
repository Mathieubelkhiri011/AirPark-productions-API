package com.airparkproductionsapi.AirParkproductionsAPI.mapper;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.user.UserDto;
import com.airparkproductionsapi.AirParkproductionsAPI.entity.User;
import org.mapstruct.Mapper;
import org.mapstruct.MappingConstants;

import java.util.List;

@Mapper(componentModel = MappingConstants.ComponentModel.SPRING)
public interface UserMapper {

    public UserDto toDto(User userEntity);

    public User toEntity(UserDto userDto);

    public List<UserDto> toDtos(List<User> users);

    public List<User> toEntities(List<UserDto> userDtos);
}
