package br.senai.sp.informatica.ibmyoung.view.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.util.SparseArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.text.DateFormat;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.repository.QuestaoRepo;
import br.senai.sp.informatica.ibmyoung.repository.TarefaRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class QuestionariosAdapter extends BaseAdapter {
    private QuestaoRepo dao = QuestaoRepo.dao;
    private SparseArray<Questao> mapa;
    private static final DateFormat fmt = DateFormat.getDateInstance(DateFormat.LONG);

    public QuestionariosAdapter(int tarefaId) {
        criarMapa(tarefaId);
    }

    private void criarMapa(int tarefaId) {
        mapa = new SparseArray<>();
        dao.getTarefas(tarefaId, new WebServiceData<List<Questao>>() {
            @Override
            public void processaDados(List<Questao> dados) {
                List<Questao> ids = dados;
                for (int linha = 0; linha < ids.size(); linha++) {
                    mapa.put(linha, ids.get(linha));
                }
                QuestionariosAdapter.this.notifyDataSetChanged();
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar lista de Questões");
            }
        });
    }

    @Override
    public int getCount() {
        return mapa.size();
    }

    @Override
    public Object getItem(int linha) {
        return mapa.get(linha);
    }

    @Override
    public long getItemId(int linha) {
        return mapa.get(linha).getOrdem();
    }

    @Override
    public View getView(int linha, View view, ViewGroup viewGroup) {
        LinearLayout layout;

        if(view == null) {
            Context ctx = viewGroup.getContext();
            LayoutInflater svc = (LayoutInflater)ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            layout = new LinearLayout(ctx);
            svc.inflate(R.layout.questionarios_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Questao obj = mapa.get(linha);
        TextView tvTitulo = layout.findViewById(R.id.tvTitulo);
        tvTitulo.setText(obj.getTitulo());
        TextView tvConteudo = layout.findViewById(R.id.tvConteudo);
        tvConteudo.setText(obj.getConteudo());

        return layout;
    }
}
