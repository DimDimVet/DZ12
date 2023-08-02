using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterData : MonoBehaviour
{
    public int CurrentLvl = 1;//��������� �������
    public int Score = 0;//���� ��������
    public int ScoreToNextLvl = 20;//���������� ����� ��� �������� ������

    //Zenject
    private IHealtEnemy healtEnemy;

    [Inject]
    public void Init(IHealtEnemy d)
    {
        healtEnemy = d;
        
    }

    private void Update()
    {
        if (healtEnemy.isUpData)
        {
            Score += healtEnemy.GetDamageEnemy();
            Debug.Log(Score);
            healtEnemy.isUpData = false;
        }
    }
        

}



