using System;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Main : Form
    {
        BestOil bestOil = new BestOil();
        MiniCafe miniCafe = new MiniCafe();
        PetrolStation petrolStation = new PetrolStation();
        public Main()
        {
            InitializeComponent();

            bestOil.MiniCafe = miniCafe;
            bestOil.PetrolStation = petrolStation;
            literRadio.Enabled = false;
            priceRadio.Enabled = false;
            gasolineComboBox.Items.Add(petrolStation.Gasolines[0].Type);
            gasolineComboBox.Items.Add(petrolStation.Gasolines[1].Type);
            gasolineComboBox.Items.Add(petrolStation.Gasolines[2].Type);
            hotdogPrice.Text = miniCafe.Foods[0].Price.ToString();
            hamburgerPrice.Text = miniCafe.Foods[1].Price.ToString();
            friesPrice.Text = miniCafe.Foods[2].Price.ToString();
            colaPrice.Text = miniCafe.Foods[3].Price.ToString();
        }

        private void gasolineComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            literRadio.Enabled = true;
            priceRadio.Enabled = true;
            PetrolStation petrolStation = new PetrolStation();

            int index = gasolineComboBox.SelectedIndex;
            gasolinePriceTextbox.Text = petrolStation.Gasolines[index].Price.ToString();
        }

        private void literRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            literAmount.Enabled = true;
            moneyAmount.Enabled = false;
            if (moneyAmount.Text != String.Empty)
            {
                try
                {
                    moneyAmount.Text = default;
                }
                catch { }
            }
        }

        private void priceRadio_CheckedChanged(object sender, EventArgs e)
        {
            moneyAmount.Enabled = true;
            literAmount.Enabled = false;
            if (literAmount.Text != String.Empty)
            {
                try
                {
                    literAmount.Text = default;
                }
                catch { }
            }
        }

        private void literAmount_TextChanged(object sender, EventArgs e)
        {
            if (literAmount.Text == String.Empty)
            {
                try
                {
                    literAmount.Text = default;
                }
                catch { }
            }
            int index = gasolineComboBox.SelectedIndex;
            petrolStation.Price = petrolStation.Gasolines[index].Price;
            try
            {
                petrolStation.Liter = double.Parse(literAmount.Text);
            }
            catch { }

            stationSum.Text = petrolStation.GetPrice().ToString();
            totalSum.Text = petrolStation.GetPrice().ToString();
        }

        private void moneyAmount_TextChanged(object sender, EventArgs e)
        {
            if (moneyAmount.Text == String.Empty)
            {
                try
                {
                    moneyAmount.Text = default;
                }
                catch { }
            }
            int index = gasolineComboBox.SelectedIndex;
            petrolStation.Price = petrolStation.Gasolines[index].Price;
            try
            {
                double price = double.Parse(moneyAmount.Text);
                petrolStation.Liter = price / petrolStation.Gasolines[index].Price;
            }
            catch { }

            literAmount.Text = ((int)petrolStation.Liter).ToString();
            stationSum.Text = petrolStation.GetPrice().ToString();
            totalSum.Text = petrolStation.GetPrice().ToString();
        }

        private void hotdogCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!hotdogQuantity.Enabled)
            {
                hotdogQuantity.Enabled = true;
            }
            else
            {
                hotdogQuantity.Text = "0";
                hotdogQuantity.Enabled = false;
                hotdogQuantity.Text = "";
            }

            if (hotdogQuantity.Text != String.Empty)
            {
                miniCafe.Foods[0].Count = int.Parse(hotdogQuantity.Text);
            }

        }

        private void hamburgCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!hamburgerQuantity.Enabled)
            {
                hamburgerQuantity.Enabled = true;
            }
            else
            {
                hamburgerQuantity.Text = "0";
                hamburgerQuantity.Enabled = false;
                hamburgerQuantity.Text = "";
            }

            if (hamburgerQuantity.Text != String.Empty)
            {
                miniCafe.Foods[1].Count = int.Parse(hamburgerQuantity.Text);
            }
        }

        private void potatoCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!friesQuantity.Enabled)
            {
                friesQuantity.Enabled = true;
            }
            else
            {
                friesQuantity.Text = "0";
                friesQuantity.Enabled = false;
                friesQuantity.Text = "";
            }

            if (friesQuantity.Text != String.Empty)
            {
                miniCafe.Foods[2].Count = int.Parse(friesQuantity.Text);
            }
        }

        private void colaCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!colaQuantity.Enabled)
            {
                colaQuantity.Enabled = true;
            }
            else
            {
                colaQuantity.Text = "0";
                colaQuantity.Enabled = false;
                colaQuantity.Text = "";
            }

            if (colaQuantity.Text != String.Empty)
            {
                miniCafe.Foods[3].Count = int.Parse(colaQuantity.Text);
            }
        }


        private void hotdogQuantity_TextChanged(object sender, EventArgs e)
        {
            if (hotdogQuantity.Text != String.Empty)
            {
                miniCafe.Foods[0].Count = int.Parse(hotdogQuantity.Text);
            }
            else
            {
                hotdogQuantity.Text = "";
            }
            cafeSum.Text = miniCafe.GetPrice().ToString();
            totalSum.Text = miniCafe.GetPrice().ToString();
            if (cafeSum.Text == "0")
            {
                cafeSum.Text = "";
            }
        }

        private void hamburgerQuantity_TextChanged(object sender, EventArgs e)
        {
            if (hamburgerQuantity.Text != String.Empty)
            {
                miniCafe.Foods[1].Count = int.Parse(hamburgerQuantity.Text);
            }
            else
            {
                hamburgerQuantity.Text = "";
            }
            cafeSum.Text = miniCafe.GetPrice().ToString();
            totalSum.Text = miniCafe.GetPrice().ToString();
            if (cafeSum.Text == "0")
            {
                cafeSum.Text = "";
            }
        }

        private void friesQuantity_TextChanged(object sender, EventArgs e)
        {
            if (friesQuantity.Text != String.Empty)
            {
                miniCafe.Foods[2].Count = int.Parse(friesQuantity.Text);
            }
            else
            {
                friesQuantity.Text = "";
            }

            cafeSum.Text = miniCafe.GetPrice().ToString();
            totalSum.Text = miniCafe.GetPrice().ToString();
            if (cafeSum.Text == "0")
            {
                cafeSum.Text = "";
            }
        }

        private void colaQuantity_TextChanged(object sender, EventArgs e)
        {
            if (colaQuantity.Text != String.Empty)
            {
                miniCafe.Foods[3].Count = int.Parse(colaQuantity.Text);
            }
            else
            {
                colaQuantity.Text = "";
            }
            cafeSum.Text = miniCafe.GetPrice().ToString();
            totalSum.Text = miniCafe.GetPrice().ToString();
            if (cafeSum.Text == "0")
            {
                cafeSum.Text = "";
            }
        }

        private void totalSum_TextChanged(object sender, EventArgs e)
        {
            //Controls.Owner.Text = bestOil.PriceTotal().ToString();
            totalSum.Text = bestOil.PriceTotal().ToString();
        }
    }
}
