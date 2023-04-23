package com.yanqingshan.console.date;


import cn.hutool.core.lang.Console;
import cn.hutool.core.util.RandomUtil;
import cn.hutool.core.util.StrUtil;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * 时间测试
 *
 * @author yanqs
 * @date 2021-05-24
 */
public class DateTest {
    public static void write() {
        List<String> a = new ArrayList<String>();
        a.add("2021-1");
        Console.log(RandomUtil.randomNumbers(4));
        Scanner scanner = new Scanner(System.in);
        StringBuilder help = new StringBuilder();
        help.append("请输入");
        System.out.println(help.toString());
        Integer sj = 0;
        Integer year = 2021;
        if (scanner.hasNext()) {
            String ipt = scanner.next();
            if (StrUtil.isNotBlank(ipt)) {
                Console.log(ipt);
                sj = Integer.valueOf(ipt);
            }
        }

        for (Integer i = 0; i < 6; i++) {
            Integer js = sj - i;
            if (js <= 0) {
                year = year - 1;
                js = 12 + js;
            }
            Console.log(year + "-" + js);
            //loginTime.add();
        }
    }
}
