using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Singularity.Code;

namespace Coinflip.Game.GameObjects
{
	public class CoinObject : GameObject
	{

		private Boolean IsThrown = false;
		private Boolean IsFinished = false;

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
			if (IsFinished)
			{
				if (!KeyboardManager.IsKeyDown(Keys.R))
					return;

				// reset.

				this.SetPosition(this.StartVector);

				this.PassedThrowTime = 0.0f;

				this.IsThrown = false;
				this.IsFinished = false;
			}

			if (!IsThrown)
			{
				// this is the first frame of the scene
				// or this coin has just been spawned.

				IsThrown = true;

				this.StartHeight = this.GetHierarchyPosition().Z;

				this.StartVector = this.GetHierarchyPosition();

				// generate a random
				var random = new Random();

				// set the rotation speed and z rotation

				this.RotationSpeed = ((float) random.NextDouble()) * MathHelper.TwoPi * 100f;
				this.AddRotation(new Vector3(0, 0, ((float) random.NextDouble()) * MathHelper.TwoPi));

			}

			// 
			var deltaHeight = (float) (-GRAVITY / 2f * (2 * this.PassedThrowTime * gameTime.ElapsedGameTime.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds * gameTime.ElapsedGameTime.TotalSeconds) + 2f * gameTime.ElapsedGameTime.TotalSeconds);

			if (this.Position.Z + deltaHeight < this.StartHeight)
			{
				this.SetPosition(new Vector3(this.StartVector.X, this.StartVector.Y, this.StartHeight));
				// end stuff

				float modRotation = this.Rotation.X;
				while (modRotation > MathHelper.TwoPi) modRotation -= MathHelper.TwoPi;

				var tolerance = 0.025f;

				Console.WriteLine($"{modRotation}");
				if (modRotation > MathHelper.PiOver2 - tolerance && modRotation < MathHelper.PiOver2 + tolerance)
				{
					this.SetRotation(new Vector3(MathHelper.PiOver2, 0, this.Rotation.Z));
					this.AddPosition(new Vector3(0, 0, this.Scale / 2f));
				}
				else if (modRotation > 3 * MathHelper.PiOver2 - tolerance && modRotation < 3 * MathHelper.PiOver2 + tolerance)
				{
					this.SetRotation(new Vector3(3 * MathHelper.PiOver2, 0, this.Rotation.Z));
					this.AddPosition(new Vector3(0, 0, this.Scale / 2f));
				}
				else if (modRotation > MathHelper.PiOver2 + tolerance && modRotation < 3 * MathHelper.PiOver2 - tolerance)
				{
					this.SetRotation(new Vector3(MathHelper.Pi, 0, this.Rotation.Z));
					this.AddPosition(new Vector3(0, 0, 0));
				}
				else
				{
					this.SetRotation(new Vector3(0, 0, this.Rotation.Z));
					this.AddPosition(new Vector3(0, 0, 0));
				}

				this.IsFinished = true;

				return;
			}

			this.AddPosition(new Vector3(0, 0, deltaHeight));


			//this.SetRotation(new Vector3(MathHelper.PiOver2, 0, 0));
			this.AddRotation(new Vector3(this.RotationSpeed, 0, 0) * (float) gameTime.ElapsedGameTime.TotalSeconds);

			

			//this.SetPosition(new Vector3(0, 0, 0.1f));
			scene.SetAbsoluteCameraTarget(new Vector3(this.GetHierarchyPosition().X, this.GetHierarchyPosition().Z, this.GetHierarchyPosition().Y));
			scene.SetCameraPosition(new Vector3(this.GetHierarchyPosition().X - 1.15f, (float) Math.Sqrt(Math.Abs(this.GetHierarchyPosition().Y)) + 0.55f, this.GetHierarchyPosition().Z));

			this.PassedThrowTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

			//scene.SetAbsoluteCameraTarget(this.Position);
			//scene.SetCameraPosition(this.Position - new Vector3(-2, 0, 0));


		}
	}
}
