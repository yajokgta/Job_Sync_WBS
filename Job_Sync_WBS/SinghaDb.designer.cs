﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Job_Sync_WBS
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WolfApproveCore.SinghaEstate")]
	public partial class SinghaDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertINFWBSElement(INFWBSElement instance);
    partial void UpdateINFWBSElement(INFWBSElement instance);
    partial void DeleteINFWBSElement(INFWBSElement instance);
    #endregion
		
		public SinghaDbDataContext() : 
				base(global::Job_Sync_WBS.Properties.Settings.Default.WolfApproveCore_SinghaEstateConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SinghaDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SinghaDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SinghaDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SinghaDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<INFWBSElement> INFWBSElements
		{
			get
			{
				return this.GetTable<INFWBSElement>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.INFWBSElement")]
	public partial class INFWBSElement : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _WBS_ID;
		
		private string _WBS_CODE;
		
		private string _DESC1;
		
		private string _COM_CODE;
		
		private string _BUSINESS_AREA;
		
		private string _DESC2;
		
		private string _CostCenter;
		
		private System.Nullable<bool> _IsActive;
		
		private System.Nullable<bool> _SAPCode;
		
		private string _Year;
		
		private string _CreatedBy;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private string _ModifiedBy;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnWBS_IDChanging(int value);
    partial void OnWBS_IDChanged();
    partial void OnWBS_CODEChanging(string value);
    partial void OnWBS_CODEChanged();
    partial void OnDESC1Changing(string value);
    partial void OnDESC1Changed();
    partial void OnCOM_CODEChanging(string value);
    partial void OnCOM_CODEChanged();
    partial void OnBUSINESS_AREAChanging(string value);
    partial void OnBUSINESS_AREAChanged();
    partial void OnDESC2Changing(string value);
    partial void OnDESC2Changed();
    partial void OnCostCenterChanging(string value);
    partial void OnCostCenterChanged();
    partial void OnIsActiveChanging(System.Nullable<bool> value);
    partial void OnIsActiveChanged();
    partial void OnSAPCodeChanging(System.Nullable<bool> value);
    partial void OnSAPCodeChanged();
    partial void OnYearChanging(string value);
    partial void OnYearChanged();
    partial void OnCreatedByChanging(string value);
    partial void OnCreatedByChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnModifiedByChanging(string value);
    partial void OnModifiedByChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public INFWBSElement()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WBS_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int WBS_ID
		{
			get
			{
				return this._WBS_ID;
			}
			set
			{
				if ((this._WBS_ID != value))
				{
					this.OnWBS_IDChanging(value);
					this.SendPropertyChanging();
					this._WBS_ID = value;
					this.SendPropertyChanged("WBS_ID");
					this.OnWBS_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WBS_CODE", DbType="NVarChar(24)")]
		public string WBS_CODE
		{
			get
			{
				return this._WBS_CODE;
			}
			set
			{
				if ((this._WBS_CODE != value))
				{
					this.OnWBS_CODEChanging(value);
					this.SendPropertyChanging();
					this._WBS_CODE = value;
					this.SendPropertyChanged("WBS_CODE");
					this.OnWBS_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESC1", DbType="NVarChar(250)")]
		public string DESC1
		{
			get
			{
				return this._DESC1;
			}
			set
			{
				if ((this._DESC1 != value))
				{
					this.OnDESC1Changing(value);
					this.SendPropertyChanging();
					this._DESC1 = value;
					this.SendPropertyChanged("DESC1");
					this.OnDESC1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COM_CODE", DbType="NVarChar(4)")]
		public string COM_CODE
		{
			get
			{
				return this._COM_CODE;
			}
			set
			{
				if ((this._COM_CODE != value))
				{
					this.OnCOM_CODEChanging(value);
					this.SendPropertyChanging();
					this._COM_CODE = value;
					this.SendPropertyChanged("COM_CODE");
					this.OnCOM_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BUSINESS_AREA", DbType="NVarChar(4)")]
		public string BUSINESS_AREA
		{
			get
			{
				return this._BUSINESS_AREA;
			}
			set
			{
				if ((this._BUSINESS_AREA != value))
				{
					this.OnBUSINESS_AREAChanging(value);
					this.SendPropertyChanging();
					this._BUSINESS_AREA = value;
					this.SendPropertyChanged("BUSINESS_AREA");
					this.OnBUSINESS_AREAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESC2", DbType="NVarChar(MAX)")]
		public string DESC2
		{
			get
			{
				return this._DESC2;
			}
			set
			{
				if ((this._DESC2 != value))
				{
					this.OnDESC2Changing(value);
					this.SendPropertyChanging();
					this._DESC2 = value;
					this.SendPropertyChanged("DESC2");
					this.OnDESC2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CostCenter", DbType="NVarChar(10)")]
		public string CostCenter
		{
			get
			{
				return this._CostCenter;
			}
			set
			{
				if ((this._CostCenter != value))
				{
					this.OnCostCenterChanging(value);
					this.SendPropertyChanging();
					this._CostCenter = value;
					this.SendPropertyChanged("CostCenter");
					this.OnCostCenterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SAPCode", DbType="Bit")]
		public System.Nullable<bool> SAPCode
		{
			get
			{
				return this._SAPCode;
			}
			set
			{
				if ((this._SAPCode != value))
				{
					this.OnSAPCodeChanging(value);
					this.SendPropertyChanging();
					this._SAPCode = value;
					this.SendPropertyChanged("SAPCode");
					this.OnSAPCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="NVarChar(50)")]
		public string Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="NVarChar(500)")]
		public string CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				if ((this._CreatedBy != value))
				{
					this.OnCreatedByChanging(value);
					this.SendPropertyChanging();
					this._CreatedBy = value;
					this.SendPropertyChanged("CreatedBy");
					this.OnCreatedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedBy", DbType="NVarChar(500)")]
		public string ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				if ((this._ModifiedBy != value))
				{
					this.OnModifiedByChanging(value);
					this.SendPropertyChanging();
					this._ModifiedBy = value;
					this.SendPropertyChanged("ModifiedBy");
					this.OnModifiedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
