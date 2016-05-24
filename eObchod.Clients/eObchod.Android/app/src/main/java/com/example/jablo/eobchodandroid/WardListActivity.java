package com.example.jablo.eobchodandroid;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;

import java.io.IOException;

public class WardListActivity extends AppCompatActivity {

    private int blockId = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ward_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Intent intent = getIntent();
        blockId = intent.getIntExtra("blockId", 0);

        //get ward list from api
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            new GetWardList().execute(getResources().getString(R.string.api_uri) + "HospitalStructure/Wards?blockId=" + blockId);
        } else {
            // display error
        }
    }

    public void onWardItemClick(View view) {
        startRoomListActivity(view.getId());
    }

    public void startRoomListActivity(int wardId){
        Intent intent = new Intent(this, RoomListActivity.class);
        intent.putExtra("blockId", blockId);
        intent.putExtra("wardId", wardId);
        Log.d("eObchod", "Clicked id " + wardId);
        startActivity(intent);
    }

    public void AddWardItem(String name, int id) {
        LinearLayout wardList = (LinearLayout) findViewById(R.id.ward_list);
        TextView wardItem = new TextView(this);
        wardItem.setPadding(10, 10, 10, 10);
        wardItem.setTextSize(30);
        wardItem.setText(name);
        wardItem.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        wardItem.setWidth(wardList.getWidth());
        wardItem.setId(id);
        wardItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onWardItemClick(v);
            }
        });
        wardList.addView(wardItem);
    }

    private class GetWardList extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... params) {
            try {
                return HttpRequestHelper.httpGet(params[0]);
            } catch (IOException e) {
                Log.d("eObchod", "Error loading wards");
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if(result != null) {
                try {
                    JSONArray json = new JSONArray(result);
                    for(int i = 0; i < json.length(); i++) {
                        AddWardItem(json.getJSONObject(i).getString("Name"), json.getJSONObject(i).getInt("Id"));
                    }

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
