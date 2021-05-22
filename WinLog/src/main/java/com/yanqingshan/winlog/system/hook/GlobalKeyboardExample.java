package com.yanqingshan.winlog.system.hook;

import java.util.Map.Entry;

import lc.kra.system.keyboard.GlobalKeyboardHook;
import lc.kra.system.keyboard.event.GlobalKeyAdapter;
import lc.kra.system.keyboard.event.GlobalKeyEvent;

/**
 * @author admin
 * @version 1.0
 * @Description
 * @date 2021-03-23 0:29
 */
/**
 * 键盘监听
 *
 * @author yanqs
 * @date 2021-03-23
 */
public class GlobalKeyboardExample {
    private static boolean run = true;

    public static void main(String[] args) {

        // Might throw a UnsatisfiedLinkError if the native library fails to load or a RuntimeException if hooking fails
        // Use false here to switch to hook instead of raw input
        GlobalKeyboardHook keyboardHook = new GlobalKeyboardHook(true);

        System.out.println("Global keyboard hook successfully started, press [escape] key to shutdown. Connected keyboards:");

        for (Entry<Long, String> keyboard : GlobalKeyboardHook.listKeyboards().entrySet()) {
            System.out.format("%d: %s\n", keyboard.getKey(), keyboard.getValue());
        }

        keyboardHook.addKeyListener(new GlobalKeyAdapter() {

            @Override
            public void keyPressed(GlobalKeyEvent event) {
                System.out.println(event);
                if (event.getVirtualKeyCode() == GlobalKeyEvent.VK_ESCAPE) {
                    run = false;
                }
            }

            @Override
            public void keyReleased(GlobalKeyEvent event) {
                System.out.println(event);
            }
        });

        try {
            while (run) {
                Thread.sleep(128);
            }
        } catch (InterruptedException e) {
            //Do nothing
        } finally {
            keyboardHook.shutdownHook();
        }
    }
}
