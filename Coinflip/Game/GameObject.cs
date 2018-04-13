using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coinflip.Game
{
	/// <summary>
	/// A GameObject can be any object in a GameScene.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class GameObject
	{
		private Vector3 Position;		// Current position of the model
		private Vector3 Rotation;		// Current rotation of the model
		private float Scale;			// Scale of the model

		public GameObject()
		{
			// Setting default values for all members
			this.Position = new Vector3();
			this.Rotation = new Vector3();
		}

		// Methods for the builder pattern

		#region Builder Pattern
		public GameObject SetPosition(Vector3 position)
		{
			this.Position = position;
			return this;
		}
		public GameObject SetRotation(Vector3 rotation)
		{
			this.Rotation = rotation;
			return this;
		}
		public GameObject SetScale(float scale)
		{
			this.Scale = scale;
			return this;
		}
		#endregion

		#region Abstract Methods

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch spriteBatch);

		#endregion

	}
}
