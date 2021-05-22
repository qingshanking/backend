import org.apache.poi.ooxml.POIXMLProperties;
import org.apache.poi.xwpf.extractor.XWPFWordExtractor;
import org.apache.poi.xwpf.usermodel.XWPFDocument;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;


/**
 * poi读取word文档
 * 参考：https://www.cnblogs.com/tuxiaoer/p/11769353.html
 *
 * @author yanqs
 * @date 2021-04-21
 */
public class ReadWord {
    public static void main(String[] args) {
        try {
            testReadByExtractor();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void testReadByExtractor() throws Exception {
        InputStream is = new FileInputStream("D:\\springbladeCloud部署2.0.docx");
        XWPFDocument doc = new XWPFDocument(is);
        XWPFWordExtractor extractor = new XWPFWordExtractor(doc);
        String text = extractor.getText();
        System.out.println(text);
        POIXMLProperties.CoreProperties coreProps = extractor.getCoreProperties();
        printCoreProperties(coreProps);
        close(is);
    }

    /**
     * 输出CoreProperties信息
     *
     * @param coreProps
     */
    private static void printCoreProperties(POIXMLProperties.CoreProperties coreProps) {
        System.out.println(coreProps.getCategory());   //分类
        System.out.println(coreProps.getCreator()); //创建者
        System.out.println(coreProps.getCreated()); //创建时间
        System.out.println(coreProps.getTitle());   //标题
    }

    /**
     * 关闭输入流
     *
     * @param is
     */
    private static void close(InputStream is) {
        if (is != null) {
            try {
                is.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
