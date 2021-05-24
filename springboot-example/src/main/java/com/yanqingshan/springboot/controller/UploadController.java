package com.yanqingshan.springboot.controller;

import lombok.AllArgsConstructor;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.multipart.MultipartHttpServletRequest;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.HashMap;
import java.util.Map;

/**
 * 上传文件
 *
 * @author yanqs
 * @date 2021-04-25
 */
@RestController
@AllArgsConstructor
@RequestMapping("/upload")
public class UploadController {

    private static String fileUploadTempDir = "D:/upload/fileuploaddir";
    private static String fileUploadDir = "D:/upload/";

    @RequestMapping("/doPost")
    @ResponseBody
    public Map fragmentation(HttpServletRequest req, HttpServletResponse resp) {
        resp.addHeader("Access-Control-Allow-Origin", "*");
        Map<String, Object> map = new HashMap<>();

        MultipartHttpServletRequest multipartRequest = (MultipartHttpServletRequest) req;

        // 获得文件分片数据
        MultipartFile file = multipartRequest.getFile("data");
        // 分片第几片
        int index = Integer.parseInt(multipartRequest.getParameter("index"));
        // 总片数
        int total = Integer.parseInt(multipartRequest.getParameter("total"));
        // 获取文件名
        String fileName = multipartRequest.getParameter("name");
        String name = fileName.substring(0, fileName.lastIndexOf("."));
        String fileEnd = fileName.substring(fileName.lastIndexOf("."));
        // 前端uuid，作为标识
        String uuid = multipartRequest.getParameter("uuid");

        File uploadFile = new File(fileUploadTempDir + "/" + uuid, uuid + name + index + ".tem");

        if (!uploadFile.getParentFile().exists()) {
            uploadFile.getParentFile().mkdirs();
        }

        if (index < total) {
            try {
                file.transferTo(uploadFile);
                // 上传的文件分片名称
                map.put("status", 201);
                return map;
            } catch (IOException e) {
                e.printStackTrace();
                map.put("status", 502);
                return map;
            }
        } else {
            try {
                file.transferTo(uploadFile);
                // 上传的文件分片名称
                map.put("status", 200);
                return map;
            } catch (IOException e) {
                e.printStackTrace();
                map.put("status", 502);
                return map;
            }
        }
    }

    /**
     * 合并分片文件
     *
     * @param uuid        文件UUID
     * @param newFileName 新文件名字
     * @return
     */
    @RequestMapping(value = "/merge", method = RequestMethod.GET)
    @ResponseBody
    public Map merge(String uuid, String newFileName) {
        Map retMap = new HashMap();
        try {
            File dirFile = new File(fileUploadTempDir + "/" + uuid);
            if (!dirFile.exists()) {
                throw new RuntimeException("文件不存在！");
            }
            //分片上传的文件已经位于同一个文件夹下，方便寻找和遍历（当文件数大于十的时候记得排序用冒泡排序确保顺序是正确的）
            String[] fileNames = dirFile.list();
            //创建空的合并文件
            File targetFile = new File(fileUploadDir, newFileName);
            RandomAccessFile writeFile = new RandomAccessFile(targetFile, "rw");


            int position = 0;
            for (String fileName : fileNames) {
                System.out.println(fileName);

                File sourceFile = new File(fileUploadTempDir + "/" + uuid, fileName);
                RandomAccessFile readFile = new RandomAccessFile(sourceFile, "rw");
                int chunksize = 1024 * 3;
                byte[] buf = new byte[chunksize];
                writeFile.seek(position);
                int byteCount = 0;
                while ((byteCount = readFile.read(buf)) != -1) {
                    if (byteCount != chunksize) {
                        byte[] tempBytes = new byte[byteCount];
                        System.arraycopy(buf, 0, tempBytes, 0, byteCount);
                        buf = tempBytes;
                    }
                    writeFile.write(buf);
                    position = position + byteCount;
                }
                readFile.close();
                //删除缓存的临时文件
                //FileUtils.deleteDirectory(sourceFile);
                //FileUtils.deleteQuietly(sourceFile);
                //FileUtils.deleteDirectory(sourceFile);
            }
            writeFile.close();
            deleteDir(dirFile);
            retMap.put("code", "200");
        } catch (IOException e) {
            e.printStackTrace();
            retMap.put("code", "500");
        }
        return retMap;
    }

    /**
     * 递归删除目录下的所有文件及子目录下所有文件
     *
     * @param dir 将要删除的文件目录
     * @return boolean Returns "true" if all deletions were successful.
     * If a deletion fails, the method stops attempting to
     * delete and returns "false".
     */
    public static boolean deleteDir(File dir) {
        if (dir.isDirectory()) {
            String[] children = dir.list();
            for (int i = 0; i < children.length; i++) {
                boolean success = deleteDir(new File(dir, children[i]));
                if (!success) {
                    return false;
                }
            }
        }
        // 目录此时为空，可以删除
        return dir.delete();
    }
}
