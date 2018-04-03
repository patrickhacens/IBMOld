package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.RadioButton;
import android.widget.TextView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Resposta;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
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
    private Questao questao;
    private int tarefaId;
    private int questaoId;

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
            questaoId = extra.getInt("questaoId");
            tarefaId = extra.getInt("tarefaId");
            dao.localizar(tarefaId, questaoId, new WebServiceData<Questao>() {
                @Override
                public void processaDados(Questao dados) {
                    questao = dados;
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
        int alternativaId = -1;
        for (int i = 0; i < questoes.length; i++) {
            if(questoes[i].isChecked()) {
                alternativaId = questao.getAlternativas().get(i).getId();
                break;
            }
        }
        if(alternativaId != -1) {
            int aprendizId = LoginRepo.dao.obterAutorizacao().getId();

            Resposta resposta = new Resposta();
            resposta.setAlternativaId(alternativaId);
            resposta.setAprendizId(aprendizId);

            Log.e("enviarClick: ", "alternativaId: " + alternativaId + " aprendizId: " + aprendizId);

            dao.responder(tarefaId, questaoId, resposta, new WebServiceData<Void>() {
                @Override
                public void processaDados(Void dados) {
                    Alerta.showToast("Resposta enviada");
                }

                @Override
                public void houveErro() {
                    Alerta.showToast("Falha ao enviar a Resposta");
                }
            });
        } else {
            Alerta.showToast("Nenhuma alternativa foi selecionada");
        }
        finish();
    }
}
