package com.springboot.logaop.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author yanqs
 * @date 2021-12-13
 */
@RestController
@RequestMapping("/test")
public class TestController {

    @GetMapping(value = "/getGetId")
    public String getTest(String id) {
        return id;
    }
}
