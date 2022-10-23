using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float x_tiling;

    [SerializeField]
    private float y_tiling;

    private Material m;

    void Awake()
    {
        m = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        m.mainTextureScale = new Vector2(x_tiling, y_tiling);
    }
}
