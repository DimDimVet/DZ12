using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterData : MonoBehaviour
{
    public List<MonoBehaviour> lvlUpAction;//создадим лист внешних скриптов с событиями
    public int CurrentLvl => currentLvl;

    public GameObject InventoryUIRoot;//объект для инвентаря
    private List<IItem> items;

    private int currentLvl = 1;//стартовый уровень
    private int score = 0;//очки условные
    private int scoreToNextLvl = 100;//количество очков для перехода уровня

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
            hEnemy.isUpData = false;
        }
        if (score >= scoreToNextLvl)
        {
            LvlUp();
        }
    }

    private void LvlUp()
    {
        currentLvl++;
        scoreToNextLvl *= 2;
        for (int i = 0; i < lvlUpAction.Count; i++)//найдем в листе соотв скрипты, и дернем метод LevelUp
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



