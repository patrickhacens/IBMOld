package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Replica;
import br.senai.sp.informatica.ibmyoung.repository.QuestaoRepo;

/**
 * Created by pena on 28/03/2018.
 */

public class AlternativasActivity extends AppCompatActivity {
    private TextView tvQuestao;
    private RadioButton rbResp1;
    private RadioButton rbResp2;
    private RadioButton rbResp3;
    private RadioButton rbResp4;
    private RadioButton[] questoes;

    private QuestaoRepo dao = QuestaoRepo.dao;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.pergunta_activity);

        tvQuestao = findViewById(R.id.tvQuestao);

        RadioButton[] qts = {
            rbResp1 = findViewById(R.id.rbResp1),
            rbResp2 = findViewById(R.id.rbResp2),
            rbResp3 = findViewById(R.id.rbResp3),
            rbResp4 = findViewById(R.id.rbResp4)
        };
        questoes = qts;

//        Bundle extra = getIntent().getExtras();
//        if(extra != null) {
//            int id = extra.getInt("id");
//            Questao obj = dao.localizar(id);
//            tvQuestao.setText(obj.getTitulo());
//            for(int i = 0;i < questoes.length;i++) {
//                String alternativa = obj.getAlternativas().get(i).getTextoAlternativa();
//                questoes[i].setText(alternativa);
//            }
//        } else {
//            Toast.makeText(this, "Problema ao carregar a Questão", Toast.LENGTH_LONG).show();
//        }

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }
    }

    public void enviarClick(View view) {
        // TODO: salvar a resposta e retornar para a lista de questões
        finish();
    }
}
