using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombC : MonoBehaviour
{
    float lifeTime = 7f;
    void Start()
    {
        Invoke("SelfDestroy", lifeTime);
    }
    void SelfDestroy()
    {
        GetComponentInParent<SpawnerC>().RemoveCube(gameObject, 1); // убираем из массива для дальнейшего спавна на этом же месте
        Destroy(gameObject);
    }
}
