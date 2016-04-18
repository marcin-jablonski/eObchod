package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

public class PatientsListActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_patients_list);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        LinearLayout patientsList = (LinearLayout) findViewById(R.id.patients_list);
        //get patients list from api
        //foreach room add TextView
        TextView sample1 = new TextView(this);
        sample1.setPadding(10, 10, 10, 10);
        sample1.setTextSize(30);
        sample1.setText("Patient 1");
        sample1.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        sample1.setWidth(patientsList.getWidth());
        sample1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onPatientItemClick(v);
            }
        });

        TextView sample2 = new TextView(this);
        sample2.setPadding(10, 10, 10, 10);
        sample2.setTextSize(30);
        sample2.setText("Patient 2");
        sample2.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        sample2.setWidth(patientsList.getWidth());
        sample2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onPatientItemClick(v);
            }
        });

        patientsList.addView(sample1);
        patientsList.addView(sample2);
    }

    public void onPatientItemClick(View view) {
        //get block data and load to intent
        startPatientDataActivity();
    }

    public void startPatientDataActivity(){
        Intent intent = new Intent(this, PatientDataActivity.class);
        startActivity(intent);
    }
}
