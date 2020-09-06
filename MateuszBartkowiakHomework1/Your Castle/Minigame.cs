using System;
using System.Drawing;
using System.Windows.Forms;

namespace MateuszBartkowiakHomework1
{
    public partial class Minigame : Form
    {

        #region Zmienne

        // Deklaracja zmiennej by odwoływać sie do okna game  
        Game game;
        // Deklaracja zmiennej decydująca o szybkości poruszania się obiektów
        int speed = 0;
        //Deklaracja zmiennej losowej
        Random r = new Random();
        // Deklaracja zmiennej współrzędnej x
        int x;
        // Deklaracja zmiennej zliczjąca emeraldy
        public int collectedEmeralds;

        #endregion Zmienne

        #region Funkcje

        /// <summary>
        /// Odpowiada za poruszanie się obiektów (drzewa)
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="pictureBoxTreeNumber"></param>
        private void MoveItems(int speed, PictureBox pictureBoxTreeNumber)
        {
            // Jeśli obrazek drzewa będzie w odległości ustalonej od góry: 
            if (pictureBoxTreeNumber.Top >= 380)
                // Ustaw położenie drzewa na samej górze
                pictureBoxTreeNumber.Top = 0;
            else
                // Przesuń drzewo w dół w zależności od parametru prędkości gry
                pictureBoxTreeNumber.Top += speed;
        }

        /// <summary>
        /// Odpowiada za poruszanie się obiektów (emeraldy/potwory)
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="pictureBoxItemNumber"></param>
        private void MoveItemsColision(int speed, PictureBox pictureBoxItemNumber)
        {
            // Jeśli odległośc od góry wynosi odpowiednią ustaloną ilość:
            if (pictureBoxItemNumber.Top >= 380)
            {
                // Wygenreuj dla x liczbę z przedziału podanego
                x = r.Next(80, 450);
                // Ustaw nową lokalizację na samej górzę oraz na wylosowanej szerokości
                pictureBoxItemNumber.Location = new Point(x, 0);
            }
            else
            {
                // Obniż obiekt w dół w zależności od zmiennej speed
                pictureBoxItemNumber.Top += speed;
            }
        }

        /// <summary>
        /// Odpowiada za wykrywanie kolizji konia i emeralda
        /// </summary>
        /// <param name="pictureBoxEmeraldNumber"></param>
        private void ColisionEmerald(PictureBox pictureBoxEmeraldNumber)
        {
            // Jeśli występuje kolizja:
            if (pictureBoxHorse.Bounds.IntersectsWith(pictureBoxEmeraldNumber.Bounds))
            {
                // Powiększ zmienną o 1
                collectedEmeralds++;
                // Przypisz do labela tą zmieną (rzutujemy ją na string by móć przypisac)
                labelEmeraldsResult.Text = collectedEmeralds.ToString();
                // Ustaw nowa lokalizację na samej górze przy wylosowanej szerokości
                pictureBoxEmeraldNumber.Location = new Point(x, 0);
            }
        }

        /// <summary>
        /// Odpowiada za wykrywanie kolizji z potworem (GAME OVER)
        /// </summary>
        /// <param name="pictureBoxEnemyNumber"></param>
        private void GameOver(PictureBox pictureBoxEnemyNumber)
        {
            // Jeśli występuje kolizka konia z potworem
            if (pictureBoxHorse.Bounds.IntersectsWith(pictureBoxEnemyNumber.Bounds))
            {
                // Wyłącz timer by zatrzymać grę 
                timerStart.Enabled = false;
                // Pokaż label Game Over
                labelEnd.Visible = true;
                // Zmien tekst na przycisku 
                buttonStart.Text = "Koniec";
            }
        }

        #endregion Funkcje

        #region Konstruktory

        public Minigame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor wywołany przez okno game
        /// </summary>
        /// <param name="game"></param>
        public Minigame(Game game)
        {
            InitializeComponent();
            // Przypsiujemy game by móc sie odwoływac do okna 
            this.game = game;
            // Ustawiamy styl dzięki któremu po zmianie położenia obiektu nie zostanie biały pozostały fragment
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion Konstruktory

        #region Wykrywanie zderzenia

        /// <summary>
        /// Wykrywanie końca gry
        /// </summary>
        private void End()
        {
            // Wywoływanie funkcji, kazda funkcja bada kolizje
            GameOver(pictureBoxEnemy1);
            GameOver(pictureBoxEnemy2);
            GameOver(pictureBoxEnemy3);
        }

        #endregion Wykrywanie zderzenia

        #region Zbieranie emeraldów

        /// <summary>
        /// Sprawdza czy wsytąpiła kolizja z jakimkolwiek emeraldem
        /// </summary>
        private void CollectEmeralds()
        {
            // Wywołujemy funkcje sprawdzająca czy wystąpiła kolizja 
            ColisionEmerald(pictureBoxEmerald1);
            ColisionEmerald(pictureBoxEmerald2);
            ColisionEmerald(pictureBoxEmerald3);
        }

        #endregion Zbieranie emeraldów

        #region Poruszanie obiektów

        /// <summary>
        /// Poruszanie się przeciwników
        /// </summary>
        /// <param name="speed"></param>
        private void MoveEnemy(int speed)
        {
            // Wywoływanie funkcji poruszania potworów
            MoveItemsColision(speed, pictureBoxEnemy1);
            MoveItemsColision(speed, pictureBoxEnemy2);
            MoveItemsColision(speed, pictureBoxEnemy3);
        }

        /// <summary>
        /// Poruszanie się emeraldów
        /// </summary>
        /// <param name="speed"></param>
        private void MoveEmerald(int speed)
        {
            // Wywoływanie funkcji poruszania emeraldów
            MoveItemsColision(speed, pictureBoxEmerald1);
            MoveItemsColision(speed, pictureBoxEmerald2);
            MoveItemsColision(speed, pictureBoxEmerald3);
        }

        /// <summary>
        /// Poruszanie się drzew
        /// </summary>
        /// <param name="speed"></param>
        private void MoveItem(int speed)
        {
            // Wywoływanie funkcji poruszania drzew
            MoveItems(speed, pictureBoxTreeLeft1);
            MoveItems(speed, pictureBoxTreeLeft2);
            MoveItems(speed, pictureBoxTreeLeft3);
            MoveItems(speed, pictureBoxTreeLeft4);
            MoveItems(speed, pictureBoxTreeLeft5);
            MoveItems(speed, pictureBoxTreeRight1);
            MoveItems(speed, pictureBoxTreeRight2);
            MoveItems(speed, pictureBoxTreeRight3);
            MoveItems(speed, pictureBoxTreeRight4);
            MoveItems(speed, pictureBoxTreeRight5);
        }

        #endregion Poruszanie obiektów

        #region Start

        /// <summary>
        /// Rozpoczęcie rozgrywki/Zakończenie rozgrywki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            // Jeśli przycisk jest oznaczona jako zagraj:
            if (buttonStart.Text == "Zagraj")
                // Uruchom mini gre
                timerStart.Start();

            // Jeśli przycisk jest oznaczony jako koniec:
            if (buttonStart.Text == "Koniec")
            {
                // Odwołujemy się do Game i zmiennej publicznej tam i przypisujemy zdobyte emeraldy
                game.emerald += collectedEmeralds;
                // Wyłączamy widocznośc tego okna Mini-Game
                this.Visible = false;
                // Włączamy widoczność okna Game 
                game.Visible = true;
            }
        }

        #endregion Start

        #region Poruszanie konia

        /// <summary>
        /// wykrywanie poruszania się konia (w zależnosci od klikniętoego klawisza po kliknięciu Start)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_KeyDown(object sender, KeyEventArgs e)
        {
            // Jeśli klikniemy A
            if (e.KeyCode == Keys.A)
            {
                // Jeśli jest wystarczające miejsce po lewo (w zależności do jakiego momentu chcemy)
                if (pictureBoxHorse.Left > 80)
                    // Przesun konia w lewo o zmienną speed
                    pictureBoxHorse.Left += -speed;
            }

            // Jeśli klikniemy D
            if (e.KeyCode == Keys.D)
            {
                // Jeśli jest wystarczające miejsce po prawo (w zależności do jakiego momentu chcemy)
                if (pictureBoxHorse.Right < 450)
                    // Przsuń konia w prawo o zmienną speed
                    pictureBoxHorse.Left += speed;
            }

            // Jeśli klikniemy W
            if (e.KeyCode == Keys.W)
            {
                // Jeśli zmienna nie przekracza 21: 
                if (speed < 21)
                    // Zwiększ zmienną o 1
                    speed++;
            }

            // Jeśli klikniemy S
            if (e.KeyCode == Keys.S)
            {
                // Jeśli zmienna jest większa od 0
                if (speed > 0)
                    // Zmniejsz zmienną o 1
                    speed--;
            }
        }

        #endregion Poruszanie konia

        #region Timer

        /// <summary>
        /// Timer odpowiadający za poruszanie się (za całą mechanikę gry)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStart_Tick(object sender, EventArgs e)
        {
            // Wywołanie funkcji poruszania się drzew
            MoveItem(speed);
            // Wywołanie funkcji poruszania się potworów
            MoveEnemy(speed);
            // Wywołanie funkcji wykrywającą czy koniec gry (kolizja z potworami)
            End();
            // Wywołanie funkcji poruszania się emeraldów
            MoveEmerald(speed);
            // Wywołanie funkcji zbierania emeraldów (kolizja z emeraldami)
            CollectEmeralds();
        }

        #endregion Timer

    }
}
