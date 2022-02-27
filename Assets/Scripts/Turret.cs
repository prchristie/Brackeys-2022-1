using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform bulletSpawnLocation;
    [SerializeField] private float shootForce;
    [SerializeField] public float shotsPerSecond;
    [SerializeField] public int bulletsPerShot;
    [SerializeField] private float spreadAngle;
    
    
    private float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime;
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        AimAtTarget(worldPosition);
    }

    public void TryFire()
    {
        if (_timer < 1 / shotsPerSecond) return;

        _timer = 0;
        
        for (int i = 0; i < bulletsPerShot; i++)
        {
            var bulletInst = Instantiate(projectile, bulletSpawnLocation.position, Quaternion.identity);
            var curAngle = transform;
            curAngle.Rotate(0, 0, Random.Range(-spreadAngle, spreadAngle));
            bulletInst.GetComponent<Rigidbody2D>().AddForce(curAngle.right * shootForce);
        }
    }

    private void AimAtTarget(Vector3 target)
    {
        var lookDir = target - transform.position;
        lookDir.z = 0;

        transform.right = lookDir;
    }
}