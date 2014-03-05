using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace LeitorDeClimaComArduino
{
    public partial class FormPrincipal : Form
    {
        private const string ETX = "\x03"; // Fim de texto
        private const string STX = "\x02"; // Início de texto
        private const string DHTLIB_ERROR_CHECKSUM = "-1";
        private const string DHTLIB_ERROR_TIMEOUT = "-2";
        private const string DHTLIB_ERROR_UNKNOWN = "-3";

        private const string ComandoLerClima = "LC#";
              
        private static readonly IDictionary<string, string> MensagensDeErro = new Dictionary<string, string>
                                                                  {
                                                                      {DHTLIB_ERROR_CHECKSUM, "Erro de integridade na leitura."}
                                                                      ,{DHTLIB_ERROR_TIMEOUT, "Erro de tempo de leitura máxima."}
                                                                      ,{DHTLIB_ERROR_UNKNOWN, "Erro desconhecido."}
                                                                  };
        private string _mensagemPadradoRodape;

        private delegate void ProcessaRespostaDelegate(string resposta);

        public FormPrincipal()
        {
            InitializeComponent();
            CarreguePortas();
            CarregueBaudRates();
        }        

        #region Eventos da tela
        private void FormPrincipalClosing(object sender, FormClosingEventArgs e)
        {
            temporizador.Stop();
            FecheComunicacaoComArduino();
        }

        private void BtDesconectarClick(object sender, EventArgs e)
        {
            FecheComunicacaoComArduino();
            AlteraBotoesPrincipais(true);
            lblStatusBarraFerramentas.Text = "Desconectado.";
            temporizador.Stop();
            climaBindingSource.Clear();
        }

        private void BtConectarClick(object sender, EventArgs e)
        {            
            try
            {
                AbraComunicacaoComArduino(portasComboBox.SelectedItem.ToString(),
                                          int.Parse(baudRateComboBox.SelectedItem.ToString()));
                AlteraBotoesPrincipais(false);
                
                _mensagemPadradoRodape = string.Format("Conectado à {0} ", portasComboBox.SelectedItem);
                lblStatusBarraFerramentas.Text = _mensagemPadradoRodape;

                temporizador.Start();
            }
            catch
            {
                MessageBox.Show(string.Format("Não foi possível conectar à porta {0}.", arduino.PortName),
                                "Falha na conexão.", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                AlteraBotoesPrincipais(true);
                lblStatusBarraFerramentas.Text = "Desconectado.";
            }            
        }

        private void BtLimparHistoricoClick(object sender, EventArgs e)
        {
            climaBindingSource.Clear();
        }        
        
        private void TemporizadorTick(object sender, EventArgs e)
        {
            EnvieComandoParaArduino(ComandoLerClima);
        }
        #endregion

        #region Trata resposta do arduino
        private void ArduinoDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var resposta = arduino.ReadTo(ETX).Replace(STX, String.Empty).Replace(ETX, String.Empty);

            Invoke(new ProcessaRespostaDelegate(ProcesseResposta), new Object[] { resposta });
        }

        private void ProcesseResposta(string resposta)
        {
            var clima = ConverteRespostasStringJsonEmObjeto(resposta);

            if (clima == null) return;

            if (String.IsNullOrEmpty(clima.Erro))
            {
                lblStatusBarraFerramentas.Text = _mensagemPadradoRodape;
                clima.Data = DateTime.Now;
                climaBindingSource.Insert(0, clima);
                historicoDeClima.Rows[0].Selected = true;
            }
            else
            {
                var mensagem = new StringBuilder();

                if (MensagensDeErro.ContainsKey(clima.Erro))
                {
                    mensagem.AppendFormat(MensagensDeErro[clima.Erro]);
                }
                else
                {
                    mensagem.Append("Erro na leitura");
                }

                mensagem.Append(".");
                lblStatusBarraFerramentas.Text = mensagem.ToString();
            }
        }

        private static Clima ConverteRespostasStringJsonEmObjeto(string resposta)
        {
            var serializer = new DataContractJsonSerializer(typeof(Clima));
            MemoryStream stream = null;

            try
            {
                stream = new MemoryStream(Encoding.UTF8.GetBytes(resposta));
                var clima = serializer.ReadObject(stream) as Clima;
                stream.Close();
                return clima;
            }
            catch
            {
                if (stream != null) stream.Close();
                return null;
            }
        }
        #endregion        

        #region Comunicacao com arduino
        private void EnvieComandoParaArduino(String comando)
        {
            arduino.Write(comando);
        }

        private void AbraComunicacaoComArduino(String porta, int baudRate)
        {
            if (arduino.IsOpen) return;
            arduino.PortName = porta;
            arduino.BaudRate = baudRate;
            arduino.Open();
        }

        private void FecheComunicacaoComArduino()
        {
            if (arduino.IsOpen) arduino.Close();
        }
        #endregion

        private void CarreguePortas()
        {
            var index = -1;
            string comPortName = null;
            var arrayComPortsNames = SerialPort.GetPortNames();

            do
            {
                index += 1;
                portasComboBox.Items.Add(arrayComPortsNames[index]);
            } while (!((arrayComPortsNames[index] == comPortName) || (index == arrayComPortsNames.GetUpperBound(0))));

            Array.Sort(arrayComPortsNames);

            portasComboBox.Text = arrayComPortsNames[0];
        }

        private void CarregueBaudRates()
        {
            baudRateComboBox.Items.Add(300);
            baudRateComboBox.Items.Add(600);
            baudRateComboBox.Items.Add(1200);
            baudRateComboBox.Items.Add(2400);
            baudRateComboBox.Items.Add(9600);
            baudRateComboBox.Items.Add(14400);
            baudRateComboBox.Items.Add(19200);
            baudRateComboBox.Items.Add(38400);
            baudRateComboBox.Items.Add(57600);
            baudRateComboBox.Items.Add(115200);
            baudRateComboBox.Text = baudRateComboBox.Items[4].ToString();
        }

        private void AlteraBotoesPrincipais(bool valor)
        {
            btConectar.Visible = valor;
            btDesconectar.Visible = !valor;
            portasComboBox.Enabled = valor;
            baudRateComboBox.Enabled = valor;
            btLimparHistorico.Enabled = !valor;
        }
    }
}
