package com.airparkproductionsapi.AirParkproductionsAPI.entity;

import jakarta.persistence.*;

import javax.validation.constraints.Pattern;
import java.util.Arrays;

@Entity
@Table(name = "Media")
public class Media {
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    @Column(name = "id_media", nullable = false)
    private Long idMedia;

    @Column(nullable = false, length = 100)
    private String title;

    private String description;

    @Column(name = "method_import", nullable = false)
    @Pattern(regexp = "IMPORT_URL|IMPORT_BASE")
    private String methodImport;

    private byte[] base64;

    private String link;

    private Boolean status;

    @Column(name = "display_home_page")
    private Boolean displayHomePage;

    @Column(name = "order_number")
    private int orderNumber;

    @ManyToOne
    @JoinColumn(name = "id_category_user")
    private Category category;

    public Media() {}

    public Media(Long idMedia, String title, String description, String methodImport, byte[] base64, String link, Boolean status, Boolean displayHomePage, int orderNumber, Category category) {
        this.idMedia = idMedia;
        this.title = title;
        this.description = description;
        this.methodImport = methodImport;
        this.base64 = base64;
        this.link = link;
        this.status = status;
        this.displayHomePage = displayHomePage;
        this.orderNumber = orderNumber;
        this.category = category;
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

    public @Pattern(regexp = "IMPORT_URL|IMPORT_BASE") String getMethodImport() {
        return methodImport;
    }

    public void setMethodImport(@Pattern(regexp = "IMPORT_URL|IMPORT_BASE") String methodImport) {
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

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }

    @Override
    public String toString() {
        return "Media{" +
                "idMedia=" + idMedia +
                ", title='" + title + '\'' +
                ", description='" + description + '\'' +
                ", methodImport='" + methodImport + '\'' +
                ", base64=" + Arrays.toString(base64) +
                ", link='" + link + '\'' +
                ", status=" + status +
                ", displayHomePage=" + displayHomePage +
                ", orderNumber=" + orderNumber +
                ", category=" + category +
                '}';
    }
}
