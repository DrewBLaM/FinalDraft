using System;
using System.Collections.Generic;
using Casting;
using Scripting;
using Services;


namespace Final_Project
{
    /// <summary>
    /// Moves the player within the game world while scrolling the screen.
    /// </summary>
    public class MovePlayerAction : Scripting.Action
    {
        public MovePlayerAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                Actor player = scene.GetFirstActor("player");
                
                // move the player and clamp it to the boundaries of the world.
                player.Move();
                player.ClampTo(world);    
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}