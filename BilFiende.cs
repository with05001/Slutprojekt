using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt
{
    public class BilFiende
    {
         private Texture2D biltexture;

        Random rnd = new Random();


        private int SpeedX =1;
        int y;
        float timer;

        public bool ardod {get; private set;} = false;


        Rectangle bil;

         public Rectangle bilFiende{
            get{return bil;}
            set{bil = value;}
        }

          public BilFiende(Texture2D texture,GameTime gameTime){
            if(gameTime.TotalGameTime.Seconds>10){
                SpeedX=2;
            } 
            if(gameTime.TotalGameTime.Seconds>20)
                {
                SpeedX=4;
            }
            if(gameTime.TotalGameTime.Seconds>30)
                {
                SpeedX=6;
            } 
            if(gameTime.TotalGameTime.Seconds>40)
                {
                SpeedX=8;
            }
            if(gameTime.TotalGameTime.Seconds>50)
                {
                SpeedX=10;
            }
           
            int vilken = rnd.Next(1,5);
            if(vilken==1)
                y = 301;
            if(vilken==2)
                y = 328;
            if(vilken==3)
                y = 355;
            if(vilken==4)
                y = 382; 

            bil = new Rectangle(800,y,75,27);
            this.biltexture = texture;
        }
         public void Update()
    {  

        if(bilFiende.X<=-75 || bil.Intersects(Bil1.bil))
            ardod = true;
        
        timer += 60f/1f;


        bil.X -= SpeedX;
        
        
       
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(biltexture, bil ,Color.White);
    }
     public void Flytta()
    {
       

    }
}



















    }
