package com.airparkproductionsapi.AirParkproductionsAPI.service;

import org.springframework.http.ResponseEntity;

public interface InstagramService {

    public ResponseEntity<String> getInstagramPosts(String userId, int count);
}
