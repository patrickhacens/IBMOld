package br.senai.sp.informatica.ibmyoung.model;

/**
 * Created by pena on 27/03/2018.
 */

public class Aprendiz {
    private Long Id;
    private String nome;
    private Nivel nivel;

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public Nivel getNivel() {
        return nivel;
    }

    public void setNivel(Nivel nivel) {
        this.nivel = nivel;
    }
}
