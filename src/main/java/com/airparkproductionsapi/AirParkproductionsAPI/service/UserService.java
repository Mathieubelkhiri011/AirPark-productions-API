package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.user.UserDto;
import com.airparkproductionsapi.AirParkproductionsAPI.mapper.UserMapper;

import java.util.List;

public interface UserService {

    public List<UserDto> getAllUsers();

    public UserDto getUserByEmail(String email);

    public UserDto getUserById(Long id);

    public UserDto create(UserDto userDto);

    public UserDto update(Long id, UserDto userDto);

    public void deleteByEmail(String email);

    public void deleteById(Long id);
}
