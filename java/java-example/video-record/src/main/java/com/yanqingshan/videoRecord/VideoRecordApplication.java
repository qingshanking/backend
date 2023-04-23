package com.yanqingshan.videoRecord;

import org.bytedeco.javacv.FrameRecorder;

import java.awt.*;
import java.util.Scanner;

/**
 * 屏幕录制启动类
 *
 * @author yanqs
 * @version 1.0
 * @Description
 * @date 2021/5/22 23:57
 */
public class VideoRecordApplication {
    public static void main(String[] args) throws FrameRecorder.Exception, AWTException {
        VideoRecord videoRecord = new VideoRecord("D:\\test", false);
        videoRecord.start();
        while (true) {
            System.out.println("你要停止吗？请输入(stop)，程序会停止。");
            Scanner sc = new Scanner(System.in);
            if (sc.next().equalsIgnoreCase("stop")) {
                videoRecord.stop();
                System.out.println("停止");
            }
            if (sc.next().equalsIgnoreCase("pause")) {
                videoRecord.pause();
                System.out.println("暂停");
            }
            if (sc.next().equalsIgnoreCase("start")) {
                videoRecord.start();
                System.out.println("开始");
            }
        }
    }
}
