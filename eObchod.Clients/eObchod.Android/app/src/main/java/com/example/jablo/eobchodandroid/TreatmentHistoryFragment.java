package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ScrollView;
import android.widget.TextView;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

/**
 * Created by jablo on 18.04.2016.
 */
public class TreatmentHistoryFragment extends Fragment {

    private String pesel;
    private View rootView;

    public TreatmentHistoryFragment() {

    }

    public static TreatmentHistoryFragment newInstance(Intent intent, String pesel) {

        TreatmentHistoryFragment fragment = new TreatmentHistoryFragment();
        fragment.setArguments(intent.getExtras());
        fragment.pesel = pesel;
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        rootView = inflater.inflate(R.layout.fragment_treatment_history, container, false);

        //get patients info from api
        new GetTreatmentData().execute(getResources().getString(R.string.api_uri)
                + "Patients?pesel=" + pesel);

        TextView title = (TextView) rootView.findViewById(R.id.patient_treatment_history_title);
        title.setText(R.string.patient_fragment_title_2);
        title.setTextSize(title.getTextSize() + 4);

        return rootView;
    }

    private void addTextViewToList(View view)
    {
        ScrollView list = (ScrollView) rootView.findViewById(R.id.patient_treatment_history_data);
        list.addView(view);
    }

    private class GetTreatmentData extends AsyncTask<String, Void, String> {
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


                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
