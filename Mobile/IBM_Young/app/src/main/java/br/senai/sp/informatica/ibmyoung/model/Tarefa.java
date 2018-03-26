package br.senai.sp.informatica.ibmyoung.model;

import java.util.Date;
import java.util.List;

/**
 * Created by CodeXP on 20/03/2018.
 */

public class Tarefa {
    private Integer id;
    private String titulo;
    private Date dataCriacao;
    private boolean entregavel;
    private int nivel;
    private String conteudo;
    private List<Questao> questoes;

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

    public Date getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(Date dataCriacao) {
        this.dataCriacao = dataCriacao;
    }

    public boolean isEntregavel() {
        return entregavel;
    }

    public void setEntregavel(boolean entregavel) {
        this.entregavel = entregavel;
    }

    public int getNivel() {
        return nivel;
    }

    public void setNivel(int nivel) {
        this.nivel = nivel;
    }

    public String getConteudo() {
        return conteudo;
    }

    public void setConteudo(String conteudo) {
        this.conteudo = conteudo;
    }

    public List<Questao> getQuestoes() {
        return questoes;
    }

    public void setQuestoes(List<Questao> questoes) {
        this.questoes = questoes;
    }
}
