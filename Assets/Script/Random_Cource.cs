using UnityEngine;
using System.Collections.Generic;

public class Random_Course : MonoBehaviour
{
   public GameObject[] Prehub_Random_Ground;   //プレハブ
   public GameObject[] Prehub_Random_obstacle;    //プレハブ
   public Transform startPoint;
   public Transform player;
   public int pieceCount= 7;
   public float pieceWidh =50f;

   public int nextIndex = 1;
   public float generateDistance = 200f;

   List<GameObject> spawnedPieces = new List<GameObject>();
   public int keepPieceCount =10;

   void Start()
    {
        for(int i = 0; i<pieceCount; i++)
        {
            SpawnPiece();
        }
    }
    void Update()
    {
        if(player.position.x + generateDistance > startPoint.position.x + nextIndex*pieceWidh)
        {
            SpawnPiece();
        }
    }
    void SpawnPiece()
    {
        Vector3 pos=startPoint.position + new Vector3( nextIndex * pieceWidh,0f,0f);

        GameObject pieceRoot = new GameObject("RandomPiece_" + nextIndex);
        pieceRoot.transform.position =pos;

        GameObject ground =Instantiate(
            Prehub_Random_Ground[Random.Range(0,Prehub_Random_Ground.Length)],
            pos,
            Quaternion.identity
        );
        ground.transform.parent =pieceRoot.transform;

        int obstacleCount =Random.Range(0,3);
        for(int j =0; j < obstacleCount; j++)
        {
            GameObject obstacle = Instantiate(
                Prehub_Random_obstacle[Random.Range(0,Prehub_Random_obstacle.Length)],
                pos,
                Quaternion.identity
            );
            obstacle.transform.parent = pieceRoot.transform;
        }

        spawnedPieces.Add(pieceRoot);
        if(spawnedPieces.Count > keepPieceCount)
        {
            Destroy(spawnedPieces[0]);
            spawnedPieces.RemoveAt(0);
        }

        nextIndex++;

    }
}
