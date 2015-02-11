﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aluminum.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_9BB309_GiantChocobo")]
	public partial class RoomOfRequirementDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCostume(Costume instance);
    partial void UpdateCostume(Costume instance);
    partial void DeleteCostume(Costume instance);
    #endregion
		
		public RoomOfRequirementDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_9BB309_GiantChocoboConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public RoomOfRequirementDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoomOfRequirementDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoomOfRequirementDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoomOfRequirementDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Costume> Costumes
		{
			get
			{
				return this.GetTable<Costume>();
			}
		}
		
		public System.Data.Linq.Table<CostumeQuestion> CostumeQuestions
		{
			get
			{
				return this.GetTable<CostumeQuestion>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Costume")]
	public partial class Costume : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _CostumeID;
		
		private string _Name;
		
		private string _ImageFileName;
		
		private byte _GenderTypeID;
		
		private bool _IsHuman;
		
		private bool _IsAnimal;
		
		private bool _HasSuperPowers;
		
		private bool _HasPants;
		
		private bool _HasShirt;
		
		private bool _HasShoes;
		
		private bool _HasHat;
		
		private bool _HasCape;
		
		private bool _HasFacialHair;
		
		private bool _HasBowtie;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCostumeIDChanging(short value);
    partial void OnCostumeIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnImageFileNameChanging(string value);
    partial void OnImageFileNameChanged();
    partial void OnGenderTypeIDChanging(byte value);
    partial void OnGenderTypeIDChanged();
    partial void OnIsHumanChanging(bool value);
    partial void OnIsHumanChanged();
    partial void OnIsAnimalChanging(bool value);
    partial void OnIsAnimalChanged();
    partial void OnHasSuperPowersChanging(bool value);
    partial void OnHasSuperPowersChanged();
    partial void OnHasPantsChanging(bool value);
    partial void OnHasPantsChanged();
    partial void OnHasShirtChanging(bool value);
    partial void OnHasShirtChanged();
    partial void OnHasShoesChanging(bool value);
    partial void OnHasShoesChanged();
    partial void OnHasHatChanging(bool value);
    partial void OnHasHatChanged();
    partial void OnHasCapeChanging(bool value);
    partial void OnHasCapeChanged();
    partial void OnHasFacialHairChanging(bool value);
    partial void OnHasFacialHairChanged();
    partial void OnHasBowtieChanging(bool value);
    partial void OnHasBowtieChanged();
    #endregion
		
		public Costume()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CostumeID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short CostumeID
		{
			get
			{
				return this._CostumeID;
			}
			set
			{
				if ((this._CostumeID != value))
				{
					this.OnCostumeIDChanging(value);
					this.SendPropertyChanging();
					this._CostumeID = value;
					this.SendPropertyChanged("CostumeID");
					this.OnCostumeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageFileName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ImageFileName
		{
			get
			{
				return this._ImageFileName;
			}
			set
			{
				if ((this._ImageFileName != value))
				{
					this.OnImageFileNameChanging(value);
					this.SendPropertyChanging();
					this._ImageFileName = value;
					this.SendPropertyChanged("ImageFileName");
					this.OnImageFileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GenderTypeID", DbType="TinyInt NOT NULL")]
		public byte GenderTypeID
		{
			get
			{
				return this._GenderTypeID;
			}
			set
			{
				if ((this._GenderTypeID != value))
				{
					this.OnGenderTypeIDChanging(value);
					this.SendPropertyChanging();
					this._GenderTypeID = value;
					this.SendPropertyChanged("GenderTypeID");
					this.OnGenderTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsHuman", DbType="Bit NOT NULL")]
		public bool IsHuman
		{
			get
			{
				return this._IsHuman;
			}
			set
			{
				if ((this._IsHuman != value))
				{
					this.OnIsHumanChanging(value);
					this.SendPropertyChanging();
					this._IsHuman = value;
					this.SendPropertyChanged("IsHuman");
					this.OnIsHumanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAnimal", DbType="Bit NOT NULL")]
		public bool IsAnimal
		{
			get
			{
				return this._IsAnimal;
			}
			set
			{
				if ((this._IsAnimal != value))
				{
					this.OnIsAnimalChanging(value);
					this.SendPropertyChanging();
					this._IsAnimal = value;
					this.SendPropertyChanged("IsAnimal");
					this.OnIsAnimalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasSuperPowers", DbType="Bit NOT NULL")]
		public bool HasSuperPowers
		{
			get
			{
				return this._HasSuperPowers;
			}
			set
			{
				if ((this._HasSuperPowers != value))
				{
					this.OnHasSuperPowersChanging(value);
					this.SendPropertyChanging();
					this._HasSuperPowers = value;
					this.SendPropertyChanged("HasSuperPowers");
					this.OnHasSuperPowersChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasPants", DbType="Bit NOT NULL")]
		public bool HasPants
		{
			get
			{
				return this._HasPants;
			}
			set
			{
				if ((this._HasPants != value))
				{
					this.OnHasPantsChanging(value);
					this.SendPropertyChanging();
					this._HasPants = value;
					this.SendPropertyChanged("HasPants");
					this.OnHasPantsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasShirt", DbType="Bit NOT NULL")]
		public bool HasShirt
		{
			get
			{
				return this._HasShirt;
			}
			set
			{
				if ((this._HasShirt != value))
				{
					this.OnHasShirtChanging(value);
					this.SendPropertyChanging();
					this._HasShirt = value;
					this.SendPropertyChanged("HasShirt");
					this.OnHasShirtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasShoes", DbType="Bit NOT NULL")]
		public bool HasShoes
		{
			get
			{
				return this._HasShoes;
			}
			set
			{
				if ((this._HasShoes != value))
				{
					this.OnHasShoesChanging(value);
					this.SendPropertyChanging();
					this._HasShoes = value;
					this.SendPropertyChanged("HasShoes");
					this.OnHasShoesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasHat", DbType="Bit NOT NULL")]
		public bool HasHat
		{
			get
			{
				return this._HasHat;
			}
			set
			{
				if ((this._HasHat != value))
				{
					this.OnHasHatChanging(value);
					this.SendPropertyChanging();
					this._HasHat = value;
					this.SendPropertyChanged("HasHat");
					this.OnHasHatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasCape", DbType="Bit NOT NULL")]
		public bool HasCape
		{
			get
			{
				return this._HasCape;
			}
			set
			{
				if ((this._HasCape != value))
				{
					this.OnHasCapeChanging(value);
					this.SendPropertyChanging();
					this._HasCape = value;
					this.SendPropertyChanged("HasCape");
					this.OnHasCapeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasFacialHair", DbType="Bit NOT NULL")]
		public bool HasFacialHair
		{
			get
			{
				return this._HasFacialHair;
			}
			set
			{
				if ((this._HasFacialHair != value))
				{
					this.OnHasFacialHairChanging(value);
					this.SendPropertyChanging();
					this._HasFacialHair = value;
					this.SendPropertyChanged("HasFacialHair");
					this.OnHasFacialHairChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasBowtie", DbType="Bit NOT NULL")]
		public bool HasBowtie
		{
			get
			{
				return this._HasBowtie;
			}
			set
			{
				if ((this._HasBowtie != value))
				{
					this.OnHasBowtieChanging(value);
					this.SendPropertyChanging();
					this._HasBowtie = value;
					this.SendPropertyChanged("HasBowtie");
					this.OnHasBowtieChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CostumeQuestion")]
	public partial class CostumeQuestion
	{
		
		private string _Question;
		
		private string _Answered;
		
		private string _DataField;
		
		private short _SortOrder;
		
		public CostumeQuestion()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Question", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Question
		{
			get
			{
				return this._Question;
			}
			set
			{
				if ((this._Question != value))
				{
					this._Question = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Answered", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Answered
		{
			get
			{
				return this._Answered;
			}
			set
			{
				if ((this._Answered != value))
				{
					this._Answered = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataField", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string DataField
		{
			get
			{
				return this._DataField;
			}
			set
			{
				if ((this._DataField != value))
				{
					this._DataField = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SortOrder", DbType="SmallInt NOT NULL")]
		public short SortOrder
		{
			get
			{
				return this._SortOrder;
			}
			set
			{
				if ((this._SortOrder != value))
				{
					this._SortOrder = value;
				}
			}
		}
	}
}
#pragma warning restore 1591