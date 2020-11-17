using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int blockscount;
    public int Hp;

    public void BlockCreated()
    {
        blockscount++;
    }
    public void BlockDestroyed()
    {
        blockscount--;
        if (blockscount <= 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
            GameManager.Instance.isStarted = false;
        }
    }
}
