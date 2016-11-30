﻿using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {
    GridManager gm;
    PlayerBehaviour pb;
    private bool isCurrent;
    private bool isSelected;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GridManager>();
        pb = GameObject.Find("GameManager").GetComponent<PlayerBehaviour>();
        if (tag == "Start") {
            pb.startMovement(gameObject);
        }
	}

    void Update () {
        if (isCurrent) {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        else if (isSelected) {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }

    public void setCurrent(bool current) {
        isCurrent = current;
    }

    public void setSelected(bool selected) {
        Debug.Log(gameObject + ": " + selected);
        isSelected = selected;
    }

    void OnTriggerEnter(Collider other) {
        gm.addConnection(gameObject, other.gameObject);
    }

    void OnTriggerExit(Collider other) {
        gm.removeConnection(gameObject, other.gameObject);
    }
}