using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private int chunkSize = 50;

    [SerializeField]
    private float noiseScale = .05f;

    [SerializeField, Range(0, 1)]
    private float threshold = .5f;

    [SerializeField]
    private Material material;

    [SerializeField]
    private bool sphere = false;

    public float blocksize;

    private void Generate()
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    float noiseValue = Perlin3D(x * noiseScale, y * noiseScale, z * noiseScale);
                    if (noiseValue >= threshold)
                    {
                        float raduis = chunkSize / 2;
                        if (sphere && Vector3.Distance(new Vector3(x, y, z), Vector3.one * raduis) > raduis)
                            continue;

                        Instantiate(blockPrefab, new Vector3((float)x * blocksize, (float)y * blocksize, (float)z * blocksize), Quaternion.identity);
                    }
                }
            }
        }
    }

    private void Start()
    {
        Generate();
    }

    public static float Perlin3D(float x, float y, float z)
    {
        float ab = Mathf.PerlinNoise(x, y);
        float bc = Mathf.PerlinNoise(y, z);
        float ac = Mathf.PerlinNoise(x, z);

        float ba = Mathf.PerlinNoise(y, x);
        float cb = Mathf.PerlinNoise(z, y);
        float ca = Mathf.PerlinNoise(z, x);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }

}