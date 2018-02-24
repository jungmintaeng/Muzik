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
    public partial class JoinForm : Form
    {
        private bool idcheck;
        private JoinConfirm joinconfirm;
        private Join join;

        private NetworkStream netStream;                  // 서버 클라이언트 간에 주고받을 networkStream                
        private TcpClient client;                         // 서버에 접속하기위한 클라이언트

        private byte[] sendBuffer = new byte[1024 * 4];     // 서버 내부에서 파일내용을 읽거나 보내기위하 버퍼
        private byte[] ReadBuffer = new byte[1024 * 4];

        private bool m_blsConnect = false;                  // 연결여부를 나타내는 bool자료형

        public JoinForm()
        {
            InitializeComponent();
            txt_PW.PasswordChar = '●';
            txt_PWConfirm.PasswordChar = '●';
        }

        private void JoinForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_PW.Text != txt_PWConfirm.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다!");
                txt_PW.Text = null;
                txt_PWConfirm.Text = null;
            }

// 보낼 패킷에 담기
            join = new Join();

            join.Name = txt_name.Text;
            join.ID = txt_ID.Text;
            join.PW = txt_PW.Text;

            Packet.Serialize(join).CopyTo(sendBuffer, 0);     // 내가 더블클릭한거에 대한 정보 serialize
            netStream.Write(sendBuffer, 0, sendBuffer.Length);     // 전송
            netStream.Flush();
            //받기

            this.netStream.Read(this.ReadBuffer, 0, this.ReadBuffer.Length); //읽어오고
            joinconfirm = (JoinConfirm)Packet.Deserialize(this.ReadBuffer); //해독해서

            //

            if (joinconfirm.joinConfirm == true)
                MessageBox.Show("회원 가입 성공하였습니다!");
                        
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JoinForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
