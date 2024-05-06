package com.airparkproductionsapi.AirParkproductionsAPI.dto.category;

import com.airparkproductionsapi.AirParkproductionsAPI.entity.Media;
import jakarta.persistence.*;

import java.util.Set;

public class Category {

    private String codeCategory;

    private String name;

    private Set<Media> medias;

    public Category() {}

    public Category(String codeCategory, String name, Set<Media> medias) {
        this.codeCategory = codeCategory;
        this.name = name;
        this.medias = medias;
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
                "codeCategory='" + codeCategory + '\'' +
                ", name='" + name + '\'' +
                ", medias=" + medias +
                '}';
    }
}
