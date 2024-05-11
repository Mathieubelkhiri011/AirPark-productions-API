package com.airparkproductionsapi.AirParkproductionsAPI.dto.email;

public class EmailDto {

    private String from;

    private String subject;

    private String body;

    public EmailDto() {}

    public EmailDto(String from, String subject, String body) {
        this.from = from;
        this.subject = subject;
        this.body = body;
    }

    public String getFrom() {
        return from;
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
                ", subject='" + subject + '\'' +
                ", body='" + body + '\'' +
                '}';
    }
}
