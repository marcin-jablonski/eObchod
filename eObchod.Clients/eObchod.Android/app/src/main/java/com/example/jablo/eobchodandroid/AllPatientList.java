package com.example.jablo.eobchodandroid;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
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

public class AllPatientList extends AppCompatActivity {

    private int blockId = 0;
    private int wardId = 0;
    private int roomId = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.all_patients_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Intent intent = getIntent();
        blockId = intent.getIntExtra("blockId", 0);
        wardId = intent.getIntExtra("wardId", 0);
        roomId = intent.getIntExtra("roomId", 0);

        //get patients list from api
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            new GetPatientList().execute(getResources().getString(R.string.api_uri)
                    + "Patients?blockId=" + blockId + "&wardId=" + wardId + "&roomId=" + roomId);
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
                upIntent.putExtra("wardId", wardId);
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
        intent.putExtra("wardId", wardId);
        setResult(RESULT_OK, intent);
        finish();
    }

    public void onPatientItemClick(View view) {
        startPatientDataActivity(((PatientListItemTextView) view).getPesel());
    }

    public void startPatientDataActivity(String pesel){
        Intent intent = new Intent(this, PatientDataActivity.class);
        intent.putExtra("blockId", blockId);
        intent.putExtra("wardId", wardId);
        intent.putExtra("roomId", roomId);
        intent.putExtra("pesel", pesel);
        Log.d("eObchod", "Clicked id " + pesel);
        startActivity(intent);
    }

    public void AddPatientItem(String name, String pesel) {
        LinearLayout patientList = (LinearLayout) findViewById(R.id.patients_list);
        PatientListItemTextView patientItem = new PatientListItemTextView(this);
        patientItem.setPadding(10, 10, 10, 10);
        patientItem.setTextSize(30);
        patientItem.setText(name);
        patientItem.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        patientItem.setWidth(patientList.getWidth());
        patientItem.setPesel(pesel);
        patientItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onPatientItemClick(v);
            }
        });
        patientList.addView(patientItem);
    }

    private class GetPatientList extends AsyncTask<String, Void, String> {
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
                        AddPatientItem(json.getJSONObject(i).getString("Name"), json.getJSONObject(i).getString("Pesel"));
                    }

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
