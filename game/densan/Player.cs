using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace densan
{
    class Player
    {
        private Vector2 position;
        private Vector2 velosity;
        private string name;
        //private bool isDesd;プレイヤーが死ぬ設定ならば使う

        public Player()
        {
            //positiom = new Vector2(初期座標);
            velosity = new Vector2(0, 0);
            name = "player";
            //isDesd = false;
        }

        //操作や移動量
        public void Update(GameTime gameTime)
        {
            velosity = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velosity.X = 1.0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velosity.X = -1.0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                velosity.Y = -1.0f;
            }

            float speed = 5.0f;
            position = position + velosity * speed;

            if (velosity.Length() != 0)
            {
                velosity.Normalize();
            }
        }

        //描画処理
        //public void Drow(Renderer renderer)
        //{
        //    renderer.DrawTexture(name, position);
        //}

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
