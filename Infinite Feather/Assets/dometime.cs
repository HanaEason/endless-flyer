using System;
using UnityEngine;
public class dometime : MonoBehaviour
{
    // Scroll main texture based on time
    float scrollSpeed = Convert.ToSingle(0.5/60);
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer> ();
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.sharedMaterial.mainTextureOffset = new Vector2(offset, 0);
    }
}
