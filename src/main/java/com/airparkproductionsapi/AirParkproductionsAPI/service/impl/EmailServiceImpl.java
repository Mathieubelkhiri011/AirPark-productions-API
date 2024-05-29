package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.dto.EmailDto;
import com.airparkproductionsapi.AirParkproductionsAPI.service.EmailService;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.util.Properties;


@Service
public class EmailServiceImpl implements EmailService {

    private String myEmail;

    private String myPassword;

    public EmailServiceImpl(@Value("${spring.mail.username}") String myEmail, @Value("${spring.mail.password}") String myPassword) {
        this.myEmail = myEmail;
        this.myPassword = myPassword;
    }

    @Override
    public void sendEmail(EmailDto emailDetails) {
        String host = "smtp.gmail.com";
        Properties properties = System.getProperties();
        properties.put("mail.smtp.host", host);
        properties.put("mail.smtp.port", "587");
        properties.put("mail.smtp.auth", "true");
        properties.put("mail.smtp.starttls.enable", "true");

        Session session = Session.getInstance(properties, new Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(myEmail, myPassword);
            }
        });

        try {
            MimeMessage message = new MimeMessage(session);
            message.setFrom(new InternetAddress(myEmail));
            message.addRecipient(Message.RecipientType.TO, new InternetAddress(myEmail)); // Destination de l'email
            message.setSubject(emailDetails.getFrom() + ":" + emailDetails.getSubject());
            message.setText(String.format("Name: %s %s\nEmail: %s\nPhone: %s\n\n%s",
                    emailDetails.getFirstname(), emailDetails.getLastname(), emailDetails.getFrom(), emailDetails.getPhone(), emailDetails.getBody()));

            message.setReplyTo(new Address[]{new InternetAddress(emailDetails.getFrom())});

            Transport.send(message);
            System.out.println("Email sent successfully...");
        } catch (MessagingException mex) {
            mex.printStackTrace();
        }
    }
}
