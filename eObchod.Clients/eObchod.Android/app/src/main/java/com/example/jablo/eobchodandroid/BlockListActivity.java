package com.example.jablo.eobchodandroid;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.util.SortedList;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

public class BlockListActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_block_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        //get block list from api
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            new GetBlockList().execute(getResources().getString(R.string.api_uri) + "HospitalStructure/Blocks");

        } else {
            // display error
        }
    }

    public void onBlockItemClick(View view) {
        startWardListActivity(view.getId());
    }

    public void startWardListActivity(int blockId){
        Intent intent = new Intent(this, WardListActivity.class);
        intent.putExtra("blockId", blockId);
        Log.d("eObchod", "Clicked id " + blockId);
        startActivity(intent);
    }

    public void AddBlockItem(String name, int id) {
        LinearLayout blockList = (LinearLayout) findViewById(R.id.block_list);
        TextView blockItem = new TextView(this);
        blockItem.setPadding(10, 10, 10, 10);
        blockItem.setTextSize(30);
        blockItem.setText(name);
        blockItem.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        blockItem.setWidth(blockList.getWidth());
        blockItem.setId(id);
        blockItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBlockItemClick(v);
            }
        });
        blockList.addView(blockItem);
    }

    private class GetBlockList extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... params) {
            try {
                return HttpRequestHelper.httpGet(params[0]);
            } catch (IOException e) {
                Log.d("eObchod", "Error loading blocks");
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if(result != null) {
                try {
                    JSONArray json = new JSONArray(result);
                    for(int i = 0; i < json.length(); i++) {
                        AddBlockItem(json.getJSONObject(i).getString("Name"), json.getJSONObject(i).getInt("Id"));
                    }

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
