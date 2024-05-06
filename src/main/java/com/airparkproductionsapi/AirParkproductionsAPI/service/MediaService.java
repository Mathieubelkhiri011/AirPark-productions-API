package com.airparkproductionsapi.AirParkproductionsAPI.service;


import com.airparkproductionsapi.AirParkproductionsAPI.dto.media.MediaDto;

import java.util.List;

public interface MediaService {

    public void insertMedia(MediaDto mediaUrl);

    public List<MediaDto> getHomeImages();
}
