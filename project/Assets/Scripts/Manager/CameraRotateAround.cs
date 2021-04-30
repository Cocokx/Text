using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public Transform target;//主相机要围绕其旋转的物体 
    public float distance = 7.0f;//主相机与目标物体之间的距离 
    private float eulerAngles_x;
    private float eulerAngles_y;
    //水平滚动相关 
    public int distanceMax = 10;//主相机与目标物体之间的最大距离 
    public int distanceMin = 3;//主相机与目标物体之间的最小距离 
    public bool invertY = false;
    public float xSpeed = 70.0f;//主相机水平方向旋转速度 

    //垂直滚动相关 
    public int yMaxLimit = 60;//最大y（单位是角度） 
    public int yMinLimit = -10;//最小y（单位是角度） 
    public float ySpeed = 70.0f;//主相机纵向旋转速度 

    //滚轮相关 
    public float MouseScrollWheelSensitivity = 1.0f;//鼠标滚轮灵敏度（备注：鼠标滚轮滚动后将调整相机与目标物体之间的间隔） 
    public LayerMask CollisionLayerMask;


    public GameObject cameraon;//初始摄像机的位置
    public GameObject camerto;//另一个点的位置
    private float speed = 1f;//缓冲的时间  时间越大缓冲速度越慢
    private Vector3 velocity;//如果是3D场景就用Vector3,2D用Vector2

    void Start()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;//当前物体的欧拉角 
        this.eulerAngles_x = eulerAngles.y;
        this.eulerAngles_y = eulerAngles.x;
    }

    void LateUpdate()
    {
        if (this.target != null)
        {
            Move();
            //if (Input.GetMouseButton(1))
            //{
            //    camerarotate();
            //}
            //this.eulerAngles_x += ((Input.GetAxis("Mouse X") * this.xSpeed) * this.distance) * 0.02f;
            //this.eulerAngles_y -= (Input.GetAxis("Mouse Y") * this.ySpeed) * 0.02f;
            //this.eulerAngles_y = ClampAngle(this.eulerAngles_y, (float)this.yMinLimit, (float)this.yMaxLimit);

            //Quaternion quaternion = Quaternion.Euler(this.eulerAngles_y, this.eulerAngles_x, (float)0);
            //this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);


            ////从目标物体处，到当前脚本所依附的对象（主相机）发射一个射线，如果中间有物体阻隔，则更改this.distance（这样做的目的是为了不被挡住） 
            //RaycastHit hitInfo = new RaycastHit();

            //if (Physics.Linecast(this.target.position, this.transform.position, out hitInfo, this.CollisionLayerMask))
            //{
            //    this.distance = hitInfo.distance - 0.05f;
            //}

            ////Vector3 vector = ((Vector3)(quaternion * new Vector3((float)0, (float)0, -this.distance))) + this.target.position;

            ////更改主相机的旋转角度和位置
            //this.transform.rotation = quaternion;
            ////this.transform.position = vector;
        }
    }
    private void Move()
    {
        cameraon.transform.position = new Vector3(Mathf.SmoothDamp(cameraon.transform.position.x, camerto.transform.position.x,
                ref velocity.x, speed), Mathf.SmoothDamp(cameraon.transform.position.y, camerto.transform.position.y,
                ref velocity.y, speed), Mathf.SmoothDamp(cameraon.transform.position.z, camerto.transform.position.z, ref velocity.z, speed));
    }
    private void camerarotate() //摄像机围绕目标旋转操作
    {
        var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * (invertY ? 1 : -1));
        transform.RotateAround(target.position, Vector3.up* Input.GetAxis("Mouse X"), ySpeed * Time.deltaTime); //摄像机围绕目标旋转
        //var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        //var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    transform.Translate(Vector3.left * (mouse_x * 15f) * Time.deltaTime);
        //    transform.Translate(Vector3.up * (mouse_y * 15f) * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    transform.RotateAround(target.transform.position, Vector3.up, mouse_x * 5);
        //    transform.RotateAround(target.transform.position, transform.right, mouse_y * 5);
        //}
    }

    //把角度限制到给定范围内 
    public float ClampAngle(float angle, float min, float max)
    {
        while (angle < -360)
        {
            angle += 360;
        }
        while (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
