using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    [DataObject("Person","ID","")]
    public class Person
    {
        [DataField("ID",true)]
        public int ID { get; set; }

        [SubDataObject(SubDataObjectFieldType.Object,"Person","Person","Hand")]
        public Hand LeftHand { get; set; }

        [SubDataObject(SubDataObjectFieldType.Object, "Person", "Person", "Hand")]
        public Hand RightHand { get; set; }

        [SubDataObject(SubDataObjectFieldType.Object, "Person", "Person", "Head")]
        public Head Head { get; set; }


        [DataField("DName","nvarchar")]
        public string UName { get; set; }

        [DataField("DSex","varchar")]
        public string USex { get; set; }

        [DataField("DAge","int")]
        public uint UAge { get; set; }
    }
    public class Hand
    {
 
    }
    public class Head
    {
 
    }
}
sealed class DataObjectAttribute : Attribute
{
    public DataObjectAttribute(string objName,string PK,string FK)
    { }
}
sealed class SubDataObjectAttribute : Attribute
{
    public SubDataObjectFieldType FieldType { get; set; }
    public string AssemblyName { get; set; }
    public string NameSpaceName { get; set; }
    public string ClassName { get; set; }

    public SubDataObjectAttribute(SubDataObjectFieldType fieldType, string assemblyName
        ,string nameSpaceName,string className)
    {

    }
                
}
public enum SubDataObjectFieldType
{
    Object,
    List
}

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
sealed class DataFieldAttribute : Attribute
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }

    public DataFieldAttribute(string fieldName,string fieldType)
    {
        this.FieldName = fieldName;
        this.FieldType = fieldType;
    }

    public DataFieldAttribute(string fieldName, bool b)
    { }
}
sealed class DataFieldNotDoubleAttribute : Attribute
{
 
}