package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.user.UserDto;
import com.airparkproductionsapi.AirParkproductionsAPI.entity.User;
import com.airparkproductionsapi.AirParkproductionsAPI.mapper.UserMapper;
import com.airparkproductionsapi.AirParkproductionsAPI.repository.UserRepository;
import com.airparkproductionsapi.AirParkproductionsAPI.service.UserService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImpl implements UserService {

    private final UserRepository userRepository;

    private final UserMapper userMapper;

    public UserServiceImpl(UserRepository userRepository, UserMapper userMapper) {
        this.userRepository = userRepository;
        this.userMapper = userMapper;
    }

    @Override
    public List<UserDto> getAllUsers() {
        return this.userMapper.toDtos(this.userRepository.findAll());
    }

    @Override
    public UserDto getUserByEmail(String email) {
        return this.userMapper.toDto(
                this.userRepository.findByEmail(email)
        );
    }

    @Override
    public UserDto getUserById(Long id) {
        return this.userRepository.findById(id)
                .map(userMapper::toDto)
                .orElseThrow(() -> new RuntimeException("User " + id + " not found !"));
    }

    @Override
    public UserDto create(UserDto userDto) {
        User userEntity = userMapper.toEntity(userDto);
        userEntity = userRepository.saveAndFlush(userEntity);
        return userMapper.toDto(userEntity);
    }

    @Override
    public UserDto update(Long id, UserDto userDto) {
        return userRepository.findById(id)
                .map(userEntity -> {
                    userEntity.setEmail(userDto.getEmail());
                    userEntity.setPassword(userDto.getPassword());
                    userEntity.setPseudo(userDto.getPseudo());
                    userRepository.save(userEntity);
                    return userEntity;
                })
                .map(userMapper::toDto)
                .orElseThrow(() -> new RuntimeException("User " + id + " not found!"));
    }

    @Override
    public void deleteByEmail(String email) {
        this.userRepository.deleteByEmail(email);
    }

    @Override
    public void deleteById(Long id) {
        this.userRepository.deleteById(id);
    }
}
