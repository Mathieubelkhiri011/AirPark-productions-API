package com.airparkproductionsapi.AirParkproductionsAPI.service;

import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import java.util.Random;

@Component
public class ScheduledTasks {

    private final Random random = new Random();

    @Scheduled(cron = "0 0/15 7-22 * * ?")
    public void performTask() {
        int randomNumber = random.nextInt();
    }
}

