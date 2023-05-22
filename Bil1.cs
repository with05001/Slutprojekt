using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Slutprojekt
{
    public class Bil1
    {
        private Texture2D biltexture;
        

        KeyboardState oldState;

        public static Rectangle bil;


        public int liv{get; private set;} = 3;


        public Rectangle bil1{
            get{return bil;}
            set{bil = value;}

        }

        public Bil1(Texture2D texture){

            bil = new Rectangle(120,301,75,27);
            this.biltexture = texture;
        }

        

    public void Update()
    {   

        foreach (var element in Game1.bilFiende)
        {
            if(element.bilFiende.Intersects(bil))
            {
                liv -= 1;

            }
        }

        


        
        Flytta();
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(biltexture, bil ,Color.White);
    }




    public void Flytta()
    {
        
        
        int bil1speedY = 27;

        KeyboardState kState = Keyboard.GetState();

        if (kState.IsKeyUp(Keys.W)&& oldState.IsKeyDown(Keys.W) && bil.Y>=327)
        {
            bil.Y-=bil1speedY;
        }
        else if (kState.IsKeyUp(Keys.S)&& oldState.IsKeyDown(Keys.S)&& bil.Y<=381)
        {
            bil.Y+=bil1speedY;
        }
        oldState = kState;   
    }
    }
}