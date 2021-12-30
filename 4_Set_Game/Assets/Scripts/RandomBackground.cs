using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    public Material[] Materials;
    void Start()
    {
        GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length - 1)];

        //Time.timeScale = 5;
        //Invoke("timescale", 10f);
    }

   //void timescale()
   // {
   //     Time.timeScale = 1;
   // }
}
