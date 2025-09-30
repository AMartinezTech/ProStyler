using System.ComponentModel;

namespace AMartinezTech.WinForms.Module.Administration.Users;

public class UpdatingMemoryData
{
    public static BindingList<UserViewModel> Excecute(UserViewModel dto, BindingList<UserViewModel> itemList)  
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.IsActived = dto.IsActived;
        }
        else
        {
            // Si el elemento no existe, lo agregamos
            itemList.Add(dto);
        }

        // Devuelvo la lista actualizada
        return itemList;
    }
}
