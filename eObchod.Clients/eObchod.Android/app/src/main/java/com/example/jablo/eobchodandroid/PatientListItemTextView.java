package com.example.jablo.eobchodandroid;

import android.annotation.TargetApi;
import android.content.Context;
import android.os.Build;
import android.os.StrictMode;
import android.util.AttributeSet;
import android.widget.TextView;

/**
 * Created by jablo on 10.05.2016.
 */
public class PatientListItemTextView extends TextView {

    private String pesel;

    public PatientListItemTextView(Context context) {
        super(context);
    }

    public PatientListItemTextView(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    public PatientListItemTextView(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
    }

    @TargetApi(Build.VERSION_CODES.LOLLIPOP)
    public PatientListItemTextView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
    }

    public String getPesel() {
        return pesel;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }
}
