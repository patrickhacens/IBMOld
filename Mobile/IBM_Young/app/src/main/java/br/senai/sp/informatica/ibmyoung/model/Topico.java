package br.senai.sp.informatica.ibmyoung.model;

import java.util.Date;
import java.util.List;

/**
 * Created by CodeXP on 20/03/2018.
 */

public class Topico {
    private Integer id;
    private String titulo;
    private String texto;
    private Date dataCriacao;
    private Aprendiz criador;
    private List<Replica> replicas;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

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

    public Date getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(Date dataCriacao) {
        this.dataCriacao = dataCriacao;
    }

    public Aprendiz getCriador() {
        return criador;
    }

    public void setCriador(Aprendiz criador) {
        this.criador = criador;
    }

    public List<Replica> getReplicas() {
        return replicas;
    }

    public void setReplicas(List<Replica> replicas) {
        this.replicas = replicas;
    }
}
