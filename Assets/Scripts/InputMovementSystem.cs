using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.Physics;

public class InputMovementSystem : SystemBase
{

    AudioSource hyperspace;

    protected override void OnCreate()
    {
        hyperspace = GameObject.Find("HyperSpace").GetComponent<AudioSource>();
        RequireSingletonForUpdate<GameSettingsComponent>();
    }

    protected override void OnUpdate()
    {

        var gameSettings = GetSingleton<GameSettingsComponent>();
        var deltaTime = Time.DeltaTime;


        byte right, left, thrust, reverseThrust;
        right = left = thrust = reverseThrust = 0;

        float mouseX = 0;
        float mouseY = 0;



    
        if (Input.GetKeyDown("w"))
        {
            thrust = 1;
            hyperspace.Play();
        }


        if (Input.GetKeyDown("s"))
        {
            reverseThrust = 1;
            hyperspace.Play();
        }

        if (Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

        }

        Entities
        .WithAll<PlayerTag>()
        .ForEach((Entity entity, int nativeThreadIndex, ref Rotation rotation, ref PhysicsVelocity velocity, ref Translation pos) =>
        {
            if (thrust == 1)
            {
                pos.Value.z += 5f;
            }
            if (reverseThrust == 1)
            {
                pos.Value.z -= 5f;
            }
            if (mouseX != 0 || mouseY != 0)
            {   
                float lookSpeedH = 2f;
                float lookSpeedV = 2f;

                //
                Quaternion currentQuaternion = rotation.Value;
                float yaw = currentQuaternion.eulerAngles.y;
                float pitch = currentQuaternion.eulerAngles.x;

                yaw += lookSpeedH * mouseX;
                pitch -= lookSpeedV * mouseY;
                Quaternion newQuaternion = Quaternion.identity;
                newQuaternion.eulerAngles = new Vector3(pitch, yaw, 0);
                rotation.Value = newQuaternion;
            }
        }).ScheduleParallel();
    }
}