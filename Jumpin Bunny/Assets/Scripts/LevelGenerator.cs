using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelBlock> legoBlocks = new List<LevelBlock>(); // Sample blocks from where to begin
    List<LevelBlock> currentBlocks = new List<LevelBlock>(); // Blocks added to the game already
    public Transform initialPoint;

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

    }
}
