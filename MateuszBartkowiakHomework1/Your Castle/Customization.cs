using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateuszBartkowiakHomework1
{
    public partial class Customization : Form
    {

        #region Zmienne

        // Deklaracja zmiennej publicznej, przechowuje nazwe gracza
        public string nick = "";
        // Deklaracja zmiennej publicznej, przechowuje nazwe specjalizacji
        public string specialization = "";
        // Deklaracja zmiennej publicznej, przechowuje wybrany obrazek
        public Image awatar;
        // Deklaracja zmiennej publicznej, przechowuje wybrany obrazek
        public Image spec;
        // Deklaracja zmiennej publicznej, przechowuje informacje czy muzyka jest włączona
        public string onOff = "on";
        // Deklaracja zmiennej publicznej, przechowuje dzwięk
        public System.Media.SoundPlayer myPlayer;
        // Deklaracja zmiennej aby móc przypisać do okna Customization okno End 
        End end;
        // Deklaracja listy obrazków avataru
        List<Image> avatarList;
        // Deklaracja zmiennej, by móc poruszać się po liście
        int idAvatar = 0;
        // Deklaracja listy obrazków specjalizacji
        List<Image> specializationList;
        // Deklaracja zmiennej, by móc poruszać się po liście
        int idSpecialization = 0;
        // Deklaracja listy obrazków zmniejszania/powiększania
        List<Image> fullScreenList;
        // Deklaracja zmiennej, by móc poruszać się po liście
        int idFullScreenList = 0;

        #endregion Zmienne

        #region Funkcje

        /// <summary>
        /// Wyświtlanie poprzedniego zdjęcia
        /// </summary>
        /// <param name="idPicture"></param>
        /// <param name="picture"></param>
        /// <param name="pictureList"></param>
        private void PreviousPicture(ref int idPicture, PictureBox picture, List<Image> pictureList)
        {
            // Warunek jeżeli, jeżeli nie
            if (idPicture > 0)
            {
                // Dekrementacja 
                idPicture--;
            }
    
            else
            {
                // Zmień id o maksymalną ilość zdjęć w liście pomniejszoną o jeden (bo indeksuje się od 0)
                idPicture = pictureList.Count - 1;
            }

            // Przypisz zdjęcie o tym id 
            picture.Image = pictureList[idPicture];
        }

        /// <summary>
        /// Wyświetlanie następnego zdjęcia
        /// </summary>
        /// <param name="idPicture"></param>
        /// <param name="picture"></param>
        /// <param name="picturelist"></param>
        public void NextPicture(ref int idPicture, PictureBox picture, List<Image> picturelist)
        {
            // Warunek jeżeli, jeżeli nie
            if (idPicture < picturelist.Count - 1)
            {
                // Inkrementacja
                idPicture++;
            }

            else
            {
                // Następny indeks=0 (od początku)
                idPicture = 0;
            }

            // Przypisz to zdjęcie
            picture.Image = picturelist[idPicture];
        }

        /// <summary>
        /// Weryfikacja specjalizacji
        /// </summary>
        private void VeryficationSpecialization()
        {
            // Switch, który sprawdza jakie id specjalizacji
            switch (idSpecialization)
            {
                case 0:
                    labelSpecialization.Text = "Wojownik";
                    break;
                case 1:
                    labelSpecialization.Text = "Hodowca";
                    break;
                case 2:
                    labelSpecialization.Text = "Rolnik";
                    break;
                case 3:
                    labelSpecialization.Text = "Kupiec";
                    break;
                case 4:
                    labelSpecialization.Text = "Drwal";
                    break;
                case 5:
                    labelSpecialization.Text = "Górnik";
                    break;

                default:
                    break;
            }
        }

        #endregion Funkcje

        #region Konstruktory

        public Customization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor wywoływany przez okno End z parametrem
        /// </summary>
        /// <param name="end"></param>
        public Customization(End end)
        {
            InitializeComponent();
            // Przypisanie by móc sie odwoływać 
            this.end = end;
        }

        #endregion Konstruktory 

        #region Odpalanie okna

        /// <summary>
        /// Wczytywanie okna wywołuje:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customization_Load(object sender, EventArgs e)
        {
            // Ukryj te okno
            this.Visible = false;
            // Stwórz okno Info i wyślij tam te okno
            Info info = new Info(this);
            // Otwórz je
            info.ShowDialog();

            // Tworzenie listy zdjęć
            avatarList = new List<Image>
            {
                // Dodanie zdjęc do listy
                Properties.Resources.Awatar1,
                Properties.Resources.Awatar2,
                Properties.Resources.Awatar3,
                Properties.Resources.Awatar4,
                Properties.Resources.Awatar5
            };

            // Tworzenie listy zdjęć
            specializationList = new List<Image>
            {
                // Dodanie zdjęc do listy
                Properties.Resources.Specjalizacja1,
                Properties.Resources.Specjalizacja2,
                Properties.Resources.Specjalizacja3,
                Properties.Resources.Specjalizacja4,
                Properties.Resources.Specjalizacja5,
                Properties.Resources.Specjalizacja6
            };

            // Tworzenie odtwarzacza
            myPlayer = new System.Media.SoundPlayer
            {
                // Przypisanie muzyki
                SoundLocation = "soundtrack.wav"
            };

            // Uruchomienie odtwarzacza
            myPlayer.Play();
        }

        #endregion Odpalanie okna

        #region FullScreen

        /// <summary>
        /// Powiększenie ekranu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFullScreen_Click(object sender, EventArgs e)
        {
            // Tworzenie nowej listy zdjęć
            fullScreenList = new List<Image>
            {
                // Dodanie zdjęć do niej
                Properties.Resources.Fullscreen,
                Properties.Resources.FullscreenOff
            };

            // If który przemiszcza się po indeksach w zależności od obecnego indeksu
            if (idFullScreenList < fullScreenList.Count - 1)
            {
                // Inkrementacja
                idFullScreenList++;
                // Maksymalizacja okna
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                // Wyzerowanie (pierwszy indeks)
                idFullScreenList = 0;
                // Normalizacja okna
                this.WindowState = FormWindowState.Normal;
            }

            // Przypisz PictureBoxowi obrazek z listy w zależności od indeksu
            pictureBoxFullScreen.Image = fullScreenList[idFullScreenList];
        }

        #endregion Fullscreen

        #region Avatar

        /// <summary>
        /// Poprzedni awatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxPreviousAvatar_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji która ustawia poprzednie zdjęcie            
            PreviousPicture(ref idAvatar, pictureBoxAvatar, avatarList);
        }

        /// <summary>
        /// Następny awatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxNextAvatar_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji która ustawia kolejne zdjęcie
            NextPicture(ref idAvatar, pictureBoxAvatar, avatarList);
        }

        #endregion Avatar

        #region Dzwięk

        /// <summary>
        /// Wyłączenie/Włączenie dzwięku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSound_Click(object sender, EventArgs e)
        {
            // Jeśli zmienna ma przypisane on wyłącz jeśli off włącz
            if (onOff == "on")
            {
                myPlayer.Stop();
                onOff = "off";
                pictureBoxSound.Image = Properties.Resources.SoundOff;
            }

            else
            {
                myPlayer.Play();
                onOff = "on";
                pictureBoxSound.Image = Properties.Resources.SoundOn;
            }

        }

        #endregion Dzwięk

        #region Timer dźwięku

        /// <summary>
        /// Timer sprawdzający stan dzwięku, aktualizuje obrazek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSound_Tick(object sender, EventArgs e)
        {
            // Dobierz obrazek zgodny z tym czy dzwięk jest włączony
            if (onOff == "on")
                pictureBoxSound.Image = Properties.Resources.SoundOn;

            if (onOff == "off")
                pictureBoxSound.Image = Properties.Resources.SoundOff;
        }

        #endregion Timer dźwięku

        #region Specjalizacja
        
        /// <summary>
        /// Poprzednia specjalizacja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxPreviousSpecialization_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji która ustawia poprzednie zdjęcie
            PreviousPicture(ref idSpecialization, pictureBoxSpecialization, specializationList);
            // Wywołanie funkcji która aktualizuje label 
            VeryficationSpecialization();
        }

        /// <summary>
        /// Następna aktualizacja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxNextSpecialization_Click(object sender, EventArgs e)
        {
            // Wywołanie metody która ustawia kolejne zdjęcie
            NextPicture(ref idSpecialization, pictureBoxSpecialization, specializationList);
            // Wywołanie metody która ustawia label w zależności od wyboru specjalizacji
            VeryficationSpecialization();
        }

        #endregion Specjalizacja

        #region Uruchamianie głównego okna

        /// <summary>
        /// Uruchomienie okna głównego (Game)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelPlay_Click(object sender, EventArgs e)
        {
            // Przypisz zmiennej publicznej tekst z label
            nick = textBoxNick.Text;
            // Przypisz zmiennej publicznej zdjęcie
            awatar = avatarList[idAvatar];
            // Przypisz zmiennej publicznej nazwe specjalizacji
            specialization = labelSpecialization.Text;

            // Switch, który przypisuje obrazek surowca naszej specjalizacji
            switch (idSpecialization)
            {

                case 0:
                    spec = Properties.Resources.ArmyResources;
                    break;
                case 1:
                    spec = Properties.Resources.AnimalResources;
                    break;
                case 2:
                    spec = Properties.Resources.FarmResources;
                    break;
                case 3:
                    spec = Properties.Resources.StoreResources;
                    break;
                case 4:
                    spec = Properties.Resources.SawmillResources;
                    break;
                case 5:
                    spec = Properties.Resources.MineResources;
                    break;
            }

            // Ukryj okno
            this.Visible = false;
            // Stwórz okno Game i wyślij tam te okno
            Game game = new Game(this);
            // Otwórz je 
            game.ShowDialog();
        }

        #endregion Uruchamianie głównego okna

        #region Zamykanie okna

        /// <summary>
        /// Zamykanie okna wywołuje zapytanie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customization_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Deklaracja zmiennej której przypisujemy powiadomienie Yes/No
            DialogResult rezultat = MessageBox.Show("Czy na pewno zamknąć program?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Jeśli klikniemy Yes
            if (rezultat == DialogResult.Yes)
                // Nie anulujemy zamykania sie programu
                e.Cancel = false;
            else
                // Anulujemy zamykanie się programu
                e.Cancel = true;
        }

        #endregion Zamykanie okna

        #region Informacja przycisk

        /// <summary>
        /// Wywołanie okna icnormacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxInfo_Click(object sender, EventArgs e)
        {
            // Ukryj okno
            this.Visible = false;
            // Stwórz nowe okno Info i wyśłij tam te okno Customization
            Info info = new Info(this);
            // Otwórz je 
            info.ShowDialog();
        }

        #endregion Informacja przycisk
       
    }
}
