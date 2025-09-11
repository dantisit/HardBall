using UnityEngine;

public class ChangeEffects : MonoBehaviour
{
    [SerializeField] private GameObject DestroyEffect;
    [SerializeField] private GameObject EffectOff;
    [SerializeField] private GameObject EffectOn;

    public void DoEffectOn() 
    { 
        Instantiate(EffectOn, transform.position, transform.rotation);
    }
    public void DoEffectOff() 
    {
        Instantiate(EffectOff, transform.position, transform.rotation);
    }

}
