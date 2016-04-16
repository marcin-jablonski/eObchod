package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

public class BlockListActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_block_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        LinearLayout blockList = (LinearLayout) findViewById(R.id.block_list);
        //get block list from api
        //foreach block add TextView
        TextView sample1 = new TextView(this);
        sample1.setPadding(10, 10, 10, 10);
        sample1.setTextSize(30);
        sample1.setText("Block 1");
        sample1.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        sample1.setWidth(blockList.getWidth());
        sample1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBlockItemClick(v);
            }
        });

        TextView sample2 = new TextView(this);
        sample2.setPadding(10, 10, 10, 10);
        sample2.setTextSize(30);
        sample2.setText("Block 2");
        sample2.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        sample2.setWidth(blockList.getWidth());
        sample2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBlockItemClick(v);
            }
        });

        blockList.addView(sample1);
        blockList.addView(sample2);
    }

    public void onBlockItemClick(View view) {
        //get block data and load to intent
        startRoomListActivity();
    }

    public void startRoomListActivity(){
        Intent intent = new Intent(this, RoomListActivity.class);
        startActivity(intent);
    }
}
