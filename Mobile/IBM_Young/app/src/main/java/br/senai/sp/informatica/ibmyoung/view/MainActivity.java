package br.senai.sp.informatica.ibmyoung.view;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageView;

import br.senai.sp.informatica.ibmyoung.R;


public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    private ImageView btRanking;
    private ImageView btPerfil;
    private ImageView btNivel1;
    private ImageView btNivel2;
    private ImageView btNivel3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_activity);

        btRanking = findViewById(R.id.btRanking);
        btRanking.setOnClickListener(this);

        btPerfil = findViewById(R.id.btPerfil);
        btPerfil.setOnClickListener(this);

        btNivel1 = findViewById(R.id.btNivel1);
        btNivel1.setOnClickListener(this);

        btNivel2 = findViewById(R.id.btNivel2);
        btNivel2.setOnClickListener(this);

        btNivel3 = findViewById(R.id.btNivel3);
        btNivel3.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        int id = view.getId();

        switch (id) {
            case R.id.btRanking:
                // chamar a tela de Classificação
                startActivity(new Intent(this, PerfilActivity.class));
                break;
            case R.id.btPerfil:
                // Chamar a tela de Perfil
                startActivity(new Intent(this, PerfilActivity.class));
                break;
            case R.id.btNivel1:
                // Consultar as tarefas no nivel 1
                break;
            case R.id.btNivel2:
                // Consultar as tarefas no nivel 1
                break;
            case R.id.btNivel3:
                // Consultar as tarefas no nivel 1
                break;
        }
    }
}
