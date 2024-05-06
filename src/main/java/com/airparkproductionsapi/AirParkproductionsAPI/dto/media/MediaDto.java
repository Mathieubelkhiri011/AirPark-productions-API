package com.airparkproductionsapi.AirParkproductionsAPI.dto.media;

import com.airparkproductionsapi.AirParkproductionsAPI.entity.Category;
import jakarta.persistence.*;

import javax.validation.constraints.Pattern;
import java.util.Arrays;

public class MediaDto {

    private Long idMedia;

    private String title;

    private String description;

    private String methodImport;

    private byte[] base64;

    private String link;

    private Boolean status;

    private Boolean displayHomePage;

    private int orderNumber;

    private Long idCategory;

    public MediaDto() {
    }

    public MediaDto(Long idMedia, String title, String description, String methodImport, byte[] base64, String link, Boolean status, Boolean displayHomePage, int orderNumber, Long idCategory) {
        this.idMedia = idMedia;
        this.title = title;
        this.description = description;
        this.methodImport = methodImport;
        this.base64 = base64;
        this.link = link;
        this.status = status;
        this.displayHomePage = displayHomePage;
        this.orderNumber = orderNumber;
        this.idCategory = idCategory;
    }

    public Long getIdMedia() {
        return idMedia;
    }

    public void setIdMedia(Long idMedia) {
        this.idMedia = idMedia;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getMethodImport() {
        return methodImport;
    }

    public void setMethodImport(String methodImport) {
        this.methodImport = methodImport;
    }

    public byte[] getBase64() {
        return base64;
    }

    public void setBase64(byte[] base64) {
        this.base64 = base64;
    }

    public String getLink() {
        return link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public Boolean getStatus() {
        return status;
    }

    public void setStatus(Boolean status) {
        this.status = status;
    }

    public Boolean getDisplayHomePage() {
        return displayHomePage;
    }

    public void setDisplayHomePage(Boolean displayHomePage) {
        this.displayHomePage = displayHomePage;
    }

    public int getOrderNumber() {
        return orderNumber;
    }

    public void setOrderNumber(int orderNumber) {
        this.orderNumber = orderNumber;
    }

    public Long getIdCategory() {
        return idCategory;
    }

    public void setIdCategory(Long idCategory) {
        this.idCategory = idCategory;
    }

    @Override
    public String toString() {
        return "MediaDto{" +
                "idMedia=" + idMedia +
                ", title='" + title + '\'' +
                ", description='" + description + '\'' +
                ", methodImport='" + methodImport + '\'' +
                ", base64=" + Arrays.toString(base64) +
                ", link='" + link + '\'' +
                ", status=" + status +
                ", displayHomePage=" + displayHomePage +
                ", orderNumber=" + orderNumber +
                ", idCategory=" + idCategory +
                '}';
    }
}
