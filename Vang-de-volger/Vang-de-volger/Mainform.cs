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

        private Image _victoryImage = Image.FromFile(@"..\..\Resources\Victory.png");
        private Image _loseImage = Image.FromFile(@"..\..\Resources\Lose.png");
        private Image _pauseImage = Image.FromFile(@"..\..\Resources\Paused.png");

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

            //Start the movement of the Villain
            _timerVillainMove.Interval = _villainMoveInterval;
            _timerVillainMove.Tick += TimerVillainMove_Tick;
            _timerVillainMove.Start();
        }

        public void GenerateField()
        {
            this.Invalidate();
            _playZone.CreateField(this);
            this.Refresh();
        }

        //Move handler and win/lose handler of the Villain
        public void TimerVillainMove_Tick(object sender, EventArgs e)
        {
            //Check to see if the villain has any moves left through a bool in the Field class.
            if (_playZone._enemy.villain_Lose(_playZone.FindVillain()) == true)
            {
                _timerVillainMove.Stop();
                endPb.Visible = true;
                endPb.Image = _victoryImage;
                _paused = true;
            }
            //Check to see if the villain has succesfully caught the player through a bool in the Field class.
            else if (_playZone._enemy.Catch_Hero(_playZone.FindVillain()) == true)
            {
                _timerVillainMove.Stop();
                endPb.Visible = true;
                endPb.Image = _loseImage;
                _paused = true;
            }
            else
            {
                _playZone._enemy.Villain_random_move(_playZone.FindVillain());
                this.Refresh();
            }
        }

        private void pause_Label_Click(object sender, EventArgs e)
        {

        }

        private void restart_Button_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_paused == false)
            {
                if (e.KeyCode == Keys.Left)
                {
                    _playZone.Move_Unit(_playZone._player, Tile.DIRECTIONS.LEFT);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    _playZone.Move_Unit(_playZone._player, Tile.DIRECTIONS.RIGHT);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    _playZone.Move_Unit(_playZone._player, Tile.DIRECTIONS.TOP);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    _playZone.Move_Unit(_playZone._player, Tile.DIRECTIONS.BOTTOM);
                }
            }
        }
    }
}
