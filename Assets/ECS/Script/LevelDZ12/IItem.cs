using UnityEngine;

public interface IItem 
{
    GameObject ItemUI { get;}
    void UseItem(CharacterData data);//���������� ������ ������ � ����������
}
