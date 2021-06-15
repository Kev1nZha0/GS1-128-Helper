using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1_128_Helper
{
	/// <summary>Class to Handle a single DataField</summary>
	internal class DataField
	{
		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		public DataField()
		{
			this.initClass(DataFieldContent.undefined, -1, -1, SpecialAction.none);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		/// <param name="FieldType">Type of the field.</param>
		public DataField(DataFieldContent FieldType)
		{
			this.initClass(FieldType, -1, -1, SpecialAction.none);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		/// <param name="FieldType">Type of the field.</param>
		/// <param name="Length">Length of the field.</param>
		public DataField(DataFieldContent FieldType, int Length)
		{
			this.initClass(FieldType, Length, Length, SpecialAction.none);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		/// <param name="FieldType">Type of the field.</param>
		/// <param name="Length">Length of the field.</param>
		/// <param name="ItemAction">Info regarding special Parsing-Options for the Content</param>
		public DataField(DataFieldContent FieldType, int Length, SpecialAction ItemAction)
		{
			this.initClass(FieldType, Length, Length, ItemAction);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		/// <param name="FieldType">Type of the field.</param>
		/// <param name="MinLength">Min. length of the field.</param>
		/// <param name="MaxLength">Max. length of the field.</param>
		public DataField(DataFieldContent FieldType, int MinLength, int MaxLength)
		{
			this.initClass(FieldType, MaxLength, MinLength, SpecialAction.none);
		}

		/// <summary>Initializes a new instance of the <see cref="T:Infineon.Barcodes.GS1_128.DataField" /> class.</summary>
		/// <param name="FieldType">Type of the field.</param>
		/// <param name="MinLength">Min. length of the field.</param>
		/// <param name="MaxLength">Max. length of the field.</param>
		/// <param name="ItemAction">Info regarding special Parsing-Options for the Content</param>
		public DataField(DataFieldContent FieldType, int MinLength, int MaxLength, SpecialAction ItemAction)
		{
			this.initClass(FieldType, MaxLength, MinLength, ItemAction);
		}

		/// <summary>Gets or sets the type of the data field.</summary>
		/// <value>The type of the data field.</value>
		public DataFieldContent DataFieldType
		{
			get
			{
				return this.dataFieldType;
			}
			set
			{
				this.dataFieldType = value;
			}
		}

		/// <summary>Gets or sets the max-length.</summary>
		/// <value>The max-length.</value>
		public int MaxLength
		{
			get
			{
				return this.maxLength;
			}
			set
			{
				this.maxLength = value;
			}
		}

		/// <summary>Gets or sets the min-length.</summary>
		/// <value>The min-length.</value>
		public int MinLength
		{
			get
			{
				return this.minLength;
			}
			set
			{
				this.minLength = value;
			}
		}

		/// <summary>Gets the application identifier.</summary>
		public string ApplicationIdentifier
		{
			get
			{
				bool flag = this.dataFieldType < DataFieldContent.BatchOrLotNumber;
				string result;
				if (flag)
				{
					string str = "0";
					int num = (int)this.dataFieldType;
					result = str + num.ToString();
				}
				else
				{
					int num = (int)this.dataFieldType;
					result = num.ToString();
				}
				return result;
			}
		}

		/// <summary>Gets a value indicating whether [variable length] is active for the Item.</summary>
		public bool VariableLength
		{
			get
			{
				return this.maxLength != this.minLength;
			}
		}

		/// <summary>Gets the item action used by the parser.</summary>
		public SpecialAction ItemAction
		{
			get
			{
				return this.parserAction;
			}
		}

		/// <summary>Inits the class (internal Constructor).</summary>
		/// <param name="FieldType">Type of the field.</param>
		/// <param name="MaxLength">Length of the max.</param>
		/// <param name="MinLength">Length of the min.</param>
		/// <param name="VariableLangth">if set to <c>true</c> [variable langth].</param>
		private void initClass(DataFieldContent FieldType, int MaxLength, int MinLength, SpecialAction ItemAction)
		{
			this.maxLength = MaxLength;
			this.minLength = MinLength;
			this.dataFieldType = FieldType;
			this.parserAction = ItemAction;
		}

		private int maxLength;

		private int minLength;

		private DataFieldContent dataFieldType;

		private SpecialAction parserAction;
	}
}
