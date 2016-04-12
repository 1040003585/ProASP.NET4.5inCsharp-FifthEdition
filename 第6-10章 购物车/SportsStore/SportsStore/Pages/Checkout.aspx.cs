using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;
using SportsStore.Models;
using SportsStore.Models.Respository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {//IsPostBack属性检测POST请求，并用模型绑定功能在窗体提交数据创建了一个Order对象
                Order myOrder = new Order();
                if (TryUpdateModel(myOrder, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    myOrder.OrderLines = new List<OrderLine>();

                    Cart myCart = SessionHelper.GetCart(Session);

                    foreach (CartLine line in myCart.Lines)
                    {
                        myOrder.OrderLines.Add(new OrderLine
                        {
                            Order=myOrder,
                            Product=line.Product,
                            Quantity=line.Quantity
                        });
                        

                    }

                    new Repository().SaveOrder(myOrder);
                    myCart.ClearMyCart();

                    /*给管理员发送有新订单邮件*/
                    new SendEmail().SendEmailToAdmin(myOrder);
                    
             

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
     

        /// <summary>
        /// 省市联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*protected void state_SelectedIndexChanged(object sender, EventArgs e)
        {

            AddCity(this.state.SelectedValue, city);
        }
        private void AddCity(string sheng, DropDownList ddl)
        {
            if (sheng.Equals("安徽省"))
            {
                ddl.Items.Clear();
                ddl.DataSource = anhui;
                ddl.DataBind();
                //ddl.Items.Add(new ListItem("", ""));
                //for (int i = 0; i < anhui.Length; i++)
                //{
                //    ddl.Items.Add(new ListItem(anhui[i]));
                //}
            }
            else if (sheng.Equals("山西省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < shangxi.Length; i++)
                {
                    ddl.Items.Add(new ListItem(shangxi[i]));
                }
            }
            else if (sheng.Equals("福建省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < fujian.Length; i++)
                {
                    ddl.Items.Add(new ListItem(fujian[i]));
                }
            }
            else if (sheng.Equals("甘肃省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < gansu.Length; i++)
                {
                    ddl.Items.Add(new ListItem(gansu[i]));
                }
            }
            else if (sheng.Equals("广东省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < guangdong.Length; i++)
                {
                    ddl.Items.Add(new ListItem(guangdong[i]));
                }
            }
            else if (sheng.Equals("澳门"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < aomen.Length; i++)
                {
                    ddl.Items.Add(new ListItem(aomen[i]));
                }
            }
            else if (sheng.Equals("广西省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < guangxi.Length; i++)
                {
                    ddl.Items.Add(new ListItem(guangxi[i]));
                }
            }
            else if (sheng.Equals("贵州省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < guizhou.Length; i++)
                {
                    ddl.Items.Add(new ListItem(guizhou[i]));
                }
            }
            else if (sheng.Equals("内蒙古"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < neimenggu.Length; i++)
                {
                    ddl.Items.Add(new ListItem(neimenggu[i]));
                }
            }
            else if (sheng.Equals("海南省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < hainan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(hainan[i]));
                }
            }
            else if (sheng.Equals("黑龙江"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < helongjian.Length; i++)
                {
                    ddl.Items.Add(new ListItem(helongjian[i]));
                }
            }
            else if (sheng.Equals("湖北省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < hubei.Length; i++)
                {
                    ddl.Items.Add(new ListItem(hubei[i]));
                }
            }
            else if (sheng.Equals("湖南省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < hunan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(hunan[i]));
                }
            }
            else if (sheng.Equals("吉林省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < jilin.Length; i++)
                {
                    ddl.Items.Add(new ListItem(jilin[i]));
                }
            }
            else if (sheng.Equals("江苏省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < jiangsu.Length; i++)
                {
                    ddl.Items.Add(new ListItem(jiangsu[i]));
                }
            }
            else if (sheng.Equals("江西省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < jiangxi.Length; i++)
                {
                    ddl.Items.Add(new ListItem(jiangxi[i]));
                }
            }
            else if (sheng.Equals("辽宁省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < liaoning.Length; i++)
                {
                    ddl.Items.Add(new ListItem(liaoning[i]));
                }
            }
            else if (sheng.Equals("河北省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < hebei.Length; i++)
                {
                    ddl.Items.Add(new ListItem(hebei[i]));
                }
            }
            else if (sheng.Equals("河南省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < henan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(henan[i]));
                }
            }
            else if (sheng.Equals("北京市"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < beijing.Length; i++)
                {
                    ddl.Items.Add(new ListItem(beijing[i]));
                }
            }
            else if (sheng.Equals("宁夏"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < ningxia.Length; i++)
                {
                    ddl.Items.Add(new ListItem(ningxia[i]));
                }
            }
            else if (sheng.Equals("青海省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < qinghai.Length; i++)
                {
                    ddl.Items.Add(new ListItem(qinghai[i]));
                }
            }
            else if (sheng.Equals("山东省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < shandong.Length; i++)
                {
                    ddl.Items.Add(new ListItem(shandong[i]));
                }
            }
            else if (sheng.Equals("陕西省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < shangxi.Length; i++)
                {
                    ddl.Items.Add(new ListItem(shangxi[i]));
                }
            }
            else if (sheng.Equals("四川省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < sichuan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(sichuan[i]));
                }
            }
            else if (sheng.Equals("上海市"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < shanghai.Length; i++)
                {
                    ddl.Items.Add(new ListItem(shanghai[i]));
                }
            }
            else if (sheng.Equals("台湾"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < taiwan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(taiwan[i]));
                }
            }
            else if (sheng.Equals("天津市"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < tianjin.Length; i++)
                {
                    ddl.Items.Add(new ListItem(tianjin[i]));
                }
            }
            else if (sheng.Equals("香港"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < xianggang.Length; i++)
                {
                    ddl.Items.Add(new ListItem(xianggang[i]));
                }
            }
            else if (sheng.Equals("云南省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < yunnan.Length; i++)
                {
                    ddl.Items.Add(new ListItem(yunnan[i]));
                }
            }
            else if (sheng.Equals("浙江省"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < zhejiang.Length; i++)
                {
                    ddl.Items.Add(new ListItem(zhejiang[i]));
                }
            }
            else if (sheng.Equals("重庆市"))
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
                for (int i = 0; i < chongqing.Length; i++)
                {
                    ddl.Items.Add(new ListItem(chongqing[i]));
                }
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("请选择", ""));
            }
        }
      
        #region 省市联动
        private string[] shangxi = { "西安", "延安", "榆林", "渭南", "商州", "安康", "汉中", "宝鸡", "铜川", "咸阳" };
        private string[] anhui = { "安庆市 ", "蚌埠市 ", "巢湖市 ", "池州市 ", "滁州市 ", "阜阳市 ", "毫州市 ", "合肥市 ", "淮北市 ", "淮南市 ", "黄山市 ", "六安市 ", "马鞍山市 ", "宿州市 ", "铜陵市 ", "芜湖市 ", "宣州市 " };
        private string[] aomen = { "澳门 " };
        private string[] beijing = { "海淀区", "朝阳区", "东城区", "西城区", "崇文区", "宣武区", "丰台区", "石景山", "房山区", "大兴区", "通州区", "顺义区", "昌平区", "密云区", "怀柔区", "延庆区", "平谷区" };
        private string[] fujian = { "福州市 ", "龙岩市 ", "南平市 ", "宁德市 ", "莆田市 ", "泉州市 ", "三明市 ", "厦门市 ", "漳州市 " };
        private string[] gansu = { "白银市 ", "定西地区 ", "甘南自治州 ", "嘉峪关市 ", "金昌市 ", "酒泉地区 ", "兰州市 ", "临夏自治州 ", "陇南地区 ", "平凉地区 ", "庆阳地区 ", "天水市 ", "武威市 ", "张掖地区 " };
        private string[] guangdong = { "深圳市 ", "潮州市 ", "东莞市 ", "佛山市 ", "广州市 ", "河源市 ", "惠州市 ", "江门市 ", "揭阳市 ", "茂名市 ", "梅州市 ", "清远市 ", "汕头市 ", "汕尾市 ", "韶关市 ", "阳江市 ", "云浮市 ", "湛江市 ", "肇庆市 ", "中山市 ", "珠海市 " };
        private string[] guangxi = { "百色地区 ", "北海市 ", "防城港市 ", "桂林地区 ", "桂林市 ", "贵港市 ", "河池地区 ", "柳州地区 ", "柳州市 ", "南宁市 ", "南宁地区 ", "钦州市 ", "贺州地区 ", "梧州市 ", "玉林市 " };
        private string[] guizhou = { "安顺市 ", "毕节地区 ", "贵阳市 ", "六盘水市 ", "黔东南自治州 ", "黔南自治州 ", "黔西南自治州 ", "铜仁市 ", "遵义市 " };
        private string[] hainan = { "海口市 ", "三亚市 " };
        private string[] hebei = { "保定市 ", "沧州地区 ", "沧州市 ", "承德市 ", "邯郸市 ", "衡水市 ", "廊坊市 ", "秦皇岛市 ", "深州市 ", "石家庄市 ", "唐山市 ", "邢台市 ", "张家口市 " };
        private string[] henan = { "安阳市 ", "鹤壁市 ", "焦作市 ", "开封市 ", "洛阳市 ", "南阳市 ", "平顶山市 ", "三门峡市 ", "商丘市 ", "新乡市 ", "信阳市 ", "许昌市 ", "郑州市 ", "周口市 ", "驻马店市 ", "漯河市 ", "濮阳市 " };
        private string[] helongjian = { "大庆市 ", "大兴安岭 ", "哈尔滨市 ", "鹤岗市 ", "黑河地区 ", "黑河市 ", "鸡西市 ", "佳木斯市 ", "牡丹江市 ", "七台河市 ", "齐齐哈尔市 ", "双鸭山市 ", "松花江地区 ", "绥化市 ", "伊春市 " };
        private string[] hubei = { "鄂州市 ", "恩施自治州 ", "黄冈市 ", "黄石市 ", "荆门市 ", "荆州市 ", "十堰市 ", "随州市 ", "武汉市 ", "咸宁市 ", "襄樊市 ", "孝感地区 ", "孝感市 ", "宜昌地区 ", "宜昌市 ", "郧阳地区 " };
        private string[] hunan = { "常德市 ", "长沙市 ", "郴州地区 ", "张家界市 ", "衡阳市 ", "怀化市 ", "永州市 ", "娄底市 ", "邵阳市 ", "湘潭市 ", "湘西自治区 ", "益阳市 ", "岳阳市 ", "株洲市 " };
        private string[] jilin = { "白城地区 ", "白不限 ", "白山市 ", "长春市 ", "浑江市 ", "吉林市 ", "辽源市 ", "四平市 ", "松原市 ", "通化市 ", "延边自治区 " };
        private string[] jiangsu = { "常州市 ", "淮阴市 ", "连云港市 ", "南京市 ", "南通市 ", "苏州市 ", "宿迁市 ", "泰州市 ", "无锡市 ", "徐州市 ", "盐不限 ", "扬州市 ", "镇江市 " };
        private string[] jiangxi = { "抚州市 ", "赣州市 ", "吉安市 ", "景德镇市 ", "九江市 ", "南昌市 ", "萍乡市 ", "上饶市 ", "新余市 ", "宜春市 ", "鹰潭市 " };
        private string[] liaoning = { "鞍山市 ", "本溪市 ", "朝阳市 ", "大连市 ", "丹东市 ", "抚顺市 ", "阜新市 ", "葫芦岛市 ", "锦州市 ", "辽阳市 ", "盘锦市 ", "沈阳市 ", "铁岭市 ", "营口市 " };
        private string[] neimenggu = { "阿拉善盟 ", "巴彦淖尔盟 ", "包头市 ", "赤峰市 ", "呼和浩特市 ", "呼伦贝尔市 ", "乌海市 ", "乌兰察布盟 ", "锡林郭勒盟 ", "兴安盟 ", "鄂尔多斯市 ", "通辽市 " };
        private string[] ningxia = { "固原市 ", "石嘴山市 ", "银川市 ", "吴忠市 " };
        private string[] qinghai = { "果洛自治州 ", "海北自治州 ", "海东地区 ", "海南自治州 ", "海西自治州 ", "黄南自治州 ", "西宁市 ", "玉树自治州 " };
        private string[] shandong = { "滨州市 ", "德州市 ", "东营市 ", "菏泽地区 ", "济南市 ", "济宁市 ", "莱芜市 ", "聊不限 ", "临沂市 ", "青岛市 ", "日照市 ", "泰安市 ", "威海市 ", "潍坊市 ", "烟台市 ", "枣庄市 ", "淄博市 " };
        private string[] shanxi = { "长治市 ", "大同市 ", "晋不限 ", "晋中市 ", "临汾市 ", "吕梁地区 ", "朔州市 ", "太原市 ", "忻州市 ", "雁北地区 ", "阳泉市 ", "运不限 " };
        private string[] shuanxi = { "安康市 ", "宝鸡市 ", "汉中市 ", "商洛市 ", "铜川市 ", "渭南市 ", "西安市 ", "咸阳市 ", "延安市 ", "榆林市 " };
        private string[] shanghai = { "上海市 " };
        private string[] sichuan = { "阿坝自治州 ", "巴中市 ", "成都市 ", "达州市 ", "德阳市 ", "甘孜自治州 ", "广安市 ", "广元市 ", "乐山市 ", "凉山自治州 ", "眉山市 ", "绵阳市 ", "南充市 ", "内江市 ", "攀枝花市 ", "遂宁市 ", "雅安市 ", "宜宾市 ", "自贡市 ", "泸州市 ", "资阳市 ", "成都" };
        private string[] taiwan = { "高雄市 ", "高雄县 ", "花莲县 ", "基隆市 ", "嘉义市 ", "嘉义县 ", "苗栗县 ", "南投县 ", "澎湖县 ", "屏东县 ", "台北市 ", "台北县 ", "台东县 ", "台南市 ", "台南县 ", "台中市 ", "台中县 ", "桃园县 ", "新竹市 ", "新竹县 ", "宜兰县 ", "云林县 ", "彰化市 ", "彰化县 " };
        private string[] tianjin = { "天津市 " };
        private string[] xizang = { "阿里地区 ", "昌都地区 ", "拉萨市 ", "林芝地区 ", "那曲地区 ", "日喀则地区 ", "山南地区 " };
        private string[] xianggang = { "香港 " };
        private string[] xinjiang = { "阿克苏地区 ", "阿勒泰地区 ", "巴音郭楞州 ", "博尔塔拉州 ", "昌吉自治州 ", "哈密地区 ", "和田地区 ", "喀什地区 ", "克拉玛依市 ", "克孜勒州 ", "石河子市 ", "塔城地区 ", "吐鲁番地区 ", "乌鲁木齐市 ", "伊犁地区 " };
        private string[] yunnan = { "保山市 ", "楚雄自治州 ", "大理自治州 ", "德宏自治州 ", "迪庆自治州 ", "东川市 ", "红河自治州 ", "昆明市 ", "丽江地区 ", "临沧地区 ", "怒江自治州 ", "曲靖市 ", "思茅地区 ", "文山自治州 ", "西双版纳州 ", "玉溪市 ", "昭通市 " };
        private string[] zhejiang = { "杭州市 ", "湖州市 ", "嘉兴市 ", "金华市 ", "丽水市 ", "宁波市 ", "绍兴市 ", "台州市 ", "温州市 ", "舟山市 ", "衢州市 " };
        private string[] chongqing = { "重庆市 " };
        #endregion
         * 
         * 
         * 
            
            <asp:DropDownList ID="state" runat="server" AutoPostBack="True" OnSelectedIndexChanged="state_SelectedIndexChanged">
                    <asp:ListItem Selected="True">请选择</asp:ListItem>
                    <asp:ListItem>北京市</asp:ListItem>
                    <asp:ListItem>上海市</asp:ListItem>
                    <asp:ListItem>天津市</asp:ListItem>
                    <asp:ListItem>重庆市</asp:ListItem>
                    <asp:ListItem>黑龙江</asp:ListItem>
                    <asp:ListItem>吉林省</asp:ListItem>
                    <asp:ListItem>辽宁省</asp:ListItem>
                    <asp:ListItem>河北省</asp:ListItem>
                    <asp:ListItem>内蒙古</asp:ListItem>
                    <asp:ListItem>江苏省</asp:ListItem>
                    <asp:ListItem>江西省</asp:ListItem>
                    <asp:ListItem>浙江省</asp:ListItem>
                    <asp:ListItem>安徽省</asp:ListItem>
                    <asp:ListItem>福建省</asp:ListItem>
                    <asp:ListItem>山西省</asp:ListItem>
                    <asp:ListItem>山东省</asp:ListItem>
                    <asp:ListItem>河南省</asp:ListItem>
                    <asp:ListItem>湖北省</asp:ListItem>
                    <asp:ListItem>湖南省</asp:ListItem>
                    <asp:ListItem>广东省</asp:ListItem>
                    <asp:ListItem>广西省</asp:ListItem>
                    <asp:ListItem>海南省</asp:ListItem>
                    <asp:ListItem>四川省</asp:ListItem>
                    <asp:ListItem>贵州省</asp:ListItem>
                    <asp:ListItem>云南省</asp:ListItem>
                    <asp:ListItem>陕西省</asp:ListItem>
                    <asp:ListItem>甘肃省</asp:ListItem>
                    <asp:ListItem>青海省</asp:ListItem>
                    <asp:ListItem>宁夏</asp:ListItem>
                    <asp:ListItem>新疆</asp:ListItem>
                    <asp:ListItem>西藏</asp:ListItem>
                    <asp:ListItem>香港</asp:ListItem>
                    <asp:ListItem>澳门</asp:ListItem>
                    <asp:ListItem>台湾</asp:ListItem>
                </asp:DropDownList>
         * 
         * 
                <asp:DropDownList ID="city" runat="server" AutoPostBack="True">
                 </asp:DropDownList>
         * 
         * 
         */
    }
}