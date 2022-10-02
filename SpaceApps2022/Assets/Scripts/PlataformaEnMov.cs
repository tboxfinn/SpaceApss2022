using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEnMov : MonoBehaviour
{
    public GameObject ObjetoAMover;

    public Transform StartPoint;
    public Transform EndPoint;

    public float Velocidad;

    private Vector3 MoverHacia;

    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAMover.transform.position = Vector3.MoveTowards(ObjetoAMover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

        if(ObjetoAMover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }

        if (ObjetoAMover.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position;
        }
    }
}
