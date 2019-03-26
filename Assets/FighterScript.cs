using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour {

    private int _tiribium;
    private int _fireRatePerSecond = 1;
    public GameObject _bulletPrefab;
    private Color _color;
    private Material _mat;
    public Base _parentBase;
    public StateMachine _stateMachine;
	// Use this for initialization
	void Start () {
        _tiribium = 7;
        _stateMachine = gameObject.AddComponent<StateMachine>();
        Transform target = PickTarget();
        _stateMachine.currentState = new Travelling();
	}

    public Transform PickTarget() {
        Transform trans = null;
       

        return trans;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void SetParent(Base parentBase) {
        _parentBase = parentBase;
    }

    public void SetColor(Material mat) {
        _mat = mat;
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material = mat;

        }
    }

    public int GetTiribium() {
        return _tiribium;
    }

    IEnumerable ShootBase(GameObject target) {

        while (true) {
            GameObject prefab = Instantiate(_bulletPrefab);
            prefab.GetComponent<Renderer>().material.color = _color;
            Bullet bullet = prefab.AddComponent<Bullet>();
            yield return new WaitForSeconds(1/_fireRatePerSecond);
        }
    }
    

}
