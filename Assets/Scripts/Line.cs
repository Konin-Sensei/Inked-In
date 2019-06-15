using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour {


	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	public Transform baseDot;

	List<Vector2> points;

	public void UpdateLine (Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List <Vector2> ();
			SetPoint (mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > .001f) {

			SetPoint (mousePos);

		}

	}

	//Konin Test
	public void ConvertLine(){
		foreach(Vector2 point in points){
			Instantiate(baseDot, point, baseDot.rotation);
		}
		/*for(int i = 0; i < points.Count; i++){
			Instantiate(baseDot, points[i], baseDot.rotation);
			if(i < points.Count - 1){
				float distance = Vector3.Distance(points[i], points[i+1]);
				float distanceCovered = 0.01f;
				while (distanceCovered <= 1){
					Instantiate(baseDot, Vector3.Lerp(points[i], points[i+1], distanceCovered), baseDot.rotation);
					distanceCovered += 0.01f;
				}
			}
		}*/
	}

	void SetPoint (Vector2 point)
	{
		points.Add (point);

		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition (points.Count - 1, point);

		if (points.Count > 1) {
			edgeCol.points = points.ToArray ();
		}
	}
}