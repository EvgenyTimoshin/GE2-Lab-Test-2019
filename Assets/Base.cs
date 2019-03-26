using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float _tiberium = 0;

    public TextMeshPro text;

    public GameObject _fighterPrefab;

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
        StateMachine stateMachine = newFighter.AddComponent<StateMachine>();

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
}
