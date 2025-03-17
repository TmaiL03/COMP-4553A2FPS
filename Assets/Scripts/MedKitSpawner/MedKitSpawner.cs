using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitSpawner : MonoBehaviour
{

    [SerializeField] private GameObject medKitPrefab;
    [SerializeField] private int _numKits;
    private GameObject _kit;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < _numKits; i++) {

            _kit = Instantiate(medKitPrefab) as GameObject;
            _kit.transform.position = new Vector3(Random.Range(-24f, 24f), 1f, Random.Range(-24f, 24f));

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
