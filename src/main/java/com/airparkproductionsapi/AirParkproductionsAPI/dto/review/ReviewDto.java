package com.airparkproductionsapi.AirParkproductionsAPI.dto.review;

import com.airparkproductionsapi.AirParkproductionsAPI.entity.User;
import jakarta.persistence.*;

public class ReviewDto {

    private String comment;

    private int rating;

    private Long idUser;

    public ReviewDto() {}

    public ReviewDto(String comment, int rating, Long idUser) {
        this.comment = comment;
        this.rating = rating;
        this.idUser = idUser;
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

    public Long getIdUser() {
        return idUser;
    }

    public void setIdUser(Long idUser) {
        this.idUser = idUser;
    }

    @Override
    public String toString() {
        return "ReviewDto{" +
                "comment='" + comment + '\'' +
                ", rating=" + rating +
                ", idUser=" + idUser +
                '}';
    }
}
