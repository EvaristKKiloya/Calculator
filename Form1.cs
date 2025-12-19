using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // IMPORTANT: remove designer layout influence
            InitializeComponent();
            Controls.Clear();

            // Form settings
            Text = "Calculator";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(320, 480);

            // ===== DISPLAY PANEL =====
            Panel displayPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(24, 24, 24),
                Padding = new Padding(10)
            };

            Label display = new Label
            {
                Text = "0",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 36, FontStyle.Bold),
                TextAlign = ContentAlignment.BottomRight
            };

            displayPanel.Controls.Add(display);

            // ===== BUTTON PANEL =====
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 6,
                ColumnCount = 4,
                BackColor = Color.FromArgb(40, 40, 40),
                Padding = new Padding(8)
            };

            for (int i = 0; i < 4; i++)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            for (int i = 0; i < 6; i++)
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));

            string[,] buttons =
            {
                { "%", "CE", "C", "⌫" },
                { "1/x", "x²", "√x", "÷" },
                { "7", "8", "9", "×" },
                { "4", "5", "6", "−" },
                { "1", "2", "3", "+" },
                { "±", "0", ".", "=" }
            };

            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Button btn = new Button
                    {
                        Text = buttons[r, c],
                        Dock = DockStyle.Fill,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 14),
                        Margin = new Padding(4),
                        ForeColor = Color.WhiteSmoke,
                        BackColor = Color.FromArgb(60, 60, 60)
                    };

                    btn.FlatAppearance.BorderSize = 0;

                    if (btn.Text == "=")
                        btn.BackColor = Color.FromArgb(0, 120, 215);

                    panel.Controls.Add(btn, c, r);
                }
            }

            // ===== ADD CONTROLS IN CORRECT ORDER =====
            Controls.Add(panel);
            Controls.Add(displayPanel);
        }
    }
}
