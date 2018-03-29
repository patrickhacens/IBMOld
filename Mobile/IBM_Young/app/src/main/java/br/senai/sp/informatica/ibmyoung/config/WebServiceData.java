package br.senai.sp.informatica.ibmyoung.config;

import br.senai.sp.informatica.ibmyoung.model.Autorizacao;

/**
 * Created by pena on 27/03/2018.
 */

public interface WebServiceData<T> {
    public void processaDados(T dados);
    public void houveErro();
}
