package com.airparkproductionsapi.AirParkproductionsAPI.dto.user;

import jakarta.persistence.Column;

public class UserDto {

    private String email;

    private String password;

    private String pseudo;

    private Boolean status;

    private String role;

    public UserDto() {}

    public UserDto(String email, String password, String pseudo, Boolean status, String role) {
        this.email = email;
        this.password = password;
        this.pseudo = pseudo;
        this.status = status;
        this.role = role;
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

    public String getPseudo() {
        return pseudo;
    }

    public void setPseudo(String pseudo) {
        this.pseudo = pseudo;
    }

    public Boolean getStatus() {
        return status;
    }

    public void setStatus(Boolean status) {
        this.status = status;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    @Override
    public String toString() {
        return "UserDto{" +
                "email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", pseudo='" + pseudo + '\'' +
                ", status=" + status +
                ", role='" + role + '\'' +
                '}';
    }
}
