using UnityEngine;

public class MyFishMovie : MonoBehaviour
{
    public float MinSpeed = 1, MaxSpeed = 2;
    public float rotationLerp = 1;
    public float speed;
    public Transform Food;
    //delay between each speed changing
    public int speedChangeDelay = 5;
    public GameObject Effect;
    //public static int NumberOfFish = 0;
    Rigidbody Rigidbody;
    public bool FishSimulating = false;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        ChangeSpeed();
    }

    //private void OnEnable()
    //{
    //    NumberOfFish++;
    //}
    //private void OnDisable()
    //{
    //    NumberOfFish--;
    //}

    //the time interval which the speed hasn't been changed
    float NotSpeedChangedTime = 0;

    //change the speed randomly
    private void ChangeSpeed()
    {
        speed = Random.Range(MinSpeed, MaxSpeed);
    }

    //public void OnDestroy()
    //{
    //    Destroy(Food.gameObject);
    //    Instantiate(Effect, transform.position, Quaternion.identity);
    //}

    private void Update()
    {
        //movement
        if (FishSimulating)
            transform.position +=
    -transform.forward * Time.deltaTime * speed * dirToFood.magnitude;


        //timer to change speed
        NotSpeedChangedTime += Time.deltaTime;
        if (NotSpeedChangedTime > speedChangeDelay)
        {
            NotSpeedChangedTime = 0;
            ChangeSpeed();
        }
    }

    Vector3 dirToFood = Vector3.zero;
    private void FixedUpdate()
    {
        //change the direction of the fish
        if (FishSimulating)
        {
            dirToFood = Food.position - transform.position;
            transform.forward = Vector3.Lerp(transform.forward, -dirToFood, rotationLerp);
            Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, Vector3.zero, rotationLerp * 2);
        }
        else
            Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, Food.position - transform.position, rotationLerp) * speed;
    }
}