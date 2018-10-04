using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public Material material;

    private void Start()
    {
        material.mainTextureOffset = new Vector2();

//        GetComponent<Renderer>().material.te

        material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        material.mainTexture.filterMode = FilterMode.Bilinear;
        material.mainTexture.anisoLevel = 0;

    }

    void Update()
    {
        material.mainTextureOffset += new Vector2(-0.1f * Time.deltaTime, 0);
        material.mainTextureOffset = new Vector2(material.mainTextureOffset.x % 2, 0);

        if (Input.GetKeyUp(KeyCode.A))
        {
            switch (material.mainTexture.wrapMode)
            {
                case TextureWrapMode.Clamp:
                    material.mainTexture.wrapMode = TextureWrapMode.Mirror;
                    Debug.Log(TextureWrapMode.Mirror);
                    break;
                case TextureWrapMode.Mirror:
                    material.mainTexture.wrapMode = TextureWrapMode.MirrorOnce;
                    Debug.Log(TextureWrapMode.MirrorOnce);
                    break;
                case TextureWrapMode.MirrorOnce:
                    material.mainTexture.wrapMode = TextureWrapMode.Repeat;
                    Debug.Log(TextureWrapMode.Repeat);
                    break;
                case TextureWrapMode.Repeat:
                    material.mainTexture.wrapMode = TextureWrapMode.Clamp;
                    Debug.Log(TextureWrapMode.Clamp);
                    break;
                default:
                    material.mainTexture.wrapMode = TextureWrapMode.Mirror;
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            switch (material.mainTexture.filterMode)
            {
                case FilterMode.Point:
                    material.mainTexture.filterMode = FilterMode.Bilinear;
                    Debug.Log(FilterMode.Bilinear);
                    break;
                case FilterMode.Bilinear:
                    material.mainTexture.filterMode = FilterMode.Trilinear;
                    Debug.Log(FilterMode.Trilinear);
                    break;
                case FilterMode.Trilinear:
                    material.mainTexture.filterMode = FilterMode.Point;
                    Debug.Log(FilterMode.Point);
                    break;
                default:
                    material.mainTexture.filterMode = FilterMode.Bilinear;
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            material.mainTexture.anisoLevel += 1;
            material.mainTexture.anisoLevel = material.mainTexture.anisoLevel % 10;
            Debug.Log(material.mainTexture.anisoLevel);
        }
    }
}