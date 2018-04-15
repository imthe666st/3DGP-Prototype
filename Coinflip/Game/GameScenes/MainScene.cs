using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coinflip.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Singularity.Code;
using Singularity.Code.GameObjects;

namespace Coinflip.Game.GameScenes
{
	public class MainScene : GameScene
	{
		public MainScene() : base("main-scene")
		{
			this.SetCameraPosition(new Vector3(-1, 0, 0));
			this.SetAbsoluteCameraTarget(new Vector3(0, 0, 0));
		}

		protected override void AddGameObjects()
		{
			//AddObject(new BasicCamera(this));
			
			AddObject(
				new CoinObject()
					.SetScale(0.2f)
					.SetPosition(new Vector3(0, 0, -0.20f))
					.SetRotation(new Vector3(0, 0, -0.5f))
					.SetDebugName("coin")
			);


			AddObject(
				new ModelObject("coin")
					.SetPosition(new Vector3(0, 0, -0.25f))
					.SetRotation(new Vector3(0, 0, 0))
					.SetDebugName("table")
			);

		}

		public override void AddLightningToEffect(BasicEffect effect)
		{
			//effect.TextureEnabled = true;

			effect.DirectionalLight0.DiffuseColor = new Vector3(0.2f, 0.2f, 0.2f); // some diffuse light
			effect.DirectionalLight0.Direction = new Vector3(1, 0, 1);  // 
			effect.DirectionalLight0.SpecularColor = new Vector3(0.05f, 0.05f, 0.05f); // a tad of specularity]
			effect.AmbientLightColor = new Vector3(0.35f, 0.35f, 0.415f); // Add some overall ambient light.
		}
	}
}
