package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.EmailDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.EmailService;
import jakarta.mail.MessagingException;
import org.springframework.web.bind.annotation.*;

@RestController
@CrossOrigin
@RequestMapping("api/email")
public class EmailController {

    private final EmailService emailService;

    public EmailController(EmailService emailService) {
        this.emailService = emailService;
    }

    @GetMapping
    public String test() {
        return "test réussi ! ";
    }

    @PostMapping
    public void send(@RequestBody EmailDto emailDto) throws MessagingException {
        this.emailService.sendEmail(emailDto);
    }
}
