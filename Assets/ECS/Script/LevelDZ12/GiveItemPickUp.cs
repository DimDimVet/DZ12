using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GiveItemPickUp : MonoBehaviour,IItem, ICollisionsComponent, IConvertGameObjectToEntity//IConvertGameObjectToEntity - ��� ��������� ���� �� ������
{

    public GameObject _ItemUI;//�������� ������� ��������� ������ ���������
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
                var newAbility = item.GetComponent<ICollisionsComponent>();//����� ������ ��������  � ����
                if (newAbility!=null)
                {
                    newAbility.Execute(colliders);
                }
                Destroy(gameObject);//����� ������
                _dstManager.DestroyEntity(_entity);//����� ������
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
        _entity = entity;//������� � ������ �������� ������
        _dstManager = dstManager;
    }


}
