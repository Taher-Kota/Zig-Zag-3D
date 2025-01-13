using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInstantiator : MonoBehaviour
{
    public GameObject instantiator;
    public GameObject tile;
    [HideInInspector]
    public GameObject CurrentTilesX,CurrentTilesZ;
    public GameObject[] diamonds;
    Vector3 lastpos;
    [HideInInspector]
    public bool Gameover = false;
    public static TileInstantiator instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lastpos = instantiator.transform.position;        
        InvokeRepeating("Spawning", 1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += tile.transform.localScale.x;
        CurrentTilesX = Instantiate(tile, pos, Quaternion.identity);
        lastpos = pos;
        Destroy(CurrentTilesX, 5f);
    }
    void SpwanZ()
    {
        Vector3 pos = lastpos;
        pos.z += tile.transform.localScale.z;
        GameObject CurrentTilesZ = Instantiate(tile, pos, Quaternion.identity);
        lastpos = pos;
        Destroy(CurrentTilesZ, 5f);
    }

    void SpawnDiamonds()
    {
        int rand = Random.Range(0, diamonds.Length);
        Vector3 pos = lastpos;
        pos.y = -1.75f;
        if (diamonds[rand].gameObject.tag == "Monster" && CurrentTilesZ)
        {
        Instantiate(diamonds[rand], pos = new Vector3(pos.x,pos.y,pos.z-.5f), Quaternion.identity);
        }
        else if(diamonds[rand].gameObject.tag == "Monster" && CurrentTilesX)
        {
        Instantiate(diamonds[rand], pos = new Vector3(pos.x+.85f,pos.y,pos.z), Quaternion.identity);            
        }
        else
        {
        Instantiate(diamonds[rand], pos, Quaternion.identity);
        }
    }

    public void Spawning()
    {
        int random = Random.Range(0, 6);
        if (random < 3)
        {
            SpawnX();
        }
        else if (random > 2)
        {
            SpwanZ();
        }
        if (random == 2 || random == 4 || random == 0)
        {
            SpawnDiamonds();
        }
        }
    }
