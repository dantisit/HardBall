using UnityEngine;

public class ChestDestroyEffect : MonoBehaviour
{
    [SerializeField] private GameObject EffectObject;
    public void Effect() 
    { 
        EffectObject.SetActive(true);
    }

}
