using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AnimationController animationController;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            animationController.SetBoolean("Died",true);
            Destroy(gameObject,4f);
            UIManager.instance.ActivateRestartButton();
        }
    }
}
