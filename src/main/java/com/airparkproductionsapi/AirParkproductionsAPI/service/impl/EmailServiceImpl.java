package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.EmailDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.EmailService;
import jakarta.mail.MessagingException;
import jakarta.mail.internet.MimeMessage;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.thymeleaf.context.Context;
import org.thymeleaf.spring6.SpringTemplateEngine;

@Service
public class EmailServiceImpl implements EmailService {

    private String emailReceiver;

    private final JavaMailSender mailSender;
    private final SpringTemplateEngine templateEngine;

    public EmailServiceImpl(@Value("${email.receiver}") String emailReceiver, JavaMailSender mailSender, SpringTemplateEngine templateEngine) {
        this.emailReceiver = emailReceiver;
        this.mailSender = mailSender;
        this.templateEngine = templateEngine;
    }

    @Override
    public void sendEmail(EmailDto emailDetails) throws MessagingException {
        MimeMessage message = mailSender.createMimeMessage();
        MimeMessageHelper helper = new MimeMessageHelper(message, true);

        Context context = new Context();
        context.setVariable("senderEmail", emailDetails.getFrom());
        context.setVariable("senderFirstName", emailDetails.getFirstname());
        context.setVariable("senderLastName", emailDetails.getLastname());
        context.setVariable("senderType", emailDetails.getType());
        context.setVariable("senderPhone", emailDetails.getPhone());
        context.setVariable("senderBody", emailDetails.getBody());

        String emailContent = templateEngine.process("emailTemplate", context);

        helper.setTo(emailReceiver);
        helper.setSubject(emailDetails.getFrom());
        helper.setText(emailContent, true);

        mailSender.send(message);
    }
}
