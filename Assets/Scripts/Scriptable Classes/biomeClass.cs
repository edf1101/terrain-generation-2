using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// struct for biome description we use this is the c# version to convert between c# and hlsl
[System.Serializable]

[CreateAssetMenu(fileName = "Biome Preset", menuName = "Scriptables/Biome Preset",order =1)]
public class biomeDescription : ScriptableObject
{
    [Header("Basic Settings")]
    public string biomeName;
    public int id;
    public string[] terrainGenTypes;


    [Header("Required Conditions")]
    public Vector2 tempRange;
    public Vector2 humRange;

    [Header("Colours")]
    public Color debugColour;
    public Gradient steepColour; // for cliff edges etc
    public Gradient steepSomewhatColour; // for almost cliff edges etc
    public Gradient lowColour; // usually for underwater or beach
    public Gradient highColour; // for high up eg mountain top
    public Gradient normalColour; // for flat terrain etc

    [Header("Tree settings")]
    public float treePercentage;
    public GameObject[] treeObjects;
    public float clearingThresh; // for object to be placed noise must be above this
    public float extraTreeHeight;

    [Header("Object settings")]
    public float objectPercentage;
    public GameObject[] objectObjects;

    [Header("Weather settings")]
    public float biomeHumidity;
    public Color particleCol;


    [Header("Sound Data")]
    public AudioClip weatherSound;
    public AudioClip footStepSound;
}


// Need to pass biomeDescription to compute shaders at some point
// but classes arent blittable so we create this slightly lighter struct that
// holds the essential data that we need for that shader and pass it in instead
[System.Serializable]
public struct BiomeDescriptionBlittable
{
    public int id;
    public Vector2 tempRange;
    public Vector2 humRange;
    public Color debugColour;

    public BiomeDescriptionBlittable(int _id, Vector2 _tempRange, Vector2 _humRange,Color _debugCol)
    {
        id = _id;
        tempRange = _tempRange;
        humRange = _humRange;
        debugColour = _debugCol;
    }
}
