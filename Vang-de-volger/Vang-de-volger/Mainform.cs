using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vang_de_volger
{
    public partial class MainForm : Form
    {
        private Field _playZone = new Field();
        private int _villainMoveInterval = 500; //interval at which villain moves in milliseconds
        private Timer _timerVillainMove = new Timer(); //Create a timer to make the villain move
        public const int x_gridSize = 15;  //Amount of tiles in X-direction on the field
        public const int y_gridSize = 15;  //Amount of tiles in Y-direction on the field
        public const int tileSize = 40; //set how big the tiles are, this value should match the tile Image
        private bool _paused = false;  //bool to track whether the paused button was pressed
        private Size endPbSize;

        public MainForm()
        {
            InitializeComponent();
            GenerateField();

            pause_Label.Left = x_gridSize * tileSize + tileSize;
            restart_Button.Left = x_gridSize * tileSize + tileSize;
            endPbSize = new Size(x_gridSize * tileSize, x_gridSize * tileSize);
            endPb.Size = endPbSize;
            endPb.Left = 0; endPb.Top = 0;
            endPb.Visible = false;
            endPb.BackColor = Color.Transparent;
        }

        public void GenerateField()
        {
            this.Invalidate();
            _playZone.CreateField(this);
            this.Refresh();
        }

        private void pause_Label_Click(object sender, EventArgs e)
        {

        }

        private void restart_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
