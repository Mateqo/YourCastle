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
    public partial class Game : Form
    {
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // jeśli używamy ref to po to żeby po zmianie w funkcji stworzonej odebrać zmienioną wartość
        // czyli po to żeby pracować na oryginale a nie kopi

        // Ogólna zasada wpisywania parametrów to zamiast place wpisujemy nazwe obiektu
        // np. zamiast placeLvl to farmLvl itp.

        // Aby nie powtarzać komenatrzy zbyt dużo, wyjaśnienie szczegółowe w sekcji farma
        // analogicznie reszta wygląda podobnie
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        #region Zmienne

        //******************Farma********************//

        // Deklaracja tablicy przechowująca maksymalną ilość surówców w zależności od poziomu
        int[] farmMaxResources = new int[] { 5, 10, 20, 40, 80 };
        // Deklaracja tablicy przechowująca maksymalną ilośc surowców po transporcie (magazyn) w zależności od poziomu
        int[] farmMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        // Deklaracja tablicy przechowująca potrzebną ilość surowców do ulepszenia w zależności od poziomu
        int[] farmRequiredResources = new int[] { 15, 30, 60, 120 };
        // Deklaracja zmiennej licząca surowce
        int farmCount = 0;
        // Deklaracja zmiennej odpowiadająca za poziom oobiektu
        int farmLvl = 1;
        // Deklaracja zmiennej licząca surowce po transporcie (magazyn)
        int farmTransport = 0;
        // Deklaracja zmiennej wydobycia surowców (ustawiamy krok Timera)
        int farmInterval = 1000;

        //******************Kopalnia********************// 

        // Podobnie jak w przypadku farmy opis
        int[] mineMaxResources = new int[] { 5, 10, 20, 40, 80 };
        int[] mineMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        int[] mineRequiredResources = new int[] { 15, 30, 60, 120 };
        int mineCount = 0;
        int mineLvl = 1;
        int mineTransport = 0;
        int mineInterval = 1000;

        //******************Tartak********************//

        // Podobnie jak w przypadku farmy opis
        int[] sawmillMaxResources = new int[] { 5, 10, 20, 40, 80 };
        int[] sawmillMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        int[] sawmillRequiredResources = new int[] { 15, 30, 60, 120 };
        int sawmillCount = 0;
        int sawmillLvl = 1;
        int sawmillTransport = 0;
        int sawmillInterval = 1000;

        //******************Sklep********************//

        // Podobnie jak w przypadku farmy opis
        int[] storeMaxResources = new int[] { 5, 10, 20, 40, 80 };
        int[] storeMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        int[] storeRequiredResources = new int[] { 15, 30, 60, 120 };
        int storeCount = 0;
        int storeLvl = 1;
        int storeTransport = 0;
        int storeInterval = 1000;

        //******************Armia********************//

        // Podobnie jak w przypadku farmy opis
        int[] armyMaxResources = new int[] { 5, 10, 20, 40, 80 };
        int[] armyMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        int[] armyRequiredResources = new int[] { 15, 30, 60, 120 };
        int armyCount = 0;
        int armyLvl = 1;
        int armyTransport = 0;
        int armyInterval = 1000;

        //******************Hodowla********************//

        // Podobnie jak w przypadku farmy opis
        int[] animalMaxResources = new int[] { 5, 10, 20, 40, 80 };
        int[] animalMaxTransport = new int[] { 20, 40, 80, 160, 320 };
        int[] animalRequiredResources = new int[] { 15, 30, 60, 120 };
        int animalCount = 0;
        int animalLvl = 1;
        int animalTransport = 0;
        int animalInterval = 1000;

        //******************Zamek********************//

        // Deklaracja tablicy przechowująca wymaganą ilośc surowców do ulepszenia w zależności od poziomu
        int[] castleRequiredResources = new int[] { 10, 20, 40, 80 };
        // Deklaracja zmiennej opisująca poziom zamku
        int castleLvl = 1;
        // Deklaracja zmiennej publicznej by móc się odwołać w oknie Mini-Game (tam zbieramy je) przechowująca ilość emeraldów
        public int emerald = 0;
        // Deklaracja zmiennej kroku timera 
        int castleInterval = 500;

        //******************Kataklizm********************//

        // Deklaracja zmiennej losowej katastrofy
        Random cataclysm = new Random();
        // Deklaracja zmiennej do niej przypisujemy wylosowany indeks danej katastrofy
        int numberCataclysm;
        // Deklaracja zmiennej przechowująca nazwe katastrofy
        string nameCataclysm;
        // Deklaracja zmiennej przechowująca informacje o katastrofie
        string cataclysmInfo;
        // Deklaracja zmiennej kroku katrastrofy
        int cataclysmInterval = 500;

        //****************Ogólne**********************//

        // Deklaracja zmiennej by móc przypisać okno Customization   
        Customization cust;
        // Deklaracja zmiennej określa ile wydobywamy surowców ręcznie
        int collectedResources = 1;
        // Deklaracja zmiennej nazwa wybranej specjalizacji
        string nameSpecialization;
        // Deklaracja zmiennej nazwa gracza
        public string nick = "";
        // Deklaracja listy powiekszenia ekranu
        List<Image> fullScreenList;
        // Zmienna żeby móc poruszać się po liście
        int idFullScreenList = 0;

        #endregion Zmienne

        #region Funkcje

        // Ogólna zasada wpisywania parametrów to zamiast place wpisujemy nazwe obiektu
        // np. zamiast placeLvl to farmLvl

        /// <summary>
        /// Nadpisuje do labela zbierane surowce danego obiektu
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="labelPlaceResources"></param>
        /// <param name="placeCount"></param>
        /// <param name="placeMaxResources"></param>
        private void CounterResources(int placeLvl, Label labelPlaceResources, int placeCount, int[] placeMaxResources)
        {
            // Switch który jest zależny od poziomu
            switch (placeLvl)
            {
                case 1:
                    labelPlaceResources.Text = placeCount + " / " + placeMaxResources[0];
                    break;
                case 2:
                    labelPlaceResources.Text = placeCount + " / " + placeMaxResources[1];
                    break;
                case 3:
                    labelPlaceResources.Text = placeCount + " / " + placeMaxResources[2];
                    break;
                case 4:
                    labelPlaceResources.Text = placeCount + " / " + placeMaxResources[3];
                    break;
                case 5:
                    labelPlaceResources.Text = placeCount + " / " + placeMaxResources[4];
                    break;
            }
        }

        /// <summary>
        /// Sprawdza czy zebrano maksymalną ilość surowców danego obiektu
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="placeCount"></param>
        /// <param name="timerPlace"></param>
        /// <param name="placeMaxResources"></param>
        /// <param name="pictureBoxPlaceManual"></param>
        private void IsMaxResources(int placeLvl, int placeCount, Timer timerPlace, int[] placeMaxResources, PictureBox pictureBoxPlaceManual)
        {
            // Jeśli poziom obiektu wynosi wybraną ilość i liczba surowców jest większa lub równa maksymalnej pojemności:
            if (placeLvl == 1 && placeCount >= placeMaxResources[0])
            {
                // Wyłącz timer zbierania surowców
                timerPlace.Enabled = false;
                // Zablokuj możliwość zbierania surowców ręznie
                pictureBoxPlaceManual.Enabled = false;
            }
            if (placeLvl == 2 && placeCount >= placeMaxResources[1])
            {
                timerPlace.Enabled = false;
                pictureBoxPlaceManual.Enabled = false;
            }
            if (placeLvl == 3 && placeCount >= placeMaxResources[2])
            {
                timerPlace.Enabled = false;
                pictureBoxPlaceManual.Enabled = false;
            }
            if (placeLvl == 4 && placeCount >= placeMaxResources[3])
            {
                timerPlace.Enabled = false;
                pictureBoxPlaceManual.Enabled = false;
            }
            if (placeLvl == 5 && placeCount >= placeMaxResources[4])
            {
                timerPlace.Enabled = false;
                pictureBoxPlaceManual.Enabled = false;
            }
        }

        /// <summary>
        /// Zmienia obrazek upgrade na jaśniejszy (pokazuje możliwość ulepszenia)
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="placeTransport"></param>
        /// <param name="pictureBoxPlaceUpgrade"></param>
        /// <param name="placeRequiredResources"></param>
        private void PictureOfUpgradeChange(int placeLvl, int placeTransport, PictureBox pictureBoxPlaceUpgrade, int[] placeRequiredResources)
        {
            // Jeśli poziom obiektu wynosi odpowiednio 1 i ilość surowców w magazynie jest większa lub równa 
            // wymaganej ilości do ulepszenia wykonaj:
            if (placeLvl == 1 && placeTransport >= placeRequiredResources[0])
            {
                // Zmień PictureBox na inne zdjęcie zaciągnięte z Resources
                pictureBoxPlaceUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (placeLvl == 2 && placeTransport >= placeRequiredResources[1])
            {
                pictureBoxPlaceUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (placeLvl == 3 && placeTransport >= placeRequiredResources[2])
            {
                pictureBoxPlaceUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (placeLvl == 4 && placeTransport >= placeRequiredResources[3])
            {
                pictureBoxPlaceUpgrade.Image = Properties.Resources.Upgrade;
            }
        }

        /// <summary>
        /// Sprawdza czy można ulepszyć i ulepsza obiekt
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="placeTransport"></param>
        /// <param name="placeRequiredResources"></param>
        /// <param name="placeMaxResources"></param>
        /// <param name="placeMaxTransport"></param>
        /// <param name="labelPlaceTransport"></param>
        /// <param name="labelPlaceResources"></param>
        /// <param name="timerPlace"></param>
        /// <param name="pictureBoxPlace"></param>
        /// <param name="pictureBoxPlaceUpgrade"></param>
        /// <param name="placeCount"></param>
        /// <param name="nameOfPlace"></param>
        /// <param name="pictureBoxPlaceManual"></param>
        private void IsUpgrade(ref int placeLvl, ref int placeTransport, int[] placeRequiredResources, int[] placeMaxResources, int[] placeMaxTransport,
            Label labelPlaceTransport, Label labelPlaceResources, Timer timerPlace, PictureBox pictureBoxPlace, PictureBox pictureBoxPlaceUpgrade, int placeCount, string nameOfPlace, PictureBox pictureBoxPlaceManual)
        {
            // Jeśli poziom wynosi 1 i surowce w magazynie są większe lub równe
            // wymaganej ilości do ulepszenia wykonaj:
            if (placeLvl == 1 && placeTransport >= placeRequiredResources[0])
            {
                // Zabierz surowce potrzebne do ulepszenia, zwiększ poziom, aktualizuj labele, włącz timer, włacz możliwość zbierania ręcznego
                placeTransport -= placeRequiredResources[0];
                placeLvl++;
                labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[1];
                labelPlaceResources.Text = placeCount + " / " + placeMaxResources[1];
                timerPlace.Enabled = true;      
                pictureBoxPlaceManual.Enabled = true;
                // Switch który zależy od nazwy miejsca 
                switch (nameOfPlace)
                {
                    case "farm":
                        pictureBoxPlace.Image = Properties.Resources.Farm2;
                        break;
                    case "mine":
                        pictureBoxPlace.Image = Properties.Resources.Mine2;
                        break;
                    case "store":
                        pictureBoxPlace.Image = Properties.Resources.Store2;
                        break;
                    case "animal":
                        pictureBoxPlace.Image = Properties.Resources.Animal2;
                        break;
                    case "sawmill":
                        pictureBoxPlace.Image = Properties.Resources.Sawmill2;
                        break;
                    case "castle":
                        pictureBoxPlace.Image = Properties.Resources.Castle2;
                        break;
                    case "army":
                        pictureBoxPlace.Image = Properties.Resources.Army2;
                        break;
                }

                // Zmieniamy obrazek ulepszenia na ciemniejszy (brak możliwości ulepszenia)
                pictureBoxPlaceUpgrade.Image = Properties.Resources.UpgradeOff;
            }
            if (placeLvl == 2 && placeTransport >= placeRequiredResources[1])
            {
                placeTransport -= placeRequiredResources[1];
                placeLvl++;
                labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[2];
                labelPlaceResources.Text = placeCount + " / " + placeMaxResources[2];
                timerPlace.Enabled = true;
                pictureBoxPlaceManual.Enabled = true;
                pictureBoxPlace.Image = Properties.Resources.Farm3;
                pictureBoxPlaceUpgrade.Image = Properties.Resources.UpgradeOff;
                switch (nameOfPlace)
                {
                    case "farm":
                        pictureBoxPlace.Image = Properties.Resources.Farm3;
                        break;
                    case "mine":
                        pictureBoxPlace.Image = Properties.Resources.Mine3;
                        break;
                    case "store":
                        pictureBoxPlace.Image = Properties.Resources.Store3;
                        break;
                    case "animal":
                        pictureBoxPlace.Image = Properties.Resources.Animal3;
                        break;
                    case "sawmill":
                        pictureBoxPlace.Image = Properties.Resources.Sawmill3;
                        break;
                    case "castle":
                        pictureBoxPlace.Image = Properties.Resources.Castle3;
                        break;
                    case "army":
                        pictureBoxPlace.Image = Properties.Resources.Army3;
                        break;
                }
            }
            if (placeLvl == 3 && placeTransport >= placeRequiredResources[2])
            {
                placeTransport -= placeRequiredResources[2];
                placeLvl++;
                labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[3];
                labelPlaceResources.Text = placeCount + " / " + placeMaxResources[3];
                timerPlace.Enabled = true;
                pictureBoxPlaceManual.Enabled = true;
                pictureBoxPlace.Image = Properties.Resources.Farm4;
                pictureBoxPlaceUpgrade.Image = Properties.Resources.UpgradeOff;
                switch (nameOfPlace)
                {
                    case "farm":
                        pictureBoxPlace.Image = Properties.Resources.Farm4;
                        break;
                    case "mine":
                        pictureBoxPlace.Image = Properties.Resources.Mine4;
                        break;
                    case "store":
                        pictureBoxPlace.Image = Properties.Resources.Store4;
                        break;
                    case "animal":
                        pictureBoxPlace.Image = Properties.Resources.Animal4;
                        break;
                    case "sawmill":
                        pictureBoxPlace.Image = Properties.Resources.Sawmill4;
                        break;
                    case "castle":
                        pictureBoxPlace.Image = Properties.Resources.Castle4;
                        break;
                    case "army":
                        pictureBoxPlace.Image = Properties.Resources.Army4;
                        break;
                }
            }
            if (placeLvl == 4 && placeTransport >= placeRequiredResources[3])
            {
                placeTransport -= placeRequiredResources[3];
                placeLvl++;
                labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[4];
                labelPlaceResources.Text = placeCount + " / " + placeMaxResources[4];
                timerPlace.Enabled = true;
                pictureBoxPlaceManual.Enabled = true;
                pictureBoxPlace.Image = Properties.Resources.Farm5;
                pictureBoxPlaceUpgrade.Image = Properties.Resources.UpgradeOff;
                switch (nameOfPlace)
                {
                    case "farm":
                        pictureBoxPlace.Image = Properties.Resources.Farm5;
                        break;
                    case "mine":
                        pictureBoxPlace.Image = Properties.Resources.Mine5;
                        break;
                    case "store":
                        pictureBoxPlace.Image = Properties.Resources.Store5;
                        break;
                    case "animal":
                        pictureBoxPlace.Image = Properties.Resources.Animal5;
                        break;
                    case "sawmill":
                        pictureBoxPlace.Image = Properties.Resources.Sawmill5;
                        break;
                    case "castle":
                        pictureBoxPlace.Image = Properties.Resources.Castle5;
                        break;
                    case "army":
                        pictureBoxPlace.Image = Properties.Resources.Army5;
                        break;
                }
            }
        }

        /// <summary>
        /// Przenosi surowce danego obiektu do magazynu
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="placeCount"></param>
        /// <param name="placeTransport"></param>
        /// <param name="placeMaxTransport"></param>
        /// <param name="placeMaxResources"></param>
        /// <param name="labelPlaceTransport"></param>
        /// <param name="labelPlaceResources"></param>
        /// <param name="timerPlace"></param>
        /// <param name="pictureBoxPlaceManual"></param>
        private void TransportResources(int placeLvl, ref int placeCount, ref int placeTransport, int[] placeMaxTransport, int[] placeMaxResources,
            Label labelPlaceTransport, Label labelPlaceResources, Timer timerPlace, PictureBox pictureBoxPlaceManual)
        {
            // Switch zależący od poziomu
            switch (placeLvl)
            {
                case 1:
                    // Jeśli ilość surowców jest za duża i nie można wszystkich prztransportować to:
                    if ((placeCount + placeTransport) > placeMaxTransport[0])
                    {
                        // Zmienna pomocnicza przechowująca ilość surowców w magazynie
                        int tmp = placeTransport;
                        // Do ilości surowców w magazynie dodajemy ilość jaka może się jeszcze zmieścić
                        placeTransport += (placeMaxTransport[0] - placeTransport);
                        // Zabieramy surowce ponieważ transportujemy (wykorzystujemy zmienną pomocniczą)
                        placeCount -= (placeMaxTransport[0] - tmp);
                        // Nadpisujemy label w nowe dane
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[0];
                        // Nadpisujemy label w nowe dane
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[0];
                    }
                    // Jeśli jest wystarczająca ilość to transportujemy wszystko
                    else
                    {
                        // Powiększamy magazyn o całą ilość surowców
                        placeTransport += placeCount;
                        // Zerujemy surowce
                        placeCount = 0;
                        // Aktualizujemy label
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[0];
                        // Aktualizujemy label
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[0];
                    }

                    // Sprawdzamy czy jest jeszcze miejsce na surowce
                    if (placeCount < placeMaxResources[0])
                    {
                        // Włączamy timer zbierania surowców
                        timerPlace.Enabled = true;
                        // Włączamy możliwość ręcznego zbierania
                        pictureBoxPlaceManual.Enabled = true;
                    }
                    //jeśli nie ma miejsca (gdy transportujemy np. 0 surowców)
                    else
                    {
                        // Wyłączamy zbieranie
                        timerPlace.Enabled = false;
                        // Wyłączamy ręczne zbieranie
                        pictureBoxPlaceManual.Enabled = false;
                    }
                    break;
                case 2:
                    if ((placeCount + placeTransport) > placeMaxTransport[1])
                    {
                        int tmp = placeTransport;
                        placeTransport += (placeMaxTransport[1] - placeTransport);
                        placeCount -= (placeMaxTransport[1] - tmp);
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[1];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[1];
                    }
                    else
                    {
                        placeTransport += placeCount;
                        placeCount = 0;
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[1];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[1];
                    }
                    if (placeCount < placeMaxResources[1])
                    {
                        timerPlace.Enabled = true;
                        pictureBoxPlaceManual.Enabled = true;
                    }
                    else
                    {
                        timerPlace.Enabled = false;
                        pictureBoxPlaceManual.Enabled = false;
                    }
                    break;
                case 3:
                    if ((placeCount + placeTransport) > placeMaxTransport[2])
                    {
                        int tmp = placeTransport;
                        placeTransport += (placeMaxTransport[2] - placeTransport);
                        placeCount -= (placeMaxTransport[2] - tmp);
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[2];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[2];
                    }
                    else
                    {
                        placeTransport += placeCount;
                        placeCount = 0;
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[2];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[2];
                    }
                    if (placeCount < placeMaxResources[2])
                    {
                        timerPlace.Enabled = true;
                        pictureBoxPlaceManual.Enabled = true;
                    }
                    else
                    {
                        timerPlace.Enabled = false;
                        pictureBoxPlaceManual.Enabled = false;
                    }
                    break;
                case 4:
                    if ((placeCount + placeTransport) > placeMaxTransport[3])
                    {
                        int tmp = placeTransport;
                        placeTransport += (placeMaxTransport[3] - placeTransport);
                        placeCount -= (placeMaxTransport[3] - tmp);
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[3];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[3];
                    }
                    else
                    {
                        placeTransport += placeCount;
                        placeCount = 0;
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[3];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[3];
                    }
                    if (placeCount < placeMaxResources[3])
                    {
                        timerPlace.Enabled = true;
                        pictureBoxPlaceManual.Enabled = true;
                    }
                    else
                    {
                        timerPlace.Enabled = false;
                        pictureBoxPlaceManual.Enabled = false;
                    }
                    break;
                case 5:
                    if ((placeCount + placeTransport) > placeMaxTransport[4])
                    {
                        int tmp = placeTransport;
                        placeTransport += (placeMaxTransport[4] - placeTransport);
                        placeCount -= (placeMaxTransport[4] - tmp);
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[4];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[4];
                    }
                    else
                    {
                        placeTransport += placeCount;
                        placeCount = 0;
                        labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[4];
                        labelPlaceResources.Text = placeCount + " / " + placeMaxResources[4];
                    }
                    if (placeCount < placeMaxResources[4])
                    {
                        timerPlace.Enabled = true;
                        pictureBoxPlaceManual.Enabled = true;
                    }
                    else
                    {
                        timerPlace.Enabled = false;
                        pictureBoxPlaceManual.Enabled = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// Włącza timery odpowiednich obiektów
        /// </summary>
        /// <param name="timerPlace"></param>
        /// <param name="timerInterval"></param>
        private void StartTimer(Timer timerPlace, int timerInterval)
        {
            // Włączanie timera
            timerPlace.Start();
            // Ustawienie jego kroku
            timerPlace.Interval = timerInterval;
        }

        /// <summary>
        /// Zeruje surowce w magazynie (transportowane surowce)
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="labelPlaceTransport"></param>
        /// <param name="placeTransport"></param>
        /// <param name="placeMaxTransport"></param>
        private void TransportCataclysm(int placeLvl, Label labelPlaceTransport,ref int placeTransport, int[] placeMaxTransport)
        {
            // Switch zależny od poziomu
            switch (placeLvl)
            { 
                case 1:
                    // Wyzeruj surowce w magazynie
                    placeTransport = 0;
                    // Aktualizacja labela
                    labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[0];
                    break;
                case 2:
                    placeTransport = 0;
                    labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[1];
                    break;
                case 3:
                    placeTransport = 0;
                    labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[2];
                    break;
                case 4:
                    placeTransport = 0;
                    labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[3];
                    break;
                case 5:
                    placeTransport = 0;
                    labelPlaceTransport.Text = placeTransport + " / " + placeMaxTransport[4];
                    break;

            }
        }

        /// <summary>
        /// Włącza możliwosć klikania w narzędzie by wydobyć ręcznie surowce
        /// </summary>
        /// <param name="pictureBoxPlaceTransportOrManual"></param>
        private void StartEnabled(PictureBox pictureBoxPlaceTransportOrManual)
        {
            // Jeśli PictureBox z narzędziem jest wyłączony to:
            if (pictureBoxPlaceTransportOrManual.Enabled == false)
                // Włącz go
                pictureBoxPlaceTransportOrManual.Enabled = true;
            else
                //Wyłącz
                pictureBoxPlaceTransportOrManual.Enabled = false;
        }

        /// <summary>
        /// Sprawdza specjalizacje i zwieksza wydajność
        /// </summary>
        private void SpecializationBenefit()
            {
            // Przypisuje nazwe specjalizacji
            nameSpecialization = labelSpecialization.Text;
            // Swicth zależny od specjalizacji
            switch (nameSpecialization)
            {
                case "Wojownik":
                    // Zmieniamy krok
                    timerArmy.Interval = 500;
                    break;
                case "Hodowca":
                    timerAnimal.Interval = 500;
                    break;
                case "Rolnik":
                    timerFarm.Interval = 500;
                    break;
                case "Kupiec":
                    timerStore.Interval = 500;
                    break;
                case "Drwal":
                    timerSawmill.Interval = 500;
                    break;
                case "Górnik":
                    timerMine.Interval = 500;
                    break;

            }
        }

        /// <summary>
        /// Zwiększa wydobycie poprzez ręczne klikanie w PictureBox
        /// </summary>
        /// <param name="placeLvl"></param>
        /// <param name="placeMaxResources"></param>
        /// <param name="placeCount"></param>
        private void CollectingResources(int placeLvl,int[] placeMaxResources,ref int placeCount)
        {
            // Switch zależny od poziomu 
            switch (placeLvl)
            {
                case 1:
                    {
                        // Sprawdzamy czy jest miejsce na wydobycie ręczne (zapas lekki żeby nie wyjść poza maks)
                        if (placeCount < (placeMaxResources[0]-1))
                            // Zwiększ surowce o zmienną 
                            placeCount += collectedResources;
                    }
                    break;
                case 2:
                    {
                        if (placeCount < (placeMaxResources[1]-2))
                            placeCount += collectedResources;
                    }
                    break;
                case 3:
                    {
                        if (placeCount < (placeMaxResources[2] - 3))
                            placeCount += collectedResources;
                    }
                    break;
                case 4:
                    {
                        if (placeCount < (placeMaxResources[3] - 4))
                            placeCount += collectedResources;
                    }
                    break;
                case 5:
                    {
                        if (placeCount < (placeMaxResources[4] - 5))
                            placeCount += collectedResources;
                    }
                    break;
            }
        }

        #endregion Funkcje

        #region Konstruktory

        public Game()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor wywołany przez okno Customization
        /// </summary>
        /// <param name="cust"></param>
        public Game(Customization cust)
        {
            InitializeComponent();
            // Przypisujemy cust by móc odwoływać sie do tego okna
            this.cust = cust;
            // Przypisujemy z okna Customization nick do labela w Game
            labelNick.Text = cust.nick;
            // Przypisujemu z okna Customization awatar do PictureBoxa w Game
            pictureBoxAvatar.Image = cust.awatar;
            // Przypisujemu z okna Customization specjalizacje do labela w Game
            labelSpecialization.Text = cust.specialization;
            // Przypisujemu z okna Customization obrazek specjalizacji do PictureBoxa w Game
            pictureBoxSpecialization.Image = cust.spec;
            // Zmiennej nick w tej klasie przypisujemy nick z Customization
            this.nick = cust.nick;
            // Zmiana obrazka w zależności od zmiennej onOff
            if (cust.onOff == "on")
                pictureBoxSound.Image = Properties.Resources.SoundOn;
            if (cust.onOff == "off")
                pictureBoxSound.Image = Properties.Resources.SoundOff;
        }

        /// <summary>
        /// Konstruktor wywołany przez okno minigry, przekazuje ilość zdobytych emeraldów
        /// </summary>
        /// <param name="collectedEmeralds"></param>
        public Game(int collectedEmeralds)
        {
            InitializeComponent();
            // Powiększ zmienną o zdobyte emeraldy z Minigry
            emerald += collectedEmeralds;
        }

        #endregion Konstruktory

        #region Zamykanie okna

        /// <summary>
        /// Wywołanie zapytanie przy zamykaniu okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zmienna która przechowuje powiadomienie, możliwe odpowiedzi yes/no
            DialogResult rezultat = MessageBox.Show("Czy na pewno chcesz wyjść do menu.\nPostęp zostanie usunięty.", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Jeśli zaznaczymy yes
            if (rezultat == DialogResult.Yes)
            {
                // Nie anulujemy zamykania sie programu
                e.Cancel = false;
                // Pojawi się okno Customization
                cust.Visible = true;
            
                //Wyłącznie wszystkich timerów
                timerFarm.Stop();
                timerMine.Stop();
                timerSawmill.Stop();
                timerStore.Stop();
                timerArmy.Stop();
                timerAnimal.Stop();
                timerCataclysm.Stop();
                timerCastle.Stop();
                timerEnd.Stop();
            }
            // Jeśli no 
            else
                // Anulujemy zamykanie
                e.Cancel = true;
            
        }

        #endregion Zamykanie okna

        #region Start

        /// <summary>
        /// Włączenie gry (uruchomienie sie zbierania,umożliwienie klikania itp..)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStart_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji która włącza timer 
            StartTimer(timerFarm, farmInterval);
            StartTimer(timerMine, mineInterval);
            StartTimer(timerSawmill, sawmillInterval);
            StartTimer(timerStore, storeInterval);
            StartTimer(timerArmy, armyInterval);
            StartTimer(timerAnimal, animalInterval);
            StartTimer(timerCataclysm, cataclysmInterval);
            StartTimer(timerCastle, castleInterval);
            StartTimer(timerEnd, castleInterval);

            // Wywołanie funkcji która umożliwia/uniemożliwia ręczne wydobycie surówców
            StartEnabled(pictureBoxFarmManual);
            StartEnabled(pictureBoxMineManual);
            StartEnabled(pictureBoxSawmillManual);
            StartEnabled(pictureBoxStoreManual);
            StartEnabled(pictureBoxArmyManual);
            StartEnabled(pictureBoxAnimalManual);

            // Wywołanie funkcji która umożliwia/uniemożliwia transport surowców 
            StartEnabled(pictureBoxFarmTransport);
            StartEnabled(pictureBoxMineTransport);
            StartEnabled(pictureBoxSawmillTransport);
            StartEnabled(pictureBoxStoreTransport);
            StartEnabled(pictureBoxArmyTransport);
            StartEnabled(pictureBoxAnimalTransport);
            
            // Wyłącz możliwość ponownego kliknięcia
            pictureBoxStart.Enabled = false;
            // Włącz możliwość kliknięcia w przycisk
            buttonMiniGame.Enabled = true;
            // Wywołaj funkcje która zwiększa wydajność w zależności od specjalizacji
            SpecializationBenefit();
            // Zmień kolor przycisku
            buttonMiniGame.BackColor = Color.Coral;
            // Ukryj obrazek startu
            pictureBoxStart.Visible = false;
        }

        #endregion Start

        #region Fullscreen
 
        /// <summary>
        /// Maksymalizacja/Minimalizacja okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFullScreen_Click(object sender, EventArgs e)
        {
            // Stwórz listę zdjęc
            fullScreenList = new List<Image>
            {
                // Dodaj obrazki
                Properties.Resources.Fullscreen,
                Properties.Resources.FullscreenOff
            };

            // Jeśli obecne zdjęcie jest pierwsze to daj kolejne poprzez
            if (idFullScreenList < fullScreenList.Count - 1)
            {
                idFullScreenList++;
                this.WindowState = FormWindowState.Maximized;
            }
            // Jeśli obecne zdjęcie jest ostatnie to daj pierwsze
            else
            {
                idFullScreenList = 0;
                this.WindowState = FormWindowState.Normal;
            }

            // Zmień obraz w zależności od id które wskazuje na liście zdjęcie
            pictureBoxFullScreen.Image = fullScreenList[idFullScreenList];
        }

        #endregion Fullscreen

        #region Katastrofa

        /// <summary>
        /// Timer odliczający katastrofę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCataclysm_Tick(object sender, EventArgs e)
        {
            // Zwiększ progress bara o 1
            progressBarCataclysm.Increment(1);

            // Aktualizacja labela 
            labelCataclysm.Text = "Katastrofa: " + progressBarCataclysm.Value + "%";

            // Jeśli progress bar naładuje się w 100%
            if (progressBarCataclysm.Value == 100)
            {
                // Wylosuj liczbę z przedziału, która odpowiada danej katastrofie
                numberCataclysm = cataclysm.Next(1, 7);
                // Wyzeruj progress bara
                progressBarCataclysm.Value = 0;
                // Switch zależny od wylosowanej katastrofy
                switch (numberCataclysm)
                {
                    case 1:
                        // Przypisz nazwe katastrofy do zmiennej
                        nameCataclysm = "susza";
                        // Przypisz co straciliśmy do zmiennej
                        cataclysmInfo = "pszenicy";
                        // Jeśli specjalizacja pokrywa sie z katastrofą:
                        if (nameSpecialization == "Farmer")
                            // Pokaż komunikat ale nie zabieraj surowców ponieważ gracz jest chroniony
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + ", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Jeśli nie posiada tej specjalizacji:
                        else
                        {
                            // Wyzeruj surowce danego obiektu
                            TransportCataclysm(farmLvl, labelFarmWarehouse,ref farmTransport, farmMaxTransport);
                            // Wyświetl komunikat o stratach
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case 2:
                        nameCataclysm = "lawina";
                        cataclysmInfo = "kamienia";
                        if (nameSpecialization == "Górnik")
                            MessageBox.Show("Nastąpiła katastrofa: "+nameCataclysm +", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            TransportCataclysm(mineLvl, labelMineWarehouse, ref mineTransport, mineMaxTransport);
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                            break;
                    case 3:
                        nameCataclysm = "pożar";
                        cataclysmInfo = "drewna";
                        if (nameSpecialization == "Drwal")
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + ", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            TransportCataclysm(sawmillLvl, labelSawmillWarehouse, ref sawmillTransport, sawmillMaxTransport);
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case 4:
                        nameCataclysm = "kradzież";
                        cataclysmInfo = "monet";
                        if (nameSpecialization == "Kupiec")
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + ", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            TransportCataclysm(storeLvl, labelStoreWarehouse, ref storeTransport, storeMaxTransport);
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case 5:
                        nameCataclysm = "epidemia";
                        cataclysmInfo = "rycerzy";
                        if (nameSpecialization == "Wojownik")
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + ", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            TransportCataclysm(armyLvl, labelArmyWarehouse, ref armyTransport, armyMaxTransport);
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case 6:
                        nameCataclysm = "głód";
                        cataclysmInfo = "krów";
                        if (nameSpecialization == "Hodowca")
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + ", lecz jesteś chroniony ze względu na specjalizacje", "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            TransportCataclysm(animalLvl, labelAnimalWarehouse, ref animalTransport, animalMaxTransport);
                            MessageBox.Show("Nastąpiła katastrofa: " + nameCataclysm + "\n Straciłeś wszystkie zasoby " + cataclysmInfo, "Katastrofa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
            }
        }

        #endregion Katastrofa

        #region Start Mini-gry

        /// <summary>
        /// Pojawienie się okna z mini grą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMiniGame_Click(object sender, EventArgs e)
        {
            // Ukryj okno Game
            this.Visible = false;
            // Stworzenie okna Minigame i wysłanie tam parametru Game
            Minigame minigame = new Minigame(this);
            // Pokaż okno Minigame
            minigame.ShowDialog();
        }

        #endregion Start Mini-gry

        #region Timer sprawdza czy koniec

        /// <summary>
        /// Wywołanie okna zwycięstwa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEnd_Tick(object sender, EventArgs e)
        {
            // Jeśli poziom wszystkich obiektów wynosi 5
            if (farmLvl == 5 && mineLvl == 5 && sawmillLvl == 5 && storeLvl == 5 && armyLvl == 5 && animalLvl == 5 && castleLvl == 5)
            {
                // Wyłącz timer
                timerEnd.Enabled = false;
                // Wyłącz timer katastrofy
                timerCataclysm.Enabled = false;
                // Ukryj okno
                this.Visible = false;
                // Stwórz okno End i wyślij te okno
                End end = new End(this);
                // Pokaż je
                end.ShowDialog();
            }
        }

        #endregion Timer sprawdza czy koniec

        #region Informacja przycisk

        /// <summary>
        /// Pojawienie się okna informacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxInfo_Click(object sender, EventArgs e)
        {
            // Ukryj okno Game
            this.Visible = false;
            // Stwórz okno Info
            Info info = new Info(this);
            // Otwórz je 
            info.ShowDialog();
        }

        #endregion Informacja przycisk

        #region Dzwięk

        /// <summary>
        /// Wyłącz/Włącz dzwięk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSound_Click(object sender, EventArgs e)
        {

            // Jeśli zmienna z okna Customization ma przypisane on:
            if (cust.onOff == "on")
            {
                // Wyłącz odtwarzacz 
                cust.myPlayer.Stop();
                cust.onOff = "off";
                pictureBoxSound.Image = Properties.Resources.SoundOff;
            }
            else
            {
                // Włącz 
                cust.myPlayer.Play();
                cust.onOff = "on";
                pictureBoxSound.Image = Properties.Resources.SoundOn;
            }
        }

        #endregion Dźwięk

        //*****************************FARMA**************************

        #region Timer farmy
         
        /// <summary>
        /// Timer odpowiedzialny za farme (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerFarm_Tick(object sender, EventArgs e)
        {
            farmCount++;

            // Wywołaj funkcje aktualizacyjną label
            CounterResources(farmLvl,labelFarmResources,farmCount,farmMaxResources);
            // Wywołanie funkcji która sprawdza czy zebrano maksymalną ilość
            IsMaxResources(farmLvl,farmCount,timerFarm,farmMaxResources, pictureBoxFarmManual);
            // Wywołanie metody która zmienia zdjęcie ulepszenia jeśli jest to możliwe
            PictureOfUpgradeChange(farmLvl,farmTransport,pictureBoxFarmUpgrade,farmRequiredResources);
        }

        #endregion Timer farmy

        #region Ulepszanie farmy

        /// <summary>
        /// Ulepszanie farmy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFarmUpgrade_Click(object sender, EventArgs e)
        {
            // Wywołanie metody która sprawdza czy można ulepszyć
            IsUpgrade(ref farmLvl,ref farmTransport,farmRequiredResources,farmMaxResources,farmMaxTransport,labelFarmWarehouse,
                labelFarmResources, timerFarm,pictureBoxFarm,pictureBoxFarmUpgrade, farmCount,"farm",pictureBoxFarmManual);
            
            // Aktuualizacja lvlu obiektu
            labelFarmLvl.Text = "Lvl " + farmLvl;
        }

        #endregion Ulepszanie farmy

        #region Transport farmy

        /// <summary>
        /// Transportowanie surowców farmy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFarmTransport_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji, która transportuje surowce 
            TransportResources(farmLvl,ref farmCount,ref farmTransport,farmMaxTransport,farmMaxResources,labelFarmWarehouse,labelFarmResources,timerFarm,pictureBoxFarmManual);
        }

        #endregion Transport farmy

        #region Dymek farma

        /// <summary>
        /// Podpowiedź, ile surowców jest wymaganych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFarmInfo_MouseEnter(object sender, EventArgs e)
        {
            // Switch zależny od poziomu
            switch (farmLvl)
            {
                case 1:
                    // Ustawianie tytułu dymku
                    toolTipFarm.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    // Ustawiamy tekst dymku
                    toolTipFarm.SetToolTip(pictureBoxFarmInfo, "Potrzebujesz x15 pszenicy");
                    break;
                case 2:
                    toolTipFarm.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipFarm.SetToolTip(pictureBoxFarmInfo, "Potrzebujesz x30 pszenicy");
                    break;
                case 3:
                    toolTipFarm.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipFarm.SetToolTip(pictureBoxFarmInfo, "Potrzebujesz x60 pszenicy");
                    break;
                case 4:
                    toolTipFarm.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipFarm.SetToolTip(pictureBoxFarmInfo, "Potrzebujesz x120 pszenicy");
                    break;
                case 5:
                    toolTipFarm.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipFarm.SetToolTip(pictureBoxFarmInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek farma

        #region Zbieranie surowców farmy

        /// <summary>
        /// Zbieranie ręczne surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxFarmManual_Click(object sender, EventArgs e)
        {
            // Wywołanie funkcji która zbiera surowce przy kliknięciu (ręczne zbieranie)
            CollectingResources(farmLvl, farmMaxResources,ref farmCount);

            // Wywołanie funkcji która aktualizuje label
            CounterResources(farmLvl, labelFarmResources, farmCount, farmMaxResources);
            // Wywołanie funkcji która sprawdza czy jest maksymalna ilość surowców
            IsMaxResources(farmLvl, farmCount, timerFarm, farmMaxResources,pictureBoxFarmManual);
            // Wywołanie funkcji zmiany obrazka upgradu (jeśli można ulepszyć, staje się jaśniejszy)
            PictureOfUpgradeChange(farmLvl, farmTransport, pictureBoxFarmUpgrade, farmRequiredResources);
        }

        #endregion Zbieranie surowców farmy

        //*****************************KOPALNIA**************************
        //Opisy analogicznie jak w farmie

        #region Timer kopalni

        /// <summary>
        /// Timer odpowiedzialny za kopalnie (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMine_Tick(object sender, EventArgs e)
        {
            mineCount++;

            CounterResources(mineLvl, labelMineResources, mineCount, mineMaxResources);
            IsMaxResources(mineLvl, mineCount, timerMine, mineMaxResources, pictureBoxMineManual);
            PictureOfUpgradeChange(mineLvl, mineTransport, pictureBoxMineUpgrade, mineRequiredResources);
        }

        #endregion Timer kopalni

        #region Ulepszenie kopalni

        /// <summary>
        /// Ulepszanie kopalni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMineUpgrade_Click(object sender, EventArgs e)
        {
            IsUpgrade(ref mineLvl, ref mineTransport, mineRequiredResources, mineMaxResources, mineMaxTransport, labelMineWarehouse,
                labelMineResources, timerMine, pictureBoxMine, pictureBoxMineUpgrade, mineCount, "mine", pictureBoxMineManual);

            labelMineLvl.Text = "Lvl " + mineLvl;
        }

        #endregion Ulepszenie kopalni

        #region Transport kopalni

        /// <summary>
        /// Transportowanie surowców do magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMineTransport_Click(object sender, EventArgs e)
        {
            TransportResources(mineLvl, ref mineCount, ref mineTransport, mineMaxTransport, mineMaxResources, labelMineWarehouse, labelMineResources, timerMine, pictureBoxMineManual);
        }

        #endregion Transport kopalni

        #region Dymek kopalnia

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMineInfo_MouseEnter(object sender, EventArgs e)
        {
            switch (mineLvl)
            {
                case 1:
                    toolTipMine.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipMine.SetToolTip(pictureBoxMineInfo, "Potrzebujesz x15 kamienia");
                    break;
                case 2:
                    toolTipMine.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipMine.SetToolTip(pictureBoxMineInfo, "Potrzebujesz x30 kamienia");
                    break;
                case 3:
                    toolTipMine.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipMine.SetToolTip(pictureBoxMineInfo, "Potrzebujesz x60 kamienia");
                    break;
                case 4:
                    toolTipMine.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipMine.SetToolTip(pictureBoxMineInfo, "Potrzebujesz x120 kamienia");
                    break;
                case 5:
                    toolTipMine.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipMine.SetToolTip(pictureBoxMineInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek kopalnia

        #region Zbieranie surowców kopalni

        /// <summary>
        /// Ręczne zbieranie surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMineManual_Click(object sender, EventArgs e)
        {
            CollectingResources(mineLvl, mineMaxResources, ref mineCount);

            CounterResources(mineLvl, labelMineResources, mineCount, mineMaxResources);
            IsMaxResources(mineLvl, mineCount, timerMine, mineMaxResources, pictureBoxMineManual);
            PictureOfUpgradeChange(mineLvl, mineTransport, pictureBoxMineUpgrade, mineRequiredResources);
        }

        #endregion Zbieranie surowców kopalni

        //*****************************TARTAK**************************
        //Opisy analogicznie jak w farmie

        #region Timer tartaku

        /// <summary>
        /// Timer odpowiedzialny za tartak (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSawmill_Tick(object sender, EventArgs e)
        {
            sawmillCount++;

            CounterResources(sawmillLvl,labelSawmillResources,sawmillCount,sawmillMaxResources);
            IsMaxResources(sawmillLvl,sawmillCount,timerSawmill,sawmillMaxResources,pictureBoxSawmillManual);
            PictureOfUpgradeChange(sawmillLvl,sawmillTransport,pictureBoxSawmillUpgrade,sawmillRequiredResources);
        }

        #endregion Timer tartaku

        #region Ulepszenie tartaku

        /// <summary>
        /// Ulepszenie kopalni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSawmillUpgrade_Click(object sender, EventArgs e)
        {
            IsUpgrade(ref sawmillLvl, ref sawmillTransport, sawmillRequiredResources, sawmillMaxResources, sawmillMaxTransport, labelSawmillWarehouse,
                labelSawmillResources, timerSawmill, pictureBoxSawmill, pictureBoxSawmillUpgrade, sawmillCount, "sawmill", pictureBoxSawmillManual);

            labelSawmillLvl.Text = "Lvl " + sawmillLvl;
        }

        #endregion Ulepszenie tartaku

        #region Transport tartaku

        /// <summary>
        /// Transportowanie surowców do magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSawmillTransport_Click(object sender, EventArgs e)
        {
            TransportResources(sawmillLvl, ref sawmillCount, ref sawmillTransport, sawmillMaxTransport, sawmillMaxResources, labelSawmillWarehouse, labelSawmillResources, timerSawmill, pictureBoxSawmillManual);

        }

        #endregion Transport tartaku

        #region Dymek tartaku

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSawmillInfo_MouseEnter(object sender, EventArgs e)
        {
            switch (sawmillLvl)
            {
                case 1:
                    toolTipSawmill.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipSawmill.SetToolTip(pictureBoxSawmillInfo, "Potrzebujesz x15 drewna");
                    break;
                case 2:
                    toolTipSawmill.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipSawmill.SetToolTip(pictureBoxSawmillInfo, "Potrzebujesz x30 drewna");
                    break;
                case 3:
                    toolTipSawmill.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipSawmill.SetToolTip(pictureBoxSawmillInfo, "Potrzebujesz x60 drewna");
                    break;
                case 4:
                    toolTipSawmill.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipSawmill.SetToolTip(pictureBoxSawmillInfo, "Potrzebujesz x120 drewna");
                    break;
                case 5:
                    toolTipSawmill.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipSawmill.SetToolTip(pictureBoxSawmillInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek tartaku

        #region Zbieranie surowców tartaku

        /// <summary>
        /// Ręczne zbieranie surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSawmillManual_Click(object sender, EventArgs e)
        {
            CollectingResources(sawmillLvl, sawmillMaxResources, ref sawmillCount);

            CounterResources(sawmillLvl, labelSawmillResources, sawmillCount, sawmillMaxResources);
            IsMaxResources(sawmillLvl, sawmillCount, timerSawmill, sawmillMaxResources, pictureBoxSawmillManual);
            PictureOfUpgradeChange(sawmillLvl, sawmillTransport, pictureBoxSawmillUpgrade, sawmillRequiredResources);
        }

        #endregion Zbieranie surowców tartaku

        //*****************************SKLEP**************************
        //Opisy analogicznie jak w farmie

        #region Timer sklepu

        /// <summary>
        /// Timer odpowiedzialny za sklep (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStore_Tick(object sender, EventArgs e)
        {
            storeCount++;

            CounterResources(storeLvl, labelStoreResources, storeCount, storeMaxResources);
            IsMaxResources(storeLvl, storeCount, timerStore, storeMaxResources, pictureBoxStoreManual);
            PictureOfUpgradeChange(storeLvl, storeTransport, pictureBoxStoreUpgrade, storeRequiredResources);
        }

        #endregion Timer sklepu

        #region Ulepszenie sklepu

        /// <summary>
        /// Ulepszenie sklepu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStoreUpgrade_Click(object sender, EventArgs e)
        {
            IsUpgrade(ref storeLvl, ref storeTransport, storeRequiredResources, storeMaxResources, storeMaxTransport, labelStoreWarehouse,
                labelStoreResources, timerStore, pictureBoxStore, pictureBoxStoreUpgrade, storeCount, "store", pictureBoxStoreManual);

            labelStoreLvl.Text = "Lvl " + storeLvl;
        }

        #endregion Ulepszenie sklepu

        #region Transport sklepu

        /// <summary>
        /// Transportowanie surowców do magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStoreTransport_Click(object sender, EventArgs e)
        {
            TransportResources(storeLvl, ref storeCount, ref storeTransport, storeMaxTransport, storeMaxResources, labelStoreWarehouse, labelStoreResources, timerStore, pictureBoxStoreManual);

        }

        #endregion Transport sklepu

        #region Dymek sklepu

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStoreInfo_MouseEnter(object sender, EventArgs e)
        {
            switch (storeLvl)
            {
                case 1:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxStoreInfo, "Potrzebujesz x15 monet");
                    break;
                case 2:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxStoreInfo, "Potrzebujesz x30 monet");
                    break;
                case 3:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxStoreInfo, "Potrzebujesz x60 monet");
                    break;
                case 4:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxStoreInfo, "Potrzebujesz x120 monet");
                    break;
                case 5:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxStoreInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek sklepu

        #region Zbieranie surowców sklepu

        /// <summary>
        /// Ręczne zbieranie surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStoreManual_Click(object sender, EventArgs e)
        {
            CollectingResources(storeLvl, storeMaxResources, ref storeCount);

            CounterResources(storeLvl, labelStoreResources, storeCount, storeMaxResources);
            IsMaxResources(storeLvl, storeCount, timerStore, storeMaxResources, pictureBoxStoreManual);
            PictureOfUpgradeChange(storeLvl, storeTransport, pictureBoxStoreUpgrade, storeRequiredResources);
        }

        #endregion Zbieranie surowców sklepu

        //*****************************ARMIA**************************
        //Opisy analogicznie jak w farmie

        #region Timer Armi

        /// <summary>
        /// Timer odpowiedzialny za armie (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerArmy_Tick(object sender, EventArgs e)
        {
            armyCount++;

            CounterResources(armyLvl, labelArmyResources, armyCount, armyMaxResources);
            IsMaxResources(armyLvl, armyCount, timerArmy, armyMaxResources, pictureBoxArmyManual);
            PictureOfUpgradeChange(armyLvl, armyTransport, pictureBoxArmyUpgrade, armyRequiredResources);
        }

        #endregion Timer Armi

        #region Ulepszenie armi

        /// <summary>
        /// Ulepszenie armi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxArmyUpgrade_Click(object sender, EventArgs e)
        {
            IsUpgrade(ref armyLvl, ref armyTransport, armyRequiredResources, armyMaxResources, armyMaxTransport, labelArmyWarehouse,
                labelArmyResources, timerArmy, pictureBoxArmy, pictureBoxArmyUpgrade, armyCount, "army", pictureBoxArmyManual);

            labelArmyLvl.Text = "Lvl " + armyLvl;
        }

        #endregion Ulepszenie armi

        #region Transport armi

        /// <summary>
        /// Transport surowców do magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxArmyTransport_Click(object sender, EventArgs e)
        {
            TransportResources(armyLvl, ref armyCount, ref armyTransport, armyMaxTransport, armyMaxResources, labelArmyWarehouse, labelArmyResources, timerArmy, pictureBoxArmyManual);

        }

        #endregion Transport armi

        #region Dymek armi

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxArmyInfo_MouseEnter(object sender, EventArgs e)
        {
            switch (armyLvl)
            {
                case 1:
                    toolTipArmy.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipArmy.SetToolTip(pictureBoxArmyInfo, "Potrzebujesz x15 rycerzy");
                    break;
                case 2:
                    toolTipArmy.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipArmy.SetToolTip(pictureBoxArmyInfo, "Potrzebujesz x30 rycerzy");
                    break;
                case 3:
                    toolTipArmy.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipArmy.SetToolTip(pictureBoxArmyInfo, "Potrzebujesz x60 rycerzy");
                    break;
                case 4:
                    toolTipArmy.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipArmy.SetToolTip(pictureBoxArmyInfo, "Potrzebujesz x120 rycerzy");
                    break;
                case 5:
                    toolTipArmy.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipArmy.SetToolTip(pictureBoxArmyInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek armi

        #region Zbieranie surowców armi

        /// <summary>
        /// Ręczne zbieranie surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxArmyManual_Click(object sender, EventArgs e)
        {
            CollectingResources(armyLvl, armyMaxResources, ref armyCount);

            CounterResources(armyLvl, labelArmyResources, armyCount, armyMaxResources);
            IsMaxResources(armyLvl, armyCount, timerArmy, armyMaxResources, pictureBoxArmyManual);
            PictureOfUpgradeChange(armyLvl, armyTransport, pictureBoxArmyUpgrade, armyRequiredResources);
        }

        #endregion Zbieranie surowców armi

        //*****************************HODOWLA**************************
        //Opisy analogicznie jak w farmie

        #region Timer hodowli

        /// <summary>
        /// Timer odpowiedzialny za hodowle (naliczanie surowców itp...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAnimal_Tick(object sender, EventArgs e)
        {
            animalCount++;

            CounterResources(animalLvl, labelAnimalResources, animalCount, animalMaxResources);
            IsMaxResources(animalLvl, animalCount, timerAnimal, animalMaxResources, pictureBoxAnimalManual);
            PictureOfUpgradeChange(animalLvl, animalTransport, pictureBoxAnimalUpgrade, animalRequiredResources);
        }

        #endregion Timer hodowli

        #region Ulepszenie hodowli

        /// <summary>
        /// Ulepszenie hodowli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxAnimalUpgrade_Click(object sender, EventArgs e)
        {
            IsUpgrade(ref animalLvl, ref animalTransport, animalRequiredResources, animalMaxResources, animalMaxTransport, labelAnimalWarehouse,
                            labelAnimalResources, timerAnimal, pictureBoxAnimal, pictureBoxAnimalUpgrade, animalCount, "animal", pictureBoxAnimalManual);

            labelAnimalLvl.Text = "Lvl " + animalLvl;
        }

        #endregion Ulepszenie hodowli

        #region Transport hodowli

        /// <summary>
        /// Transportowanie surowców do magazynu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxAnimalTransport_Click(object sender, EventArgs e)
        {
            TransportResources(animalLvl, ref animalCount, ref animalTransport, animalMaxTransport, animalMaxResources, labelAnimalWarehouse, labelAnimalResources, timerAnimal, pictureBoxAnimalManual);

        }

        #endregion Transport hodowli

        #region Dymek hodowli

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxAnimalInfo_MouseEnter(object sender, EventArgs e)
        {
            switch (animalLvl)
            {
                case 1:
                    toolTipAnimal.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipAnimal.SetToolTip(pictureBoxAnimalInfo, "Potrzebujesz x15 zwierzat");
                    break;
                case 2:
                    toolTipAnimal.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipAnimal.SetToolTip(pictureBoxAnimalInfo, "Potrzebujesz x30 zwierzat");
                    break;
                case 3:
                    toolTipAnimal.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipAnimal.SetToolTip(pictureBoxAnimalInfo, "Potrzebujesz x60 zwierzat");
                    break;
                case 4:
                    toolTipAnimal.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipAnimal.SetToolTip(pictureBoxAnimalInfo, "Potrzebujesz x120 zwierzat");
                    break;
                case 5:
                    toolTipAnimal.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipAnimal.SetToolTip(pictureBoxAnimalInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek hodowli

        #region Zbieranie surowców hodowli

        /// <summary>
        /// Ręczne zbieranie surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxAnimalManual_Click(object sender, EventArgs e)
        {
            CollectingResources(animalLvl, animalMaxResources, ref animalCount);

            CounterResources(animalLvl, labelAnimalResources, animalCount, animalMaxResources);
            IsMaxResources(animalLvl, animalCount, timerAnimal, animalMaxResources, pictureBoxAnimalManual);
            PictureOfUpgradeChange(animalLvl, animalTransport, pictureBoxAnimalUpgrade, animalRequiredResources);
        }

        #endregion Zbieranie surowców hodowli

        //*****************************ZAMEK**************************

        #region Ulepszanie zamku
        
        /// <summary>
        /// Ulepszenie zamku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxCastleUpgrade_Click(object sender, EventArgs e)
        {
            // Switch zależny od poziomu
            switch (castleLvl)
            {
                case 1:
                    // Jeśli mamy odpowiednią ilość emeraldów
                    if (emerald >= castleRequiredResources[0])
                    {
                        // Ulepszamy zamek
                        castleLvl++;
                        // Odejmujemy taką ilość emeraldów jaką potzebowaliśmy
                        emerald -= castleRequiredResources[0];
                        // Zmieniamy obrazek
                        pictureBoxCastle.Image = Properties.Resources.Castle2;
                        // Zmieniamy obrazek 
                        pictureBoxCastleUpgrade.Image = Properties.Resources.UpgradeOff;
                        // Aktualizacja labela
                        labelCastleLvl.Text = "lvl " + castleLvl;
                        // Zwiększamy ilość wydobycia surowców ręcznie
                        collectedResources = 2;
                    }
                    break;
                case 2:
                    if (emerald >= castleRequiredResources[1])
                    {
                        castleLvl++;
                        emerald -= castleRequiredResources[1];
                        pictureBoxCastle.Image = Properties.Resources.Castle3;
                        pictureBoxCastleUpgrade.Image = Properties.Resources.UpgradeOff;
                        labelCastleLvl.Text = "lvl " + castleLvl;
                        collectedResources = 3;
                    }
                    break;
                case 3:
                    if (emerald >= castleRequiredResources[2])
                    {
                        castleLvl++;
                        emerald -= castleRequiredResources[2];
                        pictureBoxCastle.Image = Properties.Resources.Castle4;
                        pictureBoxCastleUpgrade.Image = Properties.Resources.UpgradeOff;
                        labelCastleLvl.Text = "lvl " + castleLvl;
                        collectedResources = 4;
                    }
                    break;
                case 4:
                    if (emerald >= castleRequiredResources[3])
                    {
                        castleLvl++;
                        emerald -= castleRequiredResources[3];
                        pictureBoxCastle.Image = Properties.Resources.Castle5;
                        pictureBoxCastleUpgrade.Image = Properties.Resources.UpgradeOff;
                        labelCastleLvl.Text = "lvl " + castleLvl;
                        collectedResources = 5;
                    }
                    break;

            }
           
        }

        #endregion Ulepszanie zamku

        #region Dymek zamku

        /// <summary>
        /// Pojawienie się podpowiedzi w postaci dymku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxCastleInfo_MouseEnter(object sender, EventArgs e)
        {
            // Switch zależny od poziomu
            switch (castleLvl)
            {
                case 1:
                    // Ustaw tytuł dymku
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    // Ustaw treść dymku
                    toolTipStore.SetToolTip(pictureBoxCastleInfo, "Potrzebujesz x10 emeraldów");
                    break;
                case 2:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxCastleInfo, "Potrzebujesz x20 emeraldów");
                    break;
                case 3:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxCastleInfo, "Potrzebujesz x40 emeraldów");
                    break;
                case 4:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxCastleInfo, "Potrzebujesz x80 emeraldów");
                    break;
                case 5:
                    toolTipStore.ToolTipTitle = "Wymagane surowce do ulepszenia";
                    toolTipStore.SetToolTip(pictureBoxCastleInfo, "Osiągnieto maksymalny poziom");
                    break;
            }
        }

        #endregion Dymek zamku

        #region Timer zamku

        /// <summary>
        /// Timer odpowiedzialny za zamek (sprawdza warunki na bieżąco)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCastle_Tick(object sender, EventArgs e)
        {
            // Aktualizacja labela
            labelCastleResources.Text = emerald.ToString();

            // Jeśli poziom zamku wynosi 1 oraz posiadamy wystarczająco ilość emeraldów na ulepszenie
            if (castleLvl == 1 && emerald >= castleRequiredResources[0])
            {
                // Zmień obrazek ulepszenia na aktywny
                pictureBoxCastleUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (castleLvl == 2 && emerald >= castleRequiredResources[1])
            {
                pictureBoxCastleUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (castleLvl == 3 && emerald >= castleRequiredResources[2])
            {
                pictureBoxCastleUpgrade.Image = Properties.Resources.Upgrade;
            }
            if (castleLvl == 4 && emerald >= castleRequiredResources[3])
            {
                pictureBoxCastleUpgrade.Image = Properties.Resources.Upgrade;
            }
        }

        #endregion Timer zamku

        //************************************************************

    }
}
