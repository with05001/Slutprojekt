using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;



    Camera camera;
    Texture2D biltextur;
    Texture2D väg;
    Texture2D hus2;
    Texture2D hus3;
    Texture2D pixel;
    Bil1 bil; 
    

    public static List<BilFiende> bilFiende = new List<BilFiende>();
    private float timerspawnfiender;

    float spawnTimer;
    
    Random rnd = new Random();



    Rectangle hus1 = new Rectangle(-30,66,800,250);
    Rectangle väg1 = new Rectangle(0,300,800,111);    
    Rectangle hus4 = new Rectangle(716,66,800,250);   
    Rectangle Sol = new Rectangle(720,25,50,50);
    Rectangle gräss = new Rectangle(0,411,800,111);
    SpriteFont font;
    double score;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
        camera = new Camera(GraphicsDevice.Viewport);
    }

    protected override void LoadContent()
    {
        biltextur = Content.Load<Texture2D>("bil");
        väg = Content.Load<Texture2D>("väg");
        hus2 = Content.Load<Texture2D>("hus2");
        hus3 = Content.Load<Texture2D>("hus3");
        font = Content.Load<SpriteFont>("font");
        pixel = Content.Load<Texture2D>("pixel");
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here

        bil = new Bil1(biltextur);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || bil.liv==0 )
            Exit();

        timerspawnfiender += 1f/60f;
        int random = rnd.Next(5000);
        if(random<timerspawnfiender){
            bilFiende.Add(new BilFiende(biltextur,gameTime));
            random = 0;
        }
        

        for (int i = 0; i < bilFiende.Count; i++)
        {

            if(bilFiende[i].ardod){
                bilFiende.RemoveAt(i);
                i--;
            }
        }
            int SpeedX = 2;

            hus1.X -= SpeedX;
            hus4.X -= SpeedX;
            if(hus1.X == -720)
            {
                hus1.X = 766;
            }
            if(hus4.X == -720)
            {
                hus4.X = 766;
            }

            foreach (var element in bilFiende)
            {
                element.Update();
            }
            bil.Update(); 
            
            score += gameTime.ElapsedGameTime.TotalSeconds;
            
        
        // TODO: Add your update logic here
        //camera.UpdateCamera(GraphicsDevice.Viewport);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.Draw(väg,väg1,Color.White);
        _spriteBatch.Draw(hus2,hus1,Color.White);
        _spriteBatch.Draw(hus3,hus4,Color.White);
        _spriteBatch.Draw(pixel,Sol,Color.Yellow);
        _spriteBatch.Draw(pixel,gräss,Color.Green);
        _spriteBatch.DrawString(font,Math.Round(score,2).ToString() , new Vector2(50,0),Color.White);
         foreach (var element in bilFiende)
            {
                element.Draw(_spriteBatch);
            }
        bil.Draw(_spriteBatch);

        _spriteBatch.End();
        // TODO: Add your drawing code here

        
        base.Draw(gameTime);
    }

    void StartGame(){
        spawnTimer = 5f;
        bil = new Bil1(biltextur);

        
    }
}
