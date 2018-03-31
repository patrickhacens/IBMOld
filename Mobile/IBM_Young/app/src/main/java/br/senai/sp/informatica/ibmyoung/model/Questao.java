package br.senai.sp.informatica.ibmyoung.model;

import java.security.PrivateKey;
import java.util.List;

/**
 * Created by pena on 31/03/2018.
 */

public class Questao {
    private String titulo;
    private List<Alternativa> alternativas;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public List<Alternativa> getAlternativas() {
        return alternativas;
    }

    public void setAlternativas(List<Alternativa> alternativas) {
        this.alternativas = alternativas;
    }
}
