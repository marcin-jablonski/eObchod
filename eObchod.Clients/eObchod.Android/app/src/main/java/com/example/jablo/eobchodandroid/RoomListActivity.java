package com.example.jablo.eobchodandroid;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.NavUtils;
import android.support.v4.app.TaskStackBuilder;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;

import java.io.IOException;

public class RoomListActivity extends AppCompatActivity {

    private int blockId = 0;
    private int wardId = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_room_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Intent intent = getIntent();
        blockId = intent.getIntExtra("blockId", 0);
        wardId = intent.getIntExtra("wardId", 0);

        //get room list from api
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            new GetRoomList().execute(getResources().getString(R.string.api_uri) + "HospitalStructure/Rooms?blockId=" + blockId + "&wardId=" + wardId);
        } else {
            // display error
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                Intent upIntent = NavUtils.getParentActivityIntent(this);
                upIntent.putExtra("blockId", blockId);
                if(NavUtils.shouldUpRecreateTask(this, upIntent)) {
                    TaskStackBuilder.create(this)
                            .addNextIntentWithParentStack(upIntent)
                            .startActivities();
                } else {
                    NavUtils.navigateUpTo(this, upIntent);
                }
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onBackPressed() {
        Intent intent = new Intent();
        intent.putExtra("blockId", blockId);
        setResult(RESULT_OK, intent);
        finish();
    }

    public void onRoomItemClick(View view) {
        startPatientsListActivity(view.getId());
    }

    public void startPatientsListActivity(int roomId){
        Intent intent = new Intent(this, PatientsListActivity.class);
        intent.putExtra("blockId", blockId);
        intent.putExtra("wardId", wardId);
        intent.putExtra("roomId", roomId);
        Log.d("eObchod", "Clicked id " + roomId);
        startActivity(intent);
    }

    public void AddRoomItem(String name, int id) {
        LinearLayout roomList = (LinearLayout) findViewById(R.id.room_list);
        TextView roomItem = new TextView(this);
        roomItem.setPadding(10, 10, 10, 10);
        roomItem.setTextSize(30);
        roomItem.setText(name);
        roomItem.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        roomItem.setWidth(roomList.getWidth());
        roomItem.setId(id);
        roomItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onRoomItemClick(v);
            }
        });
        roomList.addView(roomItem);
    }

    private class GetRoomList extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... params) {
            try {
                return HttpRequestHelper.httpGet(params[0]);
            } catch (IOException e) {
                Log.d("eObchod", "Error loading rooms");
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if(result != null) {
                try {
                    JSONArray json = new JSONArray(result);
                    for(int i = 0; i < json.length(); i++) {
                        AddRoomItem(json.getJSONObject(i).getString("Name"), json.getJSONObject(i).getInt("Id"));
                    }

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
