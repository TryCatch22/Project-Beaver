package com.project_beaverdroid;

import java.util.ArrayList;

import android.graphics.drawable.Drawable;

import com.google.android.maps.ItemizedOverlay;
import com.google.android.maps.OverlayItem;

public class TreeItemizedOverlay extends ItemizedOverlay {

	private ArrayList<OverlayItem> treeOverlays = new ArrayList<OverlayItem>();
	
	public TreeItemizedOverlay(Drawable arg0) {
		super(boundCenter(arg0));
		// TODO Auto-generated constructor stub
	}

	@Override
	protected OverlayItem createItem(int i) {
		return treeOverlays.get(i);
	}

	@Override
	public int size() {
		// TODO Auto-generated method stub
		return treeOverlays.size();
	}
	
	public void addOverlay(OverlayItem overlay) {
		treeOverlays.add(overlay);
	    populate();
	}

}
