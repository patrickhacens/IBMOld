package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;
import android.view.View;
import android.widget.RadioButton;
import android.widget.TextView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.repository.QuestaoRepo;

/**
 * Created by pena on 28/03/2018.
 */

public class AlternativasActivity extends AppCompatActivity {
    private TextView tvTitulo;
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
        setContentView(R.layout.alternativa_activity);

        tvTitulo = findViewById(R.id.tvTitulo);
        tvQuestao = findViewById(R.id.tvQuestao);

        RadioButton[] qts = {
            rbResp1 = findViewById(R.id.rbResp1),
            rbResp2 = findViewById(R.id.rbResp2),
            rbResp3 = findViewById(R.id.rbResp3),
            rbResp4 = findViewById(R.id.rbResp4)
        };
        questoes = qts;

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }
    }

    @Override
    protected void onStart() {
        super.onStart();

        Bundle extra = getIntent().getExtras();
        if(extra != null) {
            int questaoId = extra.getInt("questaoId");
            int tarefaId = extra.getInt("tarefaId");
            dao.localizar(tarefaId, questaoId, new WebServiceData<Questao>() {
                @Override
                public void processaDados(Questao dados) {
                    tvTitulo.setText(dados.getTitulo());
                    tvQuestao.setText(dados.getConteudo());
                    for (int i = 0; i < questoes.length; i++) {
                        String alternativa = dados.getAlternativas().get(i).getTextoAlternativa();
                        questoes[i].setText(alternativa);
                    }
                }

                @Override
                public void houveErro() {
                    Alerta.showToast("Problema ao carregar a Questão");
                }
            });
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId() == android.R.id.home) {
            setResult(RESULT_CANCELED);
            finish();
        }
        return true;
    }

    public void enviarClick(View view) {
        // TODO: salvar a resposta e retornar para a lista de questões
        finish();
    }
}
