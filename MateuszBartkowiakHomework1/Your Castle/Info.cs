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
    public partial class Info : Form
    {

        #region Zmienne

        // Deklaracja zmiennej by móc odwoływać się do ona cust  
        Customization cust;
        // Deklaracja zmiennej by móc odwoływać się do okna game 
        Game game;

        #endregion Zmienne

        #region Konsktruktory

        public Info()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor wywołany przez okno customization
        /// </summary>
        /// <param name="cust"></param>
        public Info(Customization cust)
        {
            InitializeComponent();
            this.cust = cust;
        }

        /// <summary>
        /// Konstruktor wywołany przez okno game
        /// </summary>
        /// <param name="game"></param>
        public Info(Game game)
        {
            InitializeComponent();
            // Przypisujemy by móc się odwoływać do tego okna
            this.game = game;
            // Możliwość wciśnięcia labela kontynuacja włączona
            labelContinuation.Enabled = true;
            // Możliwość wciśnięcia lebela nowa gra wyłączona
            labelNewGame.Enabled = false;
        }

        #endregion Konsktruktory  

        #region Przycisk New Game

        /// <summary>
        /// Tworzy sie nowa gra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelNewGame_Click(object sender, EventArgs e)
        {
            // Wyłączenie widoczności okna Info
            this.Visible = false;
            // Włączenie widoczności okna Customization
            cust.Visible = true;
        }

        #endregion Przycisk New Game

        #region Przycisk Kontynuacja

        /// <summary>
        /// Kontunujemy rozgrywkę wcześniej zaczętą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelContinuation_Click(object sender, EventArgs e)
        {
            // Wyłączenie widoczności okna Info
            this.Visible = false;
            // Włączenie widoczności okna Game
            game.Visible = true;
        }

        #endregion Przycisk Kontynuacja

    }
}
