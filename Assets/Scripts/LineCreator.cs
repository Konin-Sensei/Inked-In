using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	public GameObject linePrefab;
	public GameObject handlerPrefab;
	Line activeLine;
	InkHandler ink_handler;

	void Start(){
		GameObject ink_handle = Instantiate(handlerPrefab);
		ink_handler = ink_handle.GetComponent<InkHandler> ();
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			GameObject lineGO = Instantiate (linePrefab);
			activeLine = lineGO.GetComponent<Line> (); 

		}

		if (Input.GetMouseButtonUp (0)) {
			if(ink_handler.ink_available()){
				int ink_used = activeLine.ConvertLine(ink_handler.ink_avail_quantity());
				for(int i = 0; i < ink_used; i++){
					ink_handler.decrease_ink();
				}
			}
			activeLine.lineRenderer.enabled = false;
			activeLine = null;
		}

		if (activeLine != null) {

			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			activeLine.UpdateLine (mousePos);
		}

	}
	

}
