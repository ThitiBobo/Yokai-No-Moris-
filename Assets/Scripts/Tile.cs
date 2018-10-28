using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private GameObject _piece;
    private Piece _pieceScript;
    private EventObserver _observer;
    private bool _occuped;

    public void SetObserver(EventObserver value)
    {
        _observer = value;
    }

    public void Awake()
    {
        _occuped = false;
    }

    public void PutPiece(GameObject piece)
    {
        _piece = piece;
        _pieceScript = piece.GetComponent<Piece>();
        _occuped = true;
        piece.transform.position = transform.position;
        piece.transform.parent = transform;
        Debug.Log("Tile");
    }

    public void RemovePiece()
    {

    }

    public bool SelectPiece()
    {
        if (_occuped)
        {
            
            return true;
        }
        return false;
    }

    public void UnselectPiece()
    {
        
    }

    public void OnMouseDown()
    {
        _observer.NotifyEvent(gameObject);
    }


}
