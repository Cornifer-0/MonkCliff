using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : MonoBehaviour
{
    public Transform MasterMonk;
    public Transform MonkHouse1;

    public bool MasterMonkOrno;

    public float speed = 1.5f;
    private Vector3 target;

    private Vector3 monkv;
    private Vector3 monkhv;
    void Start()
    {
        monkv = MasterMonk.position;
        monkhv = MonkHouse1.position;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MasterMonkOrno)
            target = monkv;
        else
            target = monkhv;

        target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
