using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    private bool _isMoving=false;
    private PlayerController _playerController;

    private bool _isClicking = false;

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Start()
    {
        DOTween.SetTweensCapacity(2000, 100);
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isClicking)
        {
            _isClicking = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.white);
                if (!_playerController.GameManager.CustomerController.IsAnyCustomerSelected)
                {

                    if (hit.transform.CompareTag("Table") /* || _hit.transform.CompareTag("Food") || _hit.transform.CompareTag("Trash") */)
                    {
                        if (_isMoving)
                        {
                            return;
                        }
                        else if (!_isMoving)
                        {
                            _isMoving = true;
                            var targetPos = hit.transform.GetComponent<TableBehaviour>().playerStandPoint;
                            transform.LookAt(targetPos.position);
                            transform.DOMove(targetPos.position,_playerSpeed).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() => { _isMoving = false; } );
                        }
                    }
                }
            }
        
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isClicking = false;
        }
    }
}
