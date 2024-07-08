package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import org.springframework.web.bind.annotation.*;

@RestController
@CrossOrigin
@RequestMapping("api/wakeup")
public class WakeUpController {

    @GetMapping
    public String WakeUp() {
        return "wake up ! ";
    }

}
