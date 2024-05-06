package com.airparkproductionsapi.AirParkproductionsAPI.dto.user;

public class AuthenticationDto {

    private String email;

    private String password;

    public AuthenticationDto() {}

    public AuthenticationDto(String email, String password) {
        this.email = email;
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "User{" +
                " email='" + email + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}
