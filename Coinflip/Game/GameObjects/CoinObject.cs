using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Singularity.Code;

namespace Coinflip.Game.GameObjects
{
	public class CoinObject : GameObject
	{

		private Boolean IsThrown = false;
		private float PassedThrowTime = 0.0f;
		private float RotationSpeed = -1.0f;

		private float StartHeight;

		private static readonly float GRAVITY = 1f; // good enough

		private Vector3 StartVector;

		public CoinObject() : base()
		{
			this.SetModel(ModelManager.GetModel("coin"));
		}

		public override void Update(GameScene scene, GameTime gameTime)
		{
			if (!IsThrown)
			{
				// this is the first frame of the scene
				// or this coin has just been spawned.

				IsThrown = true;

				this.StartHeight = this.GetHierarchyPosition().Z;

				// generate a random
				var random = new Random();

				// set the rotation speed and z rotation

				this.RotationSpeed = ((float) random.NextDouble()) * MathHelper.TwoPi;
				this.AddRotation(new Vector3(0, 0, ((float) random.NextDouble()) * MathHelper.TwoPi));

			}

			// 
			var deltaHeight = (float) (-GRAVITY / 2f * (2 * this.PassedThrowTime * gameTime.ElapsedGameTime.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds * gameTime.ElapsedGameTime.TotalSeconds) + 2f * gameTime.ElapsedGameTime.TotalSeconds);

			if (this.Position.Z + deltaHeight < this.StartHeight)
			{
				this.SetPosition(new Vector3(this.StartVector.X, this.StartVector.Y, this.StartHeight));
				// end stuff



				return;
			}

			this.AddPosition(new Vector3(0, 0, deltaHeight));

			this.AddRotation(new Vector3(this.RotationSpeed, 0, 0));

			

			//this.SetPosition(new Vector3(0, 0, 0.1f));
			scene.SetAbsoluteCameraTarget(new Vector3(this.GetHierarchyPosition().X, this.GetHierarchyPosition().Z, this.GetHierarchyPosition().Y));
			scene.SetCameraPosition(new Vector3(this.GetHierarchyPosition().X, (float) Math.Sqrt(this.GetHierarchyPosition().Y), this.GetHierarchyPosition().Z));

			this.PassedThrowTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

			//scene.SetAbsoluteCameraTarget(this.Position);
			scene.SetCameraPosition(this.Position - new Vector3(-2, 0, 0));


		}
	}
}
