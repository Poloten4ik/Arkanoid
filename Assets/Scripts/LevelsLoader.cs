using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelsLoader : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
