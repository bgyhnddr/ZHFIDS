using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace global
{
    public partial class Const
    {

        public const string ZUH = "ZUH";
        public const string Plan = "Plan";

        public const string IPKEY = "ip";
        public const string USERKEY = "user";
        public const string PASSWORDKEY = "password";
        public const string ROWCOUNT = "rowcount";
        public const string GATE = "gate";
        public const string CSSSTYLE = "cssstyle";
        public const string CAROUSELD = "carouseld";

        public const string IP_VALIDATINGEMESSAGE = "请输入正确的IP格式";
        public const string PORT_VALIDATINGEMESSAGE = "请输入正确的端口格式";
        public const string MYSQLCONNECTIONERROR = "连接航显数据库出错!";
        public const string BINDINGSUBSYSTEMCOMBOBOXERROR = "绑定子系统数据源出错!详细：{0}";
        public const string BINDDATAERROR = "绑定数据出错!详细：{0}";
        public const string UNKNOWNERROR = "发生未知错误";
        public const string SAVEDATAERROR = "保存数据出错，详细：{0}";
        public const string FORMATERROR = "格式错误";
        public const string NOTNULL = "内容不能为空";
        public const string DELETEDATAERROR = "删除数据出错，详细：{0}";
        public const string DELETEWARN = "是否删除[{0}]？";
        public const string IFSHUTDOWNIPC = "是否关闭所有工控机";
        public const string GETDYNAMICBYPLANWARN = "手动获取动态数据将会停止从运营系统获取动态数据，并且会清空所有已经存在的非人工编辑模式的动态数据";
        public const string ERROR = "发生错误，详细：{0}";
        public const string TIPS = "提示";
        public const string NORMAL = "正常";
        public const string UNNORMAL = "异常";
        public const string DYNAMICINTERVALTIPS = "请输入要设置的间隔时间（单位：秒,范围0~65535），0则表示不获取动态数据";
        public const string DYNAMICINTERVALTITLE = "动态数据获取间隔";
        public const string STARTAUTOGETPLANERROR = "启动自动获取计划出错，详细：{0}";
        public const string STOPAUTOGETPLANERROR = "停止自动获取计划出错，详细：{0}";
        public const string STARTAUTOGETDYNAMICERROR = "启动自动获取动态数据出错，详细：{0}";
        public const string STOPAUTOGETDYNAMICERROR = "停止自动获取动态数据出错，详细：{0}";
        public const string FILETRANSFERERROR = "文件传输服务启动异常：{0}";
        public const string SYNCDATASOURCE = "更新基础数据";
        public const string SHUTDOWN = "发送关机命令";
        public const string REBOOT = "发送重启命令";
        public const string SYNCPLAN = "更新计划库";
        public const string PLANTODYNAMIC = "生成动态";
        public const string CHANGEFORMERROR = "切换窗口出错";

        public const string JSON_flightCode = "flightCode";
        public const string JSON_SHARE = "JSON_SHARE"; 
        public const string JSON_flightDynamicId = "flightDynamicId";
        public const string JSON_date = "date";
        public const string JSON_FLIGHT = "FLIGHT";
        public const string JSON_FROM_Code = "FROM_Code";
        public const string JSON_TO_Code = "TO_Code";
        public const string JSON_FROM_BriefCn = "FROM_BriefCn";
        public const string JSON_FROM_BriefEn = "FROM_BriefEn";
        public const string JSON_TO_BriefCn = "TO_BriefCn";
        public const string JSON_TO_BriefEn = "TO_BriefEn";
        public const string JSON_VIA = "VIA";
        public const string JSON_VIA_code = "code";
        public const string JSON_VIA_briefCn = "briefCn";
        public const string JSON_VIA_briefEn = "briefEn";
        public const string JSON_STD = "STD";
        public const string JSON_std = "std";
        public const string JSON_ETD = "ETD";
        public const string JSON_ATD = "ATD";
        public const string JSON_STA = "STA";
        public const string JSON_sta = "sta";
        public const string JSON_ETA = "ETA";
        public const string JSON_ATA = "ATA";
        public const string JSON_airlinesCode = "airlinesCode";
        public const string JSON_counter = "counter";
        public const string JSON_counterArea = "counterArea";
        public const string JSON_boardinGateCode = "boardinGateCode";
        public const string JSON_carouselCode = "carouselCode";
        public const string JSON_arrivalStatusEn = "arrivalStatusEn";
        public const string JSON_arrivalStatusCn = "arrivalStatusCn";
        public const string JSON_departStatusEn = "departStatusEn";
        public const string JSON_departStatusCn = "departStatusCn";
        public const string JSON_arrivalOutwardCn = "arrivalOutwardCn";
        public const string JSON_departOutwardCn = "departOutwardCn";
        public const string JSON_arrivalOutwardEn = "arrivalOutwardEn";
        public const string JSON_departOutwardEn = "departOutwardEn";
        public const string JSON_lastModifyTime = "lastModifyTime";
        public const string JSON_departAirportBriefNameCn = "departAirportBriefNameCn";
        public const string JSON_departAirportNameEn = "departAirportNameEn";
        public const string JSON_airportCodeWords = "airportCodeWords";
        public const string JSON_stoppingAirport = "stoppingAirport";
        public const string JSON_airportBriefNameCn = "airportBriefNameCn";
        public const string JSON_airportNameEn = "airportNameEn";
        public const string JSON_arrivalAirportBriefNameCn = "arrivalAirportBriefNameCn";
        public const string JSON_arrivalAirportNameEn = "arrivalAirportNameEn";


        public const string JSON_Airline_code = "codeWord";
        public const string JSON_Airline_nameCn = "nameCn";
        public const string JSON_Airline_nameEn = "nameEn";

        public const string JSON_Airport_code = "codeWords";
        public const string JSON_Airport_nameCn = "briefNameCn";
        public const string JSON_Airport_nameEn = "briefNameEn";

        public const string JSON_Dict_dictID = "dictID";
        public const string JSON_Dict_dictName = "dictName";
        public const string JSON_Dict_sortNo = "sortNo";

        public const string JSON_AbnormalCause_code = "code";
        public const string JSON_AbnormalCause_outwardCn = "outwardCn";
        public const string JSON_AbnormalCause_outwardEn = "outwardEn";

        public const string Dictionary_FlightStatus = "vFlightStatus";
        public const string Dictionary_AbnormalCause = "vAbnormalCause";
        

        public const string ImageFolder = "image";
        public const string LogoFolder = "logo";
        public const string ADFolder = "ad";

        public const int AccessTimerInterval = 10000;
        public const int CountErrorTimeLimit = 300;



        public const string TIMEFORMAT = "HH:mm:ss";
        public const string DATEFORMAT = "yyyy-MM-dd";
        public const string DATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string UPDATEINTERVALCONFIG = "updateinterval";
        public const string CONNECTEDCONFIG = "connected";
        public const string SHOWERRORLINECONFIG = "showerrorline";
        public const string TIMESPLITCONFIG = "timesplit";
        public const string NODYNAMICDATA = "动态数据为空";
        public const string DELAYED = "Delayed";
        public const string CANCELLED = "Cancelled";
        public const string ALTERNATIVE = "Alternative";
        public const string CHECKDYNAMIC = "动态数据检查";
        public const string DYNAMICNORMAL = "动态数据正常";
        public const string ADMINON ="关闭管理员权限";
        public const string ADMINOFF = "开启管理员权限";
        public const string PASSWORDCONFIG = "password";
        public const string PASSWORDERROR = "密码错误";
        public const string PASSWORDNOTTHESAME = "两次输入不一致";


    }

    public enum SubsystemType
    {
        FIDS,
        arrival,
        carousel,
        departure,
        editor,
        gate,
        guide,
        server,
        carouseld
    }
}
