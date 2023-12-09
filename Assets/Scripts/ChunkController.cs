using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    public float Speed;
    public float ChunkSize;
    public List<Chunk> ChunksInScene;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ChunksInScene.Count; i = i + 1)
        {
            ChunksInScene[i].transform.Translate(Vector3.back * Speed * Time.deltaTime);
            if (ChunksInScene[i].transform.position.z < -ChunkSize)
            {
                ChunksInScene[i].transform.Translate(Vector3.forward * ChunkSize * ChunksInScene.Count);
            }
        }
    }
}
