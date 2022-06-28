using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tanvas.TanvasTouch.Resources;
using Tanvas.TanvasTouch.WpfUtilities;


namespace final_interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        // TSprite is an on-screen haptic object.
        TSprite mySpriteHarp;
        TSprite mySpriteHarpsichord;
        TSprite mySpriteFlute;
        TSprite mySpritePiano;
        TSprite mySpriteHorn;
        TSprite mySpriteSaxophone;
        TSprite mySpriteGuitar;
        TSprite mySpriteHurdyGurdy;
        TSprite mySpriteViolin;
        TSprite mySpriteAccordion;
        TSprite mySpriteTrumpet;
        TSprite mySpriteEardrum;

        // The TanvasTouchViewTracker class creates and positions a TView whose top-left corner corresponds to the top-left corner in a window's client area.
        // The TView's position and size is kept in sync with the window's position and size.
        TanvasTouchViewTracker viewTracker;

        // TView contains references to TSprites. It groups a set of TSprites.
        // The TanvasTouch Engine expects a TView's position and size to be in the screen's coordinate system, but this is not yet enforced by the TanvasTouch API library: the application must perform these coordinate transformations.
        TView myView
        {
            get
            {
                return viewTracker.View;
            }
        }

        // The audios
        System.Media.SoundPlayer playerHarp = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\harp.wav");
        System.Media.SoundPlayer playerPiano = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\piano.wav");
        System.Media.SoundPlayer playerSaxophone = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\saxophone.wav");
        System.Media.SoundPlayer playerViolin = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\violin.wav");
        System.Media.SoundPlayer playerHarpsichord = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\harpsichord.wav");
        System.Media.SoundPlayer playerEardrum = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\eardrum.wav");
        System.Media.SoundPlayer playerGuitar = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\guitar.wav");
        System.Media.SoundPlayer playerAccordion = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\accordion.wav");
        System.Media.SoundPlayer playerFlute = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\flute.wav");
        System.Media.SoundPlayer playerHorn = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\horn.wav");
        System.Media.SoundPlayer playerHurdyGurdy = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\hurdy-gurdy.wav");
        System.Media.SoundPlayer playerTrumpet = new System.Media.SoundPlayer(@"C:\Users\Tester\Desktop\TFG\Final_interface\final_interface\assets\audio-wav\trumpet.wav");

        public MainWindow()
        {
            InitializeComponent();
            // It is important that the application communicates with the TanvasTouchh engine. Otherwise, this line of code will give an error.
            // In the TanvasTouch Engine application, the calibrate button must be pressed to achieve the above-mentioned communication.
            Tanvas.TanvasTouch.API.Initialize();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewTracker = new TanvasTouchViewTracker(this);

            // Uri pointing to a PNG image.
            var uriBricks = new Uri("pack://application:,,/assets/haptic_images/bricks.png");
            var uriBristles = new Uri("pack://application:,,/assets/haptic_images/bristles.png");
            var uriBubbles = new Uri("pack://application:,,/assets/haptic_images/bubbles.png");
            var uriCactus = new Uri("pack://application:,,/assets/haptic_images/cactus.png");
            var uriDiamonds = new Uri("pack://application:,,/assets/haptic_images/diamonds.png");
            var uriIron = new Uri("pack://application:,,/assets/haptic_images/iron_spheres.png");
            var uriLeather = new Uri("pack://application:,,/assets/haptic_images/leather.png");
            var uriMarbles = new Uri("pack://application:,,/assets/haptic_images/marbles.png");
            var uriPebbles = new Uri("pack://application:,,/assets/haptic_images/pebbles.png");
            var uriPine = new Uri("pack://application:,,/assets/haptic_images/pine_leaves.png");
            var uriSand = new Uri("pack://application:,,/assets/haptic_images/sand.png");
            var uriStones = new Uri("pack://application:,,/assets/haptic_images/stones.png");
            

            // PNGToTanvasTouch converts PNGs files into friction maps.
            // CreateSpriteFromPNG creates a TSprite with a TMaterial that contains a TTexture created from the PNG at a URI.
            // TMaterial is an adaptation of texture mapping for haptic rendering. It controls how TTextures are mapped onto a TSprite.
            // TTexture stores friction maps. It is a byte array.
            mySpriteHarp = PNGToTanvasTouch.CreateSpriteFromPNG(uriBubbles);
            mySpriteHarpsichord = PNGToTanvasTouch.CreateSpriteFromPNG(uriCactus);
            mySpriteFlute = PNGToTanvasTouch.CreateSpriteFromPNG(uriSand);
            mySpritePiano = PNGToTanvasTouch.CreateSpriteFromPNG(uriBricks);
            mySpriteEardrum = PNGToTanvasTouch.CreateSpriteFromPNG(uriLeather);
            mySpriteHorn = PNGToTanvasTouch.CreateSpriteFromPNG(uriStones);
            mySpriteSaxophone = PNGToTanvasTouch.CreateSpriteFromPNG(uriPebbles);
            mySpriteGuitar = PNGToTanvasTouch.CreateSpriteFromPNG(uriMarbles);
            mySpriteHurdyGurdy = PNGToTanvasTouch.CreateSpriteFromPNG(uriPine);
            mySpriteViolin = PNGToTanvasTouch.CreateSpriteFromPNG(uriBristles);
            mySpriteAccordion = PNGToTanvasTouch.CreateSpriteFromPNG(uriDiamonds);
            mySpriteTrumpet = PNGToTanvasTouch.CreateSpriteFromPNG(uriIron);

            Application.Current.MainWindow.SizeChanged += WindowSizeChanged;
            viewTracker.OnGeometryChanged += OnViewGeometryChanged;

            ReSize();

        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReSize();

        }

        private void OnViewGeometryChanged(TView View)
        {
            ReSize();
        }

        private void ReSize()
        {
            //// In our case dpiScaleX has the same value as dpiScaleY which is 1,25. It represents the scale of the Tanvas device screen (125%).
            var dpiScaleX = VisualTreeHelper.GetDpi(Application.Current.MainWindow).DpiScaleX;
            var dpiScaleY = VisualTreeHelper.GetDpi(Application.Current.MainWindow).DpiScaleY;

            //// The size and the position of mySprite should match with the size and the position of the "graphicimage" multiplied by the dpiScale.
            mySpriteHarp.Width = (int)((int)hapticImageHarp.ActualWidth * dpiScaleX);
            mySpriteHarp.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);


            var XHarp = (Canvas.GetLeft(hapticImageHarp) + stackPanel.ActualWidth) * dpiScaleX;
            var YHarp = Canvas.GetTop(hapticImageHarp) * dpiScaleY;

            mySpriteHarp.X = (int)(XHarp);
            mySpriteHarp.Y = (int)(YHarp);

            //

            mySpriteHarpsichord.Width = (int)((int)hapticImageHarpsichord.ActualWidth * dpiScaleX);
            mySpriteHarpsichord.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);


            var XHarpsichord = (Canvas.GetLeft(hapticImageHarpsichord) + stackPanel.ActualWidth) * dpiScaleX;
            var YHarpsichord = Canvas.GetTop(hapticImageHarpsichord) * dpiScaleY;

            mySpriteHarpsichord.X = (int)(XHarpsichord);
            mySpriteHarpsichord.Y = (int)(YHarpsichord);

            //

            mySpriteFlute.Width = (int)((int)hapticImageFlute.ActualWidth * dpiScaleX);
            mySpriteFlute.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);


            var XFlute = (Canvas.GetLeft(hapticImageFlute) + stackPanel.ActualWidth) * dpiScaleX;
            var YFlute = Canvas.GetTop(hapticImageFlute) * dpiScaleY;

            mySpriteFlute.X = (int)(XFlute);
            mySpriteFlute.Y = (int)(YFlute);


            ////

            mySpritePiano.Width = (int)((int)hapticImagePiano.ActualWidth * dpiScaleX);
            mySpritePiano.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);

            var XPiano = (Canvas.GetLeft(hapticImagePiano) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YPiano = Canvas.GetTop(hapticImagePiano) * dpiScaleY;

            mySpritePiano.X = (int)(XPiano);
            mySpritePiano.Y = (int)(YPiano);

            //

            mySpriteEardrum.Width = (int)((int)hapticImageEardrum.ActualWidth * dpiScaleX);
            mySpriteEardrum.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);

            var XEardrum = (Canvas.GetLeft(hapticImageEardrum) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YEardrum = Canvas.GetTop(hapticImageEardrum) * dpiScaleY;

            mySpriteEardrum.X = (int)(XEardrum);
            mySpriteEardrum.Y = (int)(YEardrum);

            //

            mySpriteHorn.Width = (int)((int)hapticImageHorn.ActualWidth * dpiScaleX);
            mySpriteHorn.Height = (int)((int)canvasTwo.ActualHeight * dpiScaleY);

            var XHorn = (Canvas.GetLeft(hapticImageHorn) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YHorn = Canvas.GetTop(hapticImageHorn) * dpiScaleY;

            mySpriteHorn.X = (int)(XHorn);
            mySpriteHorn.Y = (int)(YHorn);

            ////

            mySpriteSaxophone.Width = (int)((int)hapticImageSaxophone.ActualWidth * dpiScaleX);
            mySpriteSaxophone.Height = (int)((int)canvasThree.ActualHeight * dpiScaleY);

            var XSaxophone = (Canvas.GetLeft(hapticImageSaxophone) + stackPanel.ActualWidth) * dpiScaleX;
            var YSaxophone = (Canvas.GetTop(hapticImageSaxophone) + canvasOne.ActualHeight) * dpiScaleY;

            mySpriteSaxophone.X = (int)(XSaxophone);
            mySpriteSaxophone.Y = (int)(YSaxophone);

            //

            mySpriteGuitar.Width = (int)((int)hapticImageGuitar.ActualWidth * dpiScaleX);
            mySpriteGuitar.Height = (int)((int)canvasThree.ActualHeight * dpiScaleY);

            var XGuitar = (Canvas.GetLeft(hapticImageGuitar) + stackPanel.ActualWidth) * dpiScaleX;
            var YGuitar = (Canvas.GetTop(hapticImageGuitar) + canvasOne.ActualHeight) * dpiScaleY;

            mySpriteGuitar.X = (int)(XGuitar);
            mySpriteGuitar.Y = (int)(YGuitar);

            //

            mySpriteHurdyGurdy.Width = (int)((int)hapticImageHurdyGurdy.ActualWidth * dpiScaleX);
            mySpriteHurdyGurdy.Height = (int)((int)canvasThree.ActualHeight * dpiScaleY);

            var XHurdyGurdy = (Canvas.GetLeft(hapticImageHurdyGurdy) + stackPanel.ActualWidth) * dpiScaleX;
            var YHurdyGurdy = (Canvas.GetTop(hapticImageHurdyGurdy) + canvasOne.ActualHeight) * dpiScaleY;

            mySpriteHurdyGurdy.X = (int)(XHurdyGurdy);
            mySpriteHurdyGurdy.Y = (int)(YHurdyGurdy);

            ////

            mySpriteViolin.Width = (int)((int)hapticImageViolin.ActualWidth * dpiScaleX);
            mySpriteViolin.Height = (int)((int)canvasFour.ActualHeight * dpiScaleY);

            var XViolin = (Canvas.GetLeft(hapticImageViolin) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YViolin = (Canvas.GetTop(hapticImageViolin) + canvasTwo.ActualHeight) * dpiScaleY;

            mySpriteViolin.X = (int)(XViolin);
            mySpriteViolin.Y = (int)(YViolin);

            //

            mySpriteAccordion.Width = (int)((int)hapticImageAccordion.ActualWidth * dpiScaleX);
            mySpriteAccordion.Height = (int)((int)canvasFour.ActualHeight * dpiScaleY);

            var XAccordion = (Canvas.GetLeft(hapticImageAccordion) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YAccordion = (Canvas.GetTop(hapticImageAccordion) + canvasTwo.ActualHeight) * dpiScaleY;

            mySpriteAccordion.X = (int)(XAccordion);
            mySpriteAccordion.Y = (int)(YAccordion);

            //

            mySpriteTrumpet.Width = (int)((int)hapticImageTrumpet.ActualWidth * dpiScaleX);
            mySpriteTrumpet.Height = (int)((int)canvasFour.ActualHeight * dpiScaleY);

            var XTrumpet = (Canvas.GetLeft(hapticImageTrumpet) + stackPanel.ActualWidth + canvasOne.ActualWidth) * dpiScaleX;
            var YTrumpet = (Canvas.GetTop(hapticImageTrumpet) + canvasTwo.ActualHeight) * dpiScaleY;

            mySpriteTrumpet.X = (int)(XTrumpet);
            mySpriteTrumpet.Y = (int)(YTrumpet);


        }

        // Functions called when the user clicks on the buttons of the main menu.
        // When the user presses these buttons four different images should be displayed. It is important not to overlap images.
        public void OnClickPage1(object sender, EventArgs e)
        {
            stopMusic();

            buttonPage2.Background = new SolidColorBrush(Color.FromRgb(119, 184, 219));
            buttonPage3.Background = new SolidColorBrush(Color.FromRgb(249, 230, 155));
            buttonPage2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            buttonPage3.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (graphicImageHarp.Visibility == Visibility.Visible)
            {
                Hider();
                buttonPage1.Background = new SolidColorBrush(Color.FromRgb(255, 188, 188));
                buttonPage1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else
            {
                Hider();

                myView.AddSprite(mySpriteHarp);
                hapticImageHarp.Visibility = Visibility.Visible;
                myView.AddSprite(mySpritePiano);
                hapticImagePiano.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteSaxophone);
                hapticImageSaxophone.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteViolin);
                hapticImageViolin.Visibility = Visibility.Visible;

                buttonPage1.Background = new SolidColorBrush(Color.FromRgb(255, 100, 150));
                buttonPage1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                graphicImageHarp.Visibility = Visibility.Visible;
                graphicImagePiano.Visibility = Visibility.Visible;
                graphicImageSaxophone.Visibility = Visibility.Visible;
                graphicImageViolin.Visibility = Visibility.Visible;
                buttonPlayOne.Visibility = Visibility.Visible;
                buttonPlayTwo.Visibility = Visibility.Visible;
                buttonPlayThree.Visibility = Visibility.Visible;
                buttonPlayFour.Visibility = Visibility.Visible;
                
            }
        }
        public void OnClickPage2(object sender, EventArgs e)
        {
            stopMusic();

            buttonPage1.Background = new SolidColorBrush(Color.FromRgb(255, 188, 188));
            buttonPage3.Background = new SolidColorBrush(Color.FromRgb(249, 230, 155));
            buttonPage1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            buttonPage3.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (graphicImageHarpsichord.Visibility == Visibility.Visible)
            {
                Hider();
                buttonPage2.Background = new SolidColorBrush(Color.FromRgb(119, 184, 219));
                buttonPage2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else
            {
                Hider();

                myView.AddSprite(mySpriteHarpsichord);
                hapticImageHarpsichord.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteEardrum);
                hapticImageEardrum.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteGuitar);
                hapticImageGuitar.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteAccordion);
                hapticImageAccordion.Visibility = Visibility.Visible;

                buttonPage2.Background = new SolidColorBrush(Color.FromRgb(255, 100, 150));
                buttonPage2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                graphicImageHarpsichord.Visibility = Visibility.Visible;
                graphicImageEardrum.Visibility = Visibility.Visible;
                graphicImageGuitar.Visibility = Visibility.Visible;
                graphicImageAccordion.Visibility = Visibility.Visible;
                buttonPlayOne.Visibility = Visibility.Visible;
                buttonPlayTwo.Visibility = Visibility.Visible;
                buttonPlayThree.Visibility = Visibility.Visible;
                buttonPlayFour.Visibility = Visibility.Visible;
            }

        }
        public void OnClickPage3(object sender, EventArgs e)
        {
            stopMusic();

            buttonPage1.Background = new SolidColorBrush(Color.FromRgb(255, 188, 188));
            buttonPage2.Background = new SolidColorBrush(Color.FromRgb(119, 184, 219));
            buttonPage1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            buttonPage2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (graphicImageFlute.Visibility == Visibility.Visible)
            {
                Hider();
                buttonPage3.Background = new SolidColorBrush(Color.FromRgb(249,230,155));
                buttonPage3.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else
            {
                Hider();

                myView.AddSprite(mySpriteFlute);
                hapticImageFlute.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteHorn);
                hapticImageHorn.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteHurdyGurdy);
                hapticImageHurdyGurdy.Visibility = Visibility.Visible;
                myView.AddSprite(mySpriteTrumpet);
                hapticImageTrumpet.Visibility = Visibility.Visible;

                buttonPage3.Background = new SolidColorBrush(Color.FromRgb(255, 100, 150));
                buttonPage3.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                graphicImageFlute.Visibility = Visibility.Visible;
                graphicImageHorn.Visibility = Visibility.Visible;
                graphicImageHurdyGurdy.Visibility = Visibility.Visible;
                graphicImageTrumpet.Visibility = Visibility.Visible;
                buttonPlayOne.Visibility = Visibility.Visible;
                buttonPlayTwo.Visibility = Visibility.Visible;
                buttonPlayThree.Visibility = Visibility.Visible;
                buttonPlayFour.Visibility = Visibility.Visible;
            }
            
        }

        // This function ensures that the images of the instruments and the play/stop buttons are not visible. 
        public void Hider()
        {
            myView.RemoveAllSprites();

            hapticImageHarp.Visibility = Visibility.Hidden;
            hapticImageHarpsichord.Visibility = Visibility.Hidden;
            hapticImageFlute.Visibility = Visibility.Hidden;
            hapticImagePiano.Visibility = Visibility.Hidden;
            hapticImageEardrum.Visibility = Visibility.Hidden;
            hapticImageHorn.Visibility = Visibility.Hidden;
            hapticImageSaxophone.Visibility = Visibility.Hidden;
            hapticImageGuitar.Visibility = Visibility.Hidden;
            hapticImageHurdyGurdy.Visibility = Visibility.Hidden;
            hapticImageViolin.Visibility = Visibility.Hidden;
            hapticImageAccordion.Visibility = Visibility.Hidden;
            hapticImageTrumpet.Visibility = Visibility.Hidden;

            graphicImageHarp.Visibility = Visibility.Hidden;
            graphicImagePiano.Visibility = Visibility.Hidden;
            graphicImageSaxophone.Visibility = Visibility.Hidden;
            graphicImageViolin.Visibility = Visibility.Hidden;
            graphicImageHarpsichord.Visibility = Visibility.Hidden;
            graphicImageEardrum.Visibility = Visibility.Hidden;
            graphicImageGuitar.Visibility = Visibility.Hidden;
            graphicImageAccordion.Visibility = Visibility.Hidden;
            graphicImageFlute.Visibility = Visibility.Hidden;
            graphicImageHorn.Visibility = Visibility.Hidden;
            graphicImageHurdyGurdy.Visibility = Visibility.Hidden;
            graphicImageTrumpet.Visibility = Visibility.Hidden;
            buttonPlayOne.Visibility = Visibility.Hidden;   
            buttonPlayTwo.Visibility = Visibility.Hidden;   
            buttonPlayThree.Visibility = Visibility.Hidden;
            buttonPlayFour.Visibility = Visibility.Hidden;
            buttonStopOne.Visibility = Visibility.Hidden;
            buttonStopTwo.Visibility = Visibility.Hidden;
            buttonStopThree.Visibility = Visibility.Hidden;
            buttonStopFour.Visibility = Visibility.Hidden;

        }

        // Each function corresponds to one of the four buttons located on each of the three pages. 
        // First you see which page is being presented so that you know which haptic image to displat and which audio to play.
        public void onClickPlayButtonOne(object sender, EventArgs e)
        {

            buttonPlayOne.Visibility = Visibility.Hidden;
            buttonPlayTwo.Visibility = Visibility.Visible;
            buttonPlayThree.Visibility = Visibility.Visible;
            buttonPlayFour.Visibility = Visibility.Visible;
            buttonStopOne.Visibility = Visibility.Visible;
            buttonStopTwo.Visibility = Visibility.Hidden;
            buttonStopThree.Visibility = Visibility.Hidden;
            buttonStopFour.Visibility = Visibility.Hidden;

            if (graphicImageHarp.Visibility == Visibility.Visible)
            {
                playerHarp.Play();
            }
            if (graphicImageHarpsichord.Visibility == Visibility.Visible)
            {
                playerHarpsichord.Play();
            }
            if (graphicImageFlute.Visibility == Visibility.Visible)
            {
                playerFlute.Play();
            }
   
        }

        public void onClickStopButtonOne(object sender, EventArgs e)
        {
            buttonPlayOne.Visibility = Visibility.Visible;
            buttonStopOne.Visibility = Visibility.Hidden;

            if (graphicImageHarp.Visibility == Visibility.Visible)
            {
                playerHarp.Stop();
            }
            if (graphicImageHarpsichord.Visibility == Visibility.Visible)
            {
                playerHarpsichord.Stop();
            }
            if (graphicImageFlute.Visibility == Visibility.Visible)
            {
                playerFlute.Stop();
            }
        }

        public void onClickPlayButtonTwo(object sender, EventArgs e)
        {
            buttonPlayOne.Visibility = Visibility.Visible;
            buttonPlayTwo.Visibility = Visibility.Hidden;
            buttonPlayThree.Visibility = Visibility.Visible;
            buttonPlayFour.Visibility = Visibility.Visible;
            buttonStopOne.Visibility = Visibility.Hidden;
            buttonStopTwo.Visibility = Visibility.Visible;
            buttonStopThree.Visibility = Visibility.Hidden;
            buttonStopFour.Visibility = Visibility.Hidden;

            if (graphicImagePiano.Visibility == Visibility.Visible)
            {
                playerPiano.Play();
            }
            if (graphicImageEardrum.Visibility == Visibility.Visible)
            {
                playerEardrum.Play();
            }
            if (graphicImageHorn.Visibility == Visibility.Visible)
            {
                playerHorn.Play();
            }
        }
        public void onClickStopButtonTwo(object sender, EventArgs e)
        {
            buttonPlayTwo.Visibility = Visibility.Visible;
            buttonStopTwo.Visibility = Visibility.Hidden;

            if (graphicImagePiano.Visibility == Visibility.Visible)
            {
                playerPiano.Stop();
            }
            if (graphicImageEardrum.Visibility == Visibility.Visible)
            {
                playerEardrum.Stop();
            }
            if (graphicImageHorn.Visibility == Visibility.Visible)
            {
                playerHorn.Stop();
            }
        }

        public void onClickPlayButtonThree(object sender, EventArgs e)
        {
            buttonPlayOne.Visibility = Visibility.Visible;
            buttonPlayTwo.Visibility = Visibility.Visible;
            buttonPlayThree.Visibility = Visibility.Hidden;
            buttonPlayFour.Visibility = Visibility.Visible;
            buttonStopOne.Visibility = Visibility.Hidden;
            buttonStopTwo.Visibility = Visibility.Hidden;
            buttonStopThree.Visibility = Visibility.Visible;
            buttonStopFour.Visibility = Visibility.Hidden;

            if (graphicImageSaxophone.Visibility == Visibility.Visible)
            {
                playerSaxophone.Play();
            }
            if (graphicImageGuitar.Visibility == Visibility.Visible)
            {
                playerGuitar.Play();
            }
            if (graphicImageHurdyGurdy.Visibility == Visibility.Visible)
            {
                playerHurdyGurdy.Play();
            }
        }
        public void onClickStopButtonThree(object sender, EventArgs e)
        {
            buttonPlayThree.Visibility = Visibility.Visible;
            buttonStopThree.Visibility = Visibility.Hidden;

            if (graphicImageSaxophone.Visibility == Visibility.Visible)
            {
                playerSaxophone.Stop();
            }
            if (graphicImageGuitar.Visibility == Visibility.Visible)
            {
                playerGuitar.Stop();
            }
            if (graphicImageHurdyGurdy.Visibility == Visibility.Visible)
            {
                playerHurdyGurdy.Stop();
            }
        }
        public void onClickPlayButtonFour(object sender, EventArgs e)
        {
            buttonPlayOne.Visibility = Visibility.Visible;
            buttonPlayTwo.Visibility = Visibility.Visible;
            buttonPlayThree.Visibility = Visibility.Visible;
            buttonPlayFour.Visibility = Visibility.Hidden;
            buttonStopOne.Visibility = Visibility.Hidden;
            buttonStopTwo.Visibility = Visibility.Hidden;
            buttonStopThree.Visibility = Visibility.Hidden;
            buttonStopFour.Visibility = Visibility.Visible;

            if (graphicImageViolin.Visibility == Visibility.Visible)
            {
                playerViolin.Play();
            }
            if (graphicImageAccordion.Visibility == Visibility.Visible)
            {
                playerAccordion.Play();
            }
            if (graphicImageTrumpet.Visibility == Visibility.Visible)
            {
                playerTrumpet.Play();
            }
        }
        public void onClickStopButtonFour(object sender, EventArgs e)
        {
            buttonPlayFour.Visibility = Visibility.Visible;
            buttonStopFour.Visibility = Visibility.Hidden;

            if (graphicImageViolin.Visibility == Visibility.Visible)
            {
                playerViolin.Stop();
            }
            if (graphicImageAccordion.Visibility == Visibility.Visible)
            {
                playerAccordion.Stop();
            }
            if (graphicImageTrumpet.Visibility == Visibility.Visible)
            {
                playerTrumpet.Stop();
            }
        }

        // This function stops the music.
        public void stopMusic()
        {
            playerHarp.Stop();
            playerPiano.Stop();
            playerSaxophone.Stop();
            playerViolin.Stop();
            playerHarpsichord.Stop();
            playerEardrum.Stop();
            playerGuitar.Stop();
            playerAccordion.Stop();
            playerFlute.Stop();
            playerHorn.Stop();
            playerHurdyGurdy.Stop();
            playerTrumpet.Stop();
        }
    }
}