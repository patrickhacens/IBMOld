package br.senai.sp.informatica.ibmyoung.model;

/**
 * Created by pena on 03/04/2018.
 */

public class NovoTopico {
    private String titulo;
    private String texto;
    private int aprendizId;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public int getAprendizId() {
        return aprendizId;
    }

    public void setAprendizId(int aprendizId) {
        this.aprendizId = aprendizId;
    }
}
