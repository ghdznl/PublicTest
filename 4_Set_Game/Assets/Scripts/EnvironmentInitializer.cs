using UnityEngine;

public class EnvironmentInitializer : MonoBehaviour
{
    public MyFishMovie[] FishPrefabs;
    public FollowingObject FollowingObjectPrefab;
    public GameObject Plan;
    public int FishesCount = 10;
    public float FoodsSpeed = 10;

    private void Start()
    {
        CreateFishes();
    }

    private void Update()
    {
        //if(MyFishMovie.NumberOfFish==0)
        //{
        //    CreateFishes();
        //}
    }

    private void CreateFishes()
    {
        for (int i = 0; i < FishesCount; i++)
        {
            int ind = Random.Range(0, FishPrefabs.Length - 1);
            MyFishMovie fishMovie = Instantiate(FishPrefabs[ind],
                new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * 10,
                FishPrefabs[ind].transform.rotation);
            var food = Instantiate(FollowingObjectPrefab, Vector3.zero, Quaternion.identity);
            food.speed = FoodsSpeed;
            food.Environment = Plan.GetComponent<BoxCollider>();
            fishMovie.Food = food.transform;
        }

        //for (int j = 0; j < FishPrefabs.Length; j++)
        //{
        //    for (int i = 0; i < FishesCount; i++)
        //    {
        //        MyFishMovie fishMovie = Instantiate(FishPrefabs[j],
        //            new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * 10,
        //            FishPrefabs[j].transform.rotation);
        //        var food = Instantiate(FollowingObjectPrefab, Vector3.zero, Quaternion.identity);
        //        food.speed = FoodsSpeed;
        //        food.Environment = Plan.GetComponent<BoxCollider>();
        //        fishMovie.Food = food.transform;
        //    }
        //}
        
    }
}
