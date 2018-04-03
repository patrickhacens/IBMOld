package br.senai.sp.informatica.ibmyoung.view.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.CardView;
import android.util.SparseArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.text.DateFormat;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.Main;
import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.repository.TarefaRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class TarefasAdapter extends BaseAdapter {
    private TarefaRepo dao = TarefaRepo.dao;
    private SparseArray<Tarefa> mapa;
    private static final DateFormat fmt = DateFormat.getDateInstance(DateFormat.LONG);

    public TarefasAdapter() {
        criarMapa();
    }

    private void criarMapa() {
        mapa = new SparseArray<>();
        int id = LoginRepo.dao.obterAutorizacao().getId();
        dao.getTarefas(id, new WebServiceData<List<Tarefa>>() {
            @Override
            public void processaDados(List<Tarefa> dados) {
                List<Tarefa> ids = dados;
                for (int linha = 0; linha < ids.size(); linha++) {
                    mapa.put(linha, ids.get(linha));
                }
                TarefasAdapter.this.notifyDataSetChanged();
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar a lista das Tarefa");
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
        return mapa.get(linha).getId();
    }

    @SuppressLint("DefaultLocale")
    @Override
    public View getView(int linha, View view, ViewGroup viewGroup) {
        LinearLayout layout;

        if(view == null) {
            Context ctx = viewGroup.getContext();
            LayoutInflater svc = (LayoutInflater)ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            layout = new LinearLayout(ctx);
            svc.inflate(R.layout.tarefas_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Tarefa obj = mapa.get(linha);
        TextView tvTitulo = layout.findViewById(R.id.tvTitulo);
        tvTitulo.setText(obj.getTitulo());
        TextView tvNivel = layout.findViewById(R.id.tvNivel);
        tvNivel.setText(String.format("Nível %d", obj.getNivel()));
        TextView tvCriacao = layout.findViewById(R.id.tvCriacao);
        tvCriacao.setText(fmt.format(obj.getDataCriacao()));

        if(obj.isRespondida()) {
            CardView cardView = layout.findViewById(R.id.cardView);
            cardView.setCardBackgroundColor(ContextCompat.getColor(Main.context, R.color.cardRespondido));
        }

        return layout;
    }
}
