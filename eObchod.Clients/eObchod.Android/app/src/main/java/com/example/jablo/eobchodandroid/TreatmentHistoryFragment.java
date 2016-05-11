package com.example.jablo.eobchodandroid;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;

import org.achartengine.ChartFactory;
import org.achartengine.GraphicalView;
import org.achartengine.chart.PointStyle;
import org.achartengine.model.XYMultipleSeriesDataset;
import org.achartengine.model.XYSeries;
import org.achartengine.model.XYValueSeries;
import org.achartengine.renderer.XYMultipleSeriesRenderer;
import org.achartengine.renderer.XYSeriesRenderer;

import java.util.ArrayList;

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

    @SuppressWarnings("unchecked")
    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        Intent intent = getActivity().getIntent();
    }

    @Override
    public void onResume() {
        super.onResume();
        drawChart();
    }

    private void drawChart() {
        XYMultipleSeriesDataset dataset= new XYMultipleSeriesDataset();
        XYSeries series = new XYSeries("temperatura");
        series.add(1, 37.2);
        series.add(2, 36.2);;
        series.add(3, 36.6);
        series.add(4, 38.1);
        series.add(5, 37.5);
        dataset.addSeries(series);
        // Now we create the renderer
        XYSeriesRenderer renderer = new XYSeriesRenderer();
        renderer.setLineWidth(2);
        renderer.setColor(Color.RED);
        renderer.setPointStyle(PointStyle.CIRCLE);

        XYMultipleSeriesRenderer mRenderer = new XYMultipleSeriesRenderer();
        mRenderer.addSeriesRenderer(renderer);
        // We want to avoid black border
        mRenderer.setMarginsColor(Color.argb(0x00, 0xff, 0x00, 0x00)); // transparent margins
// Disable Pan on two axis
        mRenderer.setPanEnabled(false, false);
        mRenderer.setYAxisMax(42);
        mRenderer.setYAxisMin(35);
        mRenderer.setXAxisMax(7);
        mRenderer.setXAxisMin(1);
        mRenderer.setShowGrid(true); // we show the grid

       /* XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer();
        renderer.setAxisTitleTextSize(16);
        renderer.setChartTitleTextSize(20);
        renderer.setLabelsTextSize(15);
        renderer.setYAxisMin(34);
        renderer.setYAxisMax(42);
        renderer.setXAxisMin(1);
        renderer.setXAxisMax(7);

        //renderer.setMargins(new int[] { 20, 30, 15, 0 });
        XYSeriesRenderer newTicketRenderer = new XYSeriesRenderer();

        newTicketRenderer.setColor(Color.BLUE);
        renderer.addSeriesRenderer(newTicketRenderer);


        renderer.setXLabels(1);
        renderer.setYLabels(1);
        renderer.setDisplayChartValues(true);
        renderer.setShowGrid(true);
        renderer.setShowLegend(false);
        renderer.setShowLabels(true);


        //renderer.setZoomEnabled(false, false);*/

        GraphicalView chartView;
		/*if (chartView != null) {
			chartView.repaint();
		}
		else { */
        chartView = ChartFactory.getLineChartView (getActivity(), dataset, mRenderer);
        //}


        LinearLayout layout = (LinearLayout) getActivity().findViewById(R.id.linear1);
        //layout.removeAllViews();
        layout.addView(chartView);
    }

}
