using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour {

    private int _tiribium;
	// Use this for initialization
	void Start () {
        _tiribium = 7;
	}


   
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetTiribium() {
        return _tiribium;
    }


    

}
