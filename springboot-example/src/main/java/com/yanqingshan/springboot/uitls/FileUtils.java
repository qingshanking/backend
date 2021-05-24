package com.yanqingshan.springboot.uitls;

import lombok.extern.slf4j.Slf4j;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;

/**
 * 文件帮助类
 *
 * @author yanqs
 * @date 2021-04-25
 */
@Slf4j
public class FileUtils {
    /**
     * 复制文件并输入文件
     *
     * @param : @param filePath1 原文件
     * @param : @param filePath2 复制之后的文件
     */
    public static void copyFile(String filePath1, String filePath2) {
        // 读取本地文件
        try (FileInputStream in = new FileInputStream(filePath1);
             // 创建新的输出文件类
             FileOutputStream out = new FileOutputStream(filePath2)) {
            byte[] b = new byte[1024];
            while (in.read(b) > -1) {
                out.write(b);
            }
        } catch (Exception e) {
            log.error(e.getMessage());
        }
    }

    /**
     * 文件转成byte[]
     *
     * @param : @param filePath
     * @param : @return
     * @return: byte[]
     */
    public static byte[] getBytesByFile(String filePath) {
        byte[] data = null;
        // 创建文件类
        File file = new File(filePath);
        try (FileInputStream fis = new FileInputStream(file);
             // 字节输出流,其中数据被写入到字节数组中
             ByteArrayOutputStream bos = new ByteArrayOutputStream(1000)) {

            byte[] b = new byte[1000];
            int n;
            while ((n = fis.read(b)) != -1) {
                bos.write(b, 0, n);
            }
            data = bos.toByteArray();
        } catch (Exception e) {
            log.error(e.getMessage());
        }
        return data;
    }

    /**
     * 文件转成byte[]
     *
     * @param : @param file
     * @param : @return
     * @return: byte[]
     */
    public static byte[] getBytesByFile(File file) {
        byte[] data = null;
        try (FileInputStream fis = new FileInputStream(file);
             // 字节输出流,其中数据被写入到字节数组中
             ByteArrayOutputStream bos = new ByteArrayOutputStream(1000)) {

            byte[] b = new byte[1000];
            int n;
            while ((n = fis.read(b)) != -1) {
                bos.write(b, 0, n);
            }
            data = bos.toByteArray();
        } catch (Exception e) {
            log.error(e.getMessage());
        }
        return data;
    }


    /**
     * 将byte数组转换成文件
     *
     * @param : @param bytes
     * @param : @param filePath
     * @param : @param fileName
     */
    public static void writeFileByBytes(byte[] bytes, String filePath, String fileName) {
        // 检查路径是否存在，创建file文件
        File file = new File(ExistsPathUtils.exists(filePath), fileName);
        try (InputStream is = new ByteArrayInputStream(bytes);
             OutputStream os = new FileOutputStream(file)) {

            // 每次传10M, 断点续传, 否则内存溢出; 如果一味的调整JVM的大小，治标不治本
            byte[] byteStr = new byte[1024 * 1024 * 10];
            int len = 0;

            while ((len = is.read(byteStr)) > 0) {
                os.write(byteStr, 0, len);
            }
        } catch (Exception e) {
            log.error(e.getMessage());
        }
    }


    /**
     * 把某个文件写到指定地址
     *
     * @param : @param file 文件
     * @param : @param filePath 写入地址
     */
    public static void writeFile(File file, String filePath) {
        byte[] b = getBytesByFile(file);
        try (FileOutputStream outputStream = new FileOutputStream(filePath)) {
            outputStream.write(b);
        } catch (IOException e) {
            log.error(e.getMessage());
        }
    }

    /**
     * 获取网络图片流
     **/
    public static InputStream getImageStream(String url) {
        try {
            HttpURLConnection connection = (HttpURLConnection) new URL(url).openConnection();
            connection.setReadTimeout(5000);
            connection.setConnectTimeout(5000);
            connection.setRequestMethod("GET");
            if (connection.getResponseCode() == HttpURLConnection.HTTP_OK) {
                InputStream inputStream = connection.getInputStream();
                return inputStream;
            }
        } catch (IOException e) {
            log.error("获取网络图片出现异常，图片路径为：" + url);
            log.error(e.getMessage());
        }
        return null;
    }

    /**
     * 静态帮组类
     */
    private static class ExistsPathUtils {
        /**
         * 判断文件是否存在
         *
         * @param filePath
         * @return
         */
        public static File exists(String filePath) {
            File disk = new File(filePath);
            // 如果路径不存在就创建
            if (!disk.exists()) {
                disk.mkdirs();
            }
            return disk;
        }
    }

}
