using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject player;
    [SerializeField] public GameObject bulletPrefab;
    GameObject projectile;

    float timeUntilFire;
    PlayerMovement pm;
    private GameObject clone;

    public Animator animator;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && timeUntilFire < Time.time)
        {
            Shoot();
            animator.Play("Attack");
            timeUntilFire = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        Vector3 position = transform.position;
        projectile = Pool.Instance.GetFromPool();
        projectile.transform.position = position;

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Transform>().localScale.x*10,0);
    }
}
