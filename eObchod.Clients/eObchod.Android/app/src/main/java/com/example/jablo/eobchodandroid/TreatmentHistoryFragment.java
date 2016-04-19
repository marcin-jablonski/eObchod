package com.example.jablo.eobchodandroid;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by jablo on 18.04.2016.
 */
public class TreatmentHistoryFragment extends Fragment {
    public TreatmentHistoryFragment() {

    }

    public static TreatmentHistoryFragment newInstance() {

        Bundle args = new Bundle();

        TreatmentHistoryFragment fragment = new TreatmentHistoryFragment();
        fragment.setArguments(args);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_treatment_history, container, false);

        TextView title = (TextView) rootView.findViewById(R.id.patient_treatment_history_title);
        title.setText(R.string.patient_fragment_title_2);
        title.setTextSize(title.getTextSize() + 4);

        return rootView;
    }
}
