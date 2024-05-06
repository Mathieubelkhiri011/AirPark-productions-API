package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.media.MediaDto;
import com.airparkproductionsapi.AirParkproductionsAPI.entity.Category;
import com.airparkproductionsapi.AirParkproductionsAPI.entity.Media;
import com.airparkproductionsapi.AirParkproductionsAPI.mapper.MediaMapper;
import com.airparkproductionsapi.AirParkproductionsAPI.repository.CategoryRepository;
import com.airparkproductionsapi.AirParkproductionsAPI.repository.MediaRepository;
import com.airparkproductionsapi.AirParkproductionsAPI.service.MediaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.nio.charset.StandardCharsets;
import java.util.List;

@Service
public class MediaServiceImpl implements MediaService {

    private final MediaRepository mediaRepository;
    private final CategoryRepository categoryRepository;
    private final MediaMapper mediaMapper;

    @Autowired
    public MediaServiceImpl(MediaRepository mediaRepository, CategoryRepository categoryRepository, MediaMapper mediaMapper) {
        this.mediaRepository = mediaRepository;
        this.categoryRepository = categoryRepository;
        this.mediaMapper = mediaMapper;
    }

    @Override
    public void insertMedia(MediaDto mediaUrl) {
        Media media = this.mediaMapper.toEntity(mediaUrl);

        if(mediaUrl.getIdCategory() != null) {
            Category category = this.categoryRepository.findById(mediaUrl.getIdCategory()).orElse(null);
            media.setCategory(category);
        }
        this.mediaRepository.save(media);
    }

    @Override
    public List<MediaDto> getHomeImages() {
        return this.mediaMapper.toDtos(
                this.mediaRepository.getListHomeImages()
        );
    }
}
