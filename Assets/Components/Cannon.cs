using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float Force=10f,Firerate=.4f;

    private float currentFirerent=0;
    private Rating Rating;
    [HideInInspector] public bool canShoot;
    public int SlimesAmount = 20;
    [HideInInspector] public GameObject CurrentSlime;
    [HideInInspector] public TextMeshProUGUI SlimesAmountText;
    [HideInInspector] public Following Following;
    [HideInInspector] public bool isFollow=false;

    public void Awake()
    {
        if (gameObject.TryGetComponent<Following>(out Following followingComponent))
        {
            isFollow = transform;
            Following = followingComponent;
        }
        canShoot = true;
    }
    public void Start()
    {
        Rating = Rating.instance;
        Rating.SlimesAmountText.text = SlimesAmount.ToString();
        SlimesAmountText = Rating.SlimesAmountText;
        AttractivePanel.instance.Cannons+=Attract;
    }

    private void Update()
    {
        if(currentFirerent<Firerate)
        {
            currentFirerent += Time.deltaTime;
        }
        
    }
    public void Attract()
    {
        if (SlimesAmount > 0 && currentFirerent >= Firerate && canShoot)
        {
            currentFirerent = 0;
            Shoot(CurrentSlime);
        }
    }
    private void Shoot(GameObject shootObject)
    {
        Vector2 direction;
        if (isFollow)
        {
            direction = Following.Direction;
        }
        else
        {
            direction = transform.up;
        }

        GameObject gameObject = Instantiate(shootObject);
        gameObject.transform.position = transform.position;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction*Force);

        if(gameObject.TryGetComponent<Magnetic>(out Magnetic magnetic))
        {
            magnetic.Cannon = this;
            magnetic.Initialize();
        }

        SlimesAmount--;
        SlimesAmountText.text = SlimesAmount.ToString();

        if (SlimesAmount == 0)
        {
            StartCoroutine(LastShootWait());
        }
    }

    public IEnumerator LastShootWait()
    {
        yield return new WaitForSeconds(7);
        Rating.SendInfo();
    }
}
