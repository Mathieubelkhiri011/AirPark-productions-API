package com.airparkproductionsapi.AirParkproductionsAPI.entity;

import jakarta.persistence.*;

import java.util.Set;

@Entity
@Table(name = "Review")
public class Review {
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    @Column(name = "id_review", nullable = false)
    private Long idReview;

    @Column(nullable = false, length = 255)
    private String comment;

    @Column(nullable = false, length = 1)
    private int rating;

    @ManyToOne
    @JoinColumn(name = "id_review_user")
    private User user;

    public Review() {}

    public Review(Long idReview, String comment, int rating, User user) {
        this.idReview = idReview;
        this.comment = comment;
        this.rating = rating;
        this.user = user;
    }

    public Long getIdReview() {
        return idReview;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    @Override
    public String toString() {
        return "Review{" +
                "idReview=" + idReview +
                ", comment='" + comment + '\'' +
                ", rating=" + rating +
                ", user=" + user +
                '}';
    }
}
