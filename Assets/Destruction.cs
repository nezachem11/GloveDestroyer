using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public Camera Cam;
    public float range;

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField, Range(0, 1)]
    private float threshold = .5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                GameObject current = hit.collider.gameObject;
                Transform currentTransform = current.transform;
                Destroy(current);

                for (int x = 0; x < 5; x++)
                    for (int y = 0; y < 5; y++)
                        for (int z = 0; z < 5; z++)
                        {
                            float limiter = Random.Range(0f, 1.0f);
                            if (limiter < threshold)
                            {
                                Instantiate(blockPrefab, new Vector3(currentTransform.position.x + (float)x / 5 + 0.1f, currentTransform.position.y + (float)y / 5 + 0.1f, currentTransform.position.z + (float)z / 5 + 0.1f), Quaternion.identity);
                            }
                        }
            }
        }

    }
}
