using UnityEngine;

public static class ExtensionMethods
{
    public static bool ContainsLayer(this LayerMask layerMask, GameObject obj)
    {
        // Check if LayerMask includes the bitwise representation of the GameObject layer
        return ((layerMask.value & (1 << obj.layer)) != 0);
    }
}
