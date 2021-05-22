package com.yanqingshan.springboot.uitls;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * 配置文件
 *
 * @author yanqs
 * @version 1.0
 * @Description
 * @date 2021/5/23 0:54
 */
@Data
@Configuration
@ConfigurationProperties(prefix = "myprops")
public class MypropsConfig {
    /**
     * List 数组
     */
    private List<String> list;
    /**
     * Map
     */
    private Map<Integer, String> showpagemaps;
}
