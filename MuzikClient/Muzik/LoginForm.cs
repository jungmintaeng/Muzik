using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Net.Sockets;
using Packet_Delivery;

namespace Muzik
{
    public partial class LoginForm : Form
    {
        public bool login_check = false;
        public string ID;
        private Login login;
        private LoginConfirm loginconfirm;

        private NetworkStream NetStream;                  // 서버 클라이언트 간에 주고받을 networkStream                
        private TcpClient Cli;                         // 서버에 접속하기위한 클라이언트

        private byte[] sendBuffer = new byte[1024 * 4];     // 서버 내부에서 파일내용을 읽거나 보내기위하 버퍼
        private byte[] ReadBuffer = new byte[1024 * 4];

        private bool ConnectedToServer = false;                  // 연결여부를 나타내는 bool자료형

        public LoginForm()
        {
            InitializeComponent();
            txt_PW.PasswordChar = '●';
        }

        private void btn_Longin_Click(object sender, EventArgs e)
        {
            /////////////connect
            try
            {

                if (!ConnectedToServer)                             //서버에 연결된 상태가 아닐 때
                {
                    Cli = new TcpClient();                          //새로운 클라이언트를 생성하고

                    try
                    {
                        this.Cli.Connect(this.txt_ip.Text, 8080);
                        //서버에 연결한다
                    }
                    catch (Exception ex)    //예외가 발생하면
                    {
                        MessageBox.Show("Connection ERROR" + ex.Message); //어떤 예외인지 출력하고
                        return; //리턴
                    }
                    NetStream = Cli.GetStream();        //네트워크 스트림 연결

                    this.ConnectedToServer = true;      //서버에 연결되었다고 bool형으로 표시

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect ERROR\r\n" + ex.Message);
            }

            /////////////

            //패킷 주고 받기
            login = new Login();

            login.ID = txt_ID.Text;
            login.PW = txt_PW.Text;

            Packet.Serialize(login).CopyTo(sendBuffer, 0);     // 내가 더블클릭한거에 대한 정보 serialize
            NetStream.Write(sendBuffer, 0, sendBuffer.Length);     // 전송
            NetStream.Flush();

            //받기

            this.NetStream.Read(this.ReadBuffer, 0, this.ReadBuffer.Length); //읽어오고
            loginconfirm = (LoginConfirm)Packet.Deserialize(this.ReadBuffer); //해독해서
            
            //
            if (loginconfirm.loginConfirm == false)
            {
                MessageBox.Show("입력하신 ID와 비밀번호를 다시 한 번 확인해주세요...", "Fail");
            }
            else if (loginconfirm.loginConfirm == true)
            {
                MainForm main = new MainForm();
                main.User = login.ID;
                main.Netstream = this.NetStream;
                main.client = this.Cli;
                this.Owner = main;
                this.Hide();
                main.Show();
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txt_ip.Text = "localhost";
            try
            {

                if (!ConnectedToServer)                             //서버에 연결된 상태가 아닐 때
                {
                    Cli = new TcpClient();                          //새로운 클라이언트를 생성하고

                    try
                    {
                        this.Cli.Connect(this.txt_ip.Text, 8080);
                        //서버에 연결한다
                    }
                    catch (Exception ex)    //예외가 발생하면
                    {
                        MessageBox.Show("Connection ERROR" + ex.Message); //어떤 예외인지 출력하고
                        return; //리턴
                    }
                    NetStream = Cli.GetStream();        //네트워크 스트림 연결

                    this.ConnectedToServer = true;      //서버에 연결되었다고 bool형으로 표시

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect ERROR\r\n" + ex.Message);
            }
        }

        private void btn_Join_Click(object sender, EventArgs e)
        {
            JoinForm Join = new JoinForm();
            Join.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
