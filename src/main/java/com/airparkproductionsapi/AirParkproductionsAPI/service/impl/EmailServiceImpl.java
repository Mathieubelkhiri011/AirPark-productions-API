package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.email.EmailDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.EmailService;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;


@Service
public class EmailServiceImpl implements EmailService {

    private final JavaMailSender javaMailSender;
    private final String toEmail;

    public EmailServiceImpl(JavaMailSender javaMailSender, @Value("${app.email.to}") String toEmail) {
        this.javaMailSender = javaMailSender;
        this.toEmail = toEmail;
    }

    @Override
    public void sendEmail(EmailDto emailDto) {
        SimpleMailMessage message = new SimpleMailMessage();
        message.setTo(toEmail);
        message.setFrom(emailDto.getFrom());
        message.setSubject(emailDto.getSubject());
        message.setText(emailDto.getBody());
        javaMailSender.send(message);
    }

}
