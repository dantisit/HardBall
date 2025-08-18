using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public int SceneIndex;

    public void Loader() 
    { 
        SceneManager.LoadScene(SceneIndex);
    }
      
}
