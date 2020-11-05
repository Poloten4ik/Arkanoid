using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int blockscount;

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
        }
    }
}
