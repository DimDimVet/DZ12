using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItemPickUpImg : MonoBehaviour,ICollisionsComponent
{
    private List<Collider> _colliders=new List<Collider>();
    public void Work()
    {
        for (int i = 0; i < _colliders.Count; i++)
        {
            HealtComponent healt = _colliders[i].GetComponent<HealtComponent>();
            if (healt != null)
            {
                healt.LvlUpData(50);//запишем и обновим
                Destroy(gameObject);//убъем объект
            }
            else
            {
                return;
            }
        }
    }

    public void Execute(List<Collider> colliders)
    {
        _colliders = colliders;
    }

}
