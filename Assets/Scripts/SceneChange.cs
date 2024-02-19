using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void To_01_Menu()
    {
        SceneManager.LoadScene("01_Menu");
    }
    public void To_02_Menu()
    {
        SceneManager.LoadScene("02_Menu");
    }
    public void To_04_Map()
    {
        SceneManager.LoadScene("04_Map");
    }
    //public void To_02_Map()
    //{
    //    SceneManager.LoadScene("02_Map");
    //}
    //public void To_03_Map()
    //{
    //    SceneManager.LoadScene("03_Map");
    //}
}
