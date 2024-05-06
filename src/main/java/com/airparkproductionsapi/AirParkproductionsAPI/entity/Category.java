package com.airparkproductionsapi.AirParkproductionsAPI.entity;

import jakarta.persistence.*;

import java.util.Set;

@Entity
@Table(name = "Category")
public class Category {
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    @Column(name = "id_category", nullable = false)
    private Long idCategory;

    @Column(name="code_category", nullable = false, unique = true)
    private String codeCategory;

    @Column(nullable = false, length = 100)
    private String name;

    @OneToMany(mappedBy = "category")
    private Set<Media> medias;

    public Category() {}

    public Category(Long idCategory, String codeCategory, String name, Set<Media> medias) {
        this.idCategory = idCategory;
        this.codeCategory = codeCategory;
        this.name = name;
        this.medias = medias;
    }

    public Long getIdCategory() {
        return idCategory;
    }

    public String getCodeCategory() {
        return codeCategory;
    }

    public void setCodeCategory(String codeCategory) {
        this.codeCategory = codeCategory;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Set<Media> getMedias() {
        return medias;
    }

    public void setMedias(Set<Media> medias) {
        this.medias = medias;
    }

    @Override
    public String toString() {
        return "Category{" +
                "idCategory=" + idCategory +
                ", codeCategory='" + codeCategory + '\'' +
                ", name='" + name + '\'' +
                ", medias=" + medias +
                '}';
    }
}
