package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.email.EmailDto;

public interface EmailService {

    void sendEmail(EmailDto emailDto);
}
