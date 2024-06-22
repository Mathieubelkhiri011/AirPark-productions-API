package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.EmailDto;
import jakarta.mail.MessagingException;

public interface EmailService {

    void sendEmail(EmailDto emailDto) throws MessagingException;
}
