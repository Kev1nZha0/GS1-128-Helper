using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1_128_Helper
{
	/// <summary>
	/// Class to parse GS1-128 (EAN128) BarCodes
	/// <para>使用方法:</para> 
	/// <para>GS1128Decoder decoder = new GS1128Decoder(textBoxEncode.Text);</para> 
	/// <para>       if (decoder.IsValidBarcode)</para> 
	/// <para>       {</para> 
	/// <para>           string text = decoder.GetFieldValue(DataFieldContent.SerialShippingContainerCode);</para> 
	/// <para>       }</para> 
	/// </summary>

	public class GS1128Decoder
	{
		/// <summary>Gets or sets the ASCII-Code for the sign to be used as split char.</summary>
		/// <value>The ASCII-Code for sign used as the split char.</value>
		public int SplitChar
		{
			get
			{
				return this._splitChar;
			}
			set
			{
				this._splitChar = value;
				this.runCodeAnalyze();
			}
		}

		/// <summary>Gets or sets the raw barcode data.</summary>
		/// <value>The raw barcode data.</value>
		/// <remarks>Just the raw string that contains the data from the Barcode. If you set it, the Analyseer is trigerred...</remarks>
		public string RawBarcodeData
		{
			get
			{
				return this._rawBarcodeData;
			}
			set
			{
				this._rawBarcodeData = value;
				this.runCodeAnalyze();
			}
		}

		/// <summary>Gets a list of the detected fields in the code.</summary>
		public List<DataFieldContent> FieldsInCode
		{
			get
			{
				return this._fieldsInCode;
			}
		}

		/// <summary>Gets a value indicating whether this instance is valid barcode.</summary>
		/// <value><c>true</c> if this instance contains valid barcode; otherwise, <c>false</c>.</value>
		public bool IsValidBarcode
		{
			get
			{
				return this._codeIsValid;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.GS1_128" /> class.</summary>
		public GS1128Decoder()
		{
			this.initClass(string.Empty, 29);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.GS1_128" /> class.</summary>
		/// <param name="rawInitialBarcodeData">The raw barcode data.</param>
		public GS1128Decoder(string rawInitialBarcodeData)
		{
			this.initClass(rawInitialBarcodeData, 29);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.GS1_128" /> class.</summary>
		/// <param name="rawInitialBarcodeData">The raw barcode data.</param>
		/// <param name="initialSplitChar">The ASCII-Code for sign used as the split char</param>
		public GS1128Decoder(string rawInitialBarcodeData, int initialSplitChar)
		{
			this.initClass(rawInitialBarcodeData, initialSplitChar);
		}

		/// <summary>Gets the value of the requested DataField.</summary>
		/// <param name="applicationIdentifier">The application identifier of the requested field.</param>
		/// <returns>the field-content or an empty string</returns>
		public string GetFieldValue(string applicationIdentifier)
		{
			return this.getFieldValue(applicationIdentifier);
		}

		/// <summary>Gets the value of the requested DataField.</summary>
		/// <param name="DataItem">The type of the requested field.</param>
		/// <returns>the field-content or an empty string</returns>
		public string GetFieldValue(DataFieldContent DataItem)
		{
			int num = (int)DataItem;
			string tmpAppId = num.ToString("#00");
			return this.getFieldValue(tmpAppId);
		}

		/// <summary>Inits the class (internal Constructor Code).</summary>
		/// <param name="rawInitialBarcodeData">The raw initial barcode data.</param>
		/// <param name="initialSplitChar">The initial split char.</param>
		private void initClass(string rawInitialBarcodeData, int initialSplitChar)
		{
			this.initFieldList();
			this._splitChar = initialSplitChar;
			this._rawBarcodeData = rawInitialBarcodeData;
			this.runCodeAnalyze();
		}

		/// <summary>Inits the field list with DataItems that can appear in GS1-128.</summary>
		private void initFieldList()
		{
			this._availableFieldsList = new List<DataField>();
			this._availableFieldsList.Add(new DataField(DataFieldContent.SerialShippingContainerCode, 18));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlobalTradeItemNumber, 14));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GtinOfContainedTradeItems, 14));
			this._availableFieldsList.Add(new DataField(DataFieldContent.BatchOrLotNumber, 0, 20));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductionDate, 6, SpecialAction.FillDayWithZeroIfEmpty));
			this._availableFieldsList.Add(new DataField(DataFieldContent.DueDate, 6, SpecialAction.FillDayWithZeroIfEmpty));
			this._availableFieldsList.Add(new DataField(DataFieldContent.PackagingDate, 6, SpecialAction.FillDayWithZeroIfEmpty));
			this._availableFieldsList.Add(new DataField(DataFieldContent.SellByDate, 6, SpecialAction.FillDayWithZeroIfEmpty));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ExpirationDate, 6, SpecialAction.FillDayWithZeroIfEmpty));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVariant, 2));
			this._availableFieldsList.Add(new DataField(DataFieldContent.SerialNumber, 0, 20));
			this._availableFieldsList.Add(new DataField(DataFieldContent.SecondaryDataFields, 0, 29));
			this._availableFieldsList.Add(new DataField(DataFieldContent.LotNumber, 0, 19));
			this._availableFieldsList.Add(new DataField(DataFieldContent.AdditionalProductIdentification, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CustomerPartNumber, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.MadeToOrderVariationNumber, 0, 6));
			this._availableFieldsList.Add(new DataField(DataFieldContent.SecondarySerialNumber, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ReferenceToSourceEntity, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlobalDocumentTypeIdentifier, 13, 17));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlnExtensionComponent, 0, 20));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountOfItems, 0, 8));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductNetWeight_Kg, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductLength_Meters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductWidth_Meters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductDepth_Meters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductArea_SquareMeters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductNetVolume_Liters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductNetVolume_CubicMeters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductNetWeight_Pounds, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductLength_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductLength_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductLength_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductWidth_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductWidth_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductWidth_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductDepth_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductDepth_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductDepth_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossWeight_Kg, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerLength_Meters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerWidth_Meters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerDepth_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerArea_SquareMeters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_Liters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_CubicMeters, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossWeight_Pounds, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerLength_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerLength_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerLength_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerWidth_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerWidth_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerWidth_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerDepth_Inches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerDepth_Feet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerDepth_Yards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductArea_SquareInches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductArea_SquareFeet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductArea_SquareYards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerArea_SquareInches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerArea_SquareFeet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerArea_SquareYards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.NetWeight_TroyOunces, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.NetWeightVolume_Ounces, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVolume_Quarts, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVolume_Gallons, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_Quarts, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_UsGallons, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVolume_CubicInches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVolume_CubicFeet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProductVolume_CubicYards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_CubicInches, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_CubicFeet, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ContainerGrossVolume_CubicYards, 6, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.NumberOfUnitsContained, 0, 8));
			this._availableFieldsList.Add(new DataField(DataFieldContent.AmountPayable_LocalCurrency, 0, 15, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.AmountPayable_WithIsoCurrency, 3, 18, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.AmountPayablePerItem_LocalCurrency, 0, 15, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.AmountPayablePerItem_WithIsoCurrency, 3, 18, SpecialAction.FourthDigitPointPosition));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CustomerPurchaseOrderNumber, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ConsignmentNumber, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.BillOfLadingNumber, 17));
			this._availableFieldsList.Add(new DataField(DataFieldContent.RoutingCode, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ShipOrDeliverTo_GlobalLocationNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.BillOrInvoiceTo_GlobalLocationNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.PurchaseFrom_GlobalLocationNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ShipDeliverOrForwardTo_GlobalLocationNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.IdentificationPhysicalLocation_GlobalLocationNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ShipOrDeliverToPostalCode_SinglePostalAuthority, 0, 20));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ShipOrDeliverToPostalCode_WithIsoCountryCode, 3, 15, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountryOfOrigin_IsoCode, 3, 3));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountryOfProcessing, 3, 15, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountryOfProcessing, 3));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountryOfDisassembly, 3));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CountryOfFullProcessChain, 3));
			this._availableFieldsList.Add(new DataField(DataFieldContent.NatoStockNumber, 13));
			this._availableFieldsList.Add(new DataField(DataFieldContent.UnEceMeatCarcassesAndCutsClassification, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ExpirationDateAndTime, 10));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ActivePotency, 0, 4));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode0, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode1, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode2, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode3, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode4, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode5, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode6, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode7, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode8, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.ProcessorApprovalWithIsoCountryCode9, 3, 30, SpecialAction.FirstThreeDigitsCountryCode));
			this._availableFieldsList.Add(new DataField(DataFieldContent.RollProducts, 14));
			this._availableFieldsList.Add(new DataField(DataFieldContent.MobilePhoneIdentifier, 0, 20));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlobalReturnableAssetId, 14, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlobalIndividualAssetId, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.PricePerUnitOfMeasure, 6));
			this._availableFieldsList.Add(new DataField(DataFieldContent.IdentificationOfComponentsOfItem, 18));
			this._availableFieldsList.Add(new DataField(DataFieldContent.InternationalBankAccountNumber, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.DateTimeOfProduction, 8, 12));
			this._availableFieldsList.Add(new DataField(DataFieldContent.GlobalServiceRelationNumber, 18));
			this._availableFieldsList.Add(new DataField(DataFieldContent.PaymentSlipReferenceNumber, 0, 25));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CouponExtendedCode_NumberSystemAndOffer, 6));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CouponExtendedCode_NumberSystemOfferAndEndOfOffer, 10));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CouponExtendedCode_NumberSystemPrecededBy0, 2));
			this._availableFieldsList.Add(new DataField(DataFieldContent.CouponCodeId, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.MutuallyAgreedBetweenTradingPartners, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_MaterialPackagingOrComponents1, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_MaterialPackagingOrComponents2, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_Vendor1, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_Vendor2, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_Shipping1, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_Shipping2, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_WholesaleOrRetail1, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_WholesaleOrRetail2, 0, 30));
			this._availableFieldsList.Add(new DataField(DataFieldContent.Internal_AgreedTexts, 0, 30));
		}

		/// <summary>Performs the Code to split and verify a Code.</summary>
		private void runCodeAnalyze()
		{
			string tmpString = ((char)this._splitChar).ToString();
			bool flag = this._rawBarcodeData.Contains(tmpString);
			if (flag)
			{
				this._codeFields = this._rawBarcodeData.Split(new char[]
				{
					(char)this._splitChar
				});
			}
			else
			{
				this._codeFields = this._rawBarcodeData.Replace(")", "").Split(new char[]
				{
					'('
				});
			}
			this._fieldsInCode = new List<DataFieldContent>();
			foreach (string codeItem in this._codeFields)
			{
				foreach (DataField field in this._availableFieldsList)
				{
					bool flag2 = codeItem.StartsWith(field.ApplicationIdentifier);
					if (flag2)
					{
						this._fieldsInCode.Add(field.DataFieldType);
						break;
					}
				}
			}
			bool flag3 = this._fieldsInCode.Count > 0;
			if (flag3)
			{
				this._codeIsValid = true;
			}
			else
			{
				this._codeIsValid = false;
			}
		}

		/// <summary>Gets the value of the requested DataField.</summary>
		/// <param name="applicationIdentifier">The application identifier of the requested field.</param>
		/// <returns>the field-content or an empty string</returns>
		private string getFieldValue(string applicationIdentifier)
		{
			DataField tmpFieldDefinition = new DataField();
			foreach (DataField field in this._availableFieldsList)
			{
				bool flag = field.ApplicationIdentifier == applicationIdentifier;
				if (flag)
				{
					tmpFieldDefinition = field;
					break;
				}
			}
			bool flag2 = tmpFieldDefinition.DataFieldType == DataFieldContent.undefined;
			string empty;
			if (flag2)
			{
				empty = string.Empty;
			}
			else
			{
				foreach (string codeItem in this._codeFields)
				{
					bool flag3 = codeItem.StartsWith(applicationIdentifier);
					if (flag3)
					{
						return this.getFieldContent(tmpFieldDefinition, codeItem);
					}
				}
				empty = string.Empty;
			}
			return empty;
		}

		/// <summary>Gets the parsed content of the field.</summary>
		/// <param name="Definition">The content definition.</param>
		/// <param name="Content">The raw content.</param>
		/// <returns>The parsed content</returns>
		private string getFieldContent(DataField Definition, string Content)
		{
			string result = string.Empty;
			SpecialAction itemAction = Definition.ItemAction;
			if (itemAction != SpecialAction.FillDayWithZeroIfEmpty)
			{
				if (itemAction != SpecialAction.FourthDigitPointPosition)
				{
					if (itemAction != SpecialAction.FirstThreeDigitsCountryCode)
					{
					}
					result = Content.Substring(Definition.ApplicationIdentifier.Length);
				}
				else
				{
					int tmpPosition = 0;
					try
					{
						tmpPosition = int.Parse(Content.Substring(3, 1));
						bool flag = tmpPosition >= Definition.MaxLength;
						if (flag)
						{
							tmpPosition = 0;
						}
					}
					catch
					{
						return result;
					}
					bool flag2 = tmpPosition == 0;
					if (flag2)
					{
						result = Content.Substring(4);
					}
					else
					{
						result = Content.Substring(4, tmpPosition) + "." + Content.Substring(4 + tmpPosition);
					}
				}
			}
			else
			{
				result = Content.Substring(Definition.ApplicationIdentifier.Length);
				bool flag3 = result.Length == 4;
				if (flag3)
				{
					result += "00";
				}
			}
			return result;
		}

		private List<DataField> _availableFieldsList;

		private List<DataFieldContent> _fieldsInCode;

		private int _splitChar;

		private string _rawBarcodeData;

		private string[] _codeFields;

		private bool _codeIsValid = false;
	}
}
