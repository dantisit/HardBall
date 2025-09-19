using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeScene : MonoBehaviour
{
    public int SceneIndex;
    public GameConrroller GameConrroller;

    public void Loader()
    {   
        SceneManager.LoadScene(SceneIndex);
    }
      
}
