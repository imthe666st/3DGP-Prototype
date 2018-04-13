using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Coinflip.Game
{
	public class GameScene
	{
		private Vector3 CameraPosition;							// Current position of the camera
		private Dictionary<Type, IList> SceneObjects;			// all current GameObjects in the scene.
		private IList BufferedSceneObjects;	// This Dictionary is used when adding new GameObjects to the Scene.

		public GameScene()
		{
			// Setting default values for all members
			CameraPosition = new Vector3();
			SceneObjects = new Dictionary<Type, IList>();
			BufferedSceneObjects = new List<GameObject>();
		}

		public void Update(GameTime gameTime)
		{
			// now update all objects.
			foreach (var type in SceneObjects.Keys)
			{
				foreach (GameObject obj in SceneObjects[type])
				{
					obj.Update(gameTime);
				}
			}

			// add the scheduled GameObjects
			foreach (GameObject obj in BufferedSceneObjects)
			{
				var type = obj.GetType();
				if (!SceneObjects.ContainsKey(type))
				{
					var listType = typeof(List<>).MakeGenericType(obj.GetType());
					var list = (IList)Activator.CreateInstance(listType);
					SceneObjects.Add(type, list);
				}

				SceneObjects[type].Add(obj);
			}
			
		}
	}
}
