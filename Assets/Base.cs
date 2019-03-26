using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float _tiberium = 0;

    public TextMeshPro text;

    public GameObject _fighterPrefab;

    public GameObject _bulletPrefab;

    Coroutine _tiberiumIncrease;

    public int _tiberiumPerSecond;

    private Color _baseColor;

    private Material _baseMaterial;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        _baseMaterial = GetComponent<Renderer>().material;

        StartCoroutine(IncreaseTiberium(_tiberiumPerSecond));
        gameObject.tag = "base";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + _tiberium;
    }

    private void SpawnFighter() {
        _tiberium -= 10;
        GameObject newFighter = Instantiate(_fighterPrefab);
        newFighter.transform.position = this.transform.position;
        FighterScript fighter = newFighter.AddComponent<FighterScript>();
        fighter.SetColor(_baseMaterial);
        fighter.SetParent(this);
        //Had to pass through here had trouble with having script on prefab for some reason
        fighter.SetBullet(_bulletPrefab);
        //tateMachine stateMachine = newFighter.AddComponent<StateMachine>();
        Boid boid = newFighter.AddComponent<Boid>();
        Arrive arrive = newFighter.AddComponent<Arrive>();
        arrive.enabled = false;

    }

    IEnumerator IncreaseTiberium(int perSecond) {

        while (true) {

            if (_tiberium >= 10) {
                SpawnFighter();
            }

            _tiberium++;
            yield return new WaitForSeconds(1.0f/perSecond);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "bullet") {
            _tiberium -= 0.5f;
        }
    }
}
