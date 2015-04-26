using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.Media.Capture;

namespace 帮我查
{
    public static class PublicS
    {
        public static MediaCapture MediaCaptureP = null;
    

        /// <summary>
        /// 是否允许后退按钮有效
        /// </summary>
        public static bool CanBeBack = true;
        /// <summary>
        /// 语音命令相关数据
        /// </summary>
        public static VoiceCommandActivatedEventArgs commandArgs = null;

        /// <summary>
        /// 弹窗选图片相关数据
        /// </summary>
        public static FileOpenPickerContinuationEventArgs commandArgs_PickFile = null;

        /// <summary>
        /// 公交城市网址
        /// </summary>
        public static Dictionary<string, string> GongJiaoDic = new Dictionary<string, string>();

        /// <summary>
        /// 星座连接对照表(周)
        /// </summary>
        public static Dictionary<string, string> XingZuoDic_z = new Dictionary<string, string>();

        /// <summary>
        /// 星座连接对照表(月)
        /// </summary>
        public static Dictionary<string, string> XingZuoDic_y = new Dictionary<string, string>();


        /// <summary>
        /// 初始化公交城市对照表
        /// </summary>
        public static void GetInitGongJiao()
        {
            PublicS.GongJiaoDic.Add("鞍山", "http://m.8684.cn/anshan_bus");
            PublicS.GongJiaoDic.Add("安康", "http://m.8684.cn/ankang_bus");
            PublicS.GongJiaoDic.Add("安庆", "http://m.8684.cn/anqing_bus");
            PublicS.GongJiaoDic.Add("安阳", "http://m.8684.cn/anyang_bus");
            PublicS.GongJiaoDic.Add("安顺", "http://m.8684.cn/anshun_bus");
            PublicS.GongJiaoDic.Add("阿克苏", "http://m.8684.cn/akesu_bus");
            PublicS.GongJiaoDic.Add("安宁", "http://m.8684.cn/anning_bus");
            PublicS.GongJiaoDic.Add("澳门", "http://m.8684.cn/aomen_bus");
            PublicS.GongJiaoDic.Add("北京", "http://m.8684.cn/beijing_bus");
            PublicS.GongJiaoDic.Add("本溪", "http://m.8684.cn/benxi_bus");
            PublicS.GongJiaoDic.Add("宝鸡", "http://m.8684.cn/baoji_bus");
            PublicS.GongJiaoDic.Add("蚌埠", "http://m.8684.cn/bengbu_bus");
            PublicS.GongJiaoDic.Add("保定", "http://m.8684.cn/baoding_bus");
            PublicS.GongJiaoDic.Add("亳州", "http://m.8684.cn/bozhou_bus");
            PublicS.GongJiaoDic.Add("保山", "http://m.8684.cn/baoshan_bus");
            PublicS.GongJiaoDic.Add("博乐", "http://m.8684.cn/bole_bus");
            PublicS.GongJiaoDic.Add("巴中", "http://m.8684.cn/bazhong_bus");
            PublicS.GongJiaoDic.Add("滨州", "http://m.8684.cn/binzhou_bus");
            PublicS.GongJiaoDic.Add("包头", "http://m.8684.cn/baotou_bus");
            PublicS.GongJiaoDic.Add("白山", "http://m.8684.cn/baishan_bus");
            PublicS.GongJiaoDic.Add("北海", "http://m.8684.cn/beihai_bus");
            PublicS.GongJiaoDic.Add("白银", "http://m.8684.cn/baiyin_bus");
            PublicS.GongJiaoDic.Add("白城", "http://m.8684.cn/baicheng_bus");
            PublicS.GongJiaoDic.Add("巴彦淖尔", "http://m.8684.cn/bayannaoer_bus");
            PublicS.GongJiaoDic.Add("百色", "http://m.8684.cn/baise_bus");
            PublicS.GongJiaoDic.Add("毕节", "http://m.8684.cn/bijie_bus");
            PublicS.GongJiaoDic.Add("成都", "http://m.8684.cn/chengdu_bus");
            PublicS.GongJiaoDic.Add("重庆", "http://m.8684.cn/chongqing_bus");
            PublicS.GongJiaoDic.Add("常州", "http://m.8684.cn/changzhou_bus");
            PublicS.GongJiaoDic.Add("长春", "http://m.8684.cn/changchun_bus");
            PublicS.GongJiaoDic.Add("长沙", "http://m.8684.cn/changsha_bus");
            PublicS.GongJiaoDic.Add("潮州", "http://m.8684.cn/chaozhou_bus");
            PublicS.GongJiaoDic.Add("朝阳", "http://m.8684.cn/chaoyang_bus");
            PublicS.GongJiaoDic.Add("巢湖", "http://m.8684.cn/chaohu_bus");
            PublicS.GongJiaoDic.Add("池州", "http://m.8684.cn/chizhou_bus");
            PublicS.GongJiaoDic.Add("滁州", "http://m.8684.cn/chuzhou_bus");
            PublicS.GongJiaoDic.Add("承德", "http://m.8684.cn/chengde_bus");
            PublicS.GongJiaoDic.Add("沧州", "http://m.8684.cn/cangzhou_bus");
            PublicS.GongJiaoDic.Add("常德", "http://m.8684.cn/changde_bus");
            PublicS.GongJiaoDic.Add("郴州", "http://m.8684.cn/chenzhou_bus");
            PublicS.GongJiaoDic.Add("长乐", "http://m.8684.cn/changle_bus");
            PublicS.GongJiaoDic.Add("长治", "http://m.8684.cn/changzhi_bus");
            PublicS.GongJiaoDic.Add("楚雄", "http://m.8684.cn/chuxiong_bus");
            PublicS.GongJiaoDic.Add("慈溪", "http://m.8684.cn/cixi_bus");
            PublicS.GongJiaoDic.Add("昌吉", "http://m.8684.cn/changji_bus");
            PublicS.GongJiaoDic.Add("城固", "http://m.8684.cn/chenggu_bus");
            PublicS.GongJiaoDic.Add("赤峰", "http://m.8684.cn/chifeng_bus");
            PublicS.GongJiaoDic.Add("常熟", "http://m.8684.cn/changshu_bus");
            PublicS.GongJiaoDic.Add("赤壁", "http://m.8684.cn/chibi_bus");
            PublicS.GongJiaoDic.Add("赤水", "http://m.8684.cn/chishui_bus");
            PublicS.GongJiaoDic.Add("崇左", "http://m.8684.cn/chongzuo_bus");
            PublicS.GongJiaoDic.Add("从化", "http://m.8684.cn/conghua_bus");
            PublicS.GongJiaoDic.Add("长海", "http://m.8684.cn/changhai_bus");
            PublicS.GongJiaoDic.Add("大连", "http://m.8684.cn/dalian_bus");
            PublicS.GongJiaoDic.Add("东莞", "http://m.8684.cn/dongguan_bus");
            PublicS.GongJiaoDic.Add("丹东", "http://m.8684.cn/dandong_bus");
            PublicS.GongJiaoDic.Add("德阳", "http://m.8684.cn/deyang_bus");
            PublicS.GongJiaoDic.Add("达州", "http://m.8684.cn/dazhou_bus");
            PublicS.GongJiaoDic.Add("东营", "http://m.8684.cn/dongying_bus");
            PublicS.GongJiaoDic.Add("德州", "http://m.8684.cn/dezhou_bus");
            PublicS.GongJiaoDic.Add("大同", "http://m.8684.cn/datong_bus");
            PublicS.GongJiaoDic.Add("大理", "http://m.8684.cn/dali_bus");
            PublicS.GongJiaoDic.Add("东阳", "http://m.8684.cn/dongyang_bus");
            PublicS.GongJiaoDic.Add("丹阳", "http://m.8684.cn/danyang_bus");
            PublicS.GongJiaoDic.Add("敦化", "http://m.8684.cn/dunhua_bus");
            PublicS.GongJiaoDic.Add("大庆", "http://m.8684.cn/daqing_bus");
            PublicS.GongJiaoDic.Add("都匀", "http://m.8684.cn/douyun_bus");
            PublicS.GongJiaoDic.Add("定西", "http://m.8684.cn/dingxi_bus");
            PublicS.GongJiaoDic.Add("都江堰", "http://m.8684.cn/dujiangyan_bus");
            PublicS.GongJiaoDic.Add("东台", "http://m.8684.cn/dongtai_bus");
            PublicS.GongJiaoDic.Add("大足", "http://m.8684.cn/dazu_bus");
            PublicS.GongJiaoDic.Add("恩施", "http://m.8684.cn/enshi_bus");
            PublicS.GongJiaoDic.Add("鄂尔多斯", "http://m.8684.cn/eerduosi_bus");
            PublicS.GongJiaoDic.Add("鄂州", "http://m.8684.cn/ezhou_bus");
            PublicS.GongJiaoDic.Add("福州", "http://m.8684.cn/fuzhou_bus");
            PublicS.GongJiaoDic.Add("抚州", "http://m.8684.cn/fuzhou2_bus");
            PublicS.GongJiaoDic.Add("佛山", "http://m.8684.cn/foshan_bus");
            PublicS.GongJiaoDic.Add("抚顺", "http://m.8684.cn/fushun_bus");
            PublicS.GongJiaoDic.Add("阜新", "http://m.8684.cn/fuxin_bus");
            PublicS.GongJiaoDic.Add("阜阳", "http://m.8684.cn/fuyang_bus");
            PublicS.GongJiaoDic.Add("富阳", "http://m.8684.cn/fuyang2_bus");
            PublicS.GongJiaoDic.Add("奉化", "http://m.8684.cn/fenghua_bus");
            PublicS.GongJiaoDic.Add("肥城", "http://m.8684.cn/feicheng_bus");
            PublicS.GongJiaoDic.Add("防城港", "http://m.8684.cn/fangchenggang_bus");
            PublicS.GongJiaoDic.Add("涪陵", "http://m.8684.cn/fuling_bus");
            PublicS.GongJiaoDic.Add("广州", "http://m.8684.cn/guangzhou_bus");
            PublicS.GongJiaoDic.Add("赣州", "http://m.8684.cn/ganzhou_bus");
            PublicS.GongJiaoDic.Add("桂林", "http://m.8684.cn/guilin_bus");
            PublicS.GongJiaoDic.Add("贵阳", "http://m.8684.cn/guiyang_bus");
            PublicS.GongJiaoDic.Add("广元", "http://m.8684.cn/guangyuan_bus");
            PublicS.GongJiaoDic.Add("个旧", "http://m.8684.cn/gejiu_bus");
            PublicS.GongJiaoDic.Add("广安", "http://m.8684.cn/guangan_bus");
            PublicS.GongJiaoDic.Add("固原", "http://m.8684.cn/guyuan_bus");
            PublicS.GongJiaoDic.Add("巩义", "http://m.8684.cn/gongyi_bus");
            PublicS.GongJiaoDic.Add("贵港", "http://m.8684.cn/guigang_bus");
            PublicS.GongJiaoDic.Add("格尔木", "http://m.8684.cn/geermu_bus");
            PublicS.GongJiaoDic.Add("高邮", "http://m.8684.cn/gaoyou_bus");
            PublicS.GongJiaoDic.Add("赣榆", "http://m.8684.cn/ganyu_bus");
            PublicS.GongJiaoDic.Add("高州", "http://m.8684.cn/gaozhou_bus");
            PublicS.GongJiaoDic.Add("高雄", "http://m.8684.cn/gaoxiong_bus");
            PublicS.GongJiaoDic.Add("杭州", "http://m.8684.cn/hangzhou_bus");
            PublicS.GongJiaoDic.Add("哈尔滨", "http://m.8684.cn/haerbin_bus");
            PublicS.GongJiaoDic.Add("合肥", "http://m.8684.cn/hefei_bus");
            PublicS.GongJiaoDic.Add("淮安", "http://m.8684.cn/huaian_bus");
            PublicS.GongJiaoDic.Add("湖州", "http://m.8684.cn/huzhou_bus");
            PublicS.GongJiaoDic.Add("呼和浩特", "http://m.8684.cn/huhehaote_bus");
            PublicS.GongJiaoDic.Add("海口", "http://m.8684.cn/haikou_bus");
            PublicS.GongJiaoDic.Add("惠州", "http://m.8684.cn/huizhou_bus");
            PublicS.GongJiaoDic.Add("河源", "http://m.8684.cn/heyuan_bus");
            PublicS.GongJiaoDic.Add("葫芦岛", "http://m.8684.cn/huludao_bus");
            PublicS.GongJiaoDic.Add("黄冈", "http://m.8684.cn/huanggang_bus");
            PublicS.GongJiaoDic.Add("汉中", "http://m.8684.cn/hanzhong_bus");
            PublicS.GongJiaoDic.Add("菏泽", "http://m.8684.cn/heze_bus");
            PublicS.GongJiaoDic.Add("淮北", "http://m.8684.cn/huaibei_bus");
            PublicS.GongJiaoDic.Add("淮南", "http://m.8684.cn/huainan_bus");
            PublicS.GongJiaoDic.Add("黄山", "http://m.8684.cn/huangshan_bus");
            PublicS.GongJiaoDic.Add("鹤壁", "http://m.8684.cn/hebi_bus");
            PublicS.GongJiaoDic.Add("衡水", "http://m.8684.cn/hengshui_bus");
            PublicS.GongJiaoDic.Add("邯郸", "http://m.8684.cn/handan_bus");
            PublicS.GongJiaoDic.Add("怀化", "http://m.8684.cn/huaihua_bus");
            PublicS.GongJiaoDic.Add("衡阳", "http://m.8684.cn/hengyang_bus");
            PublicS.GongJiaoDic.Add("哈密", "http://m.8684.cn/hami_bus");
            PublicS.GongJiaoDic.Add("海宁", "http://m.8684.cn/haining_bus");
            PublicS.GongJiaoDic.Add("和田", "http://m.8684.cn/hetian_bus");
            PublicS.GongJiaoDic.Add("花都", "http://m.8684.cn/huadu_bus");
            PublicS.GongJiaoDic.Add("海城", "http://m.8684.cn/haicheng_bus");
            PublicS.GongJiaoDic.Add("海门", "http://m.8684.cn/haimen_bus");
            PublicS.GongJiaoDic.Add("黄石", "http://m.8684.cn/huangshi_bus");
            PublicS.GongJiaoDic.Add("香港", "http://m.8684.cn/hongkong_bus");
            PublicS.GongJiaoDic.Add("呼伦贝尔", "http://m.8684.cn/hulunbeier_bus");
            PublicS.GongJiaoDic.Add("河池", "http://m.8684.cn/hechi_bus");
            PublicS.GongJiaoDic.Add("贺州", "http://m.8684.cn/hezhou_bus");
            PublicS.GongJiaoDic.Add("鹤岗", "http://m.8684.cn/hegang_bus");
            PublicS.GongJiaoDic.Add("黑河", "http://m.8684.cn/heihe_bus");
            PublicS.GongJiaoDic.Add("合川", "http://m.8684.cn/hechuan_bus");
            PublicS.GongJiaoDic.Add("海盐", "http://m.8684.cn/haiyan_bus");
            PublicS.GongJiaoDic.Add("嘉兴", "http://m.8684.cn/jiaxing_bus");
            PublicS.GongJiaoDic.Add("金华", "http://m.8684.cn/jinhua_bus");
            PublicS.GongJiaoDic.Add("济南", "http://m.8684.cn/jinan_bus");
            PublicS.GongJiaoDic.Add("九江", "http://m.8684.cn/jiujiang_bus");
            PublicS.GongJiaoDic.Add("吉安", "http://m.8684.cn/jian_bus");
            PublicS.GongJiaoDic.Add("景德镇", "http://m.8684.cn/jingdezhen_bus");
            PublicS.GongJiaoDic.Add("江门", "http://m.8684.cn/jiangmen_bus");
            PublicS.GongJiaoDic.Add("锦州", "http://m.8684.cn/jinzhou_bus");
            PublicS.GongJiaoDic.Add("荆州", "http://m.8684.cn/jingzhou_bus");
            PublicS.GongJiaoDic.Add("荆门", "http://m.8684.cn/jingmen_bus");
            PublicS.GongJiaoDic.Add("济宁", "http://m.8684.cn/jining_bus");
            PublicS.GongJiaoDic.Add("焦作", "http://m.8684.cn/jiaozuo_bus");
            PublicS.GongJiaoDic.Add("晋城", "http://m.8684.cn/jincheng_bus");
            PublicS.GongJiaoDic.Add("嘉善", "http://m.8684.cn/jiashan_bus");
            PublicS.GongJiaoDic.Add("景洪", "http://m.8684.cn/jinghong_bus");
            PublicS.GongJiaoDic.Add("晋中", "http://m.8684.cn/jinzhong_bus");
            PublicS.GongJiaoDic.Add("介休", "http://m.8684.cn/jiexiu_bus");
            PublicS.GongJiaoDic.Add("胶州", "http://m.8684.cn/jiaozhou_bus");
            PublicS.GongJiaoDic.Add("即墨", "http://m.8684.cn/jimo_bus");
            PublicS.GongJiaoDic.Add("集宁", "http://m.8684.cn/jining2_bus");
            PublicS.GongJiaoDic.Add("江阴", "http://m.8684.cn/jiangyin_bus");
            PublicS.GongJiaoDic.Add("靖江", "http://m.8684.cn/jingjiang_bus");
            PublicS.GongJiaoDic.Add("金坛", "http://m.8684.cn/jintan_bus");
            PublicS.GongJiaoDic.Add("吉林", "http://m.8684.cn/jilin_bus");
            PublicS.GongJiaoDic.Add("佳木斯", "http://m.8684.cn/jiamusi_bus");
            PublicS.GongJiaoDic.Add("酒泉", "http://m.8684.cn/jiuquan_bus");
            PublicS.GongJiaoDic.Add("晋江", "http://m.8684.cn/jinjiang_bus");
            PublicS.GongJiaoDic.Add("吉首", "http://m.8684.cn/jishou_bus");
            PublicS.GongJiaoDic.Add("鸡西", "http://m.8684.cn/jixi_bus");
            PublicS.GongJiaoDic.Add("济源", "http://m.8684.cn/jiyuan_bus");
            PublicS.GongJiaoDic.Add("句容", "http://m.8684.cn/jurong_bus");
            PublicS.GongJiaoDic.Add("嘉峪关", "http://m.8684.cn/jiayuguan_bus");
            PublicS.GongJiaoDic.Add("金昌", "http://m.8684.cn/jinchang_bus");
            PublicS.GongJiaoDic.Add("建德", "http://m.8684.cn/jiande_bus");
            PublicS.GongJiaoDic.Add("揭阳", "http://m.8684.cn/jieyang_bus");
            PublicS.GongJiaoDic.Add("姜堰", "http://m.8684.cn/jiangyan_bus");
            PublicS.GongJiaoDic.Add("建水", "http://m.8684.cn/jianshui_bus");
            PublicS.GongJiaoDic.Add("江津", "http://m.8684.cn/jiangjin_bus");
            PublicS.GongJiaoDic.Add("昆明", "http://m.8684.cn/kunming_bus");
            PublicS.GongJiaoDic.Add("开封", "http://m.8684.cn/kaifeng_bus");
            PublicS.GongJiaoDic.Add("克拉玛依", "http://m.8684.cn/kelamayi_bus");
            PublicS.GongJiaoDic.Add("开远", "http://m.8684.cn/kaiyuan_bus");
            PublicS.GongJiaoDic.Add("喀什", "http://m.8684.cn/kashen_bus");
            PublicS.GongJiaoDic.Add("奎屯", "http://m.8684.cn/kuitun_bus");
            PublicS.GongJiaoDic.Add("库尔勒", "http://m.8684.cn/kuerle_bus");
            PublicS.GongJiaoDic.Add("昆山", "http://m.8684.cn/kunshan_bus");
            PublicS.GongJiaoDic.Add("凯里", "http://m.8684.cn/kaili_bus");
            PublicS.GongJiaoDic.Add("开平", "http://m.8684.cn/kaiping_bus");
            PublicS.GongJiaoDic.Add("兰州", "http://m.8684.cn/lanzhou_bus");
            PublicS.GongJiaoDic.Add("连云港", "http://m.8684.cn/lianyungang_bus");
            PublicS.GongJiaoDic.Add("丽水", "http://m.8684.cn/lishui_bus");
            PublicS.GongJiaoDic.Add("龙岩", "http://m.8684.cn/longyan_bus");
            PublicS.GongJiaoDic.Add("拉萨", "http://m.8684.cn/lasa_bus");
            PublicS.GongJiaoDic.Add("辽阳", "http://m.8684.cn/liaoyang_bus");
            PublicS.GongJiaoDic.Add("泸州", "http://m.8684.cn/luzhou_bus");
            PublicS.GongJiaoDic.Add("临沂", "http://m.8684.cn/linyi_bus");
            PublicS.GongJiaoDic.Add("聊城", "http://m.8684.cn/liaocheng_bus");
            PublicS.GongJiaoDic.Add("六安", "http://m.8684.cn/liuan_bus");
            PublicS.GongJiaoDic.Add("洛阳", "http://m.8684.cn/luoyang_bus");
            PublicS.GongJiaoDic.Add("漯河", "http://m.8684.cn/luohe_bus");
            PublicS.GongJiaoDic.Add("廊坊", "http://m.8684.cn/langfang_bus");
            PublicS.GongJiaoDic.Add("娄底", "http://m.8684.cn/loudi_bus");
            PublicS.GongJiaoDic.Add("六盘水", "http://m.8684.cn/liupanshui_bus");
            PublicS.GongJiaoDic.Add("吕梁", "http://m.8684.cn/lvliang_bus");
            PublicS.GongJiaoDic.Add("临沧", "http://m.8684.cn/lincang_bus");
            PublicS.GongJiaoDic.Add("丽江", "http://m.8684.cn/lijiang_bus");
            PublicS.GongJiaoDic.Add("临安", "http://m.8684.cn/linan_bus");
            PublicS.GongJiaoDic.Add("潞西", "http://m.8684.cn/luxi_bus");
            PublicS.GongJiaoDic.Add("乐山", "http://m.8684.cn/leshan_bus");
            PublicS.GongJiaoDic.Add("莱芜", "http://m.8684.cn/laiwu_bus");
            PublicS.GongJiaoDic.Add("莱州", "http://m.8684.cn/laizhou_bus");
            PublicS.GongJiaoDic.Add("莱西", "http://m.8684.cn/laixi_bus");
            PublicS.GongJiaoDic.Add("溧阳", "http://m.8684.cn/liyang_bus");
            PublicS.GongJiaoDic.Add("辽源", "http://m.8684.cn/liaoyuan_bus");
            PublicS.GongJiaoDic.Add("柳州", "http://m.8684.cn/liuzhou_bus");
            PublicS.GongJiaoDic.Add("来宾", "http://m.8684.cn/laibin_bus");
            PublicS.GongJiaoDic.Add("龙海", "http://m.8684.cn/longhai_bus");
            PublicS.GongJiaoDic.Add("旅顺", "http://m.8684.cn/lvshun_bus");
            PublicS.GongJiaoDic.Add("临汾", "http://m.8684.cn/linfen_bus");
            PublicS.GongJiaoDic.Add("灵宝", "http://m.8684.cn/lingbao_bus");
            PublicS.GongJiaoDic.Add("醴陵", "http://m.8684.cn/liling_bus");
            PublicS.GongJiaoDic.Add("临夏", "http://m.8684.cn/linxia_bus");
            PublicS.GongJiaoDic.Add("临海", "http://m.8684.cn/linhai_bus");
            PublicS.GongJiaoDic.Add("乐昌", "http://m.8684.cn/lechang_bus");
            PublicS.GongJiaoDic.Add("连州", "http://m.8684.cn/lianzhou_bus");
            PublicS.GongJiaoDic.Add("马鞍山", "http://m.8684.cn/maanshan_bus");
            PublicS.GongJiaoDic.Add("茂名", "http://m.8684.cn/maoming_bus");
            PublicS.GongJiaoDic.Add("梅州", "http://m.8684.cn/meizhou_bus");
            PublicS.GongJiaoDic.Add("绵阳", "http://m.8684.cn/mianyang_bus");
            PublicS.GongJiaoDic.Add("眉山", "http://m.8684.cn/meishan_bus");
            PublicS.GongJiaoDic.Add("勉县", "http://m.8684.cn/mianxian_bus");
            PublicS.GongJiaoDic.Add("牡丹江", "http://m.8684.cn/mudanjiang_bus");
            PublicS.GongJiaoDic.Add("梅河口", "http://m.8684.cn/meihekou_bus");
            PublicS.GongJiaoDic.Add("明光", "http://m.8684.cn/mingguang_bus");
            PublicS.GongJiaoDic.Add("南京", "http://m.8684.cn/nanjing_bus");
            PublicS.GongJiaoDic.Add("南通", "http://m.8684.cn/nantong_bus");
            PublicS.GongJiaoDic.Add("宁波", "http://m.8684.cn/ningbo_bus");
            PublicS.GongJiaoDic.Add("宁德", "http://m.8684.cn/ningde_bus");
            PublicS.GongJiaoDic.Add("南平", "http://m.8684.cn/nanping_bus");
            PublicS.GongJiaoDic.Add("南昌", "http://m.8684.cn/nanchang_bus");
            PublicS.GongJiaoDic.Add("南宁", "http://m.8684.cn/nanning_bus");
            PublicS.GongJiaoDic.Add("南充", "http://m.8684.cn/nanchong_bus");
            PublicS.GongJiaoDic.Add("南阳", "http://m.8684.cn/nanyang_bus");
            PublicS.GongJiaoDic.Add("内江", "http://m.8684.cn/neijiang_bus");
            PublicS.GongJiaoDic.Add("南安", "http://m.8684.cn/nanan_bus");
            PublicS.GongJiaoDic.Add("怒江", "http://m.8684.cn/nujiang_bus");
            PublicS.GongJiaoDic.Add("宁海", "http://m.8684.cn/ninghai_bus");
            PublicS.GongJiaoDic.Add("宁乡", "http://m.8684.cn/ningxiang_bus");
            PublicS.GongJiaoDic.Add("莆田", "http://m.8684.cn/putian_bus");
            PublicS.GongJiaoDic.Add("萍乡", "http://m.8684.cn/pingxiang_bus");
            PublicS.GongJiaoDic.Add("盘锦", "http://m.8684.cn/panjin_bus");
            PublicS.GongJiaoDic.Add("平顶山", "http://m.8684.cn/pingdingshan_bus");
            PublicS.GongJiaoDic.Add("濮阳", "http://m.8684.cn/puyang_bus");
            PublicS.GongJiaoDic.Add("攀枝花", "http://m.8684.cn/panzhihua_bus");
            PublicS.GongJiaoDic.Add("平湖", "http://m.8684.cn/pinghu_bus");
            PublicS.GongJiaoDic.Add("平度", "http://m.8684.cn/pingdu_bus");
            PublicS.GongJiaoDic.Add("蓬莱", "http://m.8684.cn/penglai_bus");
            PublicS.GongJiaoDic.Add("普兰店", "http://m.8684.cn/pulandian_bus");
            PublicS.GongJiaoDic.Add("普宁", "http://m.8684.cn/puning_bus");
            PublicS.GongJiaoDic.Add("平凉", "http://m.8684.cn/pingliang_bus");
            PublicS.GongJiaoDic.Add("邳州", "http://m.8684.cn/pizhou_bus");
            PublicS.GongJiaoDic.Add("平遥", "http://m.8684.cn/pingyao_bus");
            PublicS.GongJiaoDic.Add("齐齐哈尔", "http://m.8684.cn/qiqihaer_bus");
            PublicS.GongJiaoDic.Add("衢州", "http://m.8684.cn/quzhou_bus");
            PublicS.GongJiaoDic.Add("泉州", "http://m.8684.cn/quanzhou_bus");
            PublicS.GongJiaoDic.Add("青岛", "http://m.8684.cn/qingdao_bus");
            PublicS.GongJiaoDic.Add("秦皇岛", "http://m.8684.cn/qinhuangdao_bus");
            PublicS.GongJiaoDic.Add("曲靖", "http://m.8684.cn/qujing_bus");
            PublicS.GongJiaoDic.Add("启东", "http://m.8684.cn/qidong_bus");
            PublicS.GongJiaoDic.Add("琼海", "http://m.8684.cn/qionghai_bus");
            PublicS.GongJiaoDic.Add("钦州", "http://m.8684.cn/qinzhou_bus");
            PublicS.GongJiaoDic.Add("清远", "http://m.8684.cn/qingyuan_bus");
            PublicS.GongJiaoDic.Add("庆阳", "http://m.8684.cn/qingyang_bus");
            PublicS.GongJiaoDic.Add("青州", "http://m.8684.cn/qingzhou_bus");
            PublicS.GongJiaoDic.Add("黔南", "http://m.8684.cn/qiannan_bus");
            PublicS.GongJiaoDic.Add("祁县", "http://m.8684.cn/qixian_bus");
            PublicS.GongJiaoDic.Add("清镇", "http://m.8684.cn/qingzhen_bus");
            PublicS.GongJiaoDic.Add("迁安", "http://m.8684.cn/qianan_bus");
            PublicS.GongJiaoDic.Add("潜江", "http://m.8684.cn/qianjiang_bus");
            PublicS.GongJiaoDic.Add("綦江", "http://m.8684.cn/qijiang_bus");
            PublicS.GongJiaoDic.Add("日照", "http://m.8684.cn/rizhao_bus");
            PublicS.GongJiaoDic.Add("瑞安", "http://m.8684.cn/ruian_bus");
            PublicS.GongJiaoDic.Add("日喀则", "http://m.8684.cn/rikaze_bus");
            PublicS.GongJiaoDic.Add("荣成", "http://m.8684.cn/rongcheng_bus");
            PublicS.GongJiaoDic.Add("乳山", "http://m.8684.cn/rushan_bus");
            PublicS.GongJiaoDic.Add("如皋", "http://m.8684.cn/rugao_bus");
            PublicS.GongJiaoDic.Add("上海", "http://m.8684.cn/shanghai_bus");
            PublicS.GongJiaoDic.Add("沈阳", "http://m.8684.cn/shenyang_bus");
            PublicS.GongJiaoDic.Add("苏州", "http://m.8684.cn/suzhou_bus");
            PublicS.GongJiaoDic.Add("深圳", "http://m.8684.cn/shenzhen_bus");
            PublicS.GongJiaoDic.Add("宿迁", "http://m.8684.cn/suqian_bus");
            PublicS.GongJiaoDic.Add("绍兴", "http://m.8684.cn/shaoxing_bus");
            PublicS.GongJiaoDic.Add("石家庄", "http://m.8684.cn/shijiazhuang_bus");
            PublicS.GongJiaoDic.Add("三明", "http://m.8684.cn/sanming_bus");
            PublicS.GongJiaoDic.Add("上饶", "http://m.8684.cn/shangrao_bus");
            PublicS.GongJiaoDic.Add("汕头", "http://m.8684.cn/shantou_bus");
            PublicS.GongJiaoDic.Add("韶关", "http://m.8684.cn/shaoguan_bus");
            PublicS.GongJiaoDic.Add("十堰", "http://m.8684.cn/shiyan_bus");
            PublicS.GongJiaoDic.Add("商洛", "http://m.8684.cn/shangluo_bus");
            PublicS.GongJiaoDic.Add("宿州", "http://m.8684.cn/suzhou2_bus");
            PublicS.GongJiaoDic.Add("三门峡", "http://m.8684.cn/sanmenxia_bus");
            PublicS.GongJiaoDic.Add("邵阳", "http://m.8684.cn/shaoyang_bus");
            PublicS.GongJiaoDic.Add("石河子", "http://m.8684.cn/shihezi_bus");
            PublicS.GongJiaoDic.Add("朔州", "http://m.8684.cn/shuozhou_bus");
            PublicS.GongJiaoDic.Add("商丘", "http://m.8684.cn/shangqiu_bus");
            PublicS.GongJiaoDic.Add("上虞", "http://m.8684.cn/shangyu_bus");
            PublicS.GongJiaoDic.Add("思茅", "http://m.8684.cn/simao_bus");
            PublicS.GongJiaoDic.Add("遂宁", "http://m.8684.cn/suining_bus");
            PublicS.GongJiaoDic.Add("四平", "http://m.8684.cn/siping_bus");
            PublicS.GongJiaoDic.Add("随州", "http://m.8684.cn/suizhou_bus");
            PublicS.GongJiaoDic.Add("双鸭山", "http://m.8684.cn/shuangyashan_bus");
            PublicS.GongJiaoDic.Add("三亚", "http://m.8684.cn/sanya_bus");
            PublicS.GongJiaoDic.Add("石狮", "http://m.8684.cn/shishi_bus");
            PublicS.GongJiaoDic.Add("寿光", "http://m.8684.cn/shouguang_bus");
            PublicS.GongJiaoDic.Add("石林", "http://m.8684.cn/shilin_bus");
            PublicS.GongJiaoDic.Add("沭阳", "http://m.8684.cn/shuyang_bus");
            PublicS.GongJiaoDic.Add("宿豫", "http://m.8684.cn/suyu_bus");
            PublicS.GongJiaoDic.Add("松原", "http://m.8684.cn/songyuan_bus");
            PublicS.GongJiaoDic.Add("山南", "http://m.8684.cn/shannan_bus");
            PublicS.GongJiaoDic.Add("汕尾", "http://m.8684.cn/shanwei_bus");
            PublicS.GongJiaoDic.Add("顺德", "http://m.8684.cn/shunde_bus");
            PublicS.GongJiaoDic.Add("四会", "http://m.8684.cn/sihui_bus");
            PublicS.GongJiaoDic.Add("绥化", "http://m.8684.cn/suihua_bus");
            PublicS.GongJiaoDic.Add("泗阳", "http://m.8684.cn/siyang_bus");
            PublicS.GongJiaoDic.Add("天津", "http://m.8684.cn/tianjin_bus");
            PublicS.GongJiaoDic.Add("泰州", "http://m.8684.cn/taizhou_bus");
            PublicS.GongJiaoDic.Add("台州", "http://m.8684.cn/taizhou2_bus");
            PublicS.GongJiaoDic.Add("太原", "http://m.8684.cn/taiyuan_bus");
            PublicS.GongJiaoDic.Add("铁岭", "http://m.8684.cn/tieling_bus");
            PublicS.GongJiaoDic.Add("铜川", "http://m.8684.cn/tongchuan_bus");
            PublicS.GongJiaoDic.Add("泰安", "http://m.8684.cn/taian_bus");
            PublicS.GongJiaoDic.Add("铜陵", "http://m.8684.cn/tongling_bus");
            PublicS.GongJiaoDic.Add("唐山", "http://m.8684.cn/tangshan_bus");
            PublicS.GongJiaoDic.Add("吐鲁番", "http://m.8684.cn/tulufan_bus");
            PublicS.GongJiaoDic.Add("塔城", "http://m.8684.cn/tacheng_bus");
            PublicS.GongJiaoDic.Add("腾冲", "http://m.8684.cn/tengchong_bus");
            PublicS.GongJiaoDic.Add("桐乡", "http://m.8684.cn/tongxiang_bus");
            PublicS.GongJiaoDic.Add("桐庐", "http://m.8684.cn/tonglu_bus");
            PublicS.GongJiaoDic.Add("滕州", "http://m.8684.cn/tengzhou_bus");
            PublicS.GongJiaoDic.Add("通辽", "http://m.8684.cn/tongliao_bus");
            PublicS.GongJiaoDic.Add("太仓", "http://m.8684.cn/taicang_bus");
            PublicS.GongJiaoDic.Add("通州", "http://m.8684.cn/tongzhou_bus");
            PublicS.GongJiaoDic.Add("泰兴", "http://m.8684.cn/taixing_bus");
            PublicS.GongJiaoDic.Add("天水", "http://m.8684.cn/tianshui_bus");
            PublicS.GongJiaoDic.Add("天门", "http://m.8684.cn/tianmen_bus");
            PublicS.GongJiaoDic.Add("铜仁", "http://m.8684.cn/tongren_bus");
            PublicS.GongJiaoDic.Add("天长", "http://m.8684.cn/tianchang_bus");
            PublicS.GongJiaoDic.Add("台山", "http://m.8684.cn/taishan_bus");
            PublicS.GongJiaoDic.Add("通化", "http://m.8684.cn/tonghua_bus");
            PublicS.GongJiaoDic.Add("天柱", "http://m.8684.cn/tianzhu_bus");
            PublicS.GongJiaoDic.Add("台北", "http://m.8684.cn/taipei_bus");
            PublicS.GongJiaoDic.Add("武汉", "http://m.8684.cn/wuhan_bus");
            PublicS.GongJiaoDic.Add("乌鲁木齐", "http://m.8684.cn/wulumuqi_bus");
            PublicS.GongJiaoDic.Add("无锡", "http://m.8684.cn/wuxi_bus");
            PublicS.GongJiaoDic.Add("温州", "http://m.8684.cn/wenzhou_bus");
            PublicS.GongJiaoDic.Add("渭南", "http://m.8684.cn/weinan_bus");
            PublicS.GongJiaoDic.Add("威海", "http://m.8684.cn/weihai_bus");
            PublicS.GongJiaoDic.Add("潍坊", "http://m.8684.cn/weifang_bus");
            PublicS.GongJiaoDic.Add("芜湖", "http://m.8684.cn/wuhu_bus");
            PublicS.GongJiaoDic.Add("梧州", "http://m.8684.cn/wuzhou_bus");
            PublicS.GongJiaoDic.Add("温岭", "http://m.8684.cn/wenling_bus");
            PublicS.GongJiaoDic.Add("文登", "http://m.8684.cn/wendeng_bus");
            PublicS.GongJiaoDic.Add("瓦房店", "http://m.8684.cn/wafangdian_bus");
            PublicS.GongJiaoDic.Add("吴江", "http://m.8684.cn/wujiang_bus");
            PublicS.GongJiaoDic.Add("武威", "http://m.8684.cn/wuwei_bus");
            PublicS.GongJiaoDic.Add("乌海", "http://m.8684.cn/wuhai_bus");
            PublicS.GongJiaoDic.Add("乌兰浩特", "http://m.8684.cn/wulanhaote_bus");
            PublicS.GongJiaoDic.Add("吴忠", "http://m.8684.cn/wuzhong_bus");
            PublicS.GongJiaoDic.Add("乌兰察布", "http://m.8684.cn/wulanchabu_bus");
            PublicS.GongJiaoDic.Add("武安", "http://m.8684.cn/wuan_bus");
            PublicS.GongJiaoDic.Add("西安", "http://m.8684.cn/xian_bus");
            PublicS.GongJiaoDic.Add("厦门", "http://m.8684.cn/xiamen_bus");
            PublicS.GongJiaoDic.Add("徐州", "http://m.8684.cn/xuzhou_bus");
            PublicS.GongJiaoDic.Add("新余", "http://m.8684.cn/xinyu_bus");
            PublicS.GongJiaoDic.Add("西宁", "http://m.8684.cn/xining_bus");
            PublicS.GongJiaoDic.Add("西昌", "http://m.8684.cn/xichang_bus");
            PublicS.GongJiaoDic.Add("襄阳", "http://m.8684.cn/xiangfan_bus");
            PublicS.GongJiaoDic.Add("咸阳", "http://m.8684.cn/xianyang_bus");
            PublicS.GongJiaoDic.Add("宣城", "http://m.8684.cn/xuancheng_bus");
            PublicS.GongJiaoDic.Add("信阳", "http://m.8684.cn/xinyang_bus");
            PublicS.GongJiaoDic.Add("新乡", "http://m.8684.cn/xinxiang_bus");
            PublicS.GongJiaoDic.Add("许昌", "http://m.8684.cn/xuchang_bus");
            PublicS.GongJiaoDic.Add("邢台", "http://m.8684.cn/xingtai_bus");
            PublicS.GongJiaoDic.Add("忻州", "http://m.8684.cn/xinzhou_bus");
            PublicS.GongJiaoDic.Add("湘潭", "http://m.8684.cn/xiangtan_bus");
            PublicS.GongJiaoDic.Add("象山", "http://m.8684.cn/xiangshan_bus");
            PublicS.GongJiaoDic.Add("咸宁", "http://m.8684.cn/xianning_bus");
            PublicS.GongJiaoDic.Add("仙桃", "http://m.8684.cn/xiantao_bus");
            PublicS.GongJiaoDic.Add("兴义", "http://m.8684.cn/xingyi_bus");
            PublicS.GongJiaoDic.Add("香格里拉", "http://m.8684.cn/xianggelila_bus");
            PublicS.GongJiaoDic.Add("湘乡", "http://m.8684.cn/xiangxiang_bus");
            PublicS.GongJiaoDic.Add("项城", "http://m.8684.cn/xiangcheng_bus");
            PublicS.GongJiaoDic.Add("兴化", "http://m.8684.cn/xinghua_bus");
            PublicS.GongJiaoDic.Add("新沂", "http://m.8684.cn/xinyi_bus");
            PublicS.GongJiaoDic.Add("孝感", "http://m.8684.cn/xiaogan_bus");
            PublicS.GongJiaoDic.Add("湘西", "http://m.8684.cn/xiangxi_bus");
            PublicS.GongJiaoDic.Add("新昌", "http://m.8684.cn/xinchang_bus");
            PublicS.GongJiaoDic.Add("扬州", "http://m.8684.cn/yangzhou_bus");
            PublicS.GongJiaoDic.Add("盐城", "http://m.8684.cn/yancheng_bus");
            PublicS.GongJiaoDic.Add("宜春", "http://m.8684.cn/yichun_bus");
            PublicS.GongJiaoDic.Add("鹰潭", "http://m.8684.cn/yingtan_bus");
            PublicS.GongJiaoDic.Add("银川", "http://m.8684.cn/yinchuan_bus");
            PublicS.GongJiaoDic.Add("阳江", "http://m.8684.cn/yangjiang_bus");
            PublicS.GongJiaoDic.Add("营口", "http://m.8684.cn/yingkou_bus");
            PublicS.GongJiaoDic.Add("宜宾", "http://m.8684.cn/yibin_bus");
            PublicS.GongJiaoDic.Add("雅安", "http://m.8684.cn/yaan_bus");
            PublicS.GongJiaoDic.Add("宜昌", "http://m.8684.cn/yichang_bus");
            PublicS.GongJiaoDic.Add("延安", "http://m.8684.cn/yanan_bus");
            PublicS.GongJiaoDic.Add("榆林", "http://m.8684.cn/yulin_bus");
            PublicS.GongJiaoDic.Add("烟台", "http://m.8684.cn/yantai_bus");
            PublicS.GongJiaoDic.Add("岳阳", "http://m.8684.cn/yueyang_bus");
            PublicS.GongJiaoDic.Add("永州", "http://m.8684.cn/yongzhou_bus");
            PublicS.GongJiaoDic.Add("益阳", "http://m.8684.cn/yiyang_bus");
            PublicS.GongJiaoDic.Add("伊宁", "http://m.8684.cn/yining_bus");
            PublicS.GongJiaoDic.Add("伊犁", "http://m.8684.cn/yili_bus");
            PublicS.GongJiaoDic.Add("运城", "http://m.8684.cn/yuncheng_bus");
            PublicS.GongJiaoDic.Add("阳泉", "http://m.8684.cn/yangquan_bus");
            PublicS.GongJiaoDic.Add("玉溪", "http://m.8684.cn/yuxi_bus");
            PublicS.GongJiaoDic.Add("义乌", "http://m.8684.cn/yiwu_bus");
            PublicS.GongJiaoDic.Add("余姚", "http://m.8684.cn/yuyao_bus");
            PublicS.GongJiaoDic.Add("玉环", "http://m.8684.cn/yuhuan_bus");
            PublicS.GongJiaoDic.Add("永康", "http://m.8684.cn/yongkang_bus");
            PublicS.GongJiaoDic.Add("兖州", "http://m.8684.cn/yanzhou_bus");
            PublicS.GongJiaoDic.Add("宜兴", "http://m.8684.cn/yixing_bus");
            PublicS.GongJiaoDic.Add("延吉", "http://m.8684.cn/yanji_bus");
            PublicS.GongJiaoDic.Add("伊春", "http://m.8684.cn/yichun2_bus");
            PublicS.GongJiaoDic.Add("玉林", "http://m.8684.cn/yulin2_bus");
            PublicS.GongJiaoDic.Add("牙克石", "http://m.8684.cn/yakeshi_bus");
            PublicS.GongJiaoDic.Add("延边", "http://m.8684.cn/yanbian_bus");
            PublicS.GongJiaoDic.Add("阳春", "http://m.8684.cn/yangchun_bus");
            PublicS.GongJiaoDic.Add("云浮", "http://m.8684.cn/yunfu_bus");
            PublicS.GongJiaoDic.Add("仪征", "http://m.8684.cn/yizheng_bus");
            PublicS.GongJiaoDic.Add("扬中", "http://m.8684.cn/yangzhong_bus");
            PublicS.GongJiaoDic.Add("永安", "http://m.8684.cn/yongan_bus");
            PublicS.GongJiaoDic.Add("镇江", "http://m.8684.cn/zhenjiang_bus");
            PublicS.GongJiaoDic.Add("舟山", "http://m.8684.cn/zhoushan_bus");
            PublicS.GongJiaoDic.Add("珠海", "http://m.8684.cn/zhuhai_bus");
            PublicS.GongJiaoDic.Add("郑州", "http://m.8684.cn/zhengzhou_bus");
            PublicS.GongJiaoDic.Add("漳州", "http://m.8684.cn/zhangzhou_bus");
            PublicS.GongJiaoDic.Add("中山", "http://m.8684.cn/zhongshan_bus");
            PublicS.GongJiaoDic.Add("肇庆", "http://m.8684.cn/zhaoqing_bus");
            PublicS.GongJiaoDic.Add("自贡", "http://m.8684.cn/zigong_bus");
            PublicS.GongJiaoDic.Add("枣庄", "http://m.8684.cn/zaozhuang_bus");
            PublicS.GongJiaoDic.Add("张家口", "http://m.8684.cn/zhangjiakou_bus");
            PublicS.GongJiaoDic.Add("张家界", "http://m.8684.cn/zhangjiajie_bus");
            PublicS.GongJiaoDic.Add("株洲", "http://m.8684.cn/zhuzhou_bus");
            PublicS.GongJiaoDic.Add("淄博", "http://m.8684.cn/zibo_bus");
            PublicS.GongJiaoDic.Add("遵义", "http://m.8684.cn/zunyi_bus");
            PublicS.GongJiaoDic.Add("诸暨", "http://m.8684.cn/zhuji_bus");
            PublicS.GongJiaoDic.Add("昭通", "http://m.8684.cn/zhaotong_bus");
            PublicS.GongJiaoDic.Add("章丘", "http://m.8684.cn/zhangqiu_bus");
            PublicS.GongJiaoDic.Add("诸城", "http://m.8684.cn/zhucheng_bus");
            PublicS.GongJiaoDic.Add("张家港", "http://m.8684.cn/zhangjiagang_bus");
            PublicS.GongJiaoDic.Add("周口", "http://m.8684.cn/zhoukou_bus");
            PublicS.GongJiaoDic.Add("驻马店", "http://m.8684.cn/zhumadian_bus");
            PublicS.GongJiaoDic.Add("湛江", "http://m.8684.cn/zhanjiang_bus");
            PublicS.GongJiaoDic.Add("增城", "http://m.8684.cn/zengcheng_bus");
            PublicS.GongJiaoDic.Add("张掖", "http://m.8684.cn/zhangye_bus");
            PublicS.GongJiaoDic.Add("肇东", "http://m.8684.cn/zhaodong_bus");
            PublicS.GongJiaoDic.Add("庄河", "http://m.8684.cn/zhuanghe_bus");
            PublicS.GongJiaoDic.Add("资阳", "http://m.8684.cn/ziyang_bus");

        }

        /// <summary>
        /// 返回星座
        /// </summary>
        /// <param name="say"></param>
        /// <returns></returns>
        public static string GetXZ(string say)
        {
            string tempstr = "白羊座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "金牛座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "双子座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "巨蟹座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "狮子座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "处女座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "天秤座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "天蝎座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "射手座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "摩羯座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "水瓶座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            tempstr = "双鱼座";
            if (say.IndexOf(tempstr) >= 0)
            {
                return tempstr;
            }
            return tempstr;
        }

        /// <summary>
        /// 初始化星座连接
        /// </summary>
        public static void GetInitXingZuo()
        {
            PublicS.XingZuoDic_z.Add("白羊座", "http://tools.2345.com/m/naonao/baiyang.htm");
            PublicS.XingZuoDic_y.Add("白羊座", "http://tools.2345.com/m/susan/baiyang.htm");

            PublicS.XingZuoDic_z.Add("金牛座", "http://tools.2345.com/m/naonao/jinniu.htm");
            PublicS.XingZuoDic_y.Add("金牛座", "http://tools.2345.com/m/susan/jinniu.htm");

            PublicS.XingZuoDic_z.Add("双子座", "http://tools.2345.com/m/naonao/shuangzi.htm");
            PublicS.XingZuoDic_y.Add("双子座", "http://tools.2345.com/m/susan/shuangzi.htm");

            PublicS.XingZuoDic_z.Add("巨蟹座", "http://tools.2345.com/m/naonao/jvxie.htm");
            PublicS.XingZuoDic_y.Add("巨蟹座", "http://tools.2345.com/m/susan/jvxie.htm");

            PublicS.XingZuoDic_z.Add("狮子座", "http://tools.2345.com/m/naonao/shizi.htm");
            PublicS.XingZuoDic_y.Add("狮子座", "http://tools.2345.com/m/susan/shizi.htm");

            PublicS.XingZuoDic_z.Add("处女座", "http://tools.2345.com/m/naonao/chunv.htm");
            PublicS.XingZuoDic_y.Add("处女座", "http://tools.2345.com/m/susan/chunv.htm");

            PublicS.XingZuoDic_z.Add("天秤座", "http://tools.2345.com/m/naonao/tiancheng.htm");
            PublicS.XingZuoDic_y.Add("天秤座", "http://tools.2345.com/m/susan/tiancheng.htm");

            PublicS.XingZuoDic_z.Add("天蝎座", "http://tools.2345.com/m/naonao/tianxie.htm");
            PublicS.XingZuoDic_y.Add("天蝎座", "http://tools.2345.com/m/susan/tianxie.htm");

            PublicS.XingZuoDic_z.Add("射手座", "http://tools.2345.com/m/naonao/sheshou.htm");
            PublicS.XingZuoDic_y.Add("射手座", "http://tools.2345.com/m/susan/sheshou.htm");

            PublicS.XingZuoDic_z.Add("摩羯座", "http://tools.2345.com/m/naonao/mojie.htm");
            PublicS.XingZuoDic_y.Add("摩羯座", "http://tools.2345.com/m/susan/mojie.htm");

            PublicS.XingZuoDic_z.Add("水瓶座", "http://tools.2345.com/m/naonao/shuiping.htm");
            PublicS.XingZuoDic_y.Add("水瓶座", "http://tools.2345.com/m/susan/shuiping.htm");

            PublicS.XingZuoDic_z.Add("双鱼座", "http://tools.2345.com/m/naonao/shuangyu.htm");
            PublicS.XingZuoDic_y.Add("双鱼座", "http://tools.2345.com/m/susan/shuangyu.htm");
        }

        /// <summary>
        /// 城市和区县代码数据
        /// </summary>
        public static Dictionary<string, string> CityDicDM = new Dictionary<string, string>();

        /// <summary>
        /// 初始化城市和区县代码数据
        /// </summary>
        public static void GetInitCityDM()
        {
            PublicS.CityDicDM.Add("北京", "http://waptianqi.2345.com/beijing-54511.htm");
            PublicS.CityDicDM.Add("天津", "http://waptianqi.2345.com/tianjin-54527.htm");
            PublicS.CityDicDM.Add("上海", "http://waptianqi.2345.com/shanghai-58362.htm");
            PublicS.CityDicDM.Add("井陉", "http://waptianqi.2345.com/shijiazhuang-53698.htm");
            PublicS.CityDicDM.Add("承德", "http://waptianqi.2345.com/chengde-54423.htm");
            PublicS.CityDicDM.Add("张家口", "http://waptianqi.2345.com/zhang-54401.htm");
            PublicS.CityDicDM.Add("秦皇岛", "http://waptianqi.2345.com/qinhuangdao-54449.htm");
            PublicS.CityDicDM.Add("唐山", "http://waptianqi.2345.com/tangshan-54534.htm");
            PublicS.CityDicDM.Add("廊坊", "http://waptianqi.2345.com/langfang-54515.htm");
            PublicS.CityDicDM.Add("保定", "http://waptianqi.2345.com/baoding-54602.htm");
            PublicS.CityDicDM.Add("沧州", "http://waptianqi.2345.com/cangzhou-54616.htm");
            PublicS.CityDicDM.Add("衡水", "http://waptianqi.2345.com/hengshui-54702.htm");
            PublicS.CityDicDM.Add("邢台", "http://waptianqi.2345.com/xingtai-53798.htm");
            PublicS.CityDicDM.Add("邯郸", "http://waptianqi.2345.com/handan-53892.htm");
            PublicS.CityDicDM.Add("郑州", "http://waptianqi.2345.com/zhengzhou-57083.htm");
            PublicS.CityDicDM.Add("开封", "http://waptianqi.2345.com/kaifeng-57091.htm");
            PublicS.CityDicDM.Add("洛阳", "http://waptianqi.2345.com/luoyang-57073.htm");
            PublicS.CityDicDM.Add("安阳", "http://waptianqi.2345.com/anyang-53898.htm");
            PublicS.CityDicDM.Add("焦作", "http://waptianqi.2345.com/jiaozuo-53982.htm");
            PublicS.CityDicDM.Add("鹤壁", "http://waptianqi.2345.com/hebi-53990.htm");
            PublicS.CityDicDM.Add("新乡", "http://waptianqi.2345.com/xinxiang-53986.htm");
            PublicS.CityDicDM.Add("濮阳", "http://waptianqi.2345.com/puyang-54900.htm");
            PublicS.CityDicDM.Add("许昌", "http://waptianqi.2345.com/xuchang-57089.htm");
            PublicS.CityDicDM.Add("漯河", "http://waptianqi.2345.com/luohe-57186.htm");
            PublicS.CityDicDM.Add("三门峡", "http://waptianqi.2345.com/sanmenxia-57051.htm");
            PublicS.CityDicDM.Add("南阳", "http://waptianqi.2345.com/nanyang-57178.htm");
            PublicS.CityDicDM.Add("商丘", "http://waptianqi.2345.com/shangqiu-58005.htm");
            PublicS.CityDicDM.Add("信阳", "http://waptianqi.2345.com/xinyang-57297.htm");
            PublicS.CityDicDM.Add("周口", "http://waptianqi.2345.com/zhoukou-57195.htm");
            PublicS.CityDicDM.Add("驻马店", "http://waptianqi.2345.com/zhumadian-57290.htm");
            PublicS.CityDicDM.Add("济源", "http://waptianqi.2345.com/jiyuan-53978.htm");
            PublicS.CityDicDM.Add("郏县", "http://waptianqi.2345.com/jiaxian-70275.htm");
            PublicS.CityDicDM.Add("合肥", "http://waptianqi.2345.com/hefei-58321.htm");
            PublicS.CityDicDM.Add("亳州", "http://waptianqi.2345.com/bozhou-58102.htm");
            PublicS.CityDicDM.Add("淮北", "http://waptianqi.2345.com/huaibei-58116.htm");
            PublicS.CityDicDM.Add("宿州", "http://waptianqi.2345.com/suzhou-58122.htm");
            PublicS.CityDicDM.Add("阜阳", "http://waptianqi.2345.com/fuyang-58203.htm");
            PublicS.CityDicDM.Add("蚌埠", "http://waptianqi.2345.com/bengbu-58221.htm");
            PublicS.CityDicDM.Add("淮南", "http://waptianqi.2345.com/huainan-58224.htm");
            PublicS.CityDicDM.Add("滁州", "http://waptianqi.2345.com/chuzhou-58236.htm");
            PublicS.CityDicDM.Add("六安", "http://waptianqi.2345.com/luan-58311.htm");
            PublicS.CityDicDM.Add("无为", "http://waptianqi.2345.com/wuwei-60594.htm");
            PublicS.CityDicDM.Add("含山", "http://waptianqi.2345.com/hanshan-61040.htm");
            PublicS.CityDicDM.Add("安庆", "http://waptianqi.2345.com/anqing-58424.htm");
            PublicS.CityDicDM.Add("池州", "http://waptianqi.2345.com/chizhou-58427.htm");
            PublicS.CityDicDM.Add("铜陵", "http://waptianqi.2345.com/tongling-58429.htm");
            PublicS.CityDicDM.Add("宣城", "http://waptianqi.2345.com/xuancheng-58433.htm");
            PublicS.CityDicDM.Add("黄山", "http://waptianqi.2345.com/huangshan-70931.htm");

            PublicS.CityDicDM.Add("杭州", "http://waptianqi.2345.com/hangzhou-58457.htm");
            PublicS.CityDicDM.Add("宁波", "http://waptianqi.2345.com/ningbo-58465.htm");
            PublicS.CityDicDM.Add("温州", "http://waptianqi.2345.com/wenzhou-58659.htm");
            PublicS.CityDicDM.Add("嘉兴", "http://waptianqi.2345.com/jiaxing-58452.htm");
            PublicS.CityDicDM.Add("湖州", "http://waptianqi.2345.com/huzhou-58450.htm");
            PublicS.CityDicDM.Add("绍兴", "http://waptianqi.2345.com/shaoxing-58453.htm");
            PublicS.CityDicDM.Add("金华", "http://waptianqi.2345.com/jinhua-58549.htm");
            PublicS.CityDicDM.Add("衢州", "http://waptianqi.2345.com/quzhou-58633.htm");
            PublicS.CityDicDM.Add("舟山", "http://waptianqi.2345.com/zhoushan-58477.htm");
            PublicS.CityDicDM.Add("台州", "http://waptianqi.2345.com/taizhou-58651.htm");
            PublicS.CityDicDM.Add("丽水", "http://waptianqi.2345.com/lishui-58646.htm");
            PublicS.CityDicDM.Add("重庆", "http://waptianqi.2345.com/chongqing-57516.htm");




            PublicS.CityDicDM.Add("福州", "http://waptianqi.2345.com/fuzhou-58847.htm");
            PublicS.CityDicDM.Add("厦门", "http://waptianqi.2345.com/xiamen-59134.htm");
            PublicS.CityDicDM.Add("莆田", "http://waptianqi.2345.com/putian-58946.htm");
            PublicS.CityDicDM.Add("三明", "http://waptianqi.2345.com/sanming-58828.htm");
            PublicS.CityDicDM.Add("泉州", "http://waptianqi.2345.com/quanzhou-59131.htm");
            PublicS.CityDicDM.Add("漳州", "http://waptianqi.2345.com/zhangzhou-59126.htm");
            PublicS.CityDicDM.Add("南平", "http://waptianqi.2345.com/nanping-58834.htm");
            PublicS.CityDicDM.Add("龙岩", "http://waptianqi.2345.com/longyan-58927.htm");
            PublicS.CityDicDM.Add("宁德", "http://waptianqi.2345.com/ningde-58846.htm");
            PublicS.CityDicDM.Add("钓鱼岛", "http://waptianqi.2345.com/diaoyudao-71415.htm");
            PublicS.CityDicDM.Add("南京", "http://waptianqi.2345.com/nanjing-58238.htm");
            PublicS.CityDicDM.Add("无锡", "http://waptianqi.2345.com/wuxi-58354.htm");
            PublicS.CityDicDM.Add("徐州", "http://waptianqi.2345.com/xuzhou-58027.htm");
            PublicS.CityDicDM.Add("常州", "http://waptianqi.2345.com/changzhou-58343.htm");
            PublicS.CityDicDM.Add("苏州", "http://waptianqi.2345.com/suzhou-58357.htm");
            PublicS.CityDicDM.Add("南通", "http://waptianqi.2345.com/nantong-58259.htm");
            PublicS.CityDicDM.Add("连云港", "http://waptianqi.2345.com/lianyungang-58044.htm");
            PublicS.CityDicDM.Add("淮安", "http://waptianqi.2345.com/huaian-58141.htm");
            PublicS.CityDicDM.Add("盐城", "http://waptianqi.2345.com/yancheng-58151.htm");
            PublicS.CityDicDM.Add("扬州", "http://waptianqi.2345.com/yangzhou-58245.htm");
            PublicS.CityDicDM.Add("镇江", "http://waptianqi.2345.com/zhenjiang-58248.htm");
            PublicS.CityDicDM.Add("泰州", "http://waptianqi.2345.com/taizhou-58246.htm");
            PublicS.CityDicDM.Add("宿迁", "http://waptianqi.2345.com/suqian-58131.htm");
            PublicS.CityDicDM.Add("广州", "http://waptianqi.2345.com/guangzhou-59287.htm");
            PublicS.CityDicDM.Add("深圳", "http://waptianqi.2345.com/shenzhen-59493.htm");
            PublicS.CityDicDM.Add("珠海", "http://waptianqi.2345.com/zhuhai-59488.htm");
            PublicS.CityDicDM.Add("汕头", "http://waptianqi.2345.com/shantou-59316.htm");
            PublicS.CityDicDM.Add("佛山", "http://waptianqi.2345.com/foshan-59288.htm");
            PublicS.CityDicDM.Add("韶关", "http://waptianqi.2345.com/shaoguan-59082.htm");
            PublicS.CityDicDM.Add("河源", "http://waptianqi.2345.com/heyuan-59293.htm");
            PublicS.CityDicDM.Add("梅州", "http://waptianqi.2345.com/meizhou-59109.htm");
            PublicS.CityDicDM.Add("惠州", "http://waptianqi.2345.com/huizhou-59297.htm");
            PublicS.CityDicDM.Add("汕尾", "http://waptianqi.2345.com/shanwei-59501.htm");
            PublicS.CityDicDM.Add("东莞", "http://waptianqi.2345.com/dongguan-59289.htm");
            PublicS.CityDicDM.Add("中山", "http://waptianqi.2345.com/zhongshan-59485.htm");
            PublicS.CityDicDM.Add("江门", "http://waptianqi.2345.com/jiangmen-59473.htm");
            PublicS.CityDicDM.Add("阳江", "http://waptianqi.2345.com/yangjiang-59663.htm");
            PublicS.CityDicDM.Add("湛江", "http://waptianqi.2345.com/zhanjiang-59658.htm");
            PublicS.CityDicDM.Add("茂名", "http://waptianqi.2345.com/maoming-59659.htm");
            PublicS.CityDicDM.Add("肇庆", "http://waptianqi.2345.com/zhaoqing-59278.htm");
            PublicS.CityDicDM.Add("清远", "http://waptianqi.2345.com/qingyuan-59280.htm");
            PublicS.CityDicDM.Add("潮州", "http://waptianqi.2345.com/chaozhou-59312.htm");
            PublicS.CityDicDM.Add("揭阳", "http://waptianqi.2345.com/jieyang-59315.htm");
            PublicS.CityDicDM.Add("云浮", "http://waptianqi.2345.com/yunfu-59471.htm");



            PublicS.CityDicDM.Add("南宁", "http://waptianqi.2345.com/nanning-59431.htm");
            PublicS.CityDicDM.Add("柳州", "http://waptianqi.2345.com/liuzhou-59046.htm");
            PublicS.CityDicDM.Add("桂林", "http://waptianqi.2345.com/guilin-57957.htm");
            PublicS.CityDicDM.Add("梧州", "http://waptianqi.2345.com/wuzhou-59265.htm");
            PublicS.CityDicDM.Add("北海", "http://waptianqi.2345.com/beihai-59644.htm");
            PublicS.CityDicDM.Add("防城港", "http://waptianqi.2345.com/fangchenggang-59635.htm");
            PublicS.CityDicDM.Add("钦州", "http://waptianqi.2345.com/qinzhou-59632.htm");
            PublicS.CityDicDM.Add("贵港", "http://waptianqi.2345.com/guigang-59249.htm");
            PublicS.CityDicDM.Add("玉林", "http://waptianqi.2345.com/yulin-59453.htm");
            PublicS.CityDicDM.Add("百色", "http://waptianqi.2345.com/baise-59211.htm");
            PublicS.CityDicDM.Add("贺州", "http://waptianqi.2345.com/hezhou-59065.htm");
            PublicS.CityDicDM.Add("河池", "http://waptianqi.2345.com/hechi-59023.htm");
            PublicS.CityDicDM.Add("来宾", "http://waptianqi.2345.com/laibin-59242.htm");
            PublicS.CityDicDM.Add("崇左", "http://waptianqi.2345.com/chongzuo-59425.htm");
            PublicS.CityDicDM.Add("贵阳", "http://waptianqi.2345.com/guiyang-57816.htm");
            PublicS.CityDicDM.Add("六盘水", "http://waptianqi.2345.com/liupanshui-56693.htm");
            PublicS.CityDicDM.Add("遵义", "http://waptianqi.2345.com/zunyi-57713.htm");
            PublicS.CityDicDM.Add("安顺", "http://waptianqi.2345.com/anshun-57806.htm");
            PublicS.CityDicDM.Add("铜仁", "http://waptianqi.2345.com/tongren-57741.htm");
            PublicS.CityDicDM.Add("毕节", "http://waptianqi.2345.com/bijie-57707.htm");
            PublicS.CityDicDM.Add("黔西南", "http://waptianqi.2345.com/qianxinan-70148.htm");
            PublicS.CityDicDM.Add("黔南", "http://waptianqi.2345.com/qiannan-57827.htm");
            PublicS.CityDicDM.Add("黔东南", "http://waptianqi.2345.com/qiandongnan-57825.htm");
            PublicS.CityDicDM.Add("昆明", "http://waptianqi.2345.com/kunming-56778.htm");
            PublicS.CityDicDM.Add("曲靖", "http://waptianqi.2345.com/qujing-56783.htm");
            PublicS.CityDicDM.Add("玉溪", "http://waptianqi.2345.com/yuxi-56875.htm");
            PublicS.CityDicDM.Add("昭通", "http://waptianqi.2345.com/zhaotong-56586.htm");
            PublicS.CityDicDM.Add("楚雄", "http://waptianqi.2345.com/chuxiong-56768.htm");
            PublicS.CityDicDM.Add("河口", "http://waptianqi.2345.com/hekou-71055.htm");
            PublicS.CityDicDM.Add("丽江", "http://waptianqi.2345.com/lijiang-56651.htm");
            PublicS.CityDicDM.Add("迪庆", "http://waptianqi.2345.com/diqing-70908.htm");
            PublicS.CityDicDM.Add("文山", "http://waptianqi.2345.com/wenshan-56994.htm");
            PublicS.CityDicDM.Add("西双版纳", "http://waptianqi.2345.com/xishuangbanna-60839.htm");
            PublicS.CityDicDM.Add("思茅", "http://waptianqi.2345.com/simao-56964.htm");
            PublicS.CityDicDM.Add("景谷", "http://waptianqi.2345.com/jinggu-70871.htm");
            PublicS.CityDicDM.Add("大理", "http://waptianqi.2345.com/dali-56751.htm");
            PublicS.CityDicDM.Add("保山", "http://waptianqi.2345.com/baoshan-56748.htm");
            PublicS.CityDicDM.Add("德宏", "http://waptianqi.2345.com/dehong-71126.htm");
            PublicS.CityDicDM.Add("怒江", "http://waptianqi.2345.com/nujiang-71127.htm");
            PublicS.CityDicDM.Add("临沧", "http://waptianqi.2345.com/lincang-56951.htm");
            PublicS.CityDicDM.Add("土默特左旗", "http://waptianqi.2345.com/huhehaote-53463.htm");
            PublicS.CityDicDM.Add("包头", "http://waptianqi.2345.com/baotou-53446.htm");
            PublicS.CityDicDM.Add("呼伦贝尔", "http://waptianqi.2345.com/hulunbeier-71108.htm");
            PublicS.CityDicDM.Add("兴安盟", "http://waptianqi.2345.com/xinganmeng-60001.htm");
            PublicS.CityDicDM.Add("通辽", "http://waptianqi.2345.com/tongliao-54135.htm");
            PublicS.CityDicDM.Add("赤峰", "http://waptianqi.2345.com/chifeng-54218.htm");
            PublicS.CityDicDM.Add("锡林郭勒", "http://waptianqi.2345.com/xilinguole-60149.htm");
            PublicS.CityDicDM.Add("乌兰察布", "http://waptianqi.2345.com/wulanchabu-60150.htm");
            PublicS.CityDicDM.Add("鄂尔多斯", "http://waptianqi.2345.com/eerduosi-71109.htm");
            PublicS.CityDicDM.Add("巴彦淖尔", "http://waptianqi.2345.com/bayannaoer-60002.htm");
            PublicS.CityDicDM.Add("乌海", "http://waptianqi.2345.com/wuhai-53512.htm");
            PublicS.CityDicDM.Add("阿拉善盟", "http://waptianqi.2345.com/alashanmeng-60356.htm");


            PublicS.CityDicDM.Add("南昌", "http://waptianqi.2345.com/nanchang-58606.htm");
            PublicS.CityDicDM.Add("九江", "http://waptianqi.2345.com/jiujiang-58502.htm");
            PublicS.CityDicDM.Add("景德镇", "http://waptianqi.2345.com/jingdezhen-58527.htm");
            PublicS.CityDicDM.Add("萍乡", "http://waptianqi.2345.com/pingxiang-57786.htm");
            PublicS.CityDicDM.Add("新余", "http://waptianqi.2345.com/xinyu-57796.htm");
            PublicS.CityDicDM.Add("鹰潭", "http://waptianqi.2345.com/yingtan-58627.htm");
            PublicS.CityDicDM.Add("赣州", "http://waptianqi.2345.com/ganzhou-57993.htm");
            PublicS.CityDicDM.Add("宜春", "http://waptianqi.2345.com/yichun-57793.htm");
            PublicS.CityDicDM.Add("上饶", "http://waptianqi.2345.com/shangrao-58637.htm");
            PublicS.CityDicDM.Add("吉安", "http://waptianqi.2345.com/jian-57799.htm");
            PublicS.CityDicDM.Add("抚州", "http://waptianqi.2345.com/fuzhou-58617.htm");
            PublicS.CityDicDM.Add("武汉", "http://waptianqi.2345.com/wuhan-57494.htm");
            PublicS.CityDicDM.Add("黄石", "http://waptianqi.2345.com/huangshi-58407.htm");
            PublicS.CityDicDM.Add("襄阳", "http://waptianqi.2345.com/xiangyang-57278.htm");
            PublicS.CityDicDM.Add("荆州", "http://waptianqi.2345.com/jingzhou-57476.htm");
            PublicS.CityDicDM.Add("宜昌", "http://waptianqi.2345.com/yichang-57461.htm");
            PublicS.CityDicDM.Add("黄冈", "http://waptianqi.2345.com/huanggang-57498.htm");
            PublicS.CityDicDM.Add("鄂州", "http://waptianqi.2345.com/ezhou-57496.htm");
            PublicS.CityDicDM.Add("十堰", "http://waptianqi.2345.com/shiyan-57252.htm");
            PublicS.CityDicDM.Add("孝感", "http://waptianqi.2345.com/xiaogan-57482.htm");
            PublicS.CityDicDM.Add("荆门", "http://waptianqi.2345.com/jingmen-57377.htm");
            PublicS.CityDicDM.Add("咸宁", "http://waptianqi.2345.com/xianning-57590.htm");
            PublicS.CityDicDM.Add("随州", "http://waptianqi.2345.com/suizhou-57381.htm");
            PublicS.CityDicDM.Add("神农架", "http://waptianqi.2345.com/shennongjia-57362.htm");
            PublicS.CityDicDM.Add("恩施", "http://waptianqi.2345.com/enshi-57447.htm");
            PublicS.CityDicDM.Add("仙桃", "http://waptianqi.2345.com/xiantao-57485.htm");
            PublicS.CityDicDM.Add("天门", "http://waptianqi.2345.com/tianmen-57483.htm");
            PublicS.CityDicDM.Add("潜江", "http://waptianqi.2345.com/qianjiang-57475.htm");
            PublicS.CityDicDM.Add("成都", "http://waptianqi.2345.com/chengdu-56294.htm");
            PublicS.CityDicDM.Add("自贡", "http://waptianqi.2345.com/zigong-56396.htm");
            PublicS.CityDicDM.Add("攀枝花", "http://waptianqi.2345.com/panzhihua-56666.htm");
            PublicS.CityDicDM.Add("泸州", "http://waptianqi.2345.com/luzhou-57602.htm");
            PublicS.CityDicDM.Add("德阳", "http://waptianqi.2345.com/deyang-56198.htm");
            PublicS.CityDicDM.Add("绵阳", "http://waptianqi.2345.com/mianyang-56196.htm");
            PublicS.CityDicDM.Add("广元", "http://waptianqi.2345.com/guangyuan-57206.htm");
            PublicS.CityDicDM.Add("遂宁", "http://waptianqi.2345.com/suining-57405.htm");
            PublicS.CityDicDM.Add("内江", "http://waptianqi.2345.com/neijiang-57504.htm");
            PublicS.CityDicDM.Add("乐山", "http://waptianqi.2345.com/leshan-56386.htm");
            PublicS.CityDicDM.Add("南充", "http://waptianqi.2345.com/nanchong-57411.htm");
            PublicS.CityDicDM.Add("宜宾", "http://waptianqi.2345.com/yibin-56492.htm");
            PublicS.CityDicDM.Add("广安", "http://waptianqi.2345.com/guangan-57415.htm");
            PublicS.CityDicDM.Add("达州", "http://waptianqi.2345.com/dazhou-57328.htm");
            PublicS.CityDicDM.Add("巴中", "http://waptianqi.2345.com/bazhong-57313.htm");
            PublicS.CityDicDM.Add("雅安", "http://waptianqi.2345.com/yaan-56287.htm");
            PublicS.CityDicDM.Add("眉山", "http://waptianqi.2345.com/meishan-56391.htm");
            PublicS.CityDicDM.Add("资阳", "http://waptianqi.2345.com/ziyang-56298.htm");
            PublicS.CityDicDM.Add("阿坝", "http://waptianqi.2345.com/aba-56171.htm");
            PublicS.CityDicDM.Add("甘孜", "http://waptianqi.2345.com/ganzi-56146.htm");
            PublicS.CityDicDM.Add("凉山", "http://waptianqi.2345.com/liangshan-71118.htm");
            PublicS.CityDicDM.Add("银川", "http://waptianqi.2345.com/yinchuan-53614.htm");
            PublicS.CityDicDM.Add("石嘴山", "http://waptianqi.2345.com/shizuishan-53518.htm");
            PublicS.CityDicDM.Add("中卫", "http://waptianqi.2345.com/zhongwei-53704.htm");
            PublicS.CityDicDM.Add("固原", "http://waptianqi.2345.com/guyuan-53817.htm");
            PublicS.CityDicDM.Add("吴忠", "http://waptianqi.2345.com/wuzhong-53612.htm");
            PublicS.CityDicDM.Add("西宁", "http://waptianqi.2345.com/xining-52866.htm");
            PublicS.CityDicDM.Add("海东", "http://waptianqi.2345.com/haidong-52875.htm");
            PublicS.CityDicDM.Add("海南", "http://waptianqi.2345.com/hainan-71111.htm");
            PublicS.CityDicDM.Add("海北", "http://waptianqi.2345.com/haibei-71112.htm");
            PublicS.CityDicDM.Add("海西", "http://waptianqi.2345.com/haixi-71113.htm");
            PublicS.CityDicDM.Add("格尔木", "http://waptianqi.2345.com/geermu-71354.htm");
            PublicS.CityDicDM.Add("黄南", "http://waptianqi.2345.com/huangnan-71114.htm");
            PublicS.CityDicDM.Add("果洛", "http://waptianqi.2345.com/guoluo-70529.htm");
            PublicS.CityDicDM.Add("玉树", "http://waptianqi.2345.com/yushu-70552.htm");
            PublicS.CityDicDM.Add("济南", "http://waptianqi.2345.com/jinan-54823.htm");
            PublicS.CityDicDM.Add("青岛", "http://waptianqi.2345.com/qingdao-54857.htm");
            PublicS.CityDicDM.Add("淄博", "http://waptianqi.2345.com/zibo-54830.htm");
            PublicS.CityDicDM.Add("枣庄", "http://waptianqi.2345.com/zaozhuang-58024.htm");
            PublicS.CityDicDM.Add("东营", "http://waptianqi.2345.com/dongying-54736.htm");
            PublicS.CityDicDM.Add("烟台", "http://waptianqi.2345.com/yantai-54765.htm");
            PublicS.CityDicDM.Add("潍坊", "http://waptianqi.2345.com/weifang-54843.htm");
            PublicS.CityDicDM.Add("济宁", "http://waptianqi.2345.com/jining-54915.htm");
            PublicS.CityDicDM.Add("泰安", "http://waptianqi.2345.com/taian-54827.htm");
            PublicS.CityDicDM.Add("威海", "http://waptianqi.2345.com/weihai-54774.htm");
            PublicS.CityDicDM.Add("日照", "http://waptianqi.2345.com/rizhao-54945.htm");
            PublicS.CityDicDM.Add("莱芜", "http://waptianqi.2345.com/laiwu-54828.htm");
            PublicS.CityDicDM.Add("临沂", "http://waptianqi.2345.com/linyi-54938.htm");
            PublicS.CityDicDM.Add("德州", "http://waptianqi.2345.com/dezhou-54714.htm");
            PublicS.CityDicDM.Add("聊城", "http://waptianqi.2345.com/liaocheng-54806.htm");
            PublicS.CityDicDM.Add("滨州", "http://waptianqi.2345.com/binzhou-54734.htm");
            PublicS.CityDicDM.Add("菏泽", "http://waptianqi.2345.com/heze-54906.htm");




            PublicS.CityDicDM.Add("西安", "http://waptianqi.2345.com/xian-57036.htm");
            PublicS.CityDicDM.Add("咸阳", "http://waptianqi.2345.com/xianyang-57048.htm");
            PublicS.CityDicDM.Add("宝鸡", "http://waptianqi.2345.com/baoji-57016.htm");
            PublicS.CityDicDM.Add("渭南", "http://waptianqi.2345.com/weinan-57045.htm");
            PublicS.CityDicDM.Add("铜川", "http://waptianqi.2345.com/tongchuan-53947.htm");
            PublicS.CityDicDM.Add("商洛", "http://waptianqi.2345.com/shangluo-71031.htm");
            PublicS.CityDicDM.Add("延安", "http://waptianqi.2345.com/yanan-53845.htm");
            PublicS.CityDicDM.Add("汉中", "http://waptianqi.2345.com/hanzhong-57127.htm");
            PublicS.CityDicDM.Add("安康", "http://waptianqi.2345.com/ankang-57245.htm");
            PublicS.CityDicDM.Add("榆林", "http://waptianqi.2345.com/yulin-53646.htm");
            PublicS.CityDicDM.Add("杨凌", "http://waptianqi.2345.com/yangling-71199.htm");
            PublicS.CityDicDM.Add("太原", "http://waptianqi.2345.com/taiyuan-53772.htm");
            PublicS.CityDicDM.Add("大同", "http://waptianqi.2345.com/datong-53487.htm");
            PublicS.CityDicDM.Add("阳泉", "http://waptianqi.2345.com/yangquan-53782.htm");
            PublicS.CityDicDM.Add("长治", "http://waptianqi.2345.com/changzhi-53882.htm");
            PublicS.CityDicDM.Add("晋城", "http://waptianqi.2345.com/jincheng-53976.htm");
            PublicS.CityDicDM.Add("朔州", "http://waptianqi.2345.com/shuozhou-53578.htm");
            PublicS.CityDicDM.Add("晋中", "http://waptianqi.2345.com/jinzhong-71115.htm");
            PublicS.CityDicDM.Add("运城", "http://waptianqi.2345.com/yuncheng-53959.htm");
            PublicS.CityDicDM.Add("忻州", "http://waptianqi.2345.com/xinzhou-53674.htm");
            PublicS.CityDicDM.Add("临汾", "http://waptianqi.2345.com/linfen-53868.htm");
            PublicS.CityDicDM.Add("吕梁", "http://waptianqi.2345.com/lvliang-71037.htm");
            PublicS.CityDicDM.Add("长沙", "http://waptianqi.2345.com/changsha-57687.htm");
            PublicS.CityDicDM.Add("株洲", "http://waptianqi.2345.com/zhuzhou-57780.htm");
            PublicS.CityDicDM.Add("湘潭", "http://waptianqi.2345.com/xiangtan-57773.htm");
            PublicS.CityDicDM.Add("衡阳", "http://waptianqi.2345.com/hengyang-57872.htm");
            PublicS.CityDicDM.Add("邵阳", "http://waptianqi.2345.com/shaoyang-57766.htm");
            PublicS.CityDicDM.Add("岳阳", "http://waptianqi.2345.com/yueyang-57584.htm");
            PublicS.CityDicDM.Add("常德", "http://waptianqi.2345.com/changde-57662.htm");
            PublicS.CityDicDM.Add("张家界", "http://waptianqi.2345.com/zhangjiajie-57558.htm");
            PublicS.CityDicDM.Add("益阳", "http://waptianqi.2345.com/yiyang-57674.htm");
            PublicS.CityDicDM.Add("郴州", "http://waptianqi.2345.com/chenzhou-57972.htm");
            PublicS.CityDicDM.Add("永州", "http://waptianqi.2345.com/yongzhou-57865.htm");
            PublicS.CityDicDM.Add("怀化", "http://waptianqi.2345.com/huaihua-57749.htm");
            PublicS.CityDicDM.Add("娄底", "http://waptianqi.2345.com/loudi-57763.htm");
            PublicS.CityDicDM.Add("湘西", "http://waptianqi.2345.com/xiangxi-60011.htm");
            PublicS.CityDicDM.Add("黔阳", "http://waptianqi.2345.com/qianyang-70356.htm");
            PublicS.CityDicDM.Add("兰州", "http://waptianqi.2345.com/lanzhou-52889.htm");
            PublicS.CityDicDM.Add("金昌", "http://waptianqi.2345.com/jinchang-52675.htm");
            PublicS.CityDicDM.Add("白银", "http://waptianqi.2345.com/baiyin-52896.htm");
            PublicS.CityDicDM.Add("天水", "http://waptianqi.2345.com/tianshui-57006.htm");
            PublicS.CityDicDM.Add("武威", "http://waptianqi.2345.com/wuwei-52679.htm");
            PublicS.CityDicDM.Add("张掖", "http://waptianqi.2345.com/zhangye-52652.htm");
            PublicS.CityDicDM.Add("酒泉", "http://waptianqi.2345.com/jiuquan-52533.htm");
            PublicS.CityDicDM.Add("平凉", "http://waptianqi.2345.com/pingliang-53915.htm");
            PublicS.CityDicDM.Add("庆阳", "http://waptianqi.2345.com/qingyang-53923.htm");
            PublicS.CityDicDM.Add("定西", "http://waptianqi.2345.com/dingxi-52995.htm");
            PublicS.CityDicDM.Add("陇南", "http://waptianqi.2345.com/longnan-60472.htm");
            PublicS.CityDicDM.Add("临夏", "http://waptianqi.2345.com/linxia-52984.htm");
            PublicS.CityDicDM.Add("甘南", "http://waptianqi.2345.com/gannan-56080.htm");
            PublicS.CityDicDM.Add("嘉峪关", "http://waptianqi.2345.com/jiayuguan-71129.htm");
            PublicS.CityDicDM.Add("哈尔滨 ", "http://waptianqi.2345.com/haerbin-50953.htm");
            PublicS.CityDicDM.Add("齐齐哈尔", "http://waptianqi.2345.com/qiqihaer-50745.htm");
            PublicS.CityDicDM.Add("牡丹江", "http://waptianqi.2345.com/mudanjiang-54094.htm");
            PublicS.CityDicDM.Add("佳木斯", "http://waptianqi.2345.com/jiamusi-50873.htm");
            PublicS.CityDicDM.Add("大庆", "http://waptianqi.2345.com/daqing-50842.htm");
            PublicS.CityDicDM.Add("鸡西", "http://waptianqi.2345.com/jixi-50978.htm");
            PublicS.CityDicDM.Add("双鸭山", "http://waptianqi.2345.com/shuangyashan-50884.htm");
            PublicS.CityDicDM.Add("伊春", "http://waptianqi.2345.com/yichun-50774.htm");
            PublicS.CityDicDM.Add("七台河", "http://waptianqi.2345.com/qitaihe-50973.htm");
            PublicS.CityDicDM.Add("鹤岗", "http://waptianqi.2345.com/hegang-50775.htm");
            PublicS.CityDicDM.Add("黑河", "http://waptianqi.2345.com/heihe-50468.htm");
            PublicS.CityDicDM.Add("绥化", "http://waptianqi.2345.com/suihua-50853.htm");
            PublicS.CityDicDM.Add("大兴安岭", "http://waptianqi.2345.com/daxinganling-50442.htm");


            PublicS.CityDicDM.Add("长春", "http://waptianqi.2345.com/changchun-54161.htm");
            PublicS.CityDicDM.Add("吉林", "http://waptianqi.2345.com/jilin-54172.htm");
            PublicS.CityDicDM.Add("四平", "http://waptianqi.2345.com/siping-54157.htm");
            PublicS.CityDicDM.Add("辽源", "http://waptianqi.2345.com/liaoyuan-54260.htm");
            PublicS.CityDicDM.Add("通化", "http://waptianqi.2345.com/tonghua-54363.htm");
            PublicS.CityDicDM.Add("白山", "http://waptianqi.2345.com/baishan-54371.htm");
            PublicS.CityDicDM.Add("松原", "http://waptianqi.2345.com/songyuan-50949.htm");
            PublicS.CityDicDM.Add("白城", "http://waptianqi.2345.com/baicheng-50936.htm");
            PublicS.CityDicDM.Add("延吉", "http://waptianqi.2345.com/yanji-60361.htm");
            PublicS.CityDicDM.Add("沈阳", "http://waptianqi.2345.com/shenyang-54342.htm");
            PublicS.CityDicDM.Add("大连", "http://waptianqi.2345.com/dalian-54662.htm");
            PublicS.CityDicDM.Add("鞍山", "http://waptianqi.2345.com/anshan-54339.htm");
            PublicS.CityDicDM.Add("抚顺", "http://waptianqi.2345.com/fushun-54353.htm");
            PublicS.CityDicDM.Add("本溪", "http://waptianqi.2345.com/benxi-54346.htm");
            PublicS.CityDicDM.Add("丹东", "http://waptianqi.2345.com/dandong-54497.htm");
            PublicS.CityDicDM.Add("锦州", "http://waptianqi.2345.com/jinzhou-54337.htm");
            PublicS.CityDicDM.Add("营口", "http://waptianqi.2345.com/yingkou-54471.htm");
            PublicS.CityDicDM.Add("阜新", "http://waptianqi.2345.com/fuxin-54237.htm");
            PublicS.CityDicDM.Add("辽阳", "http://waptianqi.2345.com/liaoyang-54347.htm");
            PublicS.CityDicDM.Add("铁岭", "http://waptianqi.2345.com/tieling-54249.htm");
            PublicS.CityDicDM.Add("朝阳", "http://waptianqi.2345.com/chaoyang-54433.htm");
            PublicS.CityDicDM.Add("盘锦", "http://waptianqi.2345.com/panjin-54338.htm");
            PublicS.CityDicDM.Add("葫芦岛", "http://waptianqi.2345.com/huludao-54453.htm");
            PublicS.CityDicDM.Add(" 乌鲁木齐", "http://waptianqi.2345.com/wulumuqi-51463.htm");
            PublicS.CityDicDM.Add("克拉玛依", "http://waptianqi.2345.com/kelamayi-51243.htm");
            PublicS.CityDicDM.Add("吐鲁番", "http://waptianqi.2345.com/tulufan-51573.htm");
            PublicS.CityDicDM.Add("哈密", "http://waptianqi.2345.com/hami-52203.htm");
            PublicS.CityDicDM.Add("和田", "http://waptianqi.2345.com/hetian-51828.htm");
            PublicS.CityDicDM.Add("阿克苏", "http://waptianqi.2345.com/akesu-51628.htm");
            PublicS.CityDicDM.Add("喀什", "http://waptianqi.2345.com/kashi-51709.htm");
            PublicS.CityDicDM.Add("克州", "http://waptianqi.2345.com/kezhou-51704.htm");
            PublicS.CityDicDM.Add("巴州", "http://waptianqi.2345.com/bazhou-51656.htm");
            PublicS.CityDicDM.Add("蔡家湖", "http://waptianqi.2345.com/caijiahu-71048.htm");
            PublicS.CityDicDM.Add("博州", "http://waptianqi.2345.com/bozhou-51238.htm");
            PublicS.CityDicDM.Add("伊宁", "http://waptianqi.2345.com/yining-51431.htm");
            PublicS.CityDicDM.Add("塔城", "http://waptianqi.2345.com/tacheng-51133.htm");
            PublicS.CityDicDM.Add("阿勒泰", "http://waptianqi.2345.com/aletai-51076.htm");
            PublicS.CityDicDM.Add("石河子", "http://waptianqi.2345.com/shihezi-51356.htm");
            PublicS.CityDicDM.Add("阿拉尔", "http://waptianqi.2345.com/alaer-51730.htm");
            PublicS.CityDicDM.Add("拉萨", "http://waptianqi.2345.com/lasa-55591.htm");
            PublicS.CityDicDM.Add("日喀则", "http://waptianqi.2345.com/rikaze-55578.htm");
            PublicS.CityDicDM.Add("山南", "http://waptianqi.2345.com/shannan-55597.htm");
            PublicS.CityDicDM.Add("林芝", "http://waptianqi.2345.com/linzhi-56312.htm");
            PublicS.CityDicDM.Add("昌都", "http://waptianqi.2345.com/changdu-56137.htm");
            PublicS.CityDicDM.Add("那曲", "http://waptianqi.2345.com/naqu-70774.htm");
            PublicS.CityDicDM.Add("阿里", "http://waptianqi.2345.com/ali-55437.htm");
            PublicS.CityDicDM.Add("香港", "http://waptianqi.2345.com/xianggang-45007.htm");
            PublicS.CityDicDM.Add("高雄", "http://waptianqi.2345.com/gaoxiong-59554.htm");
            PublicS.CityDicDM.Add("台中", "http://waptianqi.2345.com/taizhong-71082.htm");
            PublicS.CityDicDM.Add("桃园", "http://waptianqi.2345.com/taoyuan-71295.htm");
            PublicS.CityDicDM.Add("澳门", "http://waptianqi.2345.com/aomen-45011.htm");
            PublicS.CityDicDM.Add("海口 ", "http://waptianqi.2345.com/haikou-59758.htm");
            PublicS.CityDicDM.Add("三亚", "http://waptianqi.2345.com/sanya-59948.htm");
            PublicS.CityDicDM.Add("琼海", "http://waptianqi.2345.com/qionghai-59855.htm");
            PublicS.CityDicDM.Add("儋州", "http://waptianqi.2345.com/danzhou-59845.htm");
            PublicS.CityDicDM.Add("文昌", "http://waptianqi.2345.com/wenchang-59856.htm");
            PublicS.CityDicDM.Add("万宁", "http://waptianqi.2345.com/wanning-59951.htm");
            PublicS.CityDicDM.Add("定安", "http://waptianqi.2345.com/dingan-59851.htm");
            PublicS.CityDicDM.Add("屯昌", "http://waptianqi.2345.com/tunchang-59854.htm");
            PublicS.CityDicDM.Add("澄迈", "http://waptianqi.2345.com/chengmai-59843.htm");
            PublicS.CityDicDM.Add("白沙", "http://waptianqi.2345.com/baisha-59848.htm");
            PublicS.CityDicDM.Add("临高", "http://waptianqi.2345.com/lingao-59842.htm");
            PublicS.CityDicDM.Add("陵水", "http://waptianqi.2345.com/lingshui-59954.htm");
            PublicS.CityDicDM.Add("琼中", "http://waptianqi.2345.com/qiongzhong-59849.htm");
            PublicS.CityDicDM.Add("保亭", "http://waptianqi.2345.com/baoting-59945.htm");
            PublicS.CityDicDM.Add("乐东", "http://waptianqi.2345.com/ledong-59940.htm");
            PublicS.CityDicDM.Add("东方", "http://waptianqi.2345.com/dongfang-59838.htm");
            PublicS.CityDicDM.Add("昌江", "http://waptianqi.2345.com/changjiang-59847.htm");
            PublicS.CityDicDM.Add("西沙", "http://waptianqi.2345.com/xisha-59981.htm");
            PublicS.CityDicDM.Add("南沙岛", "http://waptianqi.2345.com/nanshadao-70983.htm");
            PublicS.CityDicDM.Add("五指山", "http://waptianqi.2345.com/tongshi-60651.htm");
            PublicS.CityDicDM.Add("中沙", "http://waptianqi.2345.com/zhongsha-71417.htm");






        }
    }

  
}
