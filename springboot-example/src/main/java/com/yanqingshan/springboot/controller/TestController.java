package com.yanqingshan.springboot.controller;

import cn.hutool.core.lang.Console;
import com.yanqingshan.springboot.uitls.MypropsConfig;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.Resource;
import java.util.List;
import java.util.Map;

/**
 * @author admin
 * @version 1.0
 * @Description
 * @date 2021/5/23 0:57
 */
@RestController
@RequestMapping("/test")
public class TestController {

    @Resource
    private MypropsConfig mypropsConfig;

    /**
     * 读取数据数据
     *
     * @return
     */
    @GetMapping("/selected")
    public List<String> selected() {
        Console.log(mypropsConfig.getList());
        return mypropsConfig.getList();
    }

    /**
     * 读取Map
     *
     * @return
     */
    @GetMapping("/showPageMap")
    public Map<Integer, String> showPageMap() {
        Map<Integer, String> showPageMaps = mypropsConfig.getShowpagemaps();
        for (Integer key : showPageMaps.keySet()) {
            Console.log("key:" + key + ",value:" + showPageMaps.get(key));
        }
        return showPageMaps;
    }
}
