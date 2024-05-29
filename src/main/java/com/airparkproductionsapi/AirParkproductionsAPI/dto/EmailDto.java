package com.airparkproductionsapi.AirParkproductionsAPI.dto;

public class EmailDto {

    private String from;
    private String phone;
    private String lastname;
    private String firstname;
    private String subject;
    private String body;

    public EmailDto() {}

    public EmailDto(String from, String phone, String lastname, String firstname, String subject, String body) {
        this.from = from;
        this.phone = phone;
        this.lastname = lastname;
        this.firstname = firstname;
        this.subject = subject;
        this.body = body;
    }

    public String getFrom() {
        return from;
    }

    public String getPhone() {
        return phone;
    }

    public String getLastname() {
        return lastname;
    }

    public String getFirstname() {
        return firstname;
    }

    public String getSubject() {
        return subject;
    }

    public String getBody() {
        return body;
    }

    @Override
    public String toString() {
        return "EmailDto{" +
                "from='" + from + '\'' +
                ", phone=" + phone +
                ", lastname='" + lastname + '\'' +
                ", firstname='" + firstname + '\'' +
                ", subject='" + subject + '\'' +
                ", body='" + body + '\'' +
                '}';
    }
}
