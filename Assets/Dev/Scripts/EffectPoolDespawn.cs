using Lean.Pool;
using UnityEngine;

public class EffectPoolDespawn : MonoBehaviour
{
    public float destroyTime;
    private float creationTime;

    private void OnEnable()
    {
        creationTime = Time.time;
    }

    private void Update()
    {
        float age = Time.time - creationTime;

        if (age >= destroyTime)
            Destroy(gameObject);
    }
}
