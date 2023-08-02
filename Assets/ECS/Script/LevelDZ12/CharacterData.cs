using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterData : MonoBehaviour
{
    public int CurrentLvl = 1;//стартовый уровень
    public int Score = 0;//очки условные
    public int ScoreToNextLvl = 20;//количество очков для перехода уровня

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



