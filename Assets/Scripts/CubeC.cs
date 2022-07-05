using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeC : MonoBehaviour
{
    float lifeTime = 4f;
    int clicksToDestroy, currentClicks;
    [SerializeField] Text text;
    void Start()
    {
        clicksToDestroy = Random.Range(1, 7);
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        text.text = clicksToDestroy.ToString();
        currentClicks = clicksToDestroy;
        Invoke("SelfDestroy", lifeTime);
    }
    public void Clicked() // нажимаем на куб
    {
        currentClicks--;
        if (currentClicks <= 0)
            DoDestroy();
    }
    void SelfDestroy()
    {
        GetComponentInParent<SpawnerC>().RemoveCube(gameObject, -1); // убираем из массива для дальнейшего спавна на этом же месте
        Destroy(gameObject);
    }
    void DoDestroy()
    {
        GetComponentInParent<SpawnerC>().RemoveCube(gameObject, clicksToDestroy); // убираем из массива для дальнейшего спавна на этом же месте
        Destroy(gameObject);
    }
}
