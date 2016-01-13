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

namespace AdminConsole.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DataSource")]
	public partial class ContactsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKontakti(Kontakti instance);
    partial void UpdateKontakti(Kontakti instance);
    partial void DeleteKontakti(Kontakti instance);
    #endregion
		
		public ContactsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ContactsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContactsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContactsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContactsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Kontakti> Kontakts
		{
			get
			{
				return this.GetTable<Kontakti>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Kontakti")]
	public partial class Kontakti : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _NorisesVieta;
		
		private string _Adrese;
		
		private string _PapildusInfo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNorisesVietaChanging(string value);
    partial void OnNorisesVietaChanged();
    partial void OnAdreseChanging(string value);
    partial void OnAdreseChanged();
    partial void OnPapildusInfoChanging(string value);
    partial void OnPapildusInfoChanged();
    #endregion
		
		public Kontakti()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NorisesVieta", DbType="NVarChar(100)")]
		public string NorisesVieta
		{
			get
			{
				return this._NorisesVieta;
			}
			set
			{
				if ((this._NorisesVieta != value))
				{
					this.OnNorisesVietaChanging(value);
					this.SendPropertyChanging();
					this._NorisesVieta = value;
					this.SendPropertyChanged("NorisesVieta");
					this.OnNorisesVietaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Adrese", DbType="NVarChar(100)")]
		public string Adrese
		{
			get
			{
				return this._Adrese;
			}
			set
			{
				if ((this._Adrese != value))
				{
					this.OnAdreseChanging(value);
					this.SendPropertyChanging();
					this._Adrese = value;
					this.SendPropertyChanged("Adrese");
					this.OnAdreseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PapildusInfo", DbType="NVarChar(100)")]
		public string PapildusInfo
		{
			get
			{
				return this._PapildusInfo;
			}
			set
			{
				if ((this._PapildusInfo != value))
				{
					this.OnPapildusInfoChanging(value);
					this.SendPropertyChanging();
					this._PapildusInfo = value;
					this.SendPropertyChanged("PapildusInfo");
					this.OnPapildusInfoChanged();
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