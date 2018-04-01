package br.senai.sp.informatica.ibmyoung.config;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by pena on 31/03/2018.
 */

public class CallBackImpl<T> implements Callback<T> {
    private WebServiceData<T> data;

    public CallBackImpl(WebServiceData<T> data) {
        this.data = data;
    }

    @Override
    public void onResponse(Call<T> call, Response<T> response) {
        data.processaDados(response.body());
    }

    @Override
    public void onFailure(Call<T> call, Throwable t) {
        data.houveErro();
    }
}
