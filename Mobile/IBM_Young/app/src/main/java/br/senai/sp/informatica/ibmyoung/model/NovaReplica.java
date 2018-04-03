package br.senai.sp.informatica.ibmyoung.model;

/**
 * Created by pena on 01/04/2018.
 */

public class NovaReplica {
    private String texto;
    private Integer topicoId;
    private Integer aprendizId;

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public Integer getTopicoId() {
        return topicoId;
    }

    public void setTopicoId(Integer topicoId) {
        this.topicoId = topicoId;
    }

    public Integer getAprendizId() {
        return aprendizId;
    }

    public void setAprendizId(Integer aprendizId) {
        this.aprendizId = aprendizId;
    }
}
