using UnityEngine;

public class TestAbstarct : DestroyableObjects
{
    protected override void Destroy()
    {
        base.Destroy();
        Debug.Log(2);
    }
}
