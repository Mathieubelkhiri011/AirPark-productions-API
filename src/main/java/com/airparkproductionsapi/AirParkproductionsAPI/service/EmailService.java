package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.EmailDto;

public interface EmailService {

    void sendEmail(EmailDto emailDto);
}
