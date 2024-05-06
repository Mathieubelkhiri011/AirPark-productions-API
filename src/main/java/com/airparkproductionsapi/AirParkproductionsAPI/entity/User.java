package com.airparkproductionsapi.AirParkproductionsAPI.entity;

import jakarta.persistence.*;

import javax.validation.constraints.Email;
import javax.validation.constraints.Pattern;
import java.util.Set;

@Entity
@Table(name = "User")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    @Column(name = "id_user", nullable = false)
    private Long idUser;

    @Column(nullable = false, length = 50)
    @Email
    private String email;

    @Column(nullable = false, length = 50)
    private String password;

    @Column(nullable = false, length = 50)
    private String pseudo;

    @Column(nullable = false)
    private Boolean status;

    @Column(nullable = false, length = 50, updatable = false)
    @Pattern(regexp = "ADMIN|VISITOR")
    private String role;

    @OneToMany(mappedBy = "user")
    private Set<Review> reviews;

    public User() {}

    public User(Long idUser, String email, String password, String pseudo, Boolean status, String role, Set<Review> reviews) {
        this.idUser = idUser;
        this.email = email;
        this.password = password;
        this.pseudo = pseudo;
        this.status = status;
        this.role = role;
        this.reviews = reviews;
    }

    public Long getId() {
        return idUser;
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

    public Set<Review> getReviews() {
        return reviews;
    }

    public void setReviews(Set<Review> reviews) {
        this.reviews = reviews;
    }

    @Override
    public String toString() {
        return "User{" +
                "idUser=" + idUser +
                ", email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", pseudo='" + pseudo + '\'' +
                ", status=" + status +
                ", role='" + role + '\'' +
                ", reviews=" + reviews +
                '}';
    }
}
