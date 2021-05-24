using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/MapChip", fileName = "Mapchipset")]

public class MapObjectSet : ScriptableObject
{
    public GameObject space;
    public GameObject field;
    public GameObject fukku;
    public GameObject hikkake;
    public GameObject dontEnter;
    public GameObject wana;
    public GameObject player;
    public GameObject start;
    public GameObject enemy;
}
