using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnterUI : MonoBehaviour
{
    [Header("游戏对象")]
    public GameObject player;

    [Tooltip("X轴值")]
    public float CamerX = 0.0f;
    [Tooltip("Y轴值")]
    public float CamerY = 0.0f;

    [Header("X轴")]
    [Tooltip("X轴旋转速度")]
    public float X_Speed = 1.5f;
    [Tooltip("X轴最小角度")]
    public float X_MinLimity = -360;
    [Tooltip("X轴最大角度")]
    public float X_MaxLimity = 360;


    [Header("Y轴")]
    [Tooltip("Y轴旋转速度")]
    public float Y_Speed = 1.5f;
    [Tooltip("Y轴最小角度")]
    public float Y_MinLimity = -20;
    [Tooltip("Y轴最大角度")]
    public float Y_MaxLimity = 20;


    [Header("摄像机距离")]
    public float CameMouse = 1.1f;
    [Tooltip("摄像机速度")]
    public float MouseSpeed = 1f;
    [Tooltip("视角最小值")]
    public float MouseMin = 1.1f;
    [Tooltip("视角最大值")]
    public float MouseMax = 3f;

    [Header("插值")]
    [Tooltip("启用")]
    public bool isNeedDamping = false;
    [Tooltip("速度值")]
    public float CameraSpeed = 2.5f;

    private void LateUpdate()
    {
        CamerX += Input.GetAxis("Mouse X") * X_Speed;
        CamerY -= Input.GetAxis("Mouse Y") * Y_Speed;
        CamerX = ClampAngle(CamerX, X_MinLimity, X_MaxLimity);
        CamerY = ClampAngle(CamerY, Y_MinLimity, Y_MaxLimity);
        Quaternion Rotation = Quaternion.Euler(CamerY, CamerX, 0);
        Vector3 Position = Rotation * new Vector3(0.0f, 0.0f) + this.player.transform.position;

        if (isNeedDamping)
        {
            this.player.transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * CameraSpeed);    //球形插值
            this.player.transform.position = Vector3.Lerp(transform.position, Position, Time.deltaTime * CameraSpeed); //线性插值
        }
        else
        {
            this.player.transform.rotation = Rotation;
            this.player.transform.position = Position;
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
