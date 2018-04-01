package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.ListView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.view.adapter.ForumAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class ForumActivity extends AppCompatActivity {
    private ListView listView;
    private ForumAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.forum_activity);

        adapter = new ForumAdapter();
        listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }
    }
}
