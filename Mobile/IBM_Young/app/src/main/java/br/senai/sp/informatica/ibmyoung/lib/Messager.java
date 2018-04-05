package br.senai.sp.informatica.ibmyoung.lib;

import java.util.ArrayDeque;
import java.util.Queue;

/**
 * Created by pena on 03/04/2018.
 */

public class Messager {
    public static Messager balcao = new Messager();
    private Queue<OnComplete> lista = new ArrayDeque<>();

    private Messager() {}

    public void add(OnComplete reference) {
        lista.clear();
        lista.add(reference);
    }

    public OnComplete get() {
       return lista.poll();
    }
}
