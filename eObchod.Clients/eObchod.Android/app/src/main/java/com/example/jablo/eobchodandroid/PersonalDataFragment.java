package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by jablo on 18.04.2016.
 */
public class PersonalDataFragment extends Fragment {

    public PersonalDataFragment() {

    }

    public static PersonalDataFragment newInstance(Intent intent) {

        PersonalDataFragment fragment = new PersonalDataFragment();
        fragment.setArguments(intent.getExtras());
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_personal_data, container, false);

        TextView title = (TextView) rootView.findViewById(R.id.patient_personal_data_title);
        title.setText(R.string.patient_fragment_title_1);
        title.setTextSize(title.getTextSize() + 4);

        return rootView;
    }
}
