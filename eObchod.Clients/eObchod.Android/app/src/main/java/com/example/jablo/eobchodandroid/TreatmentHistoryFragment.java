package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.Iterator;

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

    private void addViewToList(View view)
    {
        LinearLayout list = (LinearLayout) rootView.findViewById(R.id.patient_treatment_history_data);
        list.addView(view);
    }

    private void createMedsLayout(JSONArray meds) throws JSONException {
        LinearLayout medsLayout = new LinearLayout(this.getContext());
        medsLayout.setOrientation(LinearLayout.VERTICAL);
        TextView title = new TextView(this.getContext());
        title.setText(R.string.medicine_history_title);
        title.setTextSize(title.getTextSize()+1);
        medsLayout.addView(title);
        for (int i=0;i<meds.length();i++) {
            JSONObject med = meds.getJSONObject(i);
            LinearLayout medLayout = new LinearLayout(this.getContext());
            medLayout.setOrientation(LinearLayout.VERTICAL);
            TextView row1 = new TextView(this.getContext());
            row1.setText(med.getString("Name") + ", " + med.getString("FromTo"));
            TextView row2 = new TextView(this.getContext());
            row2.setText(med.getString("Note") == "null" ? "Brak komentarza" : med.getString("Note"));
            medLayout.addView(row1);
            medLayout.addView(row2);
            medsLayout.addView(medLayout);
        }
        addViewToList(medsLayout);
    }

    private void createDiagsLayout(JSONArray diags) throws JSONException {
        LinearLayout diagsLayout = new LinearLayout(this.getContext());
        diagsLayout.setOrientation(LinearLayout.VERTICAL);
        TextView title = new TextView(this.getContext());
        title.setText(R.string.diagnose_history_title);
        title.setTextSize(title.getTextSize()+1);
        diagsLayout.addView(title);
        for (int i=0;i<diags.length();i++) {
            JSONObject diag = diags.getJSONObject(i);
            LinearLayout diagLayout = new LinearLayout(this.getContext());
            diagLayout.setOrientation(LinearLayout.VERTICAL);
            TextView row1 = new TextView(this.getContext());
            row1.setText(diag.getString("Name") + ", " + diag.getString("Date"));
            TextView row2 = new TextView(this.getContext());
            row2.setText(diag.getString("Comment") == "null" ? "Brak komentarza" : diag.getString("Comment"));
            diagLayout.addView(row1);
            diagLayout.addView(row2);
            diagsLayout.addView(diagLayout);
        }
        addViewToList(diagsLayout);
    }

    private void createProcsLayout(JSONArray procs) throws JSONException {
        LinearLayout procsLayout = new LinearLayout(this.getContext());
        procsLayout.setOrientation(LinearLayout.VERTICAL);
        TextView title = new TextView(this.getContext());
        title.setText(R.string.procedure_history_title);
        title.setTextSize(title.getTextSize()+1);
        procsLayout.addView(title);
        for (int i=0;i<procs.length();i++) {
            JSONObject proc = procs.getJSONObject(i);
            LinearLayout procLayout = new LinearLayout(this.getContext());
            procLayout.setOrientation(LinearLayout.VERTICAL);
            TextView row1 = new TextView(this.getContext());
            row1.setText(proc.getString("Name") + ", " + proc.getString("Date"));
            TextView row2 = new TextView(this.getContext());
            row2.setText(proc.getString("Comment") == "null" ? "Brak komentarza" : proc.getString("Comment"));
            JSONObject params = proc.getJSONObject("Parameters");
            LinearLayout paramsLayout = new LinearLayout(this.getContext());
            paramsLayout.setOrientation(LinearLayout.VERTICAL);

            Iterator<?> keys = params.keys();

            while (keys.hasNext()) {
                String key = (String)keys.next();
                TextView param = new TextView(this.getContext());
                param.setText(key + ": " + params.getString(key));
                paramsLayout.addView(param);
            }

            procLayout.addView(row1);
            procLayout.addView(row2);
            procLayout.addView(paramsLayout);
            procsLayout.addView(procLayout);
        }
        addViewToList(procsLayout);
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
                    JSONArray meds = json.getJSONArray("MedicineHistory");
                    JSONArray procs = json.getJSONArray("ProcedureHistory");
                    JSONArray diags = json.getJSONArray("DiagnoseHistory");
                    createMedsLayout(meds);
                    createDiagsLayout(diags);
                    createProcsLayout(procs);

                } catch (JSONException e) {
                    Log.d("eObchod", "Error parsing JSON");
                }
            }
        }
    }
}
