using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName ="FoodData",menuName ="Game/FoodData") ]
public class FoodTypesData : ScriptableObject
{
    public string FoodName;
    public GameObject FoodModel;
    public GameObject FoodTextBalloonImage;
    public float TimeToCook;
    public float Prize;

}
