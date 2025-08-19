using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public int SceneIndex = 0;

    public void Loader() 
    { 
        SceneManager.LoadScene(SceneIndex);
    }
      
}
