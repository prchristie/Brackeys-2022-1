using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Inverts a scale vector by dividing 1 by each component
    /// </summary>
    public static Vector3 Invert(this Vector3 vec)
    {
        return new Vector3(1 / vec.x, 1 / vec.y, 1 / vec.z);
    }
    
    public static Vector3 Mult(this Vector3 v, Vector3 other)
        => new Vector3(other.x * v.x, other.y * v.y, other.z * v.z);
}