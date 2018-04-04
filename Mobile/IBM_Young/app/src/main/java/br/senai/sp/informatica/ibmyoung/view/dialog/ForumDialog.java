package br.senai.sp.informatica.ibmyoung.view.dialog;

import android.app.Activity;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.lib.Messager;
import br.senai.sp.informatica.ibmyoung.lib.OnComplete;
import br.senai.sp.informatica.ibmyoung.model.NovoTopico;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.repository.TopicoRepo;

/**
 * Created by pena on 03/04/2018.
 */

public class ForumDialog extends Dialog implements View.OnClickListener {
    private Context context;
    private EditText edTitulo;
    private EditText edTexto;
    private Button btCriar;
    private Button btFechar;

    public ForumDialog(@NonNull Context context) {
        super(context);
        this.context = context;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Criar um Tópico");
        setContentView(R.layout.forum_dialog);

        edTitulo = findViewById(R.id.edTitulo);
        edTexto = findViewById(R.id.edTexto);
        btCriar = findViewById(R.id.btCriar);
        btCriar.setOnClickListener(this);
        btFechar = findViewById(R.id.btFechar);
        btFechar.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        if(view.equals(btCriar)) {
            novoTopico();
        }
        dismiss();
    }

    private void novoTopico() {
        String titulo = edTitulo.getText().toString().trim();
        String texto = edTexto.getText().toString().trim();

        if(!titulo.isEmpty() && !texto.isEmpty()) {
            int aprendizId = LoginRepo.dao.obterAutorizacao().getId();
            NovoTopico topico = new NovoTopico();
            topico.setAprendizId(aprendizId);
            topico.setTitulo(titulo);
            topico.setTexto(texto);
            TopicoRepo.dao.novoTopico(topico, new WebServiceData<Void>() {
                @Override
                public void processaDados(Void dados) {
                    Alerta.showToast("Tópico criado");
                    OnComplete obj = Messager.balcao.get();
                    if (obj != null) obj.execute();
                }

                @Override
                public void houveErro() {
                    Alerta.showToast("Falha na criação do Tópico");
                }
            });
        } else {
            Alerta.showToast("Titulo e/ou Texto inválidos");
        }
    }

}
