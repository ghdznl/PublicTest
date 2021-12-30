using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshRotator : MonoBehaviour
{
    public Vector3 Axis;
    public float Angle;
    // Start is called before the first frame update
    void Start()
    {
        var oldv = GetComponent<MeshFilter>().mesh.vertices;
        var q = Quaternion.AngleAxis(Angle, Axis);
        for (int i = 0; i < oldv.Length; i++)
        {
            oldv[i] =  q * oldv[i];
        }
        GetComponent<MeshFilter>().mesh.vertices = oldv;
    }

}
