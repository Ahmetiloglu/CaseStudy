
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody EnemyRigidbody;
    public GameObject Target;
    public GameObject Bullet;
    public float BulletSpeed;

    private bool seePlayer = false;
    private bool isTarget;
    private bool isAnyBullet = false;
    

    [SerializeField] private AnimationController animationController;
    

    void Start()
    {
        
    }

  
    void Update()
    {
        // detect player
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if (HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else
        {
            Attack();
            if (Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Diraction = Heading / Distance;
                    
                    
                    Vector3 Move = new Vector3(Diraction.x * moveSpeed, 0, Diraction.z * moveSpeed);
                    EnemyRigidbody.velocity = Move;
                    transform.forward = Move;
                }
            }
        }
    }


    private void Attack()
    {
        if (Vector3.Distance( Target.transform.position ,transform.position) < 4f) // 4f is range of attack, is bigger then player's
        {
            moveSpeed = 0;
            animationController.SetBoolean("Onzone",true);
            if (isAnyBullet == false)
            {
             //   Vector3 x = Target.transform.position - transform.position;
             //   float angle = Mathf.Atan2(x.z, x.x) * Mathf.Rad2Deg;
             //   transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject newbullet = Instantiate(Bullet, transform.position, transform.rotation);
                newbullet.GetComponent<Rigidbody>().velocity = Target.transform.position * BulletSpeed;
                isAnyBullet = true;
                Destroy(newbullet,4f);
            }
            
        }
        else
        {
            moveSpeed = 2;
            isAnyBullet = false;
            animationController.SetBoolean("Onzone",false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Boomerang"))
        {
            animationController.SetBoolean("Onzone",false);
            animationController.SetBoolean("Dead",true);
        }
    }
    
    
    

    public void SetTarget()
    {
        isTarget = true;
    }

    public bool IsTarget()
    {
        return isTarget;
    }
}
