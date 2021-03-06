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

import java.util.List;

import br.senai.sp.informatica.ibmyoung.Main;
import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.repository.AprendizRepo;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class ClassificacaoAdapter extends BaseAdapter {
    private AprendizRepo dao = AprendizRepo.dao;
    private SparseArray<Aprendiz> mapa;
    private int aprendizId;

    public ClassificacaoAdapter() {
        aprendizId = LoginRepo.dao.obterAutorizacao().getId();
        criarMapa();
    }

    private void criarMapa() {
        mapa = new SparseArray<>();
        dao.getAprendizes(new WebServiceData<List<Aprendiz>>() {
            @Override
            public void processaDados(List<Aprendiz> dados) {
                List<Aprendiz> ids = dados;
                if(dados != null) {
                    for (int linha = 0; linha < ids.size(); linha++) {
                        mapa.put(linha, ids.get(linha));
                    }
                    ClassificacaoAdapter.this.notifyDataSetChanged();
                }
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar a lista dos Aprendizes");
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
            svc.inflate(R.layout.classificacao_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Aprendiz obj = mapa.get(linha);

        if(obj.getId() == aprendizId) {
            CardView cardView = layout.findViewById(R.id.cardView);
            cardView.setCardBackgroundColor(ContextCompat.getColor(Main.context, R.color.cardCurrent));
        }

        //  Para implementar a conversão da foto com Glide
        //  https://opensource.googleblog.com/2014/09/glide-30-media-management-library-for.html
        //  https://inthecheesefactory.com/blog/get-to-know-glide-recommended-by-google/en
        //  ImageView ivFoto = layout.findViewById(R.id.ivFoto);
        TextView tvNome = layout.findViewById(R.id.tvTitulo);
        tvNome.setText(String.format("%s %s", obj.getNome(), obj.getSobrenome()));
        TextView tvNivel = layout.findViewById(R.id.tvNivel);
        tvNivel.setText(String.format("Nível %d", obj.getNivel()));

        return layout;
    }
}
