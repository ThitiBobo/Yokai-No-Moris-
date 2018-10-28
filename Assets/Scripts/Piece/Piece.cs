using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {

    public static bool RED_PLAYER_TAG = true;
    public static bool BLUE_PLAYER_TAG = false;

    private uint _x;
    private uint _y;
    private bool _player;

    public Sprite _redSprite;
    public Sprite _blueSprite;

    public void Awake()
    {
        _player = RED_PLAYER_TAG;
    }
    public void Start()
    {        
    }

    public bool IsRed()
    {
        return _player == RED_PLAYER_TAG;
    }

    public bool IsBlue()
    {
        return _player == BLUE_PLAYER_TAG;
    }

    public void SetPlayerRed()
    {
        if (IsBlue())
        {
            GetComponent<SpriteRenderer>().sprite = _redSprite;
            _player = RED_PLAYER_TAG;
            transform.Rotate(0, 0, 180);
        }
        
    }

    public void SetPlayerBlue()
    { 
        if (IsRed())
        {
            _player = BLUE_PLAYER_TAG;
            GetComponent<SpriteRenderer>().sprite = _blueSprite;
            transform.Rotate(0, 0, 180);
        }
    }

    public abstract void Move(int x, int y);

    public void Drop(Tile tile)
    {
        
    }
    
}
