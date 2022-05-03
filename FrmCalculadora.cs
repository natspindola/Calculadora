using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        double numero1 = 0, numero2 = 0;
        char operador;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void AgregarNumero(object sender, EventArgs e)
        {
            var btn = ((Button)sender);
            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += btn.Text;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);

            if(operador == '+')
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if(operador == '-')
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == '*')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == '/')
            {
                txtResultado.Text = (numero1 / numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if(operador == '%')
            {
                var porcentagem = CalcularPorcentagem(numero1, numero2);
                txtResultado.Text = porcentagem.ToString();
            }
        }

        private void clickOperador(object sender, EventArgs e)
        {
            var btn = ((Button)sender);

            switch (btn.Text)
            {
                case "%":
                    operador = '%';
                    break;
                default:
                    break;
            }

            numero1 = Convert.ToDouble(txtResultado.Text);
            if(operador == '√')
            {
                numero1 = Math.Sqrt(numero1);
                txtResultado.Text = numero1.ToString();
            }
            else if(operador == '²')
            {
                numero1 = Math.Pow(numero1,2);
                txtResultado.Text = numero1.ToString();
            }
            else if (operador == '%')
            {
                operador = Convert.ToChar(btn.Tag);
                txtResultado.Text = "0";                
            }
            else
            {
                operador = Convert.ToChar(btn.Tag);
                txtResultado.Text = "0";
            }
        }

        private int CalcularPorcentagem(double total, double porcentagem)
        {
            var resultado = ((double)porcentagem / 100) * total;

            return Convert.ToInt32(resultado);
        }
    }
}
