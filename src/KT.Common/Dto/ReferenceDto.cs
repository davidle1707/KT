namespace KT.Common.Dto;

[Serializable]
public partial class ReferenceDto : ExtendKeyValueObjDto
{
    public ObjectId Id { get; set; }

    public string Name { get; set; }

    #region Custom

    public bool? IsSelected { get; set; }

    public int? Type { get; set; }

    #endregion
}
