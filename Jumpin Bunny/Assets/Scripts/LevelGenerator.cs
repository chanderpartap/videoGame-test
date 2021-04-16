using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelBlock> legoBlocks = new List<LevelBlock>(); // Sample blocks from where to begin
    List<LevelBlock> currentBlocks = new List<LevelBlock>(); // Blocks added to the game already
    public Transform initialPoint;
    public byte initialBlockNumber = 2;

    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance //Another way of defining a getter method
    {
        get
        {
            return _sharedInstance;
        }
    }

    private void Awake()
    {
        _sharedInstance = this;
        for (byte i = 0; i < initialBlockNumber; i++)
        {
            AddNewBlock();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void AddNewBlock()
    {
        int rNum = Random.Range(0, legoBlocks.Count);
        var block = Instantiate(legoBlocks[rNum]);
        block.transform.SetParent(this.transform, false);
        Vector3 blockPosiiton = Vector3.zero;
        if(currentBlocks.Count == 0)
        {
            blockPosiiton = initialPoint.position;
        }
        else
        {
            int lastBlockPos = currentBlocks.Count - 1;
            blockPosiiton = currentBlocks[lastBlockPos].exitPoint.position;
        }
        block.transform.position = blockPosiiton;
        currentBlocks.Add(block);
    }
}
