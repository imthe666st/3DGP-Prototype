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
		}

		protected override void AddGameObjects()
		{
			//AddObject(new BasicCamera(this).AddScript((a, b, c) => ((BasicCamera)b).Set3DEnabled(true)));
			
			AddObject(
				new CoinObject()
					.SetScale(0.1f)
					.SetPosition(new Vector3(0, 0, 0.12f))
					.SetRotation(new Vector3(0, 0, -0.5f))
					.SetDebugName("coin")
			);


			AddObject(
				new ModelObject("dae_table")
					.SetScale(0.75f)
					.SetPosition(new Vector3(0, 0, 0)) // the scale of the model seems to be wrong. No idea what's causing that. 
					.SetRotation(new Vector3(0, 0, 0))
					.SetDebugName("table")
			);

		}

		public override void AddLightningToEffect(BasicEffect effect)
		{
			//effect.TextureEnabled = true;
			effect.LightingEnabled = true;
			effect.DirectionalLight0.DiffuseColor = new Vector3(0.2f, 0.2f, 0.2f); // some diffuse light
			effect.DirectionalLight0.Direction = new Vector3(1, 0, -2);  // 
			effect.DirectionalLight0.SpecularColor = new Vector3(0.05f, 0.05f, 0.05f); // a tad of specularity]
			effect.AmbientLightColor = new Vector3(0.55f, 0.55f, 0.715f); // Add some overall ambient light.
		}
	}
}
