using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1_128_Helper
{
	/// <summary>Definition of content-types in code</summary>
	public enum DataFieldContent
	{
		/// <summary>
		/// undefined Data
		/// </summary>
		undefined = -1,
		/// <summary>
		/// Serial Shipping Container Code (SSCC)
		/// </summary>
		SerialShippingContainerCode,
		/// <summary>
		/// Global Trade Item Number (GTIN)
		/// </summary>
		GlobalTradeItemNumber,
		/// <summary>
		/// GTIN of Contained Trade Items
		/// </summary>
		GtinOfContainedTradeItems,
		/// <summary>
		/// Batch/Lot Number
		/// </summary>
		BatchOrLotNumber = 10,
		/// <summary>
		/// Production Date
		/// </summary>
		ProductionDate,
		/// <summary>
		/// DueDate
		/// </summary>
		DueDate,
		/// <summary>
		/// Packaging Date
		/// </summary>
		PackagingDate,
		/// <summary>
		/// Sell by Date (Quality Control)
		/// </summary>
		SellByDate = 15,
		/// <summary>
		/// Expiration Date
		/// </summary>
		ExpirationDate = 17,
		/// <summary>
		/// Product Variant
		/// </summary>
		ProductVariant = 20,
		/// <summary>
		/// Serial Number
		/// </summary>
		SerialNumber,
		/// <summary>
		/// Secondary Data Fields
		/// </summary>
		SecondaryDataFields,
		/// <summary>
		/// Lot number n
		/// </summary>
		LotNumber,
		/// <summary>
		/// Additional Product Identification
		/// </summary>
		AdditionalProductIdentification = 240,
		/// <summary>
		/// Customer Part Number
		/// </summary>
		CustomerPartNumber,
		/// <summary>
		/// Made-to-Order Variation Number
		/// </summary>
		MadeToOrderVariationNumber,
		/// <summary>
		/// Secondary Serial Number
		/// </summary>
		SecondarySerialNumber = 250,
		/// <summary>
		/// Reference to Source Entity
		/// </summary>
		ReferenceToSourceEntity,
		/// <summary>
		/// Global Document Type Identifier
		/// </summary>
		GlobalDocumentTypeIdentifier = 253,
		/// <summary>
		/// GLN Extension Component
		/// </summary>
		GlnExtensionComponent,
		/// <summary>
		/// Count of items
		/// </summary>
		CountOfItems = 30,
		/// <summary>
		/// Product Net Weight in kg
		/// </summary>
		ProductNetWeight_Kg = 310,
		/// <summary>
		/// Product Length/1st Dimension, in meters
		/// </summary>
		ProductLength_Meters,
		/// <summary>
		/// Product Width/Diameter/2nd Dimension, in meters
		/// </summary>
		ProductWidth_Meters,
		/// <summary>
		/// Product Depth/Thickness/Height/3rd Dimension, in meters
		/// </summary>
		ProductDepth_Meters,
		/// <summary>
		/// Product Area, in square meters
		/// </summary>
		ProductArea_SquareMeters,
		/// <summary>
		/// Product Net Volume, in liters
		/// </summary>
		ProductNetVolume_Liters,
		/// <summary>
		/// Product Net Volume, in cubic meters
		/// </summary>
		ProductNetVolume_CubicMeters,
		/// <summary>
		/// Product Net Weight, in pounds
		/// </summary>
		ProductNetWeight_Pounds = 320,
		/// <summary>
		/// Product Length/1st Dimension, in inches
		/// </summary>
		ProductLength_Inches,
		/// <summary>
		/// Product Length/1st Dimension, in feet
		/// </summary>
		ProductLength_Feet,
		/// <summary>
		/// Product Length/1st Dimension, in yards
		/// </summary>
		ProductLength_Yards,
		/// <summary>
		/// Product Width/Diameter/2nd Dimension, in inches
		/// </summary>
		ProductWidth_Inches,
		/// <summary>
		/// Product Width/Diameter/2nd Dimension, in feet
		/// </summary>
		ProductWidth_Feet,
		/// <summary>
		/// Product Width/Diameter/2nd Dimension, in yards
		/// </summary>
		ProductWidth_Yards,
		/// <summary>
		/// Product Depth/Thickness/Height/3rd Dimension, in inches
		/// </summary>
		ProductDepth_Inches,
		/// <summary>
		/// Product Depth/Thickness/Height/3rd Dimension, in feet
		/// </summary>
		ProductDepth_Feet,
		/// <summary>
		/// Product Depth/Thickness/3rd Dimension, in yards
		/// </summary>
		ProductDepth_Yards,
		/// <summary>
		/// Container Gross Weight (kg)
		/// </summary>
		ContainerGrossWeight_Kg,
		/// <summary>
		/// Container Length/1st Dimension (Meters)
		/// </summary>
		ContainerLength_Meters,
		/// <summary>
		/// Container Width/Diameter/2nd Dimension (Meters)
		/// </summary>
		ContainerWidth_Meters,
		/// <summary>
		/// Container Depth/Thickness/3rd Dimension (Meters)
		/// </summary>
		ContainerDepth_Meters,
		/// <summary>
		/// Container Area (Square Meters)
		/// </summary>
		ContainerArea_SquareMeters,
		/// <summary>
		/// Container Gross Volume (Liters)
		/// </summary>
		ContainerGrossVolume_Liters,
		/// <summary>
		/// Container Gross Volume (Cubic Meters)
		/// </summary>
		ContainerGrossVolume_CubicMeters,
		/// <summary>
		/// Container Gross Weight (Pounds)
		/// </summary>
		ContainerGrossWeight_Pounds = 340,
		/// <summary>
		/// Container Length/1st Dimension, in inches
		/// </summary>
		ContainerLength_Inches,
		/// <summary>
		/// Container Length/1st Dimension, in feet
		/// </summary>
		ContainerLength_Feet,
		/// <summary>
		/// Container Length/1st Dimension in, in yards
		/// </summary>
		ContainerLength_Yards,
		/// <summary>
		/// Container Width/Diameter/2nd Dimension, in inches
		/// </summary>
		ContainerWidth_Inches,
		/// <summary>
		/// Container Width/Diameter/2nd Dimension, in feet
		/// </summary>
		ContainerWidth_Feet,
		/// <summary>
		/// Container Width/Diameter/2nd Dimension, in yards
		/// </summary>
		ContainerWidth_Yards,
		/// <summary>
		/// Container Depth/Thickness/Height/3rd Dimension, in inches
		/// </summary>
		ContainerDepth_Inches,
		/// <summary>
		/// Container Depth/Thickness/Height/3rd Dimension, in feet
		/// </summary>
		ContainerDepth_Feet,
		/// <summary>
		/// Container Depth/Thickness/Height/3rd Dimension, in yards
		/// </summary>
		ContainerDepth_Yards,
		/// <summary>
		/// Product Area (Square Inches)
		/// </summary>
		ProductArea_SquareInches,
		/// <summary>
		/// Product Area (Square Feet)
		/// </summary>
		ProductArea_SquareFeet,
		/// <summary>
		/// Product Area (Square Yards)
		/// </summary>
		ProductArea_SquareYards,
		/// <summary>
		/// Container Area (Square Inches)
		/// </summary>
		ContainerArea_SquareInches,
		/// <summary>
		/// Container Area (Square Feet)
		/// </summary>
		ContainerArea_SquareFeet,
		/// <summary>
		/// Container Area (Square Yards)
		/// </summary>
		ContainerArea_SquareYards,
		/// <summary>
		/// Net Weight (Troy Ounces)
		/// </summary>
		NetWeight_TroyOunces,
		/// <summary>
		/// Net Weight/Volume (Ounces)
		/// </summary>
		NetWeightVolume_Ounces,
		/// <summary>
		/// Product Volume (Quarts)
		/// </summary>
		ProductVolume_Quarts = 360,
		/// <summary>
		/// Product Volume (Gallons)
		/// </summary>
		ProductVolume_Gallons,
		/// <summary>
		/// Container Gross Volume (Quarts)
		/// </summary>
		ContainerGrossVolume_Quarts,
		/// <summary>
		/// Container Gross Volume (U.S. Gallons)
		/// </summary>
		ContainerGrossVolume_UsGallons,
		/// <summary>
		/// Product Volume (Cubic Inches)
		/// </summary>
		ProductVolume_CubicInches,
		/// <summary>
		/// Product Volume (Cubic Feet)
		/// </summary>
		ProductVolume_CubicFeet,
		/// <summary>
		/// Product Volume (Cubic Yards)
		/// </summary>
		ProductVolume_CubicYards,
		/// <summary>
		/// Container Gross Volume (Cubic Inches)
		/// </summary>
		ContainerGrossVolume_CubicInches,
		/// <summary>
		/// Container Gross Volume (Cubic Feet)
		/// </summary>
		ContainerGrossVolume_CubicFeet,
		/// <summary>
		/// Container Gross Volume (Cubic Yards)
		/// </summary>
		ContainerGrossVolume_CubicYards,
		/// <summary>
		/// Number of Units Contained
		/// </summary>
		NumberOfUnitsContained = 37,
		/// <summary>
		/// Amount payable (local currency)
		/// </summary>
		AmountPayable_LocalCurrency = 390,
		/// <summary>
		/// Amount payable (with ISO currency code)
		/// </summary>
		AmountPayable_WithIsoCurrency,
		/// <summary>
		/// Amount payable per single item (local currency)
		/// </summary>
		AmountPayablePerItem_LocalCurrency,
		/// <summary>
		/// Amount payable per single item (with ISO currency code)
		/// </summary>
		AmountPayablePerItem_WithIsoCurrency,
		/// <summary>
		/// Customer Purchase Order Number
		/// </summary>
		CustomerPurchaseOrderNumber = 400,
		/// <summary>
		/// Consignment Number
		/// </summary>
		ConsignmentNumber,
		/// <summary>
		/// Bill of Lading number
		/// </summary>
		BillOfLadingNumber,
		/// <summary>
		/// Routing code
		/// </summary>
		RoutingCode,
		/// <summary>
		/// Ship To/Deliver To Location Code (Global Location Number)
		/// </summary>
		ShipOrDeliverTo_GlobalLocationNumber = 410,
		/// <summary>
		/// Bill To/Invoice Location Code (Global Location Number)
		/// </summary>
		BillOrInvoiceTo_GlobalLocationNumber,
		/// <summary>
		/// Purchase From Location Code (Global Location Number)
		/// </summary>
		PurchaseFrom_GlobalLocationNumber,
		/// <summary>
		/// Ship for, Deliver for, or Forward to Location Code (Global Location Number)
		/// </summary>
		ShipDeliverOrForwardTo_GlobalLocationNumber,
		/// <summary>
		/// Identification of a physical location (Global Location Number)
		/// </summary>
		IdentificationPhysicalLocation_GlobalLocationNumber,
		/// <summary>
		/// Ship To/Deliver To Postal Code (Single Postal Authority)
		/// </summary>
		ShipOrDeliverToPostalCode_SinglePostalAuthority = 420,
		/// <summary>
		/// Ship To/Deliver To Postal Code (with ISO country code)
		/// </summary>
		ShipOrDeliverToPostalCode_WithIsoCountryCode,
		/// <summary>
		/// Country of Origin (ISO country code)
		/// </summary>
		CountryOfOrigin_IsoCode,
		/// <summary>
		/// Country or countries of initial processing
		/// </summary>
		CountryOfInitialProcessing,
		/// <summary>
		/// Country of processing
		/// </summary>
		CountryOfProcessing,
		/// <summary>
		/// Country of disassembly
		/// </summary>
		CountryOfDisassembly,
		/// <summary>
		/// Country of full process chain
		/// </summary>
		CountryOfFullProcessChain,
		/// <summary>
		/// NATO Stock Number (NSN)
		/// </summary>
		NatoStockNumber = 7001,
		/// <summary>
		/// UN/ECE Meat Carcasses and cuts classification
		/// </summary>
		UnEceMeatCarcassesAndCutsClassification,
		/// <summary>
		/// expiration date and time
		/// </summary>
		ExpirationDateAndTime,
		/// <summary>
		/// Active Potency
		/// </summary>
		ActivePotency,
		/// <summary>
		/// Processor approval (with ISO country code) -- first out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode0 = 7030,
		/// <summary>
		/// Processor approval (with ISO country code) -- second out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode1,
		/// <summary>
		/// Processor approval (with ISO country code) -- third out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode2,
		/// <summary>
		/// Processor approval (with ISO country code) -- 4th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode3,
		/// <summary>
		/// Processor approval (with ISO country code) -- 5th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode4,
		/// <summary>
		/// Processor approval (with ISO country code) -- 6th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode5,
		/// <summary>
		/// Processor approval (with ISO country code) -- 7th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode6,
		/// <summary>
		/// Processor approval (with ISO country code) -- 8th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode7,
		/// <summary>
		/// Processor approval (with ISO country code) -- 9th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode8,
		/// <summary>
		/// Processor approval (with ISO country code) -- 10th out of ten
		/// </summary>
		ProcessorApprovalWithIsoCountryCode9,
		/// <summary>
		/// Roll Products - Width/Length/Core Diameter/Direction/Splices
		/// </summary>
		RollProducts = 8001,
		/// <summary>
		/// Mobile phone identifier
		/// </summary>
		MobilePhoneIdentifier,
		/// <summary>
		/// Global Returnable Asset Identifier
		/// </summary>
		GlobalReturnableAssetId,
		/// <summary>
		/// Global Individual Asset Identifier
		/// </summary>
		GlobalIndividualAssetId,
		/// <summary>
		/// Price per Unit of Measure
		/// </summary>
		PricePerUnitOfMeasure,
		/// <summary>
		/// identification of the components of an item
		/// </summary>
		IdentificationOfComponentsOfItem,
		/// <summary>
		/// International Bank Account Number
		/// </summary>
		InternationalBankAccountNumber,
		/// <summary>
		/// Date/time of production
		/// </summary>
		DateTimeOfProduction,
		/// <summary>
		/// Global Service Relation Number
		/// </summary>
		GlobalServiceRelationNumber = 8018,
		/// <summary>
		/// Payment slip reference number
		/// </summary>
		PaymentSlipReferenceNumber = 8020,
		/// <summary>
		/// Coupon Extended Code: Number System and Offer
		/// </summary>
		CouponExtendedCode_NumberSystemAndOffer = 8100,
		/// <summary>
		/// Coupon Extended Code: Number System, Offer, End of Offer
		/// </summary>
		CouponExtendedCode_NumberSystemOfferAndEndOfOffer,
		/// <summary>
		/// Coupon Extended Code: Number System preceded by 0
		/// </summary>
		CouponExtendedCode_NumberSystemPrecededBy0,
		/// <summary>
		/// Coupon code ID (North America)
		/// </summary>
		CouponCodeId = 8110,
		/// <summary>
		/// Mutually Agreed Between Trading Partners
		/// </summary>
		MutuallyAgreedBetweenTradingPartners = 90,
		/// <summary>
		/// Internal Company Codes - Packing or Components
		/// </summary>
		Internal_MaterialPackagingOrComponents1,
		/// <summary>
		/// Internal Company Codes - Packing or Components
		/// </summary>
		Internal_MaterialPackagingOrComponents2,
		/// <summary>
		/// Internal Company Codes - Hersteller
		/// </summary>
		Internal_Vendor1,
		/// <summary>
		/// Internal Company Codes - Hersteller
		/// </summary>
		Internal_Vendor2,
		/// <summary>
		/// Internal Company Codes - Shipping (Ship-Number, ...)
		/// </summary>
		Internal_Shipping1,
		/// <summary>
		/// Internal Company Codes - Shipping
		/// </summary>
		Internal_Shipping2,
		/// <summary>
		/// Internal Company Codes - Wholesale or Retail
		/// </summary>
		Internal_WholesaleOrRetail1,
		/// <summary>
		/// Internal Company Codes - Wholesale or Retail
		/// </summary>
		Internal_WholesaleOrRetail2,
		/// <summary>
		/// Internal Company Codes - agreed Texts
		/// </summary>
		Internal_AgreedTexts
	}
}
