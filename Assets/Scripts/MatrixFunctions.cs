using UnityEngine;

public class MatrixFunctions
{
    /// <summary>
    /// Extract translation from transform matrix.
    /// </summary>
    /// <param name="matrix">Transform matrix. This parameter is passed by reference
    /// to improve performance; no changes will be made to it.</param>
    /// <returns>
    /// Translation offset.
    /// </returns>
    public static Vector3 ExtractTranslationFromMatrix(ref Matrix4x4 matrix)
    {
        Vector3 translate;
        translate.x = matrix.m03;
        translate.y = matrix.m13;
        translate.z = matrix.m23;
        return translate;
    }

    /// <summary>
    /// Extract rotation quaternion from transform matrix.
    /// </summary>
    /// <param name="matrix">Transform matrix. This parameter is passed by reference
    /// to improve performance; no changes will be made to it.</param>
    /// <returns>
    /// Quaternion representation of rotation transform.
    /// </returns>
    public static Quaternion ExtractRotationFromMatrix(ref Matrix4x4 matrix)
    {
        Vector3 forward;
        forward.x = matrix.m02;
        forward.y = matrix.m12;
        forward.z = matrix.m22;

        Vector3 upwards;
        upwards.x = matrix.m01;
        upwards.y = matrix.m11;
        upwards.z = matrix.m21;

        return Quaternion.LookRotation(forward, upwards);
    }

    /// <summary>
    /// Extract scale from transform matrix.
    /// </summary>
    /// <param name="matrix">Transform matrix. This parameter is passed by reference
    /// to improve performance; no changes will be made to it.</param>
    /// <returns>
    /// Scale vector.
    /// </returns>
    public static Vector3 ExtractScaleFromMatrix(ref Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
}
