package com.yanqingshan.console;

import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.time.temporal.TemporalAdjusters;
import java.util.*;

/**
 * 启动类 默认方法
 *
 * @author yanqs
 * @date 2021-05-24
 */
public class ConsoleApplicationApp {
    public static void main(String[] args) {
//        Map<String,Object> m=new HashMap<>();
//        if(Objects.isNull(m.get("a"))){
//            Console.log("不存在");
//        }
//        Console.log(m.get("a"));
        //DateTime time = DateUtil.date();
        //String dateStr = time.year() + "-" + (time.month() + 1) + "-"+ DateUtil.endOfMonth(time)"";
        //Console.log(DateUtil.endOfMonth(time));

        //DateTest.write();


//        List<String> months = new ArrayList<>();
//        Integer year = DateUtil.year(DateUtil.date());
//        Integer month = DateUtil.month(DateUtil.date()) + 1;
//        for (Integer i = 0; i < 6; i++) {
//            Integer js = month - i;
//            if (js <= 0) {
//                year = year - 1;
//                js = 12 + js;
//                months.add(year + "-" + js);
//            } else {
//                months.add(year + "-0" + js);
//            }
//
//
//            //Console.log(year + "-" + js);
//
//        }
//        Console.log(months);
//
//        Collections.reverse(months);
//        Console.log(months);
//
//        List<String> types = new ArrayList<>();
//        types.add("1");
//        Console.log(Objects.nonNull(types.stream().filter(t->t.equals("1")).findFirst().orElse(null)));


//        String a=null;
//        Console.log(StrUtil.hasBlank(a));

//        List<String> list = new ArrayList<>();
//        list.add("a");
//        list.add("");
//        list.add("c");
//        for (String s : list) {
//            if (StrUtil.hasBlank(s)) {
//                continue;
//            }
//            Console.log(s);
//        }

//        Integer a = 10;
//        Integer b = 20;
//        DecimalFormat df = new DecimalFormat("0.00");
//
//        Console.log((a.doubleValue() / b.doubleValue() * 100));


//        String dateStr2 = "2017-04-01 23:33:23";
//        Date date2 = DateUtil.parse(dateStr2);
//
//        long betweenDay = DateUtil.between(date2,DateUtil.date(), DateUnit.DAY);
//        Console.log(betweenDay);
        //Long a = 123L;
        //Long b = null;

        //StrUtil.hasBlank(b);

        // Instantiates two LocalDateTime
//        LocalDateTime da_ti1 = LocalDateTime.parse("2005-10-05T10:10:10");
//        LocalDateTime da_ti2 = LocalDateTime.now();
//
//        // Display da_ti1, da_ti2
//        System.out.println("LocalDateTime da_ti1 and da_ti2: ");
//        System.out.println("da_ti1: " + da_ti1);
//        System.out.println("da_ti2: " + da_ti2);
//
//        System.out.println();
//
//        // Here, this method compares two date-time
//        // objects i.e. here it returns the
//        // difference of first non-matching field
//        // in both the objects like first non-match
//        // field is year da_ti1 = 2005 and da_ti2
//        // = 2020 so the value (2005-2020 = -15)
//        // -15 will be returned
//        int compare = da_ti1.compareTo(da_ti2);
//
//        // Display compare
//        System.out.println("da_ti1.compareTo(da_ti2): " + compare);

//        DateTimeFormatter df = DateTimeFormatter.ofPattern("yyyy-MM-dd");
//        LocalDateTime time = LocalDateTime.now();
//        String localTime = df.format(time);
//        Console.log(localTime);
//
        // String[] as = {"123", "456", "789"};
//
        //String a = "123,456";
//
//        //Console.log(a.contains(as[0]));
//        //Console.log(a.contains((as[1])));
//
//        Console.log(Joiner.on(",").join(as));
//
//        Console.log(a.substring(0, a.length() - 1));


        // Console.log(Arrays.asList(a.split(",")));

        //disjoint();

//        List<List> allList = new ArrayList<>();
//        List<String> oneList = new ArrayList<>();
//        oneList.add("one");
//        oneList.add("two");
//        List<String> twoList = new ArrayList<>();
//        twoList.add("three");
//        twoList.add("four");
//        allList.add(oneList);
//        allList.add(twoList);
//        allList.stream().flatMap(s ->s.stream()).forEach(s -> System.out.println(s));
        //date();
        //datet(6L);

        //LocalDateTime localDateTime = LocalDateTime.now();
        //Console.log(localDateTime.getMonth().getValue());

        //Console.log(getMonth(6));

//        Console.log(getTimeByFewMonthsBegin(6L));

        //getMonth(6).forEach(System.out::println);


        Date date = new Date();
//日期格式，精确到日 2017-4-16
        DateFormat df1 = DateFormat.getDateInstance();
        System.out.println(df1.format(date));

//可以精确到秒  2017-4-16 12:43:37
        DateFormat df2 = DateFormat.getDateTimeInstance();

        System.out.println(df2.format(date));

        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

        System.out.println("把当前时间转换成字符串：" + sdf.format(new Date()));


        Long a = null;
        System.out.println(a.toString());


    }


    // 获取本月的开始时间
    public static Date getBeginDayOfMonth() {
        Calendar calendar = Calendar.getInstance();
        calendar.set(getNowYear(), getNowMonth() - 1, 1);
        return getDayStartTime(calendar.getTime());
    }

    public static Integer getNowYear() {
        Date date = new Date();
        GregorianCalendar gc = (GregorianCalendar) Calendar.getInstance();
        gc.setTime(date);
        return Integer.valueOf(gc.get(1));
    }

    // 获取本月是哪一月
    public static int getNowMonth() {
        Date date = new Date();
        GregorianCalendar gc = (GregorianCalendar) Calendar.getInstance();
        gc.setTime(date);
        return gc.get(2) + 1;
    }

    // 获取某个日期的开始时间
    public static Timestamp getDayStartTime(Date d) {
        Calendar calendar = Calendar.getInstance();
        if (null != d) {
            calendar.setTime(d);
        }
        calendar.set(calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH),
                calendar.get(Calendar.DAY_OF_MONTH), 0, 0, 0);
        calendar.set(Calendar.MILLISECOND, 0);
        return new Timestamp(calendar.getTimeInMillis());
    }

    /**
     * 获取六个月数值
     *
     * @return
     */
    private static List<String> getMonth(Integer y) {
        List<String> months = new ArrayList<>();
        LocalDateTime localDateTime = LocalDateTime.now();
        Integer year = localDateTime.getYear();
        Integer month = localDateTime.getMonth().getValue();
        for (Integer i = 0; i < y; i++) {
            Integer js = month - i;
            if (js <= 0) {
                year = year - 1;
                js = 12 + js;
                months.add(year + "-" + js);
            } else {
                months.add(year + "-0" + js);
            }

        }
        Collections.reverse(months);
        return months;
    }

    public static String getTimeByFewMonthsBegin(Long i) {
        //LocalDateTime localDateTime = LocalDateTime.now();

        java.util.Date date = getBeginDayOfMonth();
        Instant instant = date.toInstant();
        ZoneId zone = ZoneId.systemDefault();
        LocalDateTime localDateTime = LocalDateTime.ofInstant(instant, zone);


        LocalDateTime resultMonth = localDateTime.plusMonths(-i + 1);

        LocalDateTime endTime = LocalDateTime.of(resultMonth.getYear(), resultMonth.getMonth().getValue(),
                1, 00, 00, 00);
        DateTimeFormatter dtf2 = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
        String strDate2 = dtf2.format(endTime);
        return strDate2;
    }


    private static void datet(Long i) {
        LocalDateTime localDateTime = LocalDateTime.now();
        LocalDateTime resultMonth = localDateTime.plusMonths(-i);
        LocalDateTime endTime = LocalDateTime.of(resultMonth.getYear(), resultMonth.getMonth(), 1, 00, 00, 00);
        System.out.println(endTime);


        DateTimeFormatter dtf2 = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");

        String strDate2 = dtf2.format(endTime);
        System.out.println(strDate2);

    }


    private static void date() {
        LocalDateTime date = LocalDateTime.now();
        LocalDateTime firstday = date.with(TemporalAdjusters.firstDayOfMonth());
        LocalDateTime lastDay = date.with(TemporalAdjusters.lastDayOfMonth());
        System.out.println("firstday:" + firstday);
        System.out.println("lastDay:" + lastDay);
    }

    private static void disjoint() {
        // Instantiate two LinkedList object
        List<Integer> l1 = new LinkedList<Integer>();
        List<Integer> l2 = new LinkedList<Integer>();

        // By using add() method is to add
        // few elements in l1
        l1.add(10);
        l1.add(20);
        l1.add(30);
        l1.add(40);

        // By using add() method is to add
        // few elements in l2
        l2.add(60);
        l2.add(70);
        l2.add(80);
        l2.add(90);

        // Display LinkedList
        System.out.println("l1: " + l1);
        System.out.println("l2: " + l2);

        // By using disjoint() method returns
        // true when no common elements exists
        // in both the collections
        boolean status = Collections.disjoint(l1, l2);

        System.out.println();

        // Display status
        System.out.println("Collections.disjoint(l1,l2): " + status);

    }

}
