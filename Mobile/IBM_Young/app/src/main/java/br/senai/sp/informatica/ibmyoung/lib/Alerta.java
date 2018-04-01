package br.senai.sp.informatica.ibmyoung.lib;

import android.widget.Toast;

import br.senai.sp.informatica.ibmyoung.Main;

/**
 * Created by pena on 31/03/2018.
 */

public class Alerta {
    private Alerta() {}
    /*
    *  Apresenta um Toast, com a redução da quantidade de parâmetros necessários
    *  para a sua construção
    */
    public static void showToast(String msg) {
        Toast.makeText(Main.context, msg, Toast.LENGTH_LONG).show();
    }
}
