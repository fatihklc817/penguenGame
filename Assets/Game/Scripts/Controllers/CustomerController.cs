using DG.Tweening;
using Game.Scripts.Managers;
using Game.Scripts.Utilities;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : CustomBehaviour
{
    public bool IsAnyCustomerSelected;
    

    [SerializeField] private float _customerSpawnDelay = 5f;
    [SerializeField] private Transform _customerSpawnPosition;
    [SerializeField] private Transform _customerQueuePositionOne;
    [SerializeField] private Transform _customerQueuePositionTwo;
    [SerializeField] private Transform _customerQueuePositionThree;
    [SerializeField] private GameObject _customerPrefab;
    
    private CustomerBehaviour _selectedCustomer;
    private GameObject _queueFirstPosCustomer;
    private GameObject _queueSecondPosCustomer;
    private GameObject _queueThirdPosCustomer;

    private bool _isQueueFirstPosFilled;
    private bool _isQueueSecondPosFilled;
    private bool _isQueueThirdPosFilled;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        InvokeRepeating("GetNewCustomerToRestaurant", 1f, _customerSpawnDelay);
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.white);
                if (_selectedCustomer == null)
                {
                    if (hit.transform.CompareTag("Customer"))
                    {
                        if (hit.transform.GetComponent<CustomerBehaviour>().Selectable == true )
                        {

                        _selectedCustomer = hit.transform.GetComponent<CustomerBehaviour>();
                        _selectedCustomer.SelectedboolBox.SetActive(true);
                            IsAnyCustomerSelected = true;
                        
                        Debug.Log("m��teri se�ildi. Masa se�in");

                        }
                    }


                }
                if (_selectedCustomer != null)
                {
                    if (hit.transform.CompareTag("Table"))
                    {
                        var targetPos = hit.transform.GetComponent<TableBehaviour>().CustomerStandPosition;
                        if (!_selectedCustomer.IsMoving)
                        {
                            
                             StartCoroutine(changeIsAnyCustomerSelectedBoolToFalseCO());
                            _selectedCustomer.SelectedboolBox.SetActive(false);
                            _selectedCustomer.IsMoving = true;
                            _selectedCustomer.transform.LookAt(targetPos);
                            _isQueueFirstPosFilled = false;
                            _queueFirstPosCustomer = null;
                            MoveQueue();
                            _selectedCustomer.transform.DOMove(targetPos.position, 10f).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() =>
                                {
                                _selectedCustomer.Selectable = false;
                                    _selectedCustomer.transform.LookAt(targetPos.parent.position);
                                    _selectedCustomer = null; 
                                });

                        }
                        else if(_selectedCustomer.IsMoving)
                        {
                            return;
                        }
                    }
                }




            }



        }
        
    }

    IEnumerator changeIsAnyCustomerSelectedBoolToFalseCO()
    {
        yield return new WaitForSeconds(0.2f);
        IsAnyCustomerSelected = false;
    }

    private void GetNewCustomerToRestaurant()
    {
        Debug.Log("yeni m��teri geldi");
       var currentCustomer = Instantiate(_customerPrefab,_customerSpawnPosition);
        if (!_isQueueFirstPosFilled)
        {
            currentCustomer.transform.DOMove(_customerQueuePositionOne.position, 1f);
            _isQueueFirstPosFilled = true;
            _queueFirstPosCustomer = currentCustomer;

        }
        else if (!_isQueueSecondPosFilled)
        {
            currentCustomer.transform.DOMove(_customerQueuePositionTwo.position, 1f);
            _isQueueSecondPosFilled= true;
            _queueSecondPosCustomer = currentCustomer;
        }
        else if (!_isQueueThirdPosFilled)
        {
            currentCustomer.transform.DOMove(_customerQueuePositionThree.position, 1f);
            _isQueueThirdPosFilled = true;
            _queueThirdPosCustomer = currentCustomer;
        }
    }

    private void MoveQueue()
    {
        if (_queueSecondPosCustomer != null)
        {
            _queueSecondPosCustomer.transform.DOMove(_customerQueuePositionOne.position, 1f);
            _isQueueSecondPosFilled = false;
            _isQueueFirstPosFilled=true;
            _queueFirstPosCustomer = _queueSecondPosCustomer;
            _queueSecondPosCustomer = null;
        }

        if (_queueThirdPosCustomer != null)
        {
            _queueThirdPosCustomer.transform.DOMove(_customerQueuePositionTwo.position, 1f);
            _isQueueThirdPosFilled=false;
            _isQueueSecondPosFilled = true;
            _queueSecondPosCustomer = _queueThirdPosCustomer;
            _queueThirdPosCustomer= null;
        }
    }
}
