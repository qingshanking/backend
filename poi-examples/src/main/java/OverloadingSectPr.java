import org.apache.poi.wp.usermodel.HeaderFooterType;
import org.apache.poi.xwpf.usermodel.*;
import org.apache.xmlbeans.XmlException;
import org.openxmlformats.schemas.wordprocessingml.x2006.main.*;

import java.io.FileOutputStream;
import java.io.IOException;

/**
 * 重写SectPr
 *
 * @author admin
 * @version 1.0
 * @Description
 * @date 2021/5/22 23:47
 */
public class OverloadingSectPr {
    private static String defaultSectPr =
            "<w:sectPr xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\">"
                    + "<w:pgSz w:w=\"12240\" w:h=\"15840\"/>" // A4
                    + "<w:pgMar w:top=\"1417\" w:right=\"1417\" w:bottom=\"1134\" w:left=\"1417\""
                    + " w:header=\"720\" w:footer=\"720\" w:gutter=\"0\"/>"
                    + "<w:cols w:space=\"720\"/>"
                    + "</w:sectPr>";
    private static String SectPr_two =
            "<w:sectPr xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\">"
                    + "<w:pgSz w:w=\"12240\" w:h=\"15840\"/>" // A4
                    + "<w:pgMar w:top=\"1417\" w:right=\"1417\" w:bottom=\"1134\" w:left=\"1417\""
                    + " w:header=\"720\" w:footer=\"720\" w:gutter=\"0\"/>"
                    + "<w:cols w:space=\"720\"/>"
                    + "<w:pgNumType w:start=\"1\"/>"
                    + "</w:sectPr>";
    public static void main(String[] args) throws IOException, XmlException {
        CTSectPr ctSectPrDefault = (CTPPr.Factory.parse(defaultSectPr)).getSectPr();
        CTSectPr ctSectPrDefault2 = (CTPPr.Factory.parse(defaultSectPr)).getSectPr();

        XWPFDocument document = new XWPFDocument();

        // Page Setting
        CTDocument1 ctDocument = document.getDocument();
        CTBody ctBody = ctDocument.getBody();

        // Footer
        XWPFFooter footer = document.createFooter(HeaderFooterType.DEFAULT);
        XWPFParagraph paragraph = footer.getParagraphArray(0);
        if (paragraph == null) {
            paragraph = footer.createParagraph();
        }
        paragraph.setAlignment(ParagraphAlignment.CENTER);
        XWPFRun run = paragraph.createRun();
        run.setText("Page ");
        paragraph.getCTP().addNewFldSimple().setInstr("PAGE \\* ARABIC MERGEFORMAT");
        run = paragraph.createRun();
        run.setText(" of ");
        paragraph.getCTP().addNewFldSimple().setInstr("SECTIONPAGES \\* ARABIC MERGEFORMAT");

        // First Section
        paragraph = document.createParagraph();
        run = paragraph.createRun();
        run.setText("Cover");
        paragraph = document.createParagraph();
        paragraph = document.createParagraph();
        run = paragraph.createRun();
        run.setText("Cover");
        paragraph = document.createParagraph();
        //set Section PPR
        paragraph.getCTP().addNewPPr().setSectPr(ctSectPrDefault);
        run.addBreak(BreakType.PAGE);

        // section 2
        paragraph = document.createParagraph();
        run = paragraph.createRun();
        run.setText("Section 2");
        paragraph = document.createParagraph();
        run = paragraph.createRun();
        run.setText("ABCDEFG");
        run.addBreak(BreakType.PAGE);
        paragraph = document.createParagraph();
        run = paragraph.createRun();
        run.setText("ABCDEFG");
        paragraph = document.createParagraph();

        CTSectPr ctSectPrLastSect = ctBody.getSectPr();
        ctSectPrLastSect.addNewPgNumType().setStart(java.math.BigInteger.valueOf(1));

        // get footer reference of first footer and move this to be footer reference for section 2
        CTHdrFtrRef ctHdrFtrRef = ctSectPrLastSect.getFooterReferenceArray(0);
        ctHdrFtrRef.setType(STHdrFtr.DEFAULT);
        CTHdrFtrRef[] ctHdrFtrRefs = new CTHdrFtrRef[] {ctHdrFtrRef};
        ctSectPrLastSect.setFooterReferenceArray(ctHdrFtrRefs);

        document.write(new FileOutputStream("d:\\multiSections.docx"));
    }
}
