package com.yanqingshan.winlog;

import com.sun.jna.platform.win32.Advapi32Util;
import com.sun.jna.platform.win32.WinNT;
import com.yanqingshan.winlog.comparable.Event;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;

/**
 * @author admin
 * @version 1.0
 * @Description
 * @date 2021/5/23 0:21
 */
public class WinLogApplication {
    public static void main(String[] args) {
        List<Event> eventList = new ArrayList<>();
        Advapi32Util.EventLogIterator iter = new Advapi32Util.EventLogIterator("EventLog");
        while (iter.hasNext()) {
            Advapi32Util.EventLogRecord record = iter.next();
            StringBuffer data = new StringBuffer();
            String[] str = record.getStrings();
            if (str != null) {
                for (String s : str) {
                    data.append(s);
                }
            }
            WinNT.EVENTLOGRECORD record1 = record.getRecord();
            //get event generated time
            if ((short) record.getEventId() == 6009) {
                eventList.add(
                        new Event(Integer.valueOf((short) record.getEventId()),
                                new Date(record1.TimeGenerated.longValue() * 1000),
                                record.getType().toString(),
                                record1.EventCategory.toString(),
                                record.getSource().toString(),
                                data.toString()
                        )
                );
            }
        }
        Collections.sort(eventList);
        eventList.forEach(System.out::println);
    }
}
