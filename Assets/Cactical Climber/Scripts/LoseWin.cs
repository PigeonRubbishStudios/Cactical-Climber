using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWin : MonoBehaviour
{
    public LevelManager levelManager;
    public int id;

    void OnTriggerEnter(Collider other)
    {
        if (id == 0)
        {
            levelManager.LoadWin();
        }
        else if (id == 1)
        {
            levelManager.LoadLose();
        }
    }
}
