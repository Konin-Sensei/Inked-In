﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Line : MonoBehaviour {


	public LineRenderer lineRenderer;
	public Transform baseDot;
	public float interpolationQuality = 0.1f;
	private int ink_used = 0;

	List<Vector2> points;

	public void UpdateLine (Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List <Vector2> ();
			SetPoint (mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > 0.1f) {

			SetPoint (mousePos);

		}

	}

	//Konin Test
	public int ConvertLine(int ink_available){
		bool fuckyouFlag = true;
		if(points.Count == 1){
			Instantiate(baseDot, points[0], baseDot.rotation);
			return 1;
		}
		while((ink_available - ink_used) > 0 && fuckyouFlag){
			for(int i = 0; i < points.Count; i++){
				ink_used += 1;
				if((ink_available - ink_used) <= 0){
					i = points.Count + 1;
				}else{
					Instantiate(baseDot, points[i], baseDot.rotation);
				}
				if(i < points.Count - 1){
					float distance = Vector3.Distance(points[i], points[i+1]);
					float distanceCovered = interpolationQuality;
					while (distanceCovered <= 1 && (ink_available - ink_used) > 0){
						Instantiate(baseDot, Vector3.Lerp(points[i], points[i+1], distanceCovered), baseDot.rotation);
						ink_used += 1;
						distanceCovered += interpolationQuality;
					}
				}
				if(i == points.Count - 1){
					fuckyouFlag = false;
				}
			}
		}
		return ink_used;
	}

	void SetPoint (Vector2 point)
	{
		points.Add (point);

		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition (points.Count - 1, point);
	}
}