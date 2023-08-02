using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtEnemyExecutor : IHealtEnemy
{
    private int healt;

    public bool isUpData { get; set ; }

    public int GetDamageEnemy()
    {
        return healt;
    }

    public void SetDamageEnemy(int damage)
    {
        healt=damage;
    }
}
