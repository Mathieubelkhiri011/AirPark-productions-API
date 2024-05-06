package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.user.UserDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.UserService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@CrossOrigin
@RequestMapping("api/user")
public class UserController {

    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping
    public List<UserDto> users() {
        return this.userService.getAllUsers();
    }

    @GetMapping("/{id}")
    public UserDto userById(@PathVariable Long id) {
        return this.userService.getUserById(id);
    }

    @GetMapping("/email/{email}")
    public UserDto userByEmail(@PathVariable String email) {
        return this.userService.getUserByEmail(email);
    }

    @PostMapping
    public UserDto create(@RequestBody UserDto userDto) {
        return this.userService.create(userDto);
    }

    @PutMapping("/{id}")
    public UserDto updateProduct(@PathVariable Long id, @RequestBody UserDto userDto) {
        return this.userService.update(id, userDto);
    }

    @DeleteMapping("/{id}")
    public void deleteById(@PathVariable Long id) {
        this.userService.deleteById(id);
    }

    @DeleteMapping("/email/{email}")
    public void deleteByEmail(@PathVariable String email) {
        this.userService.deleteByEmail(email);
    }
}
