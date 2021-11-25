using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private bool mainScene;
    public GameObject[] cars;
    private float startSpawn =0.5f, waitSpaw = 1f;
    private int countCars=0;
    private bool onceStop;
    private void Start()
    {
        StartCoroutine(westCars());
        StartCoroutine(eastCars());
        StartCoroutine(northCars());
        StartCoroutine(southCars());

        CollisionCars.lose = false;

        waitSpaw = mainScene?7f:3f;
    }
    private void Update()
    {
        if (!mainScene)
        {

            if (countCars > 40)
            {
                waitSpaw = 1f;
            }
            else if (countCars > 30)
            {
                waitSpaw = 1.5f;
            }
            else if (countCars > 20)
            {
                waitSpaw = 2f;
            }
        }
        if(CollisionCars.lose&&!onceStop)

        {
            StopAllCoroutines();
            onceStop = true;
        }
    }
    IEnumerator westCars()
        {
            yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)],
                new Vector3(-87.3f, -0.33f, 2.9f),
                Quaternion.Euler(new Vector3(0,-90f,0))) as GameObject;
            countCars++;
            int rand = mainScene ? 2 : Random.Range(0, 5);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<WestTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<WestTurnRight>();
                    break;
                
            }
            yield return new WaitForSeconds(Random.Range(waitSpaw, waitSpaw + 5f));

        }
        }
    IEnumerator eastCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)],
                new Vector3(24.4f, -0, 10.9f),
                Quaternion.Euler(new Vector3(0, 90f, 0))) as GameObject;
            countCars++;
            int rand = mainScene ? 2 : Random.Range(0, 5);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<EastTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<EastTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpaw, waitSpaw + 5f));

        }
    }
    IEnumerator northCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)],
                new Vector3(-7.1f, 0, 63.5f),
                Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            countCars++;
             int rand = mainScene ? 2 : Random.Range(0, 5);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<NorthTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<NorthTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpaw, waitSpaw + 5f));

        }
    }
    IEnumerator southCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            //создаем машину в точке
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)],
                new Vector3(-1.5f, 0, -23.7f),
                Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
            int rand = mainScene ? 2 : Random.Range(0, 5);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<SouthTurnLeft>();
                    break;
                case 2:
                    carInst.AddComponent<SouthTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpaw, waitSpaw + 5f));

        }
    }
}

