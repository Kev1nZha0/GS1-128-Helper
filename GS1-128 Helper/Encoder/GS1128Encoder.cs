using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1_128_Helper
{
    /// <summary>
    /// GS1-128编码
    /// <para>使用方法:</para> 
    /// <para>           List<BuildItem> EncodeList = new List<BuildItem>();</para>
    /// <para>           EncodeList.Add(new BuildItem() { dataFieldConten = DataFieldContent.SerialShippingContainerCode, value = "1234" });</para>
    /// <para>           GS1128Encoder code128 = new GS1128Encoder(EncodeList);</para> 
    /// <para>           code128.DataDisplay = true;</para> 
    /// <para>           string EncodeText = code128.ToString();</para> 
    /// <para>           System.Drawing.Image img = code128.GetBarCodeImage();</para> 
    ///  </summary>
    public class GS1128Encoder : IBarCode
    {
        protected string _encodedData;//编码数据
        //protected string _GS1128Builder;//原始数据
        protected List<BuildItem> _GS1128Builder;

        protected string _presentationData = null;//在条形码下面显示给人看的数据，如果为空，则取原始数据
        protected bool _dataDisplay = true;//是否显示字体

        protected byte _barCellWidth = 1;//模块单位宽度，单位Pix 默认1

        protected bool _showBlank = true;//是否显示左右空白
        protected byte _horizontalMulriple = 10;//水平左右空白对应模块的倍数
        protected byte _verticalMulriple = 8;//垂直上下空白对应模块的倍数


        protected byte _barHeight = 32;//条码高度，单位Pix 默认32

        protected Color _backColor = Color.White;//条码背景色
        protected Color _barColor = Color.Black;//条码颜色

        protected byte _fontPadding;//字体与条形码的空间间隔
        protected float _emSize;//字体大小
        protected FontFamily _fontFamily;//字体样式
        protected FontStyle _fontStyle;//字体样式
        protected StringAlignment _textAlignment;//字体布局位置
        protected Color _fontColor;//字体颜色
        protected bool _fontPositionOnBottom;//字体位置是否是底部，如果不是，则在顶部

        /// <summary>
        /// 当前条形码种类
        /// </summary>
        public string BarCodeType
        {
            get
            {
                return System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            }
        }
        /// <summary>
        /// 条码展示数据
        /// </summary>
        public string PresentationData
        {
            get { return this._presentationData; }
        }
        /// <summary>
        /// 条形码对应的编码数据
        /// </summary>
        public string EncodedData
        {
            get { return this._encodedData; }
        }
        /// <summary>
        /// 是否在条形码上显示展示数据
        /// </summary>
        public bool DataDisplay
        {
            get { return this._dataDisplay; }
            set { this._dataDisplay = value; }
        }
        /// <summary>
        /// 条码高度，必须至少是条码宽度的0.15倍或6.35mm，两者取大者
        /// 默认按照实际为32,单位mm
        /// </summary>
        public byte BarHeight
        {
            get { return this._barHeight; }
            set
            {
                this._barHeight = value;
            }
        }
        /// <summary>
        /// 模块宽度  单位：pix
        /// 默认宽度 1pix
        /// </summary>
        public byte BarCellWidth
        {
            get { return this._barCellWidth; }
            set
            {
                if (value == 0)
                {
                    this._barCellWidth = 1;
                }
                else
                {
                    this._barCellWidth = value;
                }
            }
        }
        /// <summary>
        /// 是否显示左右空白，默认标准显示
        /// </summary>
        public bool ShowBlank
        {
            get { return this._showBlank; }
            set
            {
                this._showBlank = value;
            }
        }
        /// <summary>
        /// 左右空白对应模块宽度的倍数,国际标准最小为10，如果低于10，则取10
        /// </summary>
        public byte HorizontalMulriple
        {
            get { return this._horizontalMulriple; }
            set
            {
                if (value < 10)
                {
                    this._horizontalMulriple = 10;
                }
                else
                {
                    this._horizontalMulriple = value;
                }
            }
        }
        /// <summary>
        /// 水平空白pix
        /// </summary>
        public int HorizontalMargin
        {
            get
            {
                if (this.ShowBlank)
                {
                    return this._barCellWidth * this._horizontalMulriple;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 垂直上下空白对应模块的倍数
        /// </summary>
        public byte VerticalMulriple
        {
            get { return this._verticalMulriple; }
            set
            {
                this._verticalMulriple = value;
            }
        }
        /// <summary>
        /// 垂直空白
        /// </summary>
        public int VerticalMargin
        {
            get
            {
                if (this.ShowBlank)
                {
                    return this._barCellWidth * this._verticalMulriple;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 字体与条形码的空间间隔,单位Pix
        /// </summary>
        public byte FontPadding
        {
            get { return this._fontPadding; }
            set
            {
                this._fontPadding = value;
            }
        }
        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize
        {
            get { return this._emSize; }
            set { this._emSize = value; }
        }
        /// <summary>
        /// 字体样式
        /// </summary>
        public FontFamily FontFamily
        {
            get { return this._fontFamily; }
            set { this._fontFamily = value; }
        }
        /// <summary>
        /// 字体样式
        /// </summary>
        public FontStyle FontStyle
        {
            get { return this._fontStyle; }
            set { this._fontStyle = value; }
        }
        /// <summary>
        /// 字体布局位置
        /// </summary>
        public StringAlignment TextAlignment
        {
            get { return this._textAlignment; }
            set { this._textAlignment = value; }
        }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color FontColor
        {
            get { return this._fontColor; }
            set { this._fontColor = value; }
        }

        public GS1128Encoder(List<BuildItem> rawData, bool IsDataDisplay = true)
        {
            this._GS1128Builder = rawData;
            if (this._GS1128Builder == null || this._GS1128Builder.Count == 0)
            {
                throw new Exception("无法生成空条形码");
            }
            if (!this.RawDataCheck())
            {
                throw new Exception(rawData + " 不符合 " + this.BarCodeType + " 标准");
            }
            this._encodedData = this.GetEncodedData();

            //是否加入检验可编码最大字符数超出标准48，貌似只在EAN128中有规定必须不超出48

            this.FontInit();

            //初始化一些画图参数
            this.BarCellWidth = (byte)2;
            this.HorizontalMulriple = (byte)6;
            this.VerticalMulriple = (byte)3;
            this.ShowBlank = false;
            this.DataDisplay = IsDataDisplay;
            this.FontSize = 12;
            this.TextAlignment = System.Drawing.StringAlignment.Center;
        }
        /// <summary>
        /// 字体初始化
        /// </summary>
        private void FontInit()
        {
            this._fontPadding = 4;
            this._emSize = 12;
            this._fontFamily = new FontFamily("Times New Roman");
            this._fontStyle = FontStyle.Regular;
            this._textAlignment = StringAlignment.Center;
            this._fontColor = Color.Black;
        }

        protected int GetBarCodePhyWidth()
        {
            //在212222这种BS单元下，要计算bsGroup对应模块宽度的倍率
            //应该要将总长度减去1（因为Stop对应长度为7），然后结果乘以11再除以6，与左右空白相加后再加上2（Stop比正常的BS多出2个模块组）
            int bsNum = (this._encodedData.Length - 1) * 11 / 6 + 2;//+ (this._showBlank ? this._blankMulriple * 2 : 0)
            return bsNum * this._barCellWidth;
        }


        private List<string> _aiList = new List<string>();//rawData分割后符合商品应用标识规范的字符串集
        /// <summary>
        /// 数据输入正确性验证
        /// </summary>
        /// <returns></returns>
        protected bool RawDataCheck()
        {
            this._presentationData = string.Empty;
            foreach (BuildItem ts in this._GS1128Builder)
            {
                string tempStr = (int)ts.dataFieldConten + ts.value;
                //展示数据加上括号
                this._presentationData += string.Format("({0}){1}", (int)ts.dataFieldConten, ts.value);

                this._aiList.Add(tempStr);
            }

            //是否要将_aiList进行排序，将预定长的放在前面以符合　先定长后变长　原则
            //如果修改，则需将展示数据部分重新处理

            return true;
        }

        /// <summary>
        /// 获取当前Data对应的编码数据(条空组合)
        /// </summary>
        /// <returns></returns>
        protected string GetEncodedData()
        {
            StringBuilder tempBuilder = new StringBuilder();
            CharacterSet nowCharacterSet;
            //校验字符
            int checkNum = Code128.GetStartIndex(this._aiList[0], out nowCharacterSet);
            tempBuilder.Append(Code128.BSList[checkNum]);//加上起始符
            tempBuilder.Append(Code128.BSList[Code128.FNC1]);//加上第一个FNC1表示当前是GS1-128
            checkNum += Code128.FNC1;
            int nowWeight = 2;//当前权值

            for (int i = 0; i < this._aiList.Count; i++)
            {
                string tempStr = this._aiList[i];
                int nowIndex = 0;

                Code128.GetEncodedData(tempStr, tempBuilder, ref nowCharacterSet, ref nowIndex, ref nowWeight, ref checkNum);

                if (!AI.IsPredefinedAI(tempStr) && i != this._aiList.Count - 1)
                {
                    //非预定长标识符后面加上FNC1，此时FNC1作为分隔符存在
                    Code128.EncodingCommon(tempBuilder, Code128.FNC1, ref nowWeight, ref checkNum);
                }
            }

            checkNum %= 103;
            tempBuilder.Append(Code128.BSList[checkNum]);//加上校验符
            tempBuilder.Append(Code128.BSList[Code128.Stop]);//加上结束符
            return tempBuilder.ToString();
        }

        /// <summary>
        /// 获取完整的条形码
        /// </summary>
        /// <returns></returns>
        public Image GetBarCodeImage()
        {
            Image barImage = this.GetBarOnlyImage();

            int width = barImage.Width;
            int height = barImage.Height;

            width += this.HorizontalMargin * 2;
            height += this.VerticalMargin * 2;

            if (this._dataDisplay)
            {
                height += this._fontPadding + (int)this._emSize;
            }

            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(this._backColor);

            g.DrawImage(barImage, this.HorizontalMargin, this.VerticalMargin, barImage.Width, barImage.Height);

            if (this._dataDisplay)
            {
                Font drawFont = new Font(this._fontFamily, this._emSize, this._fontStyle, GraphicsUnit.Pixel);
                Brush drawBrush = new SolidBrush(this._fontColor);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = this._textAlignment;
                RectangleF reF = new RectangleF(0, barImage.Height + this.VerticalMargin + this._fontPadding, width, this._emSize);
                g.DrawString(this.PresentationData, drawFont, drawBrush, reF, drawFormat);

                drawFont.Dispose();
                drawBrush.Dispose();
                drawFormat.Dispose();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //结束绘制
            g.Dispose();
            image.Dispose();
            return Image.FromStream(ms);
        }

        /// <summary>
        /// 获取完整的条形码
        /// </summary>
        /// <returns></returns>
        public byte[] GetBarCodeImageByte()
        {
            Image barImage = this.GetBarOnlyImage();

            int width = barImage.Width;
            int height = barImage.Height;

            width += this.HorizontalMargin * 2;
            height += this.VerticalMargin * 2;

            if (this._dataDisplay)
            {
                height += this._fontPadding + (int)this._emSize;
            }

            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(this._backColor);

            g.DrawImage(barImage, this.HorizontalMargin, this.VerticalMargin, barImage.Width, barImage.Height);

            if (this._dataDisplay)
            {
                Font drawFont = new Font(this._fontFamily, this._emSize, this._fontStyle, GraphicsUnit.Pixel);
                Brush drawBrush = new SolidBrush(this._fontColor);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = this._textAlignment;
                RectangleF reF = new RectangleF(0, barImage.Height + this.VerticalMargin + this._fontPadding, width, this._emSize);
                g.DrawString(this.PresentationData, drawFont, drawBrush, reF, drawFormat);

                drawFont.Dispose();
                drawBrush.Dispose();
                drawFormat.Dispose();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //结束绘制
            g.Dispose();
            image.Dispose();
            return ms.ToArray();
        }
        /// <summary>
        /// 获取仅包含条形码的图像
        /// </summary>
        /// <returns></returns>
        private Image GetBarOnlyImage()
        {
            int width = (int)this.GetBarCodePhyWidth();
            Bitmap image = new Bitmap(width, this._barHeight);
            int ptr = 0;
            for (int i = 0; i < this._encodedData.Length; i++)
            {
                int w = (int)char.GetNumericValue(this._encodedData[i]);
                w *= this._barCellWidth;
                Color c = i % 2 == 0 ? this._barColor : this._backColor;
                for (int j = 0; j < w; j++)
                {
                    for (int h = 0; h < this._barHeight; h++)
                    {
                        image.SetPixel(ptr, h, c);
                    }
                    ptr++;
                }
            }
            return image;
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            for (int n = 0; n < this._GS1128Builder.Count; n++)
            {
                BuildItem bi = this._GS1128Builder[n];
                string ai = ((int)bi.dataFieldConten).ToString();
                temp.Append(ai);
                temp.Append(bi.value);
                if (!AI.IsPredefinedAI(ai) && n < (this._GS1128Builder.Count - 1))
                {
                    //非预定长标识符后面加上FNC1，此时FNC1作为分隔符存在
                    string FNC1 = ((char)29).ToString();
                    temp.Append(FNC1);
                }
            }
            return temp.ToString();
        }
    }
}
