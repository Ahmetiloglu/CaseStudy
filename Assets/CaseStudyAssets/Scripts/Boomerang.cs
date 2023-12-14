using TMPro;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    enum State { Idle, Attack}

    [Header("Settings")] 
    [SerializeField] private float searchRadius;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Transform pocket;
    [SerializeField] private float moveSpeed;
    private State state;
    private Transform targetEnemy;

    public TextMeshProUGUI KillCounter;
    public int AmountofKill = 0;
    
    
    
    
    
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                SearchForTarget(); 
                break;
            case State.Attack:
                AttackTowardsTarget();
                break;
            
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length;i++)
        {
            if (detectedColliders[i].TryGetComponent(out Enemy enemy))
            {
                if (enemy.IsTarget())   
                    continue;

                enemy.SetTarget();
                targetEnemy = enemy.transform;
            
                StartAttackTowardsTarget();           
            }
        }        
    }

    private void StartAttackTowardsTarget()
    {
        // switch state func.
        state = State.Attack;
    }


    private void AttackTowardsTarget()
    {
        if (targetEnemy == null)
            return;

        transform.position =
            Vector3.MoveTowards(transform.position, targetEnemy.position, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetEnemy.position) < .1f)
        {
            AmountofKill++;
            KillCounter.text = "" + AmountofKill;
            Destroy(targetEnemy.gameObject,1f);
            transform.position = Vector3.MoveTowards(transform.position, pocket.position, moveSpeed);
            state = State.Idle;
        }
    }
    
}
