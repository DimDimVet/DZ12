using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterData : MonoBehaviour
{
    public List<MonoBehaviour> lvlUpAction;//�������� ���� ������� �������� � ���������
    [SerializeField] private int currentLvl = 1;//��������� �������
    public int CurrentLvl => currentLvl;
    [SerializeField] private int score = 0;//���� ��������
    private int scoreToNextLvl = 100;//���������� ����� ��� �������� ������

    //Zenject
    private IHealtEnemy healtEnemy;

    [Inject]
    public void Init(IHealtEnemy d)
    {
        healtEnemy = d;
    }

    //
    private void CountScore(IHealtEnemy hEnemy)
    {
        if (hEnemy.isUpData)
        {
            score += hEnemy.GetDamageEnemy();
            Debug.Log(score);
            hEnemy.isUpData = false;
        }
        if (score>=scoreToNextLvl)
        {
            LvlUp();
        }
    }

    private void LvlUp()
    {
        currentLvl++;
        scoreToNextLvl *= 2;
        for (int i = 0; i < lvlUpAction.Count; i++)//������ � ����� ����� �������, � ������ ����� LevelUp
        {
            if (lvlUpAction[i] is ILevelUp levelUp)
            {
                levelUp.LevelUp(this, currentLvl);
            }
        }
    }

    private void Update()
    {
        CountScore(healtEnemy);
    }
        

}



