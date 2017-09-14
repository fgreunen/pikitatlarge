using Repository.Pattern.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Repository.Pattern.Ef6
{
  [DataContract]
  [Serializable]
  public abstract class Entity : IObjectState
  {
    [NotMapped]
    public ObjectState ObjectState { get; set; }
  }
}