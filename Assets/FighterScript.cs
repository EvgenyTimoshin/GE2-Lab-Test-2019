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
    public Transform target;
    IEnumerator shooting;
    IEnumerator refueling;
	// Use this for initialization
	void Start () {
        _tiribium = 7;
        _stateMachine = gameObject.AddComponent<StateMachine>();
        //PickTargetBase();
        GetComponent<StateMachine>().ChangeState(new Travelling());
        
    }

    public void PickTargetBase() {
        target = BaseSingleton.Instance.GetRandomTarget(_parentBase);
        Arrive arrive = GetComponent<Arrive>();
        arrive.targetGameObject = target.gameObject;
    }

    public void SetParentTarget() {
        Arrive arrive = GetComponent<Arrive>();
        arrive.targetGameObject = _parentBase.gameObject;
        target = _parentBase.transform;
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

    public void StartShootingBase() {
        shooting = ShootBase();
        StartCoroutine(shooting);
    }

    public void StopShootingBase() {
        StopCoroutine(shooting);
    }

    public void SetBullet(GameObject bullet) {
        _bulletPrefab = bullet;
    }

    IEnumerator ShootBase() {

        while (true) {
            GameObject prefab = Instantiate(_bulletPrefab);
            prefab.GetComponent<Renderer>().material = _mat;
            Bullet bullet = prefab.AddComponent<Bullet>();
            bullet.tag = "bullet";
            bullet.transform.rotation = this.transform.rotation;
            bullet.transform.position = this.transform.position;
            _tiribium--;
            yield return new WaitForSeconds(1/_fireRatePerSecond);
        }
    }

    public void AttemptRefuel() {
        refueling = Refuelling();
        StartCoroutine(refueling);
    }

    public void StopRefueling() {
        StopCoroutine(refueling);
    }

    IEnumerator Refuelling() {

        while (true) {
            if (_parentBase._tiberium >= 7) {
                _tiribium = 7;
                _parentBase._tiberium -= 7;
                StopRefueling();
            }
               
            yield return new WaitForSeconds(1 / _fireRatePerSecond);
        }
    }
    

}
