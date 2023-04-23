package com.yanqingshan.winlog.comparable;

import lombok.Data;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * @author admin
 * @version 1.0
 * @Description
 * @date 2021/5/23 0:23
 */
@Data
public class Event implements Comparable<Event> {
    private int id;
    private Date time;
    private String type;
    private String category;
    private String Source;
    private String log;
    private SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    public Event(int id, Date time, String type, String category, String source, String log) {
        this.id = id;
        this.time = time;
        this.type = type;
        this.category = category;
        Source = source;
        this.log = log;
    }

    @Override
    public int compareTo(Event o) {
        return o.getTime().compareTo(this.getTime());
    }

    @Override
    public String toString() {
        return "Event{" +
                "id=" + id +
                ", time=" + simpleDateFormat.format(time) +
                ", type='" + type + '\'' +
                ", category='" + category + '\'' +
                ", Source='" + Source + '\'' +
                ", log='" + log + '\'' +
                '}';
    }
}
