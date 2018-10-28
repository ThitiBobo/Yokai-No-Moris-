using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour , EventObserver {

    private Board3x4 _scriptBoard;
    private GameObject _currentTile;

    void Start() {

        _scriptBoard = GetComponentInChildren<Board3x4>();
        _scriptBoard.SetObserver(this);
    }

    void OnEnable()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void NotifyEvent(GameObject src)
    {
        if (src == _currentTile)
        {
            
            Debug.Log("délectionne");
            _currentTile.GetComponent<Tile>().UnselectPiece();
            _currentTile = null;
        }
        else
        {

            if (_currentTile != null)
            {
                _currentTile.GetComponent<Tile>().UnselectPiece();
                Debug.Log("Deselectionne l'ancienne");
            }
            if (src.GetComponent<Tile>().SelectPiece())
            {
                Debug.Log("Selectionne");
                _currentTile = src;
            }
            else
            {
                Debug.Log("il y a rien");
                if (_currentTile != null)
                {
                    _currentTile.GetComponent<Tile>().UnselectPiece();
                    _currentTile = null;
                }
                
            }
            
        }

    }
}
