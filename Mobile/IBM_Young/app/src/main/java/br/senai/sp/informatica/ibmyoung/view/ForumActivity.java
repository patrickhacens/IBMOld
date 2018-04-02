package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.view.adapter.ForumAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class ForumActivity extends AppCompatActivity implements AdapterView.OnItemClickListener {
    private ListView listView;
    private ForumAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.forum_activity);

        adapter = new ForumAdapter();
        listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(this);

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }
    }

    @Override
    public void onItemClick(AdapterView<?> viewGroup, View view, int linha, long id) {
        Intent intent = new Intent(this, ForumChatActivity.class);
        intent.putExtra("id", (int)id);
        startActivity(intent);
    }
}
