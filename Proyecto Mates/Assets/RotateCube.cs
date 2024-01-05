using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    public float velocidadRotacion = 50f;
    public Text quaternionesText;
    public Text eulerText;
    public Text rotationVectorText;
    public Text rotationAxisText;
    public Text rotationMatrixText;

    public Quaternion quaternionesValor = Quaternion.identity;
    public Vector3 eulerValor = Vector3.zero;
    public Vector3 rotationVectorValor = Vector3.zero;
    public Vector3 rotationAxisValor = Vector3.zero;
    public Matrix4x4 rotationMatrixValor = Matrix4x4.identity;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializar los valores desde la rotación inicial
        ActualizarInformacion();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // Restablecer las rotaciones a 0 cuando se presiona la tecla R
            transform.rotation = Quaternion.identity;
            ActualizarInformacion();
        }
        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotar el cubo con las teclas de flecha
            float rotacionX = Input.GetKey(KeyCode.UpArrow) ? velocidadRotacion * Time.deltaTime : (Input.GetKey(KeyCode.DownArrow) ? -velocidadRotacion * Time.deltaTime : 0f);
            float rotacionY = Input.GetKey(KeyCode.RightArrow) ? velocidadRotacion * Time.deltaTime : (Input.GetKey(KeyCode.LeftArrow) ? -velocidadRotacion * Time.deltaTime : 0f);
            transform.Rotate(Vector3.right, rotacionX);
            transform.Rotate(Vector3.up, rotacionY);

            // Actualizar las variables desde la rotación actual
            ActualizarInformacion();
        }
    }

    private void ActualizarInformacion()
    {
        // Actualizar las variables desde la rotación actual
        quaternionesValor = transform.rotation;
        eulerValor = transform.eulerAngles;
        rotationVectorValor = transform.rotation.eulerAngles;
        rotationAxisValor = transform.rotation.eulerAngles;
        rotationMatrixValor = Matrix4x4.Rotate(transform.rotation);

        // Actualizar los textos en los paneles
        quaternionesText.text = $"Quaterniones: {quaternionesValor.ToString("F2")}";
        eulerText.text = $"Ángulo y Eje principal de Euler: {eulerValor.ToString("F2")}";
        rotationVectorText.text = $"Ángulos de Euler: {rotationVectorValor.ToString("F2")}";
        rotationAxisText.text = $"Vector de rotación: {rotationAxisValor.ToString("F2")}";
        rotationMatrixText.text = $"Matriz de rotación: {rotationMatrixValor.ToString("F2")}";
    }


    public void SetQuaternionesValue()
    {
        transform.rotation = quaternionesValor;
        ActualizarInformacion();
    }
    public void SetEulerValue()
    {
        transform.eulerAngles = eulerValor;
        ActualizarInformacion();
    }
    public void SetRotationVectorValue()
    {
        Quaternion newRotation = Quaternion.Euler(rotationVectorValor);
        transform.rotation = newRotation;
        ActualizarInformacion();
    }

    public void SetRotationAxisValue()
    {
        Quaternion newRotation = Quaternion.Euler(rotationAxisValor);
        transform.rotation = newRotation;
        ActualizarInformacion();
    }

}





