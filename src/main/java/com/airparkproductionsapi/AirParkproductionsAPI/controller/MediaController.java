package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.media.MediaDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.MediaService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@CrossOrigin
@RequestMapping("api/media")
public class MediaController {

    private final MediaService mediaService;

    public MediaController(MediaService mediaService) {
        this.mediaService = mediaService;
    }

    @GetMapping("/image/home")
    public List<MediaDto> homeImage() {
        return this.mediaService.getHomeImages();
    }

    @PostMapping
    public void insertMediaUrl(@RequestBody MediaDto mediaDto) {
        this.mediaService.insertMedia(mediaDto);
    }
}
