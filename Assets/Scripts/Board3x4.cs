using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board3x4 : MonoBehaviour {

    public GameObject _tile;
    public GameObject _kodama;
    public GameObject _koropokkuru;
    public GameObject _kitsune;
    public GameObject _tanuki;

    public Sprite _grassTileSprite;
    public Sprite _ligthGrassTileSprite;
    public Sprite _rockTileSprite;

    private static uint _rows = 4 ;
    private static uint _cols = 3 ;

    private GameObject[,] _board;


    // Use this for initialization
    void Awake () {
        _board = new GameObject[_rows, _cols];
        CreateTile();
        CreateAllPiece();
    }
	
    private void CreateTile()
    {
        Vector3 size = _tile.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 pos = new Vector2();
        
        float sizeInterTile = size.x / 25;
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                pos.x = (size.x - (float)0.25 /*+ Random.value * sizeInterTile / 2*/) * j;
                pos.y = (size.y - (float)0.25 /*+ Random.value * sizeInterTile / 2*/) * i;
                _board[i,j] = Instantiate(_tile, transform.position + pos, transform.rotation);
                _board[i,j].transform.parent = transform;

                if ((i * _cols + j) % 2 == 0)
                    _board[i, j].GetComponent<SpriteRenderer>().sprite = _ligthGrassTileSprite;
                if ((i * _cols + j) == 10 || (i * _cols + j) == 1)
                    _board[i, j].GetComponent<SpriteRenderer>().sprite = _rockTileSprite;

            }
        }
    }

    private void CreateAllPiece()
    {
        CreatePiece(0, 3, Piece.BLUE_PLAYER_TAG, _tanuki);
        CreatePiece(1, 3, Piece.BLUE_PLAYER_TAG, _koropokkuru);
        CreatePiece(2, 3, Piece.BLUE_PLAYER_TAG, _kitsune);
        CreatePiece(1, 2, Piece.BLUE_PLAYER_TAG, _kodama);

        CreatePiece(0, 0, Piece.RED_PLAYER_TAG, _tanuki);
        CreatePiece(1, 0, Piece.RED_PLAYER_TAG, _koropokkuru);
        CreatePiece(2, 0, Piece.RED_PLAYER_TAG, _kitsune);
        CreatePiece(1, 1, Piece.RED_PLAYER_TAG, _kodama);
    }

    private void CreatePiece(int j, int i, bool player, GameObject pieceType)
    {

        GameObject piece = Instantiate(pieceType, transform.position, transform.rotation);
        _board[i, j].GetComponent<Tile>().PutPiece(piece);
        Piece script = (Piece)piece.GetComponent(typeof(Piece));
        if (player == Piece.RED_PLAYER_TAG)
            script.SetPlayerRed();
        else
            script.SetPlayerBlue();
    }

    public void SetObserver(EventObserver observer)
    {
        for(int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                _board[i, j].GetComponent<Tile>().SetObserver(observer);
            }
        }
    }
}
