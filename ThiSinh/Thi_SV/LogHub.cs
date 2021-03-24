using Microsoft.AspNet.SignalR;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Thi_SV
{
    public class LogHub : Hub
    {
        public static Dictionary<string, int> ConnectionIDList = new Dictionary<string, int>();
        public static HashSet<string> BusyIdList = new HashSet<string>();
        public static readonly Timer _Timer = null;
        public static int interval = 1000;
        static LogHub()
        {
            //_Timer.Interval = 2000;
            //_Timer.Elapsed += TimerElapsed;
            //_Timer.Start();
            _Timer = new Timer((g) =>
            {
                TimerJob();
                _Timer.Change(interval, Timeout.Infinite);
            }, null, 0, Timeout.Infinite);
        }

        static void TimerJob()
        {
            foreach (var connection in ConnectionIDList.ToList())
            {
                if (ConnectionIDList.ContainsKey(connection.Key) && !BusyIdList.Contains(connection.Key))
                {
                    UpdateLastTime(connection.Value, connection.Key);
                }
            }
            //var hub = GlobalHost.ConnectionManager.GetHubContext("LogHub");
            //hub.Clients.All.logMessage(string.Format("{0} - Still running", DateTime.UtcNow));
        }
        

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void Init(int idKiThiSV = 0)
        {
            if (ConnectionIDList.ContainsKey(Context.ConnectionId))
            {
                ConnectionIDList[Context.ConnectionId] = idKiThiSV;
            }
        }

        public override Task OnConnected()
        {
            ConnectionIDList.Add(Context.ConnectionId, 0);
            return Clients.All.connected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            //int kiThiSvId = ConnectionIDList[Context.ConnectionId];
            //updateLastTime(kiThiSvId);
            ConnectionIDList.Remove(Context.ConnectionId);
            return Clients.All.disconnected();
            //return base.OnDisconnected(stopCalled);
        }

        static void UpdateLastTime(int IDKiThiSV, string connectionId)
        {
            if (BusyIdList.Contains(connectionId))
            {
                return;
            }
            BusyIdList.Add(connectionId);
            var thi = dnn_NuceThi_KiThi_LopHoc_SinhVien.get(IDKiThiSV);
            if (thi.Rows.Count > 0)
            {
                var ngayGioBatDau = thi.Rows[0].IsNull("NgayGioBatDau") ? DateTime.Now : DateTime.Parse(thi.Rows[0]["NgayGioBatDau"].ToString());
                var ngayGioNopBai = thi.Rows[0].IsNull("NgayGioNopBai") ? DateTime.Now : DateTime.Parse(thi.Rows[0]["NgayGioNopBai"].ToString());
                var tongThoiGianConLai = int.Parse(thi.Rows[0]["TongThoiGianConLai"].ToString());

                var lastTime = Utils.ReadFile(IDKiThiSV);
                if (lastTime != null)
                {
                    ngayGioBatDau = lastTime.NgayGioBatDau;
                    ngayGioNopBai = lastTime.NgayGioNopBai;
                    tongThoiGianConLai = lastTime.TongThoiGianConLai;
                }

                var status = int.Parse(thi.Rows[0]["Status"].ToString());

                if (status == 2 || status == 3)
                {
                    var now = DateTime.Now;

                    ngayGioBatDau = ngayGioNopBai;
                    ngayGioNopBai = now;

                    if (!ConnectionIDList.ContainsKey(connectionId))
                    {
                        BusyIdList.Remove(connectionId);
                        return;
                    }
                    if (ngayGioBatDau.ToString("yyyy/MM/dd HH:mm:ss") != ngayGioNopBai.ToString("yyyy/MM/dd HH:mm:ss"))
                    {
                        tongThoiGianConLai -= interval / 1000;
                        tongThoiGianConLai = tongThoiGianConLai < 0 ? 0 : tongThoiGianConLai;
                    }

                    string content = Utils.generateContent(IDKiThiSV, tongThoiGianConLai, ngayGioBatDau, ngayGioNopBai, connectionId);
                    Utils.WriteContentFile(IDKiThiSV, content);
                }
                else if (status > 3)
                { 
                    DeleteFile(ConnectionIDList[connectionId]);
                    ConnectionIDList.Remove(connectionId);
                }
            }
            BusyIdList.Remove(connectionId);
        }

        static void DeleteFile(int kiThiId)
        {
            string tempDir = ConfigurationManager.AppSettings["TempFolder"];
            string path = Path.Combine(tempDir, kiThiId.ToString());
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}