using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace Collision
{
    class Renderer
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        

        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        ///<summary>
        ///画像読み込み
        ///</summary>
        ///<param name="assetName">アセット名</param>
        ///<param name="filepath">ファイルパス</param>

        public void LoadContent(string assetName,string filepath="./")
        {
            if (textures.ContainsKey(assetName))
            {
#if DEBUG
                Console.WriteLine(
                    assetName +
                    "はすでに読み込まれています。\n" +
                    "プログラムを確認してください。");
#endif
                return;
            }
            textures.Add(assetName,
                contentManager.Load<Texture2D>(filepath + assetName));
        }
        ///<summary>
        ///描画開始
        ///</summary>
        public void Begin()
        {
            spriteBatch.Begin();
        }
        public void End()
        {
            spriteBatch.End();
        }
        ///<summary>
        ///画像の描画(画像サイズそのまま)
        ///</summary>
        ///<param name="assetName">アセット名</param>
        ///<param name="position">位置</param>
        ///<param name="alpha">透明値(1.0f:不透明0.0f:透明)</param>
        public void DrawTexture(string assetName,Vector2 position,float alpha=1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");
            spriteBatch.Draw(textures[assetName], position, Color.White*alpha);
        }
        ///<summary>
        ///画像の描画(画像を指定範囲内だけ描画)
        ///</summary>
        ///<<param name="assetName">アセット名</param>
        ///<param name="position">位置</param>
        ///<param name="rect">指定範囲</param>
        ///<param name="alpha">透明値</param>
        
        public void DrawTexture(string assetName,Vector2 position,
            Rectangle rect,float alpha=1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

            spriteBatch.Draw(
                textures[assetName],//テクスチャ
                position,//位置
                rect,//指定範囲(矩形で指定:左上の座標、幅、高さ)
                Color.White * alpha);//透明値
        }
    }
}
