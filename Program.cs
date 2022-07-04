using Casting;
using Directing;
using Scripting;
using Services;



namespace Final_Project
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to scroll a world while the player moves.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            //Instantiate the actors          
            Actor player = new Actor();
            player.SizeTo(50, 50);
            player.MoveTo(640, 480);
            player.Tint(Color.Red());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(1280, 960);
            world.MoveTo(0, 0);

            Actor enemy = new Actor();
            enemy.SizeTo(50,50);
            enemy.MoveTo(640, 480);
            enemy.Tint(Color.Blue());
            

            Camera camera = new Camera(player, screen, world);

            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("player", player);
            scene.AddActor("enemy", enemy);
            scene.AddActor("camera", camera);
            
            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Output, drawActorsAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}