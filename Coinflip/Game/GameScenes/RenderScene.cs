using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coinflip.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Singularity.Code;
using Singularity.Code.GameObjects;

namespace Coinflip.Game.GameScenes
{
	public class RenderScene : GameScene
	{
		public RenderScene() : base("render-scene")
		{
		}

		protected override void AddGameObjects()
		{
			// add a camera
			AddObject(new BasicCamera(this).AddScript((scene, obj, gameTime) =>
			{
				if (KeyboardManager.IsKeyDown(Keys.F1)) ((BasicCamera) obj).Set3DEnabled(!((BasicCamera)obj).Is3DEnabled);
			}));

			AddObject(new ModelObject("dae_coin2").SetScale(10.0f));

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
