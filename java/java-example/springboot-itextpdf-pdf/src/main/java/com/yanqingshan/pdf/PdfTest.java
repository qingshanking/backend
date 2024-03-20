package com.yanqingshan.pdf;

import cn.hutool.core.io.resource.ClassPathResource;
import cn.hutool.core.io.resource.ResourceUtil;
import com.itextpdf.text.*;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.FileOutputStream;
import java.io.IOException;

/**
 * @author yanqs
 */
public class PdfTest {
    public static void main(String[] args) {
        Document document = new Document();

        try {
            PdfWriter.getInstance(document, new FileOutputStream("report.pdf"));
            document.open();

            BaseFont bfKai = BaseFont.createFont("STSongStd-Light" ,"UniGB-UCS2-H",BaseFont.NOT_EMBEDDED);
            Font myKai8B = new Font(bfKai, 8, Font.BOLD);


            // 设置标题字体样式
            //Font titleFont = FontFactory.getFont("SimSun", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 12, Font.NORMAL, BaseColor.BLACK);
            Paragraph title = new Paragraph("审批报告", myKai8B);
            title.setAlignment(Element.ALIGN_CENTER);
            document.add(title);

            document.add(Chunk.NEWLINE); // 添加空行

            // 设置副标题样式
            Font subtitleFont = FontFactory.getFont("SimSun", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 12, Font.NORMAL, BaseColor.BLACK);
            Paragraph subtitle = new Paragraph();
            subtitle.add(new Chunk("本次新增 ", myKai8B));
            subtitle.add(createColoredChunk("10", BaseColor.GREEN, myKai8B));
            subtitle.add(new Chunk(" 个数据，修改",myKai8B));
            subtitle.add(createColoredChunk("2", BaseColor.BLUE, myKai8B));
            subtitle.add(new Chunk(" 条，删除",myKai8B));
            subtitle.add(createColoredChunk("3", BaseColor.RED, myKai8B));
            subtitle.add(new Chunk(" 个岗位",myKai8B));
            document.add(subtitle);

            // 创建表格并设置样式
            PdfPTable table = new PdfPTable(3);
            table.setWidthPercentage(100); // 将表格宽度设置为100%
            table.setSpacingBefore(10f);
            table.setSpacingAfter(10f);

            // 设置表格标题样式
            Font tableTitleFont = FontFactory.getFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            PdfPCell tableTitleCell = new PdfPCell(new Phrase("Employee Information", tableTitleFont));
            tableTitleCell.setBackgroundColor(BaseColor.LIGHT_GRAY);
            tableTitleCell.setHorizontalAlignment(Element.ALIGN_CENTER);
            tableTitleCell.setColspan(3);
            table.addCell(tableTitleCell);

            // 设置表头样式
            Font headerFont = FontFactory.getFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
            PdfPCell headerCell1 = new PdfPCell(new Phrase("Name", headerFont));
            headerCell1.setBackgroundColor(BaseColor.GRAY);
            headerCell1.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(headerCell1);

            PdfPCell headerCell2 = new PdfPCell(new Phrase("Age", headerFont));
            headerCell2.setBackgroundColor(BaseColor.GRAY);
            headerCell2.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(headerCell2);

            PdfPCell headerCell3 = new PdfPCell(new Phrase("Country", headerFont));
            headerCell3.setBackgroundColor(BaseColor.GRAY);
            headerCell3.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(headerCell3);

            // 设置数据行样式
            Font dataFont = FontFactory.getFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            PdfPCell dataCell1 = new PdfPCell(new Phrase("John Doe", dataFont));
            dataCell1.setHorizontalAlignment(Element.ALIGN_LEFT);
            table.addCell(dataCell1);

            PdfPCell dataCell2 = new PdfPCell(new Phrase("30", dataFont));
            dataCell2.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(dataCell2);

            PdfPCell dataCell3 = new PdfPCell(new Phrase("USA", dataFont));
            dataCell3.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(dataCell3);

            document.add(table);

            document.close();
            System.out.println("PDF report generated successfully.");
        } catch (DocumentException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static Chunk createColoredChunk(String text, BaseColor color, Font font) {
        Font coloredFont = new Font(font.getBaseFont(), font.getSize(), font.getStyle(), color);
        return new Chunk(text, coloredFont);
    }
}
