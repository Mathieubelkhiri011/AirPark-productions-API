package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.email.EmailDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.EmailService;
import org.springframework.web.bind.annotation.*;

@RestController
@CrossOrigin
@RequestMapping("api/email")
public class EmailController {

    private final EmailService emailService;

    public EmailController(EmailService emailService) {
        this.emailService = emailService;
    }

    @PostMapping
    public void send(@RequestBody EmailDto emailDto) {
        this.emailService.sendEmail(emailDto);
    }
}
