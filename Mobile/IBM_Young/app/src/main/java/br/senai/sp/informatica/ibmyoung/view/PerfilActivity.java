package br.senai.sp.informatica.ibmyoung.view;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import org.w3c.dom.Text;

import br.senai.sp.informatica.ibmyoung.R;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class PerfilActivity extends AppCompatActivity {
    private TextView tvNome;
    private TextView tvIdade;
    private TextView tvFuncao;
    private TextView tvInstituicao;
    private TextView tvNomeCompleto;
    private ImageView ivFoto;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.perfil_activity);

        tvNome = findViewById(R.id.tvNome);
        tvIdade = findViewById(R.id.tvIdade);
        tvFuncao = findViewById(R.id.tvFucao);
        tvInstituicao = findViewById(R.id.tvInstituicao);
        tvNomeCompleto = findViewById(R.id.tvNomeCompleto);
        ivFoto = findViewById(R.id.ivFoto);

        consultaDados();
    }

    public void consultaDados() {

    }

    public void voltarClick(View view) {
        finish();
    }
}

