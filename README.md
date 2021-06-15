# GS1-128-Helper
GS1-128 编码和解码

编码使用方法:

    List<BuildItem> EncodeList = new List<BuildItem>();
    EncodeList.Add(new BuildItem() { dataFieldConten = DataFieldContent.SerialShippingContainerCode, value = "1234" });
    GS1128Encoder code128 = new GS1128Encoder(EncodeList);
    string EncodeText = code128.ToString();
    System.Drawing.Image img = code128.GetBarCodeImage();

编码借鉴轮子地址:
    https://blog.csdn.net/starfd/article/details/7190128

优化了一下生成条码的方法,更加直观

解码使用方法:

    GS1128Decoder decoder = new GS1128Decoder(textBoxEncode.Text);
	if (decoder.IsValidBarcode)
	{
	    string text = decoder.GetFieldValue(DataFieldContent.SerialShippingContainerCode); 
	}


