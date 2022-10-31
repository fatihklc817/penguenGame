using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerBehaviour : MonoBehaviour
{

    public GameObject SelectedboolBox;
    public bool Selectable=true;
    public bool IsMoving = false;

    private CustomerController _customerController;

    private FoodTypesData _mySelectedFood;

    public void Initialize(CustomerController customerController)
    {
        _customerController = customerController;
        
    }

    //when customer sits customerSittingbool turns to true
    // customer start thinking (thinking image pops)
    // customer choose a food or drink randomly then image pops
    // the food choosen enters to the food queue after estimated seconds food will come to the waitress table
    //player takes food gives it to customer
    // customer eats the food nam nam nam nam 
    // customer leaves some money and leaves


   
    //call when sat down
    public void selectFood()
    {
        List<FoodTypesData> listofFood = _customerController.GameManager.KitchenManager.FoodList;
        int randomIndex = Random.Range(0,listofFood.Count );
        _mySelectedFood = listofFood[randomIndex];
        Debug.Log(_mySelectedFood.FoodName);
        var textBallon = Instantiate(_mySelectedFood.FoodTextBalloonImage, transform.position + new Vector3(-1f,1f,0f),Quaternion.Euler(36f,180f,0f));

    }

    //call when player comes to take order
    public void GiveOrder()
    {
        Debug.Log("sipariþ verildi.");
       
    }

    public void TakeFood()
    {

    }



    public void LeaveTableAndDropMoney()
    {
        
    }

    



}
