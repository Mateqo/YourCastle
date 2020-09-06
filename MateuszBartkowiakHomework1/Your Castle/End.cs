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
    public partial class End : Form
    {

        #region Zmienne

        // Deklaracja zmiennej by odwoływać się  
        Game game;

        #endregion Zmienne

        #region Kontruktory

        public End()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kontruktor wywołany przez okno Game
        /// </summary>
        /// <param name="game"></param>
        public End(Game game)
        {
            InitializeComponent();
            // Przypisujemy zmiennej game, by móc się odwoływać
            this.game = game;
        }

        #endregion Kontruktory

        #region Ekran zwycięstwa 

        /// <summary>
        /// Wyświetlanie labela oraz nicku gracza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Load(object sender, EventArgs e)
        {
            // Aktualizuj label o nick gracza
            labelEnd.Text = "Zwycięstwo gracza " + game.nick;
        }

        #endregion Ekran zwycięstwa

        #region Wyjście do menu
        
        /// <summary>
        /// Ukrycie okna, pojawienie się okna Customization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            // Ukryj okno 
            this.Visible = false;
            // Stwórz okno Customization
            Customization cust = new Customization(this);
            // Otwórz je
            cust.ShowDialog();
        }

        #endregion Wyjście do menu

    }
}
