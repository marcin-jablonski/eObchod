package com.example.jablo.eobchodandroid;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

/**
 * Created by jablo on 18.04.2016.
 */
public class PersonalDataFragment extends Fragment {

    private String pesel;
    private View rootView;

    public PersonalDataFragment() {

    }

    public static PersonalDataFragment newInstance(Intent intent, String pesel) {

        PersonalDataFragment fragment = new PersonalDataFragment();
        fragment.setArguments(intent.getExtras());
        fragment.pesel = pesel;
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        rootView = inflater.inflate(R.layout.fragment_personal_data, container, false);

        //get patients info from api
        new GetPatientData().execute(getResources().getString(R.string.api_uri)
                + "Patients?pesel=" + pesel);

        TextView title = (TextView) rootView.findViewById(R.id.patient_personal_data_title);
        title.setText(R.string.patient_fragment_title_1);
        title.setTextSize(title.getTextSize() + 4);

        return rootView;
    }

    private void setTextView(String text, int id) {
        TextView tv = (TextView) rootView.findViewById(id);
        tv.setText(text);
    }

    private class GetPatientData extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... params) {
            try {
                return HttpRequestHelper.httpGet(params[0]);
            } catch (IOException e) {
                Log.d("eObchod", "Error loading patient data");
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if(result != null) {
                try {
                    JSONObject json = new JSONObject(result);

                    setTextView(json.getString("Pesel"), R.id.pesel);

                    setTextView(json.getString("FirstName"), R.id.first_name);

                    setTextView(json.getString("LastName"), R.id.last_name);

                    setTextView(json.getString("Gender"), R.id.sex);

                    setTextView(json.getString("BirthDate"), R.id.birth_date);

                    setTextView(String.valueOf(json.getInt("Age")), R.id.age);

                    setTextView(json.getString("MainBookNumber"), R.id.main_book);

                    setTextView(json.getString("WardBookNumber"), R.id.ward_book);

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
