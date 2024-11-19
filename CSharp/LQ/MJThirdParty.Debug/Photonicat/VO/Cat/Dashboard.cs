namespace Photonicat.VO.Cat
{

    public class Wifi_Interfaces
    {
        public string band { get; set; } = "2G";

        public string device { get; set; } = "radio0";

        public string device_type { get; set; } = "板载";

        public string encryption { get; set; } = "psk2";

        public bool exist { get; set; }

        public string frequency { get; set; } = "2g";

        public string hidden { get; set; } = "0";

        public string htmode { get; set; } = "HT20";

        public string ssid { get; set; } = "photonicat-dac3f0d7";

        public string password { get; set; } = "photonicat";

    }
    public class Dashboard
    {

        #region 主要状态

        /// <summary>
        /// mobile = 蜂窝网络
        /// wired  = 有线
        /// </summary>
        public string connection { get; set; } = "mobile";

        /// <summary>
        /// 
        /// </summary>
        public string carrier { get; set; } = "4G";

        /// <summary>
        /// 下载速度
        /// </summary>
        public int down_speed { get; set; }

        /// <summary>
        /// 上传速度
        /// </summary>
        public int up_speed { get; set; }

        /// <summary>
        /// 开机时长
        /// </summary>
        public string uptime { get; set; } = "up 7 hours, 16 minutes\n";

        #endregion

        #region 系统
        /// <summary>
        /// 主机名
        /// </summary>
        public string hostname { get; set; } = "photonicat";

        /// <summary>
        /// 型号
        /// </summary>
        public string model { get; set; } = "";

        /// <summary>
        /// MCU 版本
        /// </summary>
        public string firmware_version { get; set; } = "RA2E1221213000";

        /// <summary>
        /// 内核版本
        /// </summary>
        public string kernel { get; set; } = "";
        #endregion

        #region 连接

        /// <summary>
        /// IP 地址
        /// </summary>
        public string wan_ip { get; set; } = string.Empty;

        /// <summary>
        /// DHCP 客户端
        /// </summary>
        public int dhcp_clients_count { get; set; }

        /// <summary>
        /// Wi-Fi 客户端
        /// </summary>
        public int wifi_clients_count { get; set; }

        public List<Wifi_Interfaces> wifi_interfaces { get; set; } = new();
        //"": 0,
        #endregion

        #region 硬件
        /// <summary>
        /// 电量
        /// </summary>
        public int charge_percent { get; set; }

        /// <summary>
        /// 是否充电中
        /// </summary>
        public bool on_charging { get; set; }

        /// <summary>
        /// 电池电压
        /// </summary>
        public int voltage { get; set; }

        /// <summary>
        /// 充电电压
        /// </summary>
        public int charge_voltage { get; set; }



        /// <summary>
        /// CPU 温度
        /// </summary>
        public int board_temperature { get; set; }

        /// <summary>
        /// SD 卡状态
        /// 已插入 = 1
        /// </summary>
        public int sd_state { get; set; }

        /// <summary>
        /// SIM卡状态
        /// </summary>
        public string sim_state { get; set; } = "ready";

        #endregion

        #region 其他
        /// <summary>
        /// 运营商
        /// China Unicom  = 中国联通
        /// China Mobile  = 中国移动
        /// China Telecom = 中国电信
        /// </summary>
        public string isp_name { get; set; } = "China Mobile";


        /// <summary>
        /// 信号强度
        /// </summary>
        public int modem_signal_strength { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public string product_model { get; set; } = "4G";



        public string server_location { get; set; } = "Unknown";
        #endregion

    }
}
