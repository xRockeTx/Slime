using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public TextMeshProUGUI SlimesAmountText;
    private Following Following;
    private bool isFollow=false;
    public GameObject Slime,SuperSlime;
    public float Force=10f,Firerate=.4f;
    public int SlimesAmount=20, FirstSlimesAmount=20;
    private float currentFirerent=0;
    public Rating Rating;

    public void Awake()
    {
        SlimesAmount = FirstSlimesAmount;
        SlimesAmountText.text = SlimesAmount.ToString();
        if (gameObject.TryGetComponent<Following>(out Following followingComponent))
        {
            isFollow = transform;
            Following = followingComponent;
        }
    }

    private void Update()
    {
        if(currentFirerent<Firerate)
        {
            currentFirerent += Time.deltaTime;
        }
        if (SlimesAmount > 0 && currentFirerent >= Firerate)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                currentFirerent = 0;
                Shoot(Slime);
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                currentFirerent = 0;
                Shoot(SuperSlime);
            }
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
