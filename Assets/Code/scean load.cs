using UnityEngine;
using UnityEngine.SceneManagement;

public class sceanload : MonoBehaviour
{
   
    // Update is called once per frame
    public void dd()
    {
        SceneManager.LoadScene("game");
    }
    public void cc()
    {
        SceneManager.LoadScene("Hard mode");
    }
}
