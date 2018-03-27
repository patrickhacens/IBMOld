package br.senai.sp.informatica.ibmyoung.view;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import br.senai.sp.informatica.ibmyoung.R;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class MissaoActivity extends AppCompatActivity {
    private TextView tvTitulo;
    private TextView tvDescricao;
    private TextView btEntregar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.missao_activity);

        tvTitulo = findViewById(R.id.tvTitulo);
        tvDescricao = findViewById(R.id.tvDescricao);
        btEntregar = findViewById(R.id.btEntregar);

        //TODO: chamar os dados da atividade e carregar na tela

        //TODO: verificar se a atividade tem entregavel para ativar/desativar o botao
    }

    public void entregarMissao(View view) {
        Toast.makeText(this, "Acesse o Portal utilizando um computador", Toast.LENGTH_LONG).show();
    }
}
