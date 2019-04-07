using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public List<Material> myMats = new List<Material>();
    public Material material;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        if (material == null)
        {
            material = new Material(SetRandomColor());
            meshRenderer.materials[0].CopyPropertiesFromMaterial(material);

        }
    }

    private void Start()
    {
        SetRandomColor();
    }

    public Material SetRandomColor()
    {
        int index = Random.Range(0, myMats.Count);
        return myMats[index];
    }

}
