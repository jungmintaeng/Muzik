using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Data.OracleClient;
using Packet_Delivery;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Muzik
{
    public partial class MainForm : Form
    {
        const int PortNum = 8080;
        private string _strConn = "Data Source=orcl; User Id=SOSIL3; Password=qwerty123;Integrated Security=no;";
        const int PIANO_KIT = 0;
        const int GUITAR_KIT = 1;
        const int DRUM_KIT = 2;

        private int count = 1;
        private int nRead = 0;

        private NetworkStream NetStream; //네트워크 스트림 선언
        private byte[] ReadBuffer = new byte[1024 * 4]; //Receive에 사용할 버퍼
        private byte[] SendBuffer = new byte[1024 * 4]; //Send에 사용할 버퍼
        private TcpListener server; //Server측이기 때문에 클라이언트를 기다리는 listener 생성

        private Thread thr;         //ServerStart(Listen)하는 쓰레드
        private Thread threader;    //Receive하는 쓰레드

        private FileStream f;       //파일스트림
        private Socket Cli;         //클라이언트 연결 소켓

        private bool ServerRunning = false; //서버가 켜져있는지
        private bool CliConnected = false;  //클라이언트가 연결되었는지

        private FilePacket Fp;
        private FileList Fl;
        private Request Rq;         //타입에 맞게 사용하기 위해 Packet의 자식 클래스들 선언

        OracleConnection conn;

        private string User = "root";
        private string clientID;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\AudioSpectrum\AudioSpectrum\bin\Debug\AudioSpectrum.exe";
            Process.Start(path);
            ip_Label.BackColor = Color.Transparent;
            ip_Label.Parent = this.BGPic;
            try
            {
                conn = new OracleConnection(_strConn);
                conn.Open();
                thr = new Thread(new ThreadStart(ServerStart)); //서버를 시작하는 함수 쓰레드 할당
                thr.Start();    //시작
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 아이콘 마우스 이벤트
        private void pianoPic_MouseEnter(object sender, EventArgs e)
        {
            pianoPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void pianoPic_MouseLeave(object sender, EventArgs e)
        {
            pianoPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void GuitarPic_MouseEnter(object sender, EventArgs e)
        {
            guitarPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void GuitarPic_MouseLeave(object sender, EventArgs e)
        {
            guitarPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void drumPic_MouseEnter(object sender, EventArgs e)
        {
            drumPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void drumPic_MouseLeave(object sender, EventArgs e)
        {
            drumPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void pianoPlay_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void send_Btn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void send_Btn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        // 아이콘 마우스 이벤트 끝

        private void pianoPic_Click(object sender, EventArgs e)
        {
            PianoForm pianoform = new PianoForm();
            pianoform.Owner = this;
            pianoform.Show();
            this.Hide();
        }

        private void GuitarPic_Click(object sender, EventArgs e)
        {
            GuitarForm guitarform = new GuitarForm();
            guitarform.Owner = this;
            guitarform.Show();
            this.Hide();
        }

        private void drumPic_Click(object sender, EventArgs e)
        {
            DrumpadForm drumform = new DrumpadForm();
            drumform.Owner = this;
            this.Hide();
            drumform.Show();
            drumform.Activate();
            drumform.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Process pr in Process.GetProcesses())
                {
                    if (pr.ProcessName.StartsWith("AudioSpectrum"))
                    {
                        pr.Kill();
                    }
                }
            }
            catch { }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch { }
                finally
                {
                    ServerStop();
                }

            }
        }

        private void send_Btn_Click(object sender, EventArgs e)
        {

        }

        private void ServerStart()  //서버를 시작하여 Listener를 열고 클라이언트를 기다리는 함수
        {
            try
            {
                server = new TcpListener(PortNum);  //Port란에 써있는 숫자로 server 열기
                server.Start(); //서버 시작

               // IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName()); //HostName을 통해 자신의 IP 알아냄

                this.ServerRunning = true;              //서버가 켜졌다는 플래그 참

                while (ServerRunning)               //서버가 Running되는 동안
                {
                    Cli = server.AcceptSocket();    //클라이언트를 기다려서 연결한다

                    if (Cli.Connected)       //클라이언트 연결됨
                    {
                        CliConnected = true;    //클라이언트가 연결되었다는 플래그를 참으로 만들고

                        this.Invoke(new MethodInvoker(delegate ()//컨트롤을 건드리는 부분
                        {
                            MessageBox.Show("클라이언트 접속됨");
                        }));

                        this.NetStream = new NetworkStream(Cli);    //넷스트림 연결

                        threader = new Thread(new ThreadStart(Receive));    //받는 쓰레드 생성
                        threader.Start();   //시작
                    }
                    else
                    {
                        CliConnected = false;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (OverflowException ex)    //위의 3개 Exception은 Port number parsing
                                            //과정에서 나올 수 있는 예외이다
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void SendFileList()     //파일의 이름과 사이즈만 보내어 리스트 뷰의 아이템을 만들 수 있도록 한다
        {
            foreach (string s in Directory.GetDirectories(@"C:\Users\Mike\Desktop\Server"))
            {//디렉토리에 있는 파일들을 가져온 후 첫 파일부터 마지막 파일까지
                Users user = new Users();
                user.ID = s;
                Packet.Serialize(user).CopyTo(this.SendBuffer, 0);    //Serialize하여 SendBuffer에 저장
                NetStream.Write(SendBuffer, 0, SendBuffer.Length);  //네트워크 스트림에 쓰고
                NetStream.Flush();  //보낸다
                ClearBuffer(SendBuffer);    //SendBuffer를 비운다
            }
        
        }

        private void SendFileList(string ID)
        {
            foreach (string s in Directory.GetFiles(@"C:\Users\Mike\Desktop\Server\" + ID))
            {//디렉토리에 있는 파일들을 가져온 후 첫 파일부터 마지막 파일까지
                Fl = new FileList();
                FileInfo fi = new FileInfo(s);  //파일 정보를 얻기 위해
                Fl.FileName = fi.Name;  //파일이름
                Fl.FileSize = fi.Length;    //파일 사이즈
                Fl.Type = 1;    //보내기 타입 = 리스트뷰 아이템
                Packet.Serialize(Fl).CopyTo(this.SendBuffer, 0);    //Serialize하여 SendBuffer에 저장
                NetStream.Write(SendBuffer, 0, SendBuffer.Length);  //네트워크 스트림에 쓰고
                NetStream.Flush();  //보낸다
                ClearBuffer(SendBuffer);    //SendBuffer를 비운다
            }
        }

        private void Receive()  //전송이 오면 받는 함수-> 쓰레드로 돌아감
        {
            try
            {
                int count = 1;  //현재 파일의 받고 있는 부분
                int nRead = 0;  //파일을 몇번 전송해야 하는가

                while (CliConnected)    //클라이언트가 서버에 연결되어 있는 동안
                {
                    this.NetStream.Read(this.ReadBuffer, 0, this.ReadBuffer.Length);    //전송이 온 경우 네트워크 스트림을 읽고
                    Packet p = (Packet)Packet.Deserialize(this.ReadBuffer);     //해독한 후

                    switch (p.Type) //타입에 따라 행동한다
                    {
                        case 0: //보통의 파일 전송타입일 때
                            {
                                Fp = (FilePacket)p; //파일 전송을 위한 클래스로 다운캐스팅
                                nRead = (int)Fp.FileSize / Fp.FileData.Length + 1;  //몇 번 보내야 하는가
                                int fileIndex = 1;  //파일 이름의 중복을 처리하기 위한 변수
                                string fileName = @"C:\Users\Mike\Desktop\Server\" + clientID + "\\" + Fp.FileName;    //파일 이름을 저장하고

                                if (count == 1) //파일의 첫부분을 받았을 때
                                {
                                    while (File.Exists(fileName))   //파일의 이름이 존재한다면
                                    {
                                        fileName = @"C:\Users\Mike\Desktop\Server\" + clientID + "\\" + "(" + fileIndex.ToString() + ")" + Fp.FileName;
                                        fileIndex++;//파일 이름이 중복될 경우 앞에 번호를 붙이는 식으로 중복을 피함
                                    }
                                    f = new FileStream(fileName, FileMode.Create, FileAccess.Write); //중복되지 않는 파일 이름으로 파일을 생성
                                }

                                f.Write(Fp.FileData, 0, Fp.FileData.Length);    //파일에 데이터를 쓴다
                                                                                //이 때 파일 안에서의 position은 파일을 닫지 않으면 계속 이어서 쓸 수 있기 때문에
                                                                                //파일의 끝부분을 받았을 때 파일스트림을 닫아준다

                                count++;

                                if (count > nRead)  //count = nRead일 때가 마지막 전송이므로, count가 nRead보다 커진다면
                                {
                                    count = 1;      //다른 파일을 받을 수 있도록 count = 1로 초기화 해주고
                                    f.Dispose();
                                    f.Close();      //파일을 다 썼으므로 파일을 닫는다.
                                }
                                break;
                            }
                        case (int)Packet.TF_TYPE.LIST_VIEW: //1 파일의 리스트를 달라는것.
                            {
                                SendFileList(clientID);
                                break;
                            }
                        case (int)Packet.TF_TYPE.FILE_REQUEST: //2 파일을 달라는 request일 때
                            {
                                try
                                {
                                    Rq = (Request)p;    //요청 클래스를 받아서 다운캐스팅
                                    f = new FileStream(@"C:\Users\Mike\Desktop\Server\" + clientID + "\\" + Rq.FileName, FileMode.Open, FileAccess.Read);
                                    //파일 이름을 받았고, 경로도 알고 있기 때문에 파일스트림 생성 가능
                                    Fp = new FilePacket();  //파일 전송을 위한 클래스 인스턴스 생성

                                    Fp.Type = 0;        //타입은 보통의 파일 전송
                                    Fp.FileName = Rq.FileName;  //파일 이름
                                    Fp.FileSize = f.Length; //파일 크기
                                    for (int i = 0; i < (int)(f.Length / Fp.FileData.Length) + 1; i++)
                                    {//파일 크기를 나누고 버퍼의 크기로 나누고, 나머지부분을 한번 더 전송하기 위해 +1을 함
                                        f.Read(Fp.FileData, 0, Fp.FileData.Length); //파일의 데이터를 버퍼의 크기만큼 읽어와 버퍼에 넣어줌
                                        Packet.Serialize(Fp).CopyTo(this.SendBuffer, 0);    //Serialize해서 SendBuffer에 넣어줌
                                        NetStream.Write(SendBuffer, 0, SendBuffer.Length);  //네트워크 스트림에 쓰고
                                        NetStream.Flush();  //보냄

                                        Thread.Sleep(50);
                                        ClearBuffer(SendBuffer);    //버퍼를 초기화 한다
                                    }
                                    f.Dispose();
                                    f.Close();      //파일 읽기가 끝났으므로 파일을 닫아준다.
                                }
                                catch (Exception ex)
                                {
                                }

                                break;
                                
                            }
                        case (int)Packet.TF_TYPE.SELECT_ID://3
                            {
                                Users user = (Users)p;
                                SendFileList(user.ID);
                                break;
                            }
                        case (int)Packet.TF_TYPE.LOGIN://4
                            {
                                LoginConfirm confirm = null;
                                Login loginInfo = (Login)p;
                                clientID = loginInfo.ID;
                                bool login_check = false;
                                OracleCommand cmd = new OracleCommand();
                                cmd.Connection = conn;

                                cmd.CommandText = "SELECT * FROM SUBSCRIBER";

                                OracleDataReader rdr = cmd.ExecuteReader();

                                while (rdr.Read())
                                {
                                    string id = rdr["ID"] as string;
                                    string pw = rdr["PASSWORD"] as string;

                                    if (id == loginInfo.ID && pw == loginInfo.PW)
                                    {
                                        login_check = true;
                                        break;
                                    }
                                    else if (id != loginInfo.ID || pw != loginInfo.PW)
                                    {
                                        login_check = false;
                                    }
                                }
                                if (login_check == false)
                                {
                                    confirm = new LoginConfirm();
                                    confirm.loginConfirm = false;
                                    MessageBox.Show("로그인 요청이 들어왔지만 실패했습니다.");
                                }
                                else if (login_check == true)
                                {
                                    confirm = new LoginConfirm();
                                    confirm.loginConfirm = true;
                                    MessageBox.Show("클라이언트 로그인 성공하였습니다!", "Success");
                                }

                                Packet.Serialize(confirm).CopyTo(SendBuffer, 0);
                                NetStream.Write(SendBuffer, 0, SendBuffer.Length);
                                NetStream.Flush();

                                ClearBuffer(SendBuffer);

                                rdr.Close();



                                conn.Close();
                                break;
                            }
                        case (int)Packet.TF_TYPE.JOIN://5
                            {
                                Join join = (Join)p;
                                bool duplicate = false;
                                bool joinSuc = false;
                                OracleCommand cmd = new OracleCommand();
                                cmd.Connection = conn;

                                cmd.CommandText = "SELECT * FROM SUBSCRIBER";

                                OracleDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    string id = rdr["ID"] as string;

                                    if (id == join.ID)
                                    {
                                        duplicate = true;
                                        break;
                                    }
                                }
                                if(duplicate)
                                {
                                    JoinConfirm j = new JoinConfirm();
                                    j.joinConfirm = false;
                                    Packet.Serialize(j).CopyTo(SendBuffer, 0);
                                    NetStream.Write(SendBuffer, 0, SendBuffer.Length);
                                    NetStream.Flush();

                                    ClearBuffer(SendBuffer);

                                    return;
                                }

                                rdr.Close();

                                cmd.CommandText = "INSERT INTO SUBSCRIBER VALUES (:NAME,:ID,:PASSWORD)";

                                OracleParameter db_name = new OracleParameter();
                                db_name.Value = join.Name;
                                db_name.ParameterName = "NAME";

                                OracleParameter db_ID = new OracleParameter();
                                db_ID.Value = join.ID;
                                db_ID.ParameterName = "ID";

                                OracleParameter db_PW = new OracleParameter();
                                db_PW.Value = join.PW;
                                db_PW.ParameterName = "PASSWORD";

                                cmd.Parameters.Add(db_name);
                                cmd.Parameters.Add(db_ID);
                                cmd.Parameters.Add(db_PW);

                                int result;
                                result = cmd.ExecuteNonQuery();
                                if (result != 1)
                                {
                                    JoinConfirm j = new JoinConfirm();
                                    j.joinConfirm = false;
                                    Packet.Serialize(j).CopyTo(SendBuffer, 0);
                                    NetStream.Write(SendBuffer, 0, SendBuffer.Length);
                                    NetStream.Flush();

                                    ClearBuffer(SendBuffer);

                                    return;
                                }
                                else if(result == 1)
                                {
                                    JoinConfirm j = new JoinConfirm();
                                    j.joinConfirm = true;
                                    Packet.Serialize(j).CopyTo(SendBuffer, 0);
                                    NetStream.Write(SendBuffer, 0, SendBuffer.Length);
                                    NetStream.Flush();

                                    ClearBuffer(SendBuffer);
                                    Directory.CreateDirectory(@"C:\Users\Mike\Desktop\Server\" + join.ID);
                                }

                                conn.Close();
                                break;
                            }
                        case (int)Packet.TF_TYPE.LOGIN_CONFIRM: //6 //받을일 없고
                            {
                                break;
                            }
                        case (int)Packet.TF_TYPE.JOIN_CONFIRM://7   //너도없어
                            {
                                break;
                            }
                    }   //switch문 끝
                }
            }
            catch (Exception ex)
            {//예상되는 무시해도 되는 오류들을 깔끔히 처리하기 위해 catch문을 비워두었다.ex)쓰레드가 중단되었습니다
                //MessageBox.Show(ex.Message);
            }
        }

        private void ServerStop()
        {
            try
            {
                ServerRunning = false;              //서버의 상태를 꺼짐으로 바꿈
                CliConnected = false;               //클라이언트 연결 플래그를 거짓으로 바꿈
                if (server != null)
                    server.Stop();                  //서버를 중지
                if (thr.IsAlive)
                    thr.Abort();                    //Listen하는 쓰레드 중지
                if (f != null)
                    f.Close();                      //파일 닫기
                if (threader.IsAlive)
                    threader.Abort();               //Receive하는 쓰레드 중지
                if (Cli != null)
                    Cli.Close();                    //클라이언트 소켓 닫음
            }
            catch
            {
                //개체 인스턴스로 설정되지 않았다는 예외 처리-->아무행동도 하지 않음
            }
        }

        private void ClearBuffer(byte[] array)  //버퍼를 초기화해주는 함수
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = 0;
        }

    }//MainForm class 끝
}//namespace 끝
