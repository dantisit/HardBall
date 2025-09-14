using UnityEngine;

public class DestroyableObject : DestroyableObjects
{
    protected override void DestroyObject()
    {
        // Останавливается, происходит анимация смерти, сбрасывает лут
        base.DestroyObject();
    }
}
