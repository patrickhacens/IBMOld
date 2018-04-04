package br.senai.sp.informatica.ibmyoung;

import android.annotation.SuppressLint;
import android.app.Application;
import android.content.Context;
import android.content.Intent;

import java.util.Date;

import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.view.ClassificacaoActivity;

public class Main extends Application {
    @SuppressLint("StaticFieldLeak")
    public static Context context;

    @Override
    public void onCreate() {
        super.onCreate();

        context = getApplicationContext();
    }
}
