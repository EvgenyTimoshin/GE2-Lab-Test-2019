using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton : MonoBehaviour {

    public List<Base> _allBases = new List<Base>();
    public static BaseSingleton Instance;
	// Use this for initialization
	void Start () {
        //Instance = this;
	}

    void Awake() {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetRandomTarget(Base notSelf) {
        List<Base> possibles = new List<Base>();

        foreach (Base b in _allBases) {
            if (b.Equals(notSelf))
            {
            }
            else {
                possibles.Add(b);
            }
        }

        return possibles[(int)Random.Range(0, possibles.Count)].transform;
    }


}
