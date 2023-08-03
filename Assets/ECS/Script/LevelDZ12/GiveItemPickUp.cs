using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GiveItemPickUp : MonoBehaviour,IItem, ICollisionsComponent, IConvertGameObjectToEntity//IConvertGameObjectToEntity - для получения инфы об ентити
{

    public GameObject _ItemUI;//картинка которая выведется внутри инвентаря
    public GameObject ItemUI => _ItemUI;

    private Entity _entity;
    private EntityManager _dstManager;

    public void Execute(List<Collider> colliders)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            CharacterData characterData = colliders[i].GetComponent<CharacterData>();
            if (characterData != null)
            {
                var item = GameObject.Instantiate(ItemUI,characterData.InventoryUIRoot.transform);
                var newAbility = item.GetComponent<ICollisionsComponent>();//новый объект заполним  в лист
                if (newAbility!=null)
                {
                    newAbility.Execute(colliders);
                }
                Destroy(gameObject);//убъем объект
                _dstManager.DestroyEntity(_entity);//убъем ентити
            }
            else
            {
                return;
            }
        }
    }

    public void UseItem(CharacterData data)
    {
        throw new System.NotImplementedException();
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        _entity = entity;//запишем в ентити найденый ентити
        _dstManager = dstManager;
    }


}
